/*
 * Created by SharpDevelop.
 * User: Diego
 * Date: 05/12/2016
 * Time: 23:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace LaserGRBL
{
	partial class ConnectLogForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private LaserGRBL.UserControls.GrblTextBox TxtManualCommand;
		private LaserGRBL.UserControls.CommandLog CmdLog;
		private System.Windows.Forms.TextBox TbFileName;
		private LaserGRBL.UserControls.DoubleProgressBar PB;
		private LaserGRBL.UserControls.ImageButton BtnOpen;
		private LaserGRBL.UserControls.ImageButton BtnRunProgram;
		private System.Windows.Forms.Label LblComPort;
		private System.Windows.Forms.Label LblBaudRate;
		private System.Windows.Forms.ComboBox CBPort;
		private System.Windows.Forms.ComboBox CBSpeed;
		private System.Windows.Forms.ToolTip TT;
		
		/// <summary>
		/// Disposes resources used by the control.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectLogForm));
			this.label5 = new System.Windows.Forms.Label();
			this.LblComPort = new System.Windows.Forms.Label();
			this.TbFileName = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.CBPort = new System.Windows.Forms.ComboBox();
			this.LblAddress = new System.Windows.Forms.Label();
			this.TxtAddress = new System.Windows.Forms.TextBox();
			this.LblBaudRate = new System.Windows.Forms.Label();
			this.CBSpeed = new System.Windows.Forms.ComboBox();
			this.UDLoopCounter = new System.Windows.Forms.NumericUpDown();
			this.TT = new System.Windows.Forms.ToolTip(this.components);
			this.BtnRunProgram = new LaserGRBL.UserControls.ImageButton();
			this.BtnOpen = new LaserGRBL.UserControls.ImageButton();
			this.BtnCD = new LaserGRBL.UserControls.ImageButton();
			this.TxtManualCommand = new LaserGRBL.UserControls.GrblTextBox();
			this.CmdLog = new LaserGRBL.UserControls.CommandLog();
			this.PB = new LaserGRBL.UserControls.DoubleProgressBar();
			((System.ComponentModel.ISupportInitialize)(this.UDLoopCounter)).BeginInit();
			this.SuspendLayout();
			// 
			// label5
			// 
			resources.ApplyResources(this.label5, "label5");
			this.label5.Name = "label5";
			// 
			// LblComPort
			// 
			resources.ApplyResources(this.LblComPort, "LblComPort");
			this.LblComPort.Name = "LblComPort";
			// 
			// TbFileName
			// 
			resources.ApplyResources(this.TbFileName, "TbFileName");
			this.TbFileName.Name = "TbFileName";
			this.TbFileName.ReadOnly = true;
			this.TbFileName.TabStop = false;
			this.TbFileName.MouseEnter += new System.EventHandler(this.TbFileName_MouseEnter);
			this.TbFileName.MouseLeave += new System.EventHandler(this.TbFileName_MouseLeave);
			// 
			// label3
			// 
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			// 
			// CBPort
			// 
			resources.ApplyResources(this.CBPort, "CBPort");
			this.CBPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CBPort.FormattingEnabled = true;
			this.CBPort.Name = "CBPort";
			this.CBPort.SelectedIndexChanged += new System.EventHandler(this.CBPort_SelectedIndexChanged);
			// 
			// LblAddress
			// 
			resources.ApplyResources(this.LblAddress, "LblAddress");
			this.LblAddress.Name = "LblAddress";
			// 
			// TxtAddress
			// 
			resources.ApplyResources(this.TxtAddress, "TxtAddress");
			this.TxtAddress.Name = "TxtAddress";
			this.TxtAddress.TextChanged += new System.EventHandler(this.TxtHostName_TextChanged);
			// 
			// LblBaudRate
			// 
			resources.ApplyResources(this.LblBaudRate, "LblBaudRate");
			this.LblBaudRate.Name = "LblBaudRate";
			// 
			// CBSpeed
			// 
			resources.ApplyResources(this.CBSpeed, "CBSpeed");
			this.CBSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CBSpeed.FormattingEnabled = true;
			this.CBSpeed.Name = "CBSpeed";
			this.CBSpeed.SelectedIndexChanged += new System.EventHandler(this.CBSpeed_SelectedIndexChanged);
			// 
			// UDLoopCounter
			// 
			resources.ApplyResources(this.UDLoopCounter, "UDLoopCounter");
			this.UDLoopCounter.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
			this.UDLoopCounter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.UDLoopCounter.Name = "UDLoopCounter";
			this.TT.SetToolTip(this.UDLoopCounter, resources.GetString("UDLoopCounter.ToolTip"));
			this.UDLoopCounter.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.UDLoopCounter.ValueChanged += new System.EventHandler(this.UDLoopCounter_ValueChanged);
			// 
			// BtnRunProgram
			// 
			this.BtnRunProgram.AltImage = null;
			resources.ApplyResources(this.BtnRunProgram, "BtnRunProgram");
			this.BtnRunProgram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.BtnRunProgram.Coloration = System.Drawing.Color.Empty;
			this.BtnRunProgram.Image = ((System.Drawing.Image)(resources.GetObject("BtnRunProgram.Image")));
			this.BtnRunProgram.Name = "BtnRunProgram";
			this.BtnRunProgram.SizingMode = LaserGRBL.UserControls.ImageButton.SizingModes.FixedSize;
			this.BtnRunProgram.TabStop = false;
			this.TT.SetToolTip(this.BtnRunProgram, resources.GetString("BtnRunProgram.ToolTip"));
			this.BtnRunProgram.UseAltImage = false;
			this.BtnRunProgram.Click += new System.EventHandler(this.BtnRunProgramClick);
			// 
			// BtnOpen
			// 
			this.BtnOpen.AltImage = null;
			resources.ApplyResources(this.BtnOpen, "BtnOpen");
			this.BtnOpen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.BtnOpen.Coloration = System.Drawing.Color.Empty;
			this.BtnOpen.Image = ((System.Drawing.Image)(resources.GetObject("BtnOpen.Image")));
			this.BtnOpen.Name = "BtnOpen";
			this.BtnOpen.SizingMode = LaserGRBL.UserControls.ImageButton.SizingModes.FixedSize;
			this.BtnOpen.TabStop = false;
			this.TT.SetToolTip(this.BtnOpen, resources.GetString("BtnOpen.ToolTip"));
			this.BtnOpen.UseAltImage = false;
			this.BtnOpen.Click += new System.EventHandler(this.BtnOpenClick);
			// 
			// BtnCD
			// 
			this.BtnCD.AltImage = ((System.Drawing.Image)(resources.GetObject("BtnCD.AltImage")));
			resources.ApplyResources(this.BtnCD, "BtnCD");
			this.BtnCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.BtnCD.Coloration = System.Drawing.Color.Empty;
			this.BtnCD.Image = ((System.Drawing.Image)(resources.GetObject("BtnCD.Image")));
			this.BtnCD.Name = "BtnCD";
			this.BtnCD.SizingMode = LaserGRBL.UserControls.ImageButton.SizingModes.FixedSize;
			this.BtnCD.TabStop = false;
			this.TT.SetToolTip(this.BtnCD, resources.GetString("BtnCD.ToolTip"));
			this.BtnCD.UseAltImage = false;
			this.BtnCD.Click += new System.EventHandler(this.BtnConnectDisconnectClick);
			// 
			// TxtManualCommand
			// 
			resources.ApplyResources(this.TxtManualCommand, "TxtManualCommand");
			this.TxtManualCommand.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.TxtManualCommand.Name = "TxtManualCommand";
			this.TxtManualCommand.WaterMark = "type gcode here";
			this.TxtManualCommand.WaterMarkActiveForeColor = System.Drawing.Color.Gray;
			this.TxtManualCommand.WaterMarkFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxtManualCommand.WaterMarkForeColor = System.Drawing.Color.LightGray;
			this.TxtManualCommand.CommandEntered += new LaserGRBL.UserControls.GrblTextBox.CommandEnteredDlg(this.TxtManualCommandCommandEntered);
			this.TxtManualCommand.Enter += new System.EventHandler(this.TxtManualCommand_Enter);
			this.TxtManualCommand.Leave += new System.EventHandler(this.TxtManualCommand_Leave);
			// 
			// CmdLog
			// 
			resources.ApplyResources(this.CmdLog, "CmdLog");
			this.CmdLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.CmdLog.Name = "CmdLog";
			this.CmdLog.TabStop = false;
			// 
			// PB
			// 
			resources.ApplyResources(this.PB, "PB");
			this.PB.BarColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.PB.BorderColor = System.Drawing.Color.Black;
			this.PB.DrawProgressString = true;
			this.PB.FillColor = System.Drawing.Color.White;
			this.PB.FillStyle = LaserGRBL.UserControls.FillStyles.Solid;
			this.PB.ForeColor = System.Drawing.Color.Black;
			this.PB.Maximum = 100D;
			this.PB.Minimum = 0D;
			this.PB.Name = "PB";
			this.PB.PercString = null;
			this.PB.ProgressStringDecimals = 0;
			this.PB.Reverse = false;
			this.PB.Step = 10D;
			this.PB.ThrowExceprion = false;
			this.PB.Value = 0D;
			// 
			// ConnectLogForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.BtnRunProgram);
			this.Controls.Add(this.BtnOpen);
			this.Controls.Add(this.PB);
			this.Controls.Add(this.BtnCD);
			this.Controls.Add(this.UDLoopCounter);
			this.Controls.Add(this.TxtManualCommand);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.CmdLog);
			this.Controls.Add(this.TbFileName);
			this.Controls.Add(this.LblComPort);
			this.Controls.Add(this.CBPort);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.LblBaudRate);
			this.Controls.Add(this.TxtAddress);
			this.Controls.Add(this.LblAddress);
			this.Controls.Add(this.CBSpeed);
			this.Name = "ConnectLogForm";
			((System.ComponentModel.ISupportInitialize)(this.UDLoopCounter)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label LblAddress;
		private System.Windows.Forms.TextBox TxtAddress;
		private System.Windows.Forms.NumericUpDown UDLoopCounter;
		private UserControls.ImageButton BtnCD;
	}
}
