using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;


namespace PageListenDialer
{
    public class MobileAt
    {
        public bool IsOpen { get { return isOpen; } }

        public MobileAt(string portName)
        {
            this.portName = portName;

            Regex r1 = new Regex(@"^\+CMTI\:");
            Regex r2 = new Regex(@"^\+CMGR\:");
            Regex r3 = new Regex(@"^\+RING\:");

            ATBeginHandlerMap.Add(r1, OnBeginCMTI);
            ATBeginHandlerMap.Add(r2, OnBeginCMGR);
            ATBeginHandlerMap.Add(r3, OnBeginRING);

            ATHandlerMap.Add(r1, OnCMTI);
            ATHandlerMap.Add(r2, OnCMGR);
            ATHandlerMap.Add(r3, OnRING);

            responseMap.Add(typeof(SendMessageRequest), OnCMGSResponse);
        }

        public void Open()
        {
            port = new SerialPort(portName);
            port.Encoding = Encoding.Default;
            port.ReadTimeout = 30000;
            port.WriteTimeout = 30000;
            port.BaudRate = 9600;
            port.RtsEnable = true;

            port.Open();
            port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);

            AddRequestToQueue(new SettingReuqest("AT").Execute(port));
            Thread.Sleep(50);
            AddRequestToQueue(new SettingReuqest("ATE0").Execute(port));
            AddRequestToQueue(new SettingReuqest("AT+CMGF=1").Execute(port));
            AddRequestToQueue(new SettingReuqest("AT+CNMI=2,1").Execute(port));
            AddRequestToQueue(new SettingReuqest("AT+CSMP=49,167,0,8").Execute(port));

            isOpen = true;
        }

        public void Close()
        {
            port.DataReceived -= port_DataReceived;
            port.Close();
            isOpen = false;
        }

        public void Send(Message arg)
        {
            if (arg.Text.Length > 70)
            {
                throw new ArgumentOutOfRangeException("短信不能超过70个字符");
            }

            AddRequestToQueue(new SendMessageRequest(arg).Execute(port));
        }

        // ----------------------------------------------------------------------
        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string line = string.Empty;

