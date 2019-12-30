/*
 * Created by SharpDevelop.
 * User: Diego
 * Date: 05/12/2016
 * Time: 23:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace LaserGRBL
{
	/// <summary>
	/// Description of PreviewForm.
	/// </summary>
	public partial class PreviewForm : System.Windows.Forms.UserControl
	{
		GrblCore Core;

		public PreviewForm()
		{
			InitializeComponent();
			CustomButtonArea.OrderChanged += CustomButtonArea_OrderChanged;
		}

		private void CustomButtonArea_OrderChanged(int oldindex, int newindex)
		{
			CustomButtons.Reorder(oldindex, newindex);
			RefreshCustomButtons();
		}

		public void SetCore(GrblCore core)
		{
			Core = core;
			Preview.SetComProgram(core);

			RefreshCustomButtons();
			TimerUpdate();
		}

		public void TimerUpdate()
		{
			Preview.TimerUpdate();
			SuspendLayout();
			BtnReset.Enabled = Core.CanResetGrbl;
			BtnHoming.Visible = Core.Configuration.HomingEnabled;
			BtnHoming.Enabled = Core.CanDoHoming;
			BtnUnlock.Enabled = Core.CanUnlock;
			BtnStop.Enabled = Core.CanFeedHold;
			BtnResume.Enabled = Core.CanResumeHold;
			BtnZeroing.Enabled = Core.CanDoZeroing;

			foreach (CustomButtonIB ib in CustomButtonArea.Controls)
				ib.RefreshEnabled();

			ResumeLayout();
		}

		void BtnGoHomeClick(object sender, EventArgs e)
		{
			Core.GrblHoming();
		}
		void BtnResetClick(object sender, EventArgs e)
		{
			Core.GrblReset();
		}
		void BtnStopClick(object sender, EventArgs e)
		{
			Core.FeedHold(false);
		}
		void BtnResumeClick(object sender, EventArgs e)
		{
			Core.CycleStartResume(false);
		}

		private void BtnUnlockClick(object sender, EventArgs e)
		{
			Core.GrblUnlock();
		}

		private void addCustomButtonToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CustomButtonForm.CreateAndShowDialog();
			RefreshCustomButtons();
		}

		private void RefreshCustomButtons()
		{
			CustomButtonArea.Controls.Clear();
			foreach (CustomButton cb in CustomButtons.Buttons)
			{
				CustomButtonIB ib = new CustomButtonIB(Core, cb, this);
				CustomButtonArea.Controls.Add(ib);
			}

		}

        public List<CustomButtonIB> CustomImageButtons
        {
            get
            {
                List<CustomButtonIB> rv = new List<CustomButtonIB>();
                foreach (Control c in CustomButtonArea.Controls)
                    if (c is CustomButtonIB)
                        rv.Add(c as CustomButtonIB);
                return rv;
            }
        }

		public class CustomButtonIB : UserControls.ImageButton
		{
			private GrblCore Core;
			private LaserGRBL.CustomButton cb;
			PreviewForm form;
			private ToolTip tt;
			private ContextMenuStrip cms;
			private bool mDrawDisabled = true;

			public CustomButtonIB(GrblCore Core, LaserGRBL.CustomButton cb, PreviewForm form)
			{
				// TODO: Complete member initialization
				this.Core = Core;
				this.cb = cb;
				this.form = form;
				this.tt = new ToolTip();

				Image = cb.Image;
				Tag = cb;

				//ContextMenuStrip = MNRemEditCB;
				SizingMode = UserControls.ImageButton.SizingModes.FixedSize;
				BorderStyle = BorderStyle.FixedSingle;
				Size = new Size(49, 49);
				Margin = new Padding(2);
				tt.SetToolTip(this, cb.ToolTip);


				cms = new ContextMenuStrip();
				cms.Items.Add(Strings.CustomButtonRemove, null, RemoveButton_Click);
				cms.Items.Add(Strings.CustomButtonEdit, null, EditButton_Click);

				ContextMenuStrip = cms;
				AllowDrag = true;
			}


			protected override void Dispose(bool disposing)
			{
				tt.SetToolTip(this, null);
				base.Dispose(disposing);
			}

			public CustomButton CustomButton
			{ get { return Tag as CustomButton; } }

			internal void RefreshEnabled()
			{
				bool disabled = !CustomButton.EnabledNow(Core);
				if (mDrawDisabled != disabled)
				{
					mDrawDisabled = disabled;
					Refresh();
				}
			}

			protected override bool DrawDisabled()
			{
				return mDrawDisabled;
			}

			protected override void OnClick(EventArgs e)
            {PerformClick(e);}

            private bool mEmulateMouseInside;
            public bool EmulateMouseInside
            {
                get { return mEmulateMouseInside; }
                set { mEmulateMouseInside = value; Invalidate(); }
            }

            public override bool IsMouseInside()
            {
                return EmulateMouseInside || base.IsMouseInside();
            }

            private bool on;
            public void PerformClick(EventArgs e)
            {
                if (((MouseEventArgs)e).Button != MouseButtons.Left)
                    return;

                if (mDrawDisabled || !CustomButton.EnabledNow(Core))
                    return;

                if (cb.ButtonType == CustomButton.ButtonTypes.Button)
                    Core.ExecuteCustombutton(cb.GCode);

                if (cb.ButtonType == CustomButton.ButtonTypes.TwoStateButton)
                {
                    on = !on;
                    Core.ExecuteCustombutton(on ? cb.GCode : cb.GCode2);
                    BackColor = on ? Color.Orange : Parent.BackColor;
                }

                base.OnClick(e);
            }

            protected override void OnMouseDown(MouseEventArgs e)
            {
				_mX = e.X;
				_mY = e.Y;
				this._isDragging = false;

				PerformMouseDown(e);
			}

            public void PerformMouseDown(MouseEventArgs e)
            {
                if (e.Button != MouseButtons.Left)
                    return;

                if (mDrawDisabled || !CustomButton.EnabledNow(Core))
                    return;

                if (cb.ButtonType == CustomButton.ButtonTypes.PushButton)
                {
                    Core.ExecuteCustombutton(cb.GCode);
                    BackColor = Color.LightBlue;
                }

                base.OnMouseDown(e);
            }

            protected override void OnMouseUp(MouseEventArgs e)
            {
				_isDragging = false;
				PerformMouseUp(e);
			}

            public void PerformMouseUp(MouseEventArgs e)
            {
                if (e.Button != MouseButtons.Left)
                    return;

                if (mDrawDisabled || !CustomButton.EnabledNow(Core))
                    return;

                if (cb.ButtonType == CustomButton.ButtonTypes.PushButton)
                {
                    Core.ExecuteCustombutton(cb.GCode2);
                    BackColor = Parent.BackColor;
                }

                base.OnMouseUp(e);
            }

            private void RemoveButton_Click(object sender, EventArgs e)
			{
				if (MessageBox.Show(Strings.BoxDeleteCustomButtonText, Strings.BoxDeleteCustomButtonTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
				{
					CustomButtons.Remove(CustomButton);
					CustomButtons.SaveFile();
					form.RefreshCustomButtons();
				}
			}

			private void EditButton_Click(object sender, EventArgs e)
			{
				CustomButtonForm.CreateAndShowDialog(CustomButton);
				form.RefreshCustomButtons();
			}


			#region DragDrop


			//Check radius for begin drag n drop
			public bool AllowDrag { get; set; }
			private bool _isDragging = false;
			private int _DDradius = 40;
			private int _mX = 0;
			private int _mY = 0;

			protected override void OnMouseMove(MouseEventArgs e)
			{
				if (!_isDragging)
				{
					// This is a check to see if the mouse is moving while pressed.
					// Without this, the DragDrop is fired directly when the control is clicked, now you have to drag a few pixels first.
					if (e.Button == MouseButtons.Left && _DDradius > 0 && this.AllowDrag)
					{
						int num1 = _mX - e.X;
						int num2 = _mY - e.Y;
						if (((num1 * num1) + (num2 * num2)) > _DDradius)
						{
							DoDragDrop(this, DragDropEffects.Move);
							_isDragging = true;
							return;
						}
					}
					base.OnMouseMove(e);
				}
			}

			#endregion

		}

		private class MyFlowPanel : FlowLayoutPanel
		{
			public delegate void OrderChangedDlg(int oldindex, int newindex);
			public event OrderChangedDlg OrderChanged;

			public MyFlowPanel()
			{
				AllowDrop = true;
				ResizeRedraw = true;
			}

			protected override void OnControlAdded(ControlEventArgs e)
			{
				base.OnControlAdded(e);
				Invalidate();
			}
			protected override void OnControlRemoved(ControlEventArgs e)
			{
				base.OnControlRemoved(e);
				Invalidate();
			}

			protected override void OnPaintBackground(PaintEventArgs e)
			{
				e.Graphics.Clear(BackColor);
				if (Controls.Count == 0)
				{
					string text = Strings.AddCustomButtonsHint;
					SizeF size = e.Graphics.MeasureString(text, Font);
					e.Graphics.DrawString(text, Font, Brushes.DarkGray, (Width - size.Width) / 2, (Height - size.Height) / 2);
				}
			}

			protected override void OnDragEnter(DragEventArgs drgevent)
			{
				CustomButtonIB btn = (CustomButtonIB)drgevent.Data.GetData(typeof(CustomButtonIB));
				if (btn != null)
					drgevent.Effect = DragDropEffects.Move;
				else
					drgevent.Effect = DragDropEffects.None;

				base.OnDragEnter(drgevent);
			}

			protected override void OnDragDrop(DragEventArgs drgevent)
			{
				CustomButtonIB btn = (CustomButtonIB)drgevent.Data.GetData(typeof(CustomButtonIB));
				MyFlowPanel dst = this;
				MyFlowPanel src = btn?.Parent as MyFlowPanel;

				if (btn != null && src != null && dst != null &&  src == dst)
				{
					drgevent.Effect = DragDropEffects.Move;

					Point p = dst.PointToClient(new Point(drgevent.X, drgevent.Y));
					Control item = dst.GetChildAtPoint(p);
					int oldindex = dst.Controls.GetChildIndex(btn);
					int newindex = dst.Controls.GetChildIndex(item, false);
					
					OrderChanged?.Invoke(oldindex, newindex);
				}
				else
				{
					drgevent.Effect = DragDropEffects.None;
				}

				base.OnDragDrop(drgevent);
			}

		}


		internal void OnColorChange()
		{
			Preview.OnColorChange();
		}

		private void BtnZeroing_Click(object sender, EventArgs e)
		{
			Core.SetNewZero();
		}

        #region Modified by wuxiaojie 20191225
        /// <summary>
        /// 记录左下角坐标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLeftBottom_Click(object sender, EventArgs e)
        {
            Preview.manualLBPos = Core.MachinePosition;
            string text = "X: " + Preview.manualLBPos.X.ToString("0.000") + "  Y: " + Preview.manualLBPos.Y.ToString("0.000");
            if (MessageBox.Show(text, "左下质控点坐标", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Preview.ManualPos();
            }
        }

        /// <summary>
        /// 记录右下角坐标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRightBottom_Click(object sender, EventArgs e)
        {
            Preview.manualRBPos = Core.MachinePosition;
            string text = "X: " + Preview.manualRBPos.X.ToString("0.000") + "  Y: " + Preview.manualRBPos.Y.ToString("0.000");
            if (MessageBox.Show(text, "右下质控点坐标", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Preview.ManualPos();
            }
        }

        /// <summary>
        /// 记录左上角坐标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLeftTop_Click(object sender, EventArgs e)
        {
            Preview.manualLTPos = Core.MachinePosition;
            string text = "X: " + Preview.manualLTPos.X.ToString("0.000") + "  Y: " + Preview.manualLTPos.Y.ToString("0.000");
            if (MessageBox.Show(text, "左上质控点坐标", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Preview.ManualPos();
            }
        }

        /// <summary>
        /// 记录右上角坐标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRightTop_Click(object sender, EventArgs e)
        {
            Preview.manualRTPos = Core.MachinePosition;
            string text = "X: " + Preview.manualRTPos.X.ToString("0.000") + "  Y: " + Preview.manualRTPos.Y.ToString("0.000");
            if (MessageBox.Show(text, "右上质控点坐标", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Preview.ManualPos();
            }
        }

        /// <summary>
        /// 生成gcode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnGcode_Click(object sender, EventArgs e)
        {
            StringBuilder sb = CalcPos();

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "gcode文件(*.gcode)|*.gcode";
            sfd.FileName = "Cut" + DateTime.Now.ToString("yyyyMMddHHmmss");
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string filename = sfd.FileName.ToString();
                System.IO.FileStream fs = (System.IO.FileStream)sfd.OpenFile();
                byte[] array = Encoding.ASCII.GetBytes(sb.ToString());
                fs.Write(array, 0, array.Length);
                fs.Close();

                // 打开文件
                Core.OpenFile(ParentForm, filename);
            }
        }

        /// <summary>
        /// 计算坐标
        /// </summary>
        /// <returns></returns>
        private StringBuilder CalcPos()
        {
            #region 参数
            // 行
            int row = Convert.ToInt32(ConfigurationManager.AppSettings.Get("row"));
            // 列
            int column = Convert.ToInt32(ConfigurationManager.AppSettings.Get("column"));
            // 延长5mm
            int extend = Convert.ToInt32(ConfigurationManager.AppSettings.Get("extend"));
            // 运行速度
            int speed = Convert.ToInt32(ConfigurationManager.AppSettings.Get("speed"));
            // 功率
            int power = Convert.ToInt32(ConfigurationManager.AppSettings.Get("power"));
            // 质控点上/左边距
            float paddingTL = (9.5f - 1.25f * 3) / 2;
            // 质控点下/右边距
            float paddingBR = 9.5f - paddingTL;
            #endregion

            #region 手工定位点
            // 定位点坐标
            // 左上
            GPoint manualLTPos = Preview.manualLTPos;
            // 右上
            GPoint manualRTPos = Preview.manualRTPos;
            // 左下
            GPoint manualLBPos = Preview.manualLBPos;
            // 右下
            GPoint manualRBPos = Preview.manualRBPos;

            // 定位点向量模
            // 左边
            float manualLLength = (float)Math.Sqrt(Math.Pow((manualLTPos.X - manualLBPos.X), 2) + Math.Pow((manualLTPos.Y - manualLBPos.Y), 2));
            // 右边
            float manualRLength = (float)Math.Sqrt(Math.Pow((manualRTPos.X - manualRBPos.X), 2) + Math.Pow((manualRTPos.Y - manualRBPos.Y), 2));
            // 上边
            float manualTLength = (float)Math.Sqrt(Math.Pow((manualRTPos.X - manualLTPos.X), 2) + Math.Pow((manualRTPos.Y - manualLTPos.Y), 2));
            // 下边
            float manualBLength = (float)Math.Sqrt(Math.Pow((manualRBPos.X - manualLBPos.X), 2) + Math.Pow((manualRBPos.Y - manualLBPos.Y), 2));

            // 定位点单位向量
            // 左下-左上
            GPoint manualLBLTVector = new GPoint();
            manualLBLTVector.X = (manualLTPos.X - manualLBPos.X) / manualLLength;
            manualLBLTVector.Y = (manualLTPos.Y - manualLBPos.Y) / manualLLength;
            // 右下-右上
            GPoint manualRBRTVector = new GPoint();
            manualRBRTVector.X = (manualRTPos.X - manualRBPos.X) / manualRLength;
            manualRBRTVector.Y = (manualRTPos.Y - manualRBPos.Y) / manualRLength;
            // 左上-右上
            GPoint manualLTRTVector = new GPoint();
            manualLTRTVector.X = (manualRTPos.X - manualLTPos.X) / manualTLength;
            manualLTRTVector.Y = (manualRTPos.Y - manualLTPos.Y) / manualTLength;
            // 左下-右下
            GPoint manualLBRBVector = new GPoint();
            manualLBRBVector.X = (manualRBPos.X - manualLBPos.X) / manualBLength;
            manualLBRBVector.Y = (manualRBPos.Y - manualLBPos.Y) / manualBLength;

            // 边界点坐标
            // 左上边界点
            GPoint borderLTPos = new GPoint();
            borderLTPos.X = manualLTPos.X + paddingTL * manualLBLTVector.X - paddingTL * manualLTRTVector.X;
            borderLTPos.Y = manualLTPos.Y + paddingTL * manualLBLTVector.Y - paddingTL * manualLTRTVector.Y;
            // 左下边界点
            GPoint borderLBPos = new GPoint();
            borderLBPos.X = manualLBPos.X - paddingBR * manualLBLTVector.X - paddingTL * manualLBRBVector.X;
            borderLBPos.Y = manualLBPos.Y - paddingBR * manualLBLTVector.Y - paddingTL * manualLBRBVector.Y;
            // 右上边界点
            GPoint borderRTPos = new GPoint();
            borderRTPos.X = manualRTPos.X + paddingTL * manualRBRTVector.X + paddingBR * manualLTRTVector.X;
            borderRTPos.Y = manualRTPos.Y + paddingTL * manualRBRTVector.Y + paddingBR * manualLTRTVector.Y;
            // 右下边界点
            GPoint borderRBPos = new GPoint();
            borderRBPos.X = manualRBPos.X - paddingBR * manualRBRTVector.X + paddingBR * manualLBRBVector.X;
            borderRBPos.Y = manualRBPos.Y - paddingBR * manualRBRTVector.Y + paddingBR * manualLBRBVector.Y;
            #endregion

            #region 计算边界点
            // 边界点向量模
            // 左边
            float borderLLength = (float)Math.Sqrt(Math.Pow((borderLTPos.X - borderLBPos.X), 2) + Math.Pow((borderLTPos.Y - borderLBPos.Y), 2));
            // 右边
            float borderRLength = (float)Math.Sqrt(Math.Pow((borderRTPos.X - borderRBPos.X), 2) + Math.Pow((borderRTPos.Y - borderRBPos.Y), 2));
            // 上边
            float borderTLength = (float)Math.Sqrt(Math.Pow((borderRTPos.X - borderLTPos.X), 2) + Math.Pow((borderRTPos.Y - borderLTPos.Y), 2));
            // 下边
            float borderBLength = (float)Math.Sqrt(Math.Pow((borderRBPos.X - borderLBPos.X), 2) + Math.Pow((borderRBPos.Y - borderLBPos.Y), 2));

            // 边界点单位向量
            // 左下-左上
            GPoint borderLBLTVector = new GPoint();
            borderLBLTVector.X = (borderLTPos.X - borderLBPos.X) / borderLLength;
            borderLBLTVector.Y = (borderLTPos.Y - borderLBPos.Y) / borderLLength;
            // 右下-右上
            GPoint borderRBRTVector = new GPoint();
            borderRBRTVector.X = (borderRTPos.X - borderRBPos.X) / borderRLength;
            borderRBRTVector.Y = (borderRTPos.Y - borderRBPos.Y) / borderRLength;
            // 左上-右上
            GPoint borderLTRTVector = new GPoint();
            borderLTRTVector.X = (borderRTPos.X - borderLTPos.X) / borderTLength;
            borderLTRTVector.Y = (borderRTPos.Y - borderLTPos.Y) / borderTLength;
            // 左下-右下
            GPoint borderLBRBVector = new GPoint();
            borderLBRBVector.X = (borderRBPos.X - borderLBPos.X) / borderBLength;
            borderLBRBVector.Y = (borderRBPos.Y - borderLBPos.Y) / borderBLength;

            // 左边界点集合
            Dictionary<int, GPoint> borderMapLPos = new Dictionary<int, GPoint>();
            for (int i = 0; i < row + 1; i++)
            {
                GPoint pos = new GPoint();
                pos.X = borderLBPos.X + borderLBLTVector.X * i * (borderLLength / row);
                pos.Y = borderLBPos.Y + borderLBLTVector.Y * i * (borderLLength / row);
                borderMapLPos.Add(i, pos);
            }
            // 右边界点集合
            Dictionary<int, GPoint> borderMapRPos = new Dictionary<int, GPoint>();
            for (int i = 0; i < row + 1; i++)
            {
                GPoint pos = new GPoint();
                pos.X = borderRBPos.X + borderRBRTVector.X * i * (borderRLength / row);
                pos.Y = borderRBPos.Y + borderRBRTVector.Y * i * (borderRLength / row);
                borderMapRPos.Add(i, pos);
            }
            // 上边界点集合
            Dictionary<int, GPoint> borderMapTPos = new Dictionary<int, GPoint>();
            for (int i = 0; i < column + 1; i++)
            {
                GPoint pos = new GPoint();
                pos.X = borderLTPos.X + borderLTRTVector.X * i * (borderTLength / column);
                pos.Y = borderLTPos.Y + borderLTRTVector.Y * i * (borderTLength / column);
                borderMapTPos.Add(i, pos);
            }
            // 下边界点集合
            Dictionary<int, GPoint> borderMapBPos = new Dictionary<int, GPoint>();
            for (int i = 0; i < column + 1; i++)
            {
                GPoint pos = new GPoint();
                pos.X = borderLBPos.X + borderLBRBVector.X * i * (borderBLength / column);
                pos.Y = borderLBPos.Y + borderLBRBVector.Y * i * (borderBLength / column);
                borderMapBPos.Add(i, pos);
            }
            #endregion

            #region 计算延长点
            // 左、右延长点集合
            Dictionary<int, GPoint> extendMapLPos = new Dictionary<int, GPoint>();
            Dictionary<int, GPoint> extendMapRPos = new Dictionary<int, GPoint>();
            for (int i = 0; i < row + 1; i++)
            {
                // 单位向量
                GPoint pos = new GPoint();
                pos.X = borderMapRPos[i].X - borderMapLPos[i].X;
                pos.Y = borderMapRPos[i].Y - borderMapLPos[i].Y;
                float length = (float)Math.Sqrt(pos.X * pos.X + pos.Y * pos.Y);
                // 左延长点
                GPoint leftPos = new GPoint();
                leftPos.X = borderMapLPos[i].X - extend * (pos.X / length);
                leftPos.Y = borderMapLPos[i].Y - extend * (pos.Y / length);
                extendMapLPos.Add(i, leftPos);
                // 右延长点
                GPoint rightPos = new GPoint();
                rightPos.X = borderMapRPos[i].X + extend * (pos.X / length);
                rightPos.Y = borderMapRPos[i].Y + extend * (pos.Y / length);
                extendMapRPos.Add(i, rightPos);
            }

            // 上、下延长点集合
            Dictionary<int, GPoint> extendMapTPos = new Dictionary<int, GPoint>();
            Dictionary<int, GPoint> extendMapBPos = new Dictionary<int, GPoint>();
            for (int i = 0; i < column + 1; i++)
            {
                // 单位向量
                GPoint pos = new GPoint();
                pos.X = borderMapTPos[i].X - borderMapBPos[i].X;
                pos.Y = borderMapTPos[i].Y - borderMapBPos[i].Y;
                float length = (float)Math.Sqrt(pos.X * pos.X + pos.Y * pos.Y);
                // 上延长点
                GPoint topPos = new GPoint();
                topPos.X = borderMapTPos[i].X + extend * (pos.X / length);
                topPos.Y = borderMapTPos[i].Y + extend * (pos.Y / length);
                extendMapTPos.Add(i, topPos);
                // 下延长点
                GPoint bottomPos = new GPoint();
                bottomPos.X = borderMapBPos[i].X - extend * (pos.X / length);
                bottomPos.Y = borderMapBPos[i].Y - extend * (pos.Y / length);
                extendMapBPos.Add(i, bottomPos);
            }
            #endregion

            #region gcode
            StringBuilder sb = new StringBuilder();
            // 关掉主轴和激光
            sb.Append("M5 S0" + Environment.NewLine);
            // 以毫米作为单位
            sb.Append("G21" + Environment.NewLine);
            // 设定运行速度
            sb.Append("G1 F" + speed + Environment.NewLine);
            // 回到0点
            sb.Append("G1 X0 Y0" + Environment.NewLine);

            // 行切
            for (int i = 0; i < row + 1; i++)
            {
                if (i % 2 == 0)
                {
                    sb.Append("G1 X" + extendMapLPos[i].X + " Y" + extendMapLPos[i].Y + Environment.NewLine);
                    sb.Append("G4 P0" + Environment.NewLine);
                    sb.Append("M3 S" + power + Environment.NewLine);
                    sb.Append("G4 P0" + Environment.NewLine);
                    sb.Append("G1 X" + extendMapRPos[i].X + " Y" + extendMapRPos[i].Y + Environment.NewLine);
                    sb.Append("M5 S0" + Environment.NewLine);
                }
                else
                {
                    sb.Append("G1 X" + extendMapRPos[i].X + " Y" + extendMapRPos[i].Y + Environment.NewLine);
                    sb.Append("G4 P0" + Environment.NewLine);
                    sb.Append("M3 S" + power + Environment.NewLine);
                    sb.Append("G4 P0" + Environment.NewLine);
                    sb.Append("G1 X" + extendMapLPos[i].X + " Y" + extendMapLPos[i].Y + Environment.NewLine);
                    sb.Append("M5 S0" + Environment.NewLine);
                }
            }

            // 列切
            for (int i = 0; i < column + 1; i++)
            {
                if (i % 2 == 0)
                {
                    sb.Append("G1 X" + extendMapTPos[i].X + " Y" + extendMapTPos[i].Y + Environment.NewLine);
                    sb.Append("G4 P0" + Environment.NewLine);
                    sb.Append("M3 S" + power + Environment.NewLine);
                    sb.Append("G4 P0" + Environment.NewLine);
                    sb.Append("G1 X" + extendMapBPos[i].X + " Y" + extendMapBPos[i].Y + Environment.NewLine);
                    sb.Append("M5 S0" + Environment.NewLine);
                }
                else
                {
                    sb.Append("G1 X" + extendMapBPos[i].X + " Y" + extendMapBPos[i].Y + Environment.NewLine);
                    sb.Append("G4 P0" + Environment.NewLine);
                    sb.Append("M3 S" + power + Environment.NewLine);
                    sb.Append("G4 P0" + Environment.NewLine);
                    sb.Append("G1 X" + extendMapTPos[i].X + " Y" + extendMapTPos[i].Y + Environment.NewLine);
                    sb.Append("M5 S0" + Environment.NewLine);
                }
            }

            sb.Append("G1 X0 Y0");

            return sb;
            #endregion
        }
        #endregion

        private void exportCustomButtonsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CustomButtons.Export();
		}

		private void importCustomButtonsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (CustomButtons.Import())
			{
				RefreshCustomButtons();
				CustomButtons.SaveFile();
			}
		}

		private void MNAddCB_Opening(object sender, CancelEventArgs e)
		{
			exportCustomButtonsToolStripMenuItem.Enabled = CustomButtons.Count > 0;
		}
    }

}
