using System.Diagnostics;
using AxTAPIEXLib;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;

namespace PageListenDialer
{
	internal class Form1 : System.Windows.Forms.Form
	{
		[STAThread]
		static void Main()
		{
			Application.Run(new Form1());
		}
		#region "Windows Form Designer generated code "
		public Form1() {
			if (m_vb6FormDefInstance == null)
			{
				if (m_InitializingDefInstance)
				{
					m_vb6FormDefInstance = this;
				}
				else
				{
					try
					{
						//For the start-up form, the first instance created is the default instance.
						if (System.Reflection.Assembly.GetExecutingAssembly().EntryPoint.DeclaringType == this.GetType())
						{
							m_vb6FormDefInstance = this;
						}
					}
					catch
					{
					}
				}
			}
			//This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		//Form overrides dispose to clean up the component list.
		protected override void Dispose (bool Disposing)
		{
			if (Disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(Disposing);
		}

        private System.ComponentModel.IContainer components;
        //Required by the Windows Form Designer
		public System.Windows.Forms.ToolTip ToolTip1;
		public System.Windows.Forms.TextBox TxtLog;
		public System.Windows.Forms.TextBox EdWaveFile;
		public System.Windows.Forms.Button BnPlayWave;
		public System.Windows.Forms.Button BnDrop;
		public System.Windows.Forms.ComboBox CbLines;
		public System.Windows.Forms.TextBox Ednumber;
		public System.Windows.Forms.Button Dial;
		public AxTAPIEXLib.AxTAPIExCtl mTAPIEx;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label Label2;
        private Button btnListenStar;
        private WebBrowser webBrowser1;
        private Button shouwPageButton;
        private TextBox txtPageAddress;
        private Label label5;
        private Timer pageTimer;
        private Button btnListenStop;
        public Label label6;
        public TextBox txtListenString;
		public System.Windows.Forms.Label Label1;
//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent ()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.TxtLog = new System.Windows.Forms.TextBox();
            this.EdWaveFile = new System.Windows.Forms.TextBox();
            this.BnPlayWave = new System.Windows.Forms.Button();
            this.BnDrop = new System.Windows.Forms.Button();
            this.CbLines = new System.Windows.Forms.ComboBox();
            this.Ednumber = new System.Windows.Forms.TextBox();
            this.Dial = new System.Windows.Forms.Button();
            this.mTAPIEx = new AxTAPIEXLib.AxTAPIExCtl();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnListenStar = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.shouwPageButton = new System.Windows.Forms.Button();
            this.txtPageAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pageTimer = new System.Windows.Forms.Timer(this.components);
            this.btnListenStop = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtListenString = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.mTAPIEx)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtLog
            // 
            this.TxtLog.AcceptsReturn = true;
            this.TxtLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtLog.BackColor = System.Drawing.SystemColors.Window;
            this.TxtLog.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtLog.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLog.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtLog.Location = new System.Drawing.Point(11, 580);
            this.TxtLog.MaxLength = 0;
            this.TxtLog.Multiline = true;
            this.TxtLog.Name = "TxtLog";
            this.TxtLog.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TxtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtLog.Size = new System.Drawing.Size(1327, 151);
            this.TxtLog.TabIndex = 10;
            // 
            // EdWaveFile
            // 
            this.EdWaveFile.AcceptsReturn = true;
            this.EdWaveFile.BackColor = System.Drawing.SystemColors.Window;
            this.EdWaveFile.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.EdWaveFile.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EdWaveFile.ForeColor = System.Drawing.SystemColors.WindowText;
            this.EdWaveFile.Location = new System.Drawing.Point(1618, 14);
            this.EdWaveFile.MaxLength = 0;
            this.EdWaveFile.Name = "EdWaveFile";
            this.EdWaveFile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.EdWaveFile.Size = new System.Drawing.Size(201, 20);
            this.EdWaveFile.TabIndex = 8;
            this.EdWaveFile.Visible = false;
            // 
            // BnPlayWave
            // 
            this.BnPlayWave.BackColor = System.Drawing.SystemColors.Control;
            this.BnPlayWave.Cursor = System.Windows.Forms.Cursors.Default;
            this.BnPlayWave.Enabled = false;
            this.BnPlayWave.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnPlayWave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BnPlayWave.Location = new System.Drawing.Point(1832, 14);
            this.BnPlayWave.Name = "BnPlayWave";
            this.BnPlayWave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BnPlayWave.Size = new System.Drawing.Size(97, 25);
            this.BnPlayWave.TabIndex = 7;
            this.BnPlayWave.Text = "Play Wave";
            this.BnPlayWave.UseVisualStyleBackColor = false;
            this.BnPlayWave.Visible = false;
            this.BnPlayWave.Click += new System.EventHandler(this.BnPlayWave_Click);
            // 
            // BnDrop
            // 
            this.BnDrop.BackColor = System.Drawing.SystemColors.Control;
            this.BnDrop.Cursor = System.Windows.Forms.Cursors.Default;
            this.BnDrop.Enabled = false;
            this.BnDrop.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnDrop.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BnDrop.Location = new System.Drawing.Point(1673, 40);
            this.BnDrop.Name = "BnDrop";
            this.BnDrop.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BnDrop.Size = new System.Drawing.Size(97, 25);
            this.BnDrop.TabIndex = 6;
            this.BnDrop.Text = "Drop";
            this.BnDrop.UseVisualStyleBackColor = false;
            this.BnDrop.Visible = false;
            this.BnDrop.Click += new System.EventHandler(this.BnDrop_Click);
            // 
            // CbLines
            // 
            this.CbLines.BackColor = System.Drawing.SystemColors.Window;
            this.CbLines.Cursor = System.Windows.Forms.Cursors.Default;
            this.CbLines.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbLines.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CbLines.Location = new System.Drawing.Point(72, 13);
            this.CbLines.Name = "CbLines";
            this.CbLines.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CbLines.Size = new System.Drawing.Size(208, 22);
            this.CbLines.TabIndex = 3;
            // 
            // Ednumber
            // 
            this.Ednumber.AcceptsReturn = true;
            this.Ednumber.BackColor = System.Drawing.SystemColors.Window;
            this.Ednumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Ednumber.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ednumber.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Ednumber.Location = new System.Drawing.Point(361, 14);
            this.Ednumber.MaxLength = 0;
            this.Ednumber.Name = "Ednumber";
            this.Ednumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Ednumber.Size = new System.Drawing.Size(185, 20);
            this.Ednumber.TabIndex = 1;
            // 
            // Dial
            // 
            this.Dial.BackColor = System.Drawing.SystemColors.Control;
            this.Dial.Cursor = System.Windows.Forms.Cursors.Default;
            this.Dial.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dial.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Dial.Location = new System.Drawing.Point(1582, 40);
            this.Dial.Name = "Dial";
            this.Dial.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Dial.Size = new System.Drawing.Size(97, 25);
            this.Dial.TabIndex = 0;
            this.Dial.Text = "Make Call";
            this.Dial.UseVisualStyleBackColor = false;
            this.Dial.Visible = false;
            this.Dial.Click += new System.EventHandler(this.Dial_Click);
            // 
            // mTAPIEx
            // 
            this.mTAPIEx.Enabled = true;
            this.mTAPIEx.Location = new System.Drawing.Point(1557, 35);
            this.mTAPIEx.Name = "mTAPIEx";
            this.mTAPIEx.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mTAPIEx.OcxState")));
            this.mTAPIEx.Size = new System.Drawing.Size(30, 30);
            this.mTAPIEx.TabIndex = 11;
            this.mTAPIEx.Visible = false;
            this.mTAPIEx.OnConnected += new AxTAPIEXLib._ITAPIExEvents_OnConnectedEventHandler(this.mTapiex_OnConnected);
            this.mTAPIEx.OnIdle += new AxTAPIEXLib._ITAPIExEvents_OnIdleEventHandler(this.mTAPIEx_OnIdle);
            this.mTAPIEx.OnDebug += new AxTAPIEXLib._ITAPIExEvents_OnDebugEventHandler(this.mTapiex_OnDebug);
            this.mTAPIEx.OnNewCall += new AxTAPIEXLib._ITAPIExEvents_OnNewCallEventHandler(this.mTapiex_OnNewCall);
            // 
            // Label4
            // 
            this.Label4.BackColor = System.Drawing.SystemColors.Control;
            this.Label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label4.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label4.Location = new System.Drawing.Point(1554, 14);
            this.Label4.Name = "Label4";
            this.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label4.Size = new System.Drawing.Size(57, 17);
            this.Label4.TabIndex = 9;
            this.Label4.Text = "Wave File:";
            this.Label4.Visible = false;
            // 
            // Label3
            // 
            this.Label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label3.BackColor = System.Drawing.SystemColors.Control;
            this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label3.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label3.Location = new System.Drawing.Point(8, 559);
            this.Label3.Name = "Label3";
            this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label3.Size = new System.Drawing.Size(99, 26);
            this.Label3.TabIndex = 5;
            this.Label3.Text = "Log message:";
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.SystemColors.Control;
            this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label2.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label2.Location = new System.Drawing.Point(8, 16);
            this.Label2.Name = "Label2";
            this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label2.Size = new System.Drawing.Size(89, 17);
            this.Label2.TabIndex = 4;
            this.Label2.Text = "拨号设备:";
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.SystemColors.Control;
            this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label1.Location = new System.Drawing.Point(298, 16);
            this.Label1.Name = "Label1";
            this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label1.Size = new System.Drawing.Size(89, 17);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "电话号码:";
            // 
            // btnListenStar
            // 
            this.btnListenStar.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnListenStar.Location = new System.Drawing.Point(571, 53);
            this.btnListenStar.Name = "btnListenStar";
            this.btnListenStar.Size = new System.Drawing.Size(86, 26);
            this.btnListenStar.TabIndex = 16;
            this.btnListenStar.Text = "开始监听";
            this.btnListenStar.UseVisualStyleBackColor = true;
            this.btnListenStar.Click += new System.EventHandler(this.btnListenStar_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(11, 95);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1328, 445);
            this.webBrowser1.TabIndex = 15;
            // 
            // shouwPageButton
            // 
            this.shouwPageButton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.shouwPageButton.Location = new System.Drawing.Point(490, 53);
            this.shouwPageButton.Name = "shouwPageButton";
            this.shouwPageButton.Size = new System.Drawing.Size(65, 26);
            this.shouwPageButton.TabIndex = 14;
            this.shouwPageButton.Text = "浏览";
            this.shouwPageButton.UseVisualStyleBackColor = true;
            this.shouwPageButton.Click += new System.EventHandler(this.shouwPageButton_Click);
            // 
            // txtPageAddress
            // 
            this.txtPageAddress.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPageAddress.Location = new System.Drawing.Point(101, 53);
            this.txtPageAddress.Name = "txtPageAddress";
            this.txtPageAddress.Size = new System.Drawing.Size(376, 26);
            this.txtPageAddress.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(11, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "输入网址";
            // 
            // pageTimer
            // 
            this.pageTimer.Interval = 5000;
            this.pageTimer.Tick += new System.EventHandler(this.pageTimer_Tick);
            // 
            // btnListenStop
            // 
            this.btnListenStop.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnListenStop.Location = new System.Drawing.Point(571, 53);
            this.btnListenStop.Name = "btnListenStop";
            this.btnListenStop.Size = new System.Drawing.Size(86, 26);
            this.btnListenStop.TabIndex = 17;
            this.btnListenStop.Text = "停止监听";
            this.btnListenStop.UseVisualStyleBackColor = true;
            this.btnListenStop.Visible = false;
            this.btnListenStop.Click += new System.EventHandler(this.btnListenStop_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Cursor = System.Windows.Forms.Cursors.Default;
            this.label6.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(564, 16);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label6.Size = new System.Drawing.Size(75, 17);
            this.label6.TabIndex = 18;
            this.label6.Text = "监听字符：";
            // 
            // txtListenString
            // 
            this.txtListenString.AcceptsReturn = true;
            this.txtListenString.BackColor = System.Drawing.SystemColors.Window;
            this.txtListenString.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtListenString.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtListenString.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtListenString.Location = new System.Drawing.Point(628, 14);
            this.txtListenString.MaxLength = 0;
            this.txtListenString.Name = "txtListenString";
            this.txtListenString.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtListenString.Size = new System.Drawing.Size(185, 20);
            this.txtListenString.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1351, 738);
            this.Controls.Add(this.txtListenString);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.shouwPageButton);
            this.Controls.Add(this.txtPageAddress);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtLog);
            this.Controls.Add(this.EdWaveFile);
            this.Controls.Add(this.BnPlayWave);
            this.Controls.Add(this.BnDrop);
            this.Controls.Add(this.CbLines);
            this.Controls.Add(this.Ednumber);
            this.Controls.Add(this.Dial);
            this.Controls.Add(this.mTAPIEx);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.btnListenStop);
            this.Controls.Add(this.btnListenStar);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(4, 23);
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "监听拨号程序";
            this.Closed += new System.EventHandler(this.Form1_Closed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mTAPIEx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
		#region "Upgrade Support "
		private static Form1 m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static Form1 DefInstance
		{
			get{
				Form1 returnValue;
				if (m_vb6FormDefInstance == null || m_vb6FormDefInstance.IsDisposed)
				{
					m_InitializingDefInstance = true;
					m_vb6FormDefInstance = new Form1();
					m_InitializingDefInstance = false;
				}
				returnValue = m_vb6FormDefInstance;
				return returnValue;
			}
			set
			{
				m_vb6FormDefInstance = value;
			}
		}
		#endregion
        #region "TAPIEX"
        public class CLineDevice
        {
            public string m_Name;
            public int m_ID;
            public override string ToString()
            {
                return m_Name;
            }
        }

        private TAPIEXLib.ITAPICall currCall;

        private void BnAboutBox_Click()
        {
            mTAPIEx.AboutBox();
        }

        private void BnDrop_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            currCall.Drop();
        }