            try
            {
                while (port.BytesToRead > 0)
                {
                    line = port.ReadLine();
                    if (!string.IsNullOrEmpty(line) && "\r" != line)
                    {
                        Console.WriteLine(line);
                        receiveBuffer.Add(line);

                        if (!isInterrupt)
                        {
                            if (IsBeginInterrupt(line))
                            {
                                if (IsEndInterrupt())
                                {
                                    EndInterrupt();
                                }
                            }
                            else
                            {
                                string c = line.TrimEnd('\r');
                                if ("OK" == c || "ERROR" == c)
                                {
                                    var response = new ModemResponse(receiveBuffer);
                                    response.Request = requestQueue.Dequeue();
                                    Type t = response.Request.GetType();
                                    if (responseMap.ContainsKey(t))
                                    {
                                        responseMap[t](response);
                                    }
                                    receiveBuffer.Clear();
                                }
                            }
                        }
                        else
                        {
                            if (IsEndInterrupt())
                            {
                                EndInterrupt();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
            }
        }

        private void EndInterrupt()
        {
            interruptHandler(receiveBuffer);

            beginInterruptHandler = null;
            interruptHandler = null;
            receiveBuffer.Clear();
        }

        private bool IsEndInterrupt()
        {
            Trace.Assert(beginInterruptHandler != null);
            bool result = false;
            if (beginInterruptHandler(receiveBuffer))
            {
                result = true;
            }
            return result;
        }

        private bool IsBeginInterrupt(string arg)
        {
            bool result = false;

            foreach (var each in ATBeginHandlerMap.Keys)
            {
                if (each.IsMatch(arg))
                {
                    beginInterruptHandler = ATBeginHandlerMap[each];
                    interruptHandler = ATHandlerMap[each];
                    result = true;
                    break;
                }
            }

            return result;
        }

        private bool OnBeginCMTI(List<string> content)
        {
            return true;
        }

        private void OnCMTI(List<string> content)
        {
            // +CMTI:"SM",1
            Regex pattern = new Regex(@"^\+CMTI:.+,(\d+)");
            Match m = pattern.Match(content[0]);
            index = Convert.ToInt32(m.Groups[1].Value);

            AddRequestToQueue(new RetrieveMessageReuqest(index).Execute(port));
        }

        private bool OnBeginCMGR(List<string> content)
        {
            return (content.Count == 3);
        }

        private void OnCMGR(List<string> content)
        {
            Regex pattern = new Regex("^\\+CMGR:.+,\"(\\S+)\",");

            Match m = pattern.Match(content[0]);
            string address = m.Groups[1].Value;
            if (address.StartsWith("+86"))
            {
                address = address.Substring(3);
            }
            string content1 = content[1].TrimEnd('\r');
            if (content1.StartsWith("050003"))
            {
                content1 = content1.Substring(12);
            }

            //Message message = new Message(address, MessageHelper.MessageDecode(content1));
            Message message = new Message(address, content1);

            message.Raw = content[1].TrimEnd('\r');
            //message.Flags = MessageFlags.UNREAD;
            message.CreatedAt = DateTime.Now;

            DeleteByIndex(index);
            Receive(message);
        }

        private bool OnBeginRING(List<string> content)
        {
            return true;
        }

        private void OnRING(List<string> content)
        {

        }

        private void OnCMGSResponse(ModemResponse response)
        {
            SendResult(response);
        }

        private void DeleteByIndex(int index)
        {
            port.Write(string.Format("AT+CMGD={0}\r", index));
        }

        private void AddRequestToQueue(ModemMessage arg)
        {
            if (arg is ModemRequest)
            {
                requestQueue.Enqueue(arg as ModemRequest);
            }
        }

        private List<string> receiveBuffer = new List<string>();
        private ATReceivedEventHandler interruptHandler;
        private ATBeginReceivedEventHandler beginInterruptHandler;
        private bool isInterrupt { get { return beginInterruptHandler != null; } }

        private Queue<ModemRequest> requestQueue = new Queue<ModemRequest>();
        private Dictionary<Type, ModemResponseHandler> responseMap = new Dictionary<Type, ModemResponseHandler>();
        private Dictionary<Regex, ATBeginReceivedEventHandler> ATBeginHandlerMap = new Dictionary<Regex, ATBeginReceivedEventHandler>();
        private Dictionary<Regex, ATReceivedEventHandler> ATHandlerMap = new Dictionary<Regex, ATReceivedEventHandler>();
        private string portName;
        private SerialPort port;
        private int index;
        private bool isOpen = false;

        public event MessageReceivedEventHandler Receive;
        public event MessageSendEventHandler SendResult;
    }

    public abstract class ModemMessage
    {
        public List<string> Content { get; set; }
        public virtual ModemMessage Execute(SerialPort port) { return this; }
    }

    public class ModemRequest : ModemMessage
    {

    }

    public class ModemResponse : ModemMessage
    {
        public ModemRequest Request { get; set; }

        public ModemResponse(List<string> content)
        {
            Content = content;
        }
    }

    public class ModemNotify : ModemMessage { }
    public class SettingReuqest : ModemRequest
    {
        public SettingReuqest(string command)
        {
            this.command = command;
        }

        public override ModemMessage Execute(SerialPort port)
        {
            base.Execute(port);

            port.Write(command + "\r");

            return this;
        }

        private string command;
    }
    public class SendMessageRequest : ModemRequest
    {
        public Message Message { get; set; }

        public SendMessageRequest(Message message)
        {
            Message = message;
        }

        public override ModemMessage Execute(SerialPort port)
        {
            base.Execute(port);

            try
            {
                port.DiscardInBuffer();
                port.Write(string.Format("AT+CMGS={0}\r", Message.Address));
                port.DiscardInBuffer();
                //port.Write(MessageHelper.MessageEncode(Message.Text) + ControlZ + "\r");
                port.Write(Message.Text + ControlZ + "\r");
                //Message.Flags = MessageFlags.SENDED;
                Message.CreatedAt = DateTime.Now;
            }
            catch (Exception)
            {
                //Message.Flags = MessageFlags.SENDFAILED;
                Message.CreatedAt = DateTime.Now;
                throw;
            }

            return this;
        }

        private const char ControlZ = (char)0x1A;
    }

    public class RetrieveMessageReuqest : ModemRequest
    {
        public RetrieveMessageReuqest(int index)
        {
            this.index = index;
        }

        public override ModemMessage Execute(SerialPort port)
        {
            base.Execute(port);
            port.Write(string.Format("AT+CMGR={0}\r", index));
            return this;
        }

        private int index;
    }

    public delegate bool ATBeginReceivedEventHandler(List<string> content);
    public delegate void ATReceivedEventHandler(List<string> content);
    public delegate void ModemResponseHandler(ModemResponse response);
    public delegate void MessageReceivedEventHandler(Message arg);
    public delegate void MessageSendEventHandler(ModemResponse response);
}