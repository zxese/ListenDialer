using System.Diagnostics;
using AxTAPIEXLib;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.InteropServices;

namespace Dialer_Demo
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
		//Required by the Windows Form Designer
		private System.ComponentModel.Container components = null;
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
		public System.Windows.Forms.Label Label1;
//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent ()
		{
			this.components = new System.ComponentModel.Container();
			base.Load += new System.EventHandler(Form1_Load);
			base.Closed += new System.EventHandler(Form1_Closed);
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.TxtLog = new System.Windows.Forms.TextBox();
			this.EdWaveFile = new System.Windows.Forms.TextBox();
			this.BnPlayWave = new System.Windows.Forms.Button();
			BnPlayWave.Click += new System.EventHandler(BnPlayWave_Click);
			this.BnDrop = new System.Windows.Forms.Button();
			BnDrop.Click += new System.EventHandler(BnDrop_Click);
			this.CbLines = new System.Windows.Forms.ComboBox();
			this.Ednumber = new System.Windows.Forms.TextBox();
			this.Dial = new System.Windows.Forms.Button();
			Dial.Click += new System.EventHandler(Dial_Click);
			this.mTAPIEx = new AxTAPIEXLib.AxTAPIExCtl();
			mTAPIEx.OnConnected += new AxTAPIEXLib._ITAPIExEvents_OnConnectedEventHandler(mTapiex_OnConnected);
			mTAPIEx.OnDebug += new AxTAPIEXLib._ITAPIExEvents_OnDebugEventHandler(mTapiex_OnDebug);
			mTAPIEx.OnNewCall += new AxTAPIEXLib._ITAPIExEvents_OnNewCallEventHandler(mTapiex_OnNewCall);
			mTAPIEx.OnIdle += new AxTAPIEXLib._ITAPIExEvents_OnIdleEventHandler(mTAPIEx_OnIdle);
			this.Label4 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.mTAPIEx)).BeginInit();
			this.SuspendLayout();
			//
			//TxtLog
			//
			this.TxtLog.AcceptsReturn = true;
			this.TxtLog.AutoSize = false;
			this.TxtLog.BackColor = System.Drawing.SystemColors.Window;
			this.TxtLog.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.TxtLog.Font = new System.Drawing.Font("Arial", (float) (8.0), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point,((byte)(0)));
			this.TxtLog.ForeColor = System.Drawing.SystemColors.WindowText;
			this.TxtLog.Location = new System.Drawing.Point(8, 128);
			this.TxtLog.MaxLength = 0;
			this.TxtLog.Multiline = true;
			this.TxtLog.Name = "TxtLog";
			this.TxtLog.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.TxtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.TxtLog.Size = new System.Drawing.Size(416, 160);
			this.TxtLog.TabIndex = 10;
			this.TxtLog.Text = "";
			//
			//EdWaveFile
			//
			this.EdWaveFile.AcceptsReturn = true;
			this.EdWaveFile.AutoSize = false;
			this.EdWaveFile.BackColor = System.Drawing.SystemColors.Window;
			this.EdWaveFile.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.EdWaveFile.Font = new System.Drawing.Font("Arial", (float) (8.0), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point,((byte)(0)));
			this.EdWaveFile.ForeColor = System.Drawing.SystemColors.WindowText;
			this.EdWaveFile.Location = new System.Drawing.Point(72, 80);
			this.EdWaveFile.MaxLength = 0;
			this.EdWaveFile.Name = "EdWaveFile";
			this.EdWaveFile.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.EdWaveFile.Size = new System.Drawing.Size(201, 19);
			this.EdWaveFile.TabIndex = 8;
			this.EdWaveFile.Text = "";
			//
			//BnPlayWave
			//
			this.BnPlayWave.BackColor = System.Drawing.SystemColors.Control;
			this.BnPlayWave.Cursor = System.Windows.Forms.Cursors.Default;
			this.BnPlayWave.Enabled = false;
			this.BnPlayWave.Font = new System.Drawing.Font("Arial", (float) (8.0), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point,((byte)(0)));
			this.BnPlayWave.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BnPlayWave.Location = new System.Drawing.Point(320, 80);
			this.BnPlayWave.Name = "BnPlayWave";
			this.BnPlayWave.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.BnPlayWave.Size = new System.Drawing.Size(97, 25);
			this.BnPlayWave.TabIndex = 7;
			this.BnPlayWave.Text = "Play Wave";
			//
			//BnDrop
			//
			this.BnDrop.BackColor = System.Drawing.SystemColors.Control;
			this.BnDrop.Cursor = System.Windows.Forms.Cursors.Default;
			this.BnDrop.Enabled = false;
			this.BnDrop.Font = new System.Drawing.Font("Arial", (float) (9.75), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point,((byte)(0)));
			this.BnDrop.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BnDrop.Location = new System.Drawing.Point(320, 40);
			this.BnDrop.Name = "BnDrop";
			this.BnDrop.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.BnDrop.Size = new System.Drawing.Size(97, 25);
			this.BnDrop.TabIndex = 6;
			this.BnDrop.Text = "Drop";
			//
			//CbLines
			//
			this.CbLines.BackColor = System.Drawing.SystemColors.Window;
			this.CbLines.Cursor = System.Windows.Forms.Cursors.Default;
			this.CbLines.Font = new System.Drawing.Font("Arial", (float) (8.0), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point,((byte)(0)));
			this.CbLines.ForeColor = System.Drawing.SystemColors.WindowText;
			this.CbLines.Location = new System.Drawing.Point(72, 8);
			this.CbLines.Name = "CbLines";
			this.CbLines.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.CbLines.Size = new System.Drawing.Size(208, 22);
			this.CbLines.TabIndex = 3;
			//
			//Ednumber
			//
			this.Ednumber.AcceptsReturn = true;
			this.Ednumber.AutoSize = false;
			this.Ednumber.BackColor = System.Drawing.SystemColors.Window;
			this.Ednumber.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.Ednumber.Font = new System.Drawing.Font("Arial", (float) (8.0), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point,((byte)(0)));
			this.Ednumber.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Ednumber.Location = new System.Drawing.Point(88, 40);
			this.Ednumber.MaxLength = 0;
			this.Ednumber.Name = "Ednumber";
			this.Ednumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Ednumber.Size = new System.Drawing.Size(185, 19);
			this.Ednumber.TabIndex = 1;
			this.Ednumber.Text = "";
			//
			//Dial
			//
			this.Dial.BackColor = System.Drawing.SystemColors.Control;
			this.Dial.Cursor = System.Windows.Forms.Cursors.Default;
			this.Dial.Font = new System.Drawing.Font("Arial", (float) (9.75), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point,((byte)(0)));
			this.Dial.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Dial.Location = new System.Drawing.Point(320, 8);
			this.Dial.Name = "Dial";
			this.Dial.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Dial.Size = new System.Drawing.Size(97, 25);
			this.Dial.TabIndex = 0;
			this.Dial.Text = "Make Call";
			//
			//mTAPIEx
			//
			this.mTAPIEx.Enabled = true;
			this.mTAPIEx.Location = new System.Drawing.Point(280, 8);
			this.mTAPIEx.Name = "mTAPIEx";
			this.mTAPIEx.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mTAPIEx.OcxState")));
			this.mTAPIEx.Size = new System.Drawing.Size(30, 30);
			this.mTAPIEx.TabIndex = 11;
			//
			//Label4
			//
			this.Label4.BackColor = System.Drawing.SystemColors.Control;
			this.Label4.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label4.Font = new System.Drawing.Font("Arial", (float) (8.0), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point,((byte)(0)));
			this.Label4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label4.Location = new System.Drawing.Point(8, 80);
			this.Label4.Name = "Label4";
			this.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label4.Size = new System.Drawing.Size(57, 17);
			this.Label4.TabIndex = 9;
			this.Label4.Text = "Wave File:";
			//
			//Label3
			//
			this.Label3.BackColor = System.Drawing.SystemColors.Control;
			this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label3.Font = new System.Drawing.Font("Arial", (float) (8.0), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point,((byte)(0)));
			this.Label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label3.Location = new System.Drawing.Point(8, 104);
			this.Label3.Name = "Label3";
			this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label3.Size = new System.Drawing.Size(73, 25);
			this.Label3.TabIndex = 5;
			this.Label3.Text = "Log message:";
			//
			//Label2
			//
			this.Label2.BackColor = System.Drawing.SystemColors.Control;
			this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label2.Font = new System.Drawing.Font("Arial", (float) (8.0), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point,((byte)(0)));
			this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label2.Location = new System.Drawing.Point(8, 8);
			this.Label2.Name = "Label2";
			this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label2.Size = new System.Drawing.Size(89, 17);
			this.Label2.TabIndex = 4;
			this.Label2.Text = "Device:";
			//
			//Label1
			//
			this.Label1.BackColor = System.Drawing.SystemColors.Control;
			this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label1.Font = new System.Drawing.Font("Arial", (float) (8.0), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point,((byte)(0)));
			this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label1.Location = new System.Drawing.Point(8, 40);
			this.Label1.Name = "Label1";
			this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label1.Size = new System.Drawing.Size(89, 17);
			this.Label1.TabIndex = 2;
			this.Label1.Text = "Phone number:";
			//
			//Form1
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(432, 302);
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
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.Font = new System.Drawing.Font("Arial", (float) (8.0), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point,((byte)(0)));
			this.Location = new System.Drawing.Point(4, 23);
			this.Name = "Form1";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Simple Dialer Demo";
			((System.ComponentModel.ISupportInitialize)(this.mTAPIEx)).EndInit();
			this.ResumeLayout(false);
			
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
		//#####################################################################################
		//# Program name: Simple Dialer Demo                                                  #
		//#                                                                                   #
		//# Version: v1.5                                                                     #
		//#                                                                                   #
		//# Last modification Date: March. 16th 2006                                          #
		//#                                                                                   #
		//# This program demonstrates how to dial a call, monitor for Caller ID or digits,    #
		//# play wave file and then hang-up. If you want to monitor the ringback or busy tone #
		//# or detect the call has been answered, please refer our "MonitorTones" demo.       #
		//#                                                                                   #
		//# Requirements: TAPIEx control,  VOICE modem or TAPI compliant telephony device     #
		//#                                                                                   #
		//# Operating System: Windows 98, Windows ME, Windows NT 4, Windows 2000, Windows XP  #
		//#                                                                                   #
		//# Note: Under Windows NT 4 voice modems may not supported because of the lack of a  #
		//# voice capable TAPI universal modem driver.                                        #
		//#                                                                                   #
		//# Program Purpose:To demonstrate how to add telephony functions to your application #
		//# using the TAPIEx ActiveX control.                                                 #
		//#                                                                                   #
		//####################################################################################
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
		
		private void BnAboutBox_Click ()
		{
			mTAPIEx.AboutBox();
		}
		
		private void BnDrop_Click (System.Object eventSender, System.EventArgs eventArgs)
		{
			currCall.Drop();
		}
		
		private void BnPlayWave_Click (System.Object eventSender, System.EventArgs eventArgs)
		{
			currCall.PlaybackFile(EdWaveFile.Text);
		}
		
		
		
		private void Dial_Click (System.Object eventSender, System.EventArgs eventArgs)
		{
			TAPIEXLib.ITAPILine line;
			if (CbLines.SelectedIndex >= 0)
			{
				CLineDevice lDevice;
				lDevice = (Dialer_Demo.Form1.CLineDevice) CbLines.SelectedItem;
				line = mTAPIEx.GetLineFromDeviceID(lDevice.m_ID);
				if (line.Open())
				{
					currCall = line.MakeCall(Ednumber.Text);
				}
			}
		}
		
		private void Form1_Load (System.Object eventSender, System.EventArgs eventArgs)
		{
			
			TAPIEXLib.ITAPILine line;
			
			mTAPIEx.initialize(); //Initialize
			foreach (TAPIEXLib.ITAPILine tempLoopVar_line in mTAPIEx.Lines) //enumerate the line devices
			{
				line = tempLoopVar_line;
				if ((line.Caps.Line_Features & (TAPIEXLib.LINEFEATURE) TAPIEXLib.LINE_FEATURE.LINE_FEATURE_MAKECALL) > 0)
				{
					CLineDevice lDevice = new CLineDevice();
					lDevice.m_Name = line.DeviceName;
					lDevice.m_ID = line.DeviceID;
					CbLines.Items.Add(lDevice);
				}
			}
		}
		
		private void Form1_Closed (System.Object eventSender, System.EventArgs eventArgs)
		{
			mTAPIEx.UnInitialize();
		}
		
		
		
		
		private void mTapiex_OnConnected (System.Object eventSender, AxTAPIEXLib._ITAPIExEvents_OnConnectedEvent eventArgs)
		{
			BnPlayWave.Enabled = true;
		}
		
		private void mTapiex_OnDebug (System.Object eventSender, AxTAPIEXLib._ITAPIExEvents_OnDebugEvent eventArgs)
		{
			TxtLog.Text = eventArgs.msg + Convert.ToChar(13) + Convert.ToChar(10) + TxtLog.Text;
		}
		
		
		private void mTapiex_OnNewCall (System.Object eventSender, AxTAPIEXLib._ITAPIExEvents_OnNewCallEvent eventArgs)
		{
			BnDrop.Enabled = true;
		}
		
		
		private void mTAPIEx_OnIdle (object sender, AxTAPIEXLib._ITAPIExEvents_OnIdleEvent e)
		{
			BnPlayWave.Enabled = false;
			BnDrop.Enabled = false;
			Marshal.ReleaseComObject(currCall); // release the COM object completely.
			currCall=null;
		}
	}
}