        private void BnPlayWave_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            currCall.PlaybackFile(EdWaveFile.Text);
        }



        private void Dial_Click(System.Object eventSender, System.EventArgs eventArgs)
        {
            TAPIEXLib.ITAPILine line;
            if (CbLines.SelectedIndex >= 0)
            {
                CLineDevice lDevice;
                lDevice = (PageListenDialer.Form1.CLineDevice)CbLines.SelectedItem;
                line = mTAPIEx.GetLineFromDeviceID(lDevice.m_ID);
                if (line.Open())
                {
                    currCall = line.MakeCall(Ednumber.Text);
                }
            }
        }

        private void mTapiex_OnConnected(System.Object eventSender, AxTAPIEXLib._ITAPIExEvents_OnConnectedEvent eventArgs)
        {
            BnPlayWave.Enabled = true;
        }

        private void mTapiex_OnDebug(System.Object eventSender, AxTAPIEXLib._ITAPIExEvents_OnDebugEvent eventArgs)
        {
            TxtLog.Text = eventArgs.msg + Convert.ToChar(13) + Convert.ToChar(10) + TxtLog.Text;
        }


        private void mTapiex_OnNewCall(System.Object eventSender, AxTAPIEXLib._ITAPIExEvents_OnNewCallEvent eventArgs)
        {
            BnDrop.Enabled = true;
        }


        private void mTAPIEx_OnIdle(object sender, AxTAPIEXLib._ITAPIExEvents_OnIdleEvent e)
        {
            BnPlayWave.Enabled = false;
            BnDrop.Enabled = false;
            Marshal.ReleaseComObject(currCall); // release the COM object completely.
            currCall = null;
        }
        #endregion

        static string filePath = "./SetUp.ini";
		private void Form1_Load (System.Object eventSender, System.EventArgs eventArgs)
		{
			


            //写入/更新键值
            //INIOperationClass.INIWriteValue(filePath, "Seting", "ListenTime", "300000");
            string value = INIOperationClass.INIGetStringValue(filePath, "Seting", "ListenString", "");
            if (value.Trim() != "")
            {
                txtListenString.Text = value;
            }
            else
            {
                TxtLog.Text = "请设置设置文件中的监听字段！" + Convert.ToChar(13) + Convert.ToChar(10) + TxtLog.Text;
            }
            value = INIOperationClass.INIGetStringValue(filePath, "Seting", "ListenPhone", "");
            Ednumber.Text = value;
            value = INIOperationClass.INIGetStringValue(filePath, "Seting", "ListenDevice", "");

            TAPIEXLib.ITAPILine line;

            mTAPIEx.initialize(); //Initialize
            int index = 0;
            int selectIndex = 0;

            foreach (TAPIEXLib.ITAPILine tempLoopVar_line in mTAPIEx.Lines) //enumerate the line devices
            {
                line = tempLoopVar_line;
                if ((line.Caps.Line_Features & (TAPIEXLib.LINEFEATURE)TAPIEXLib.LINE_FEATURE.LINE_FEATURE_MAKECALL) > 0)
                {
                    CLineDevice lDevice = new CLineDevice();
                    lDevice.m_Name = line.DeviceName;
                    lDevice.m_ID = line.DeviceID;
                    if (lDevice.m_Name.ToLower().Equals(value.ToLower()))
                    {
                        selectIndex = index;
                    }
                    CbLines.Items.Add(lDevice);
                    index = index + 1;
                }
            }
            if (CbLines!=null && CbLines.Items.Count > 0)
            {
                CbLines.SelectedIndex = selectIndex;
            }
            
		}

		private void Form1_Closed (System.Object eventSender, System.EventArgs eventArgs)
		{
			mTAPIEx.UnInitialize();
		}
		

        private void shouwPageButton_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(txtPageAddress.Text.Trim());         //显示网页
            //htmlelement html = webbrowser1.document.body;      //定义html元素
            //string str = html.outerhtml;                       //获取当前元素的html代码
            //txtlog.text = str + convert.tochar(13) + convert.tochar(10) + txtlog.text;
            
        }

        private void pageTimer_Tick(object sender, EventArgs e)
        {
            if (webBrowser1.Document != null)
            {
                //模拟执行页面查询按钮
                HtmlDocument htmlDoc = webBrowser1.Document.Window.Frames["iframe"].Document;
                htmlDoc.InvokeScript("queryBtn");
                //Thread.Sleep(2000);
                //分割多个监听内容
                string[] arrListenString = Regex.Split(txtListenString.Text.ToString(), @"[,，]|\s+");

                for (int i = 0; i < arrListenString.Length;i++ )
                {
                    if (htmlDoc.Body.InnerText.Contains(arrListenString[i]))
                    {
                        //给指定电话号码拨号
                        TAPIEXLib.ITAPILine line;
                        if (CbLines.SelectedIndex >= 0)
                        {
                            CLineDevice lDevice;
                            lDevice = (PageListenDialer.Form1.CLineDevice)CbLines.SelectedItem;
                            line = mTAPIEx.GetLineFromDeviceID(lDevice.m_ID);
                            if (line.Open())
                            {
                                if (currCall != null)
                                {
                                    currCall.Drop();
                                }
                                //拨打电话
                                currCall = line.MakeCall(Ednumber.Text);
                            }
                        }
                    }
                }

            }

        }

        private void btnListenStar_Click(object sender, EventArgs e)
        {
            //设置监听时间
            string value = INIOperationClass.INIGetStringValue(filePath, "Seting", "ListenTime", "");
            if(value.Trim() != "")
            {
                pageTimer.Interval = Convert.ToInt32(value);
            }
            else
            {
                TxtLog.Text = "请设置设置文件中的监听时间参数！" + Convert.ToChar(13) + Convert.ToChar(10) + TxtLog.Text;
            }


            if (webBrowser1.Document != null)
            {
                if (webBrowser1.Document.Window.Frames["iframe"] == null)
                {
                    TxtLog.Text = "该网页无法监听，请联系系统管理员！" + Convert.ToChar(13) + Convert.ToChar(10) + TxtLog.Text;
                    return;
                }
                //模拟执行页面查询按钮
                HtmlDocument htmlDoc = webBrowser1.Document.Window.Frames["iframe"].Document;

                htmlDoc.InvokeScript("queryBtn");
                //获得输入流
                //StreamReader sr = new StreamReader(webBrowser1.DocumentStream, Encoding.GetEncoding("gb2312"));
                //读取html内容并填充到textBox中.
                //TxtLog.Text = htmlDoc.Body.InnerText + Convert.ToChar(13) + Convert.ToChar(10) + TxtLog.Text;
            }
            else
            {
                TxtLog.Text = "该网页无法监听，请联系系统管理员！" + Convert.ToChar(13) + Convert.ToChar(10) + TxtLog.Text;
                return;
            }

            
            TxtLog.Text = "开始监听网页" + Convert.ToChar(13) + Convert.ToChar(10) + TxtLog.Text;
            TAPIEXLib.ITAPILine line;
            if (CbLines.SelectedIndex < 0)
            {
                TxtLog.Text = "无可用调制解调器设备！" + Convert.ToChar(13) + Convert.ToChar(10) + TxtLog.Text;
                return;
            }else
            {
                CLineDevice lDevice;
                lDevice = (PageListenDialer.Form1.CLineDevice)CbLines.SelectedItem;
                line = mTAPIEx.GetLineFromDeviceID(lDevice.m_ID);
                if (!line.Open())
                {
                    TxtLog.Text = "调制解调器设备错误！" + Convert.ToChar(13) + Convert.ToChar(10) + TxtLog.Text;
                    return;
                }else
                {
                    line.Close();
                }
            }

            if (Ednumber.Text.Trim() == "")
            {
                TxtLog.Text = "请输入拨打的电话号码！" + Convert.ToChar(13) + Convert.ToChar(10) + TxtLog.Text;
                return;
            }


            if (txtListenString.Text.Trim().Length  == 0)
            {
                TxtLog.Text = "请输入监视内容！" + Convert.ToChar(13) + Convert.ToChar(10) + TxtLog.Text;
                return;
            }

            if (currCall != null)
            {
                currCall.Drop();
            }

            btnListenStar.Visible = false;
            btnListenStop.Visible = true;
            Ednumber.Enabled = false;
            CbLines.Enabled = false;
            txtListenString.Enabled = false;
            pageTimer.Start();
        }

        private void btnListenStop_Click(object sender, EventArgs e)
        {
            TxtLog.Text = "停止监听网页" + Convert.ToChar(13) + Convert.ToChar(10) + TxtLog.Text;
            btnListenStar.Visible = true;
            btnListenStop.Visible = false;
            Ednumber.Enabled = true;
            CbLines.Enabled = true;
            txtListenString.Enabled = true;
            if (currCall != null)
            {
                currCall.Drop();
            }
            pageTimer.Stop();
        }

        //WebClient取网页源码
        private string GetHtmlSource(string Url)
        {
            string text1 = "";
            try
            {
                WebClient wc = new WebClient();

                text1 = wc.DownloadString(Url);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return text1;
        }
	}
}
