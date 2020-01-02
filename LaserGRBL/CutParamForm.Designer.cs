namespace LaserGRBL
{
    partial class CutParamForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CutParamForm));
            this.lSpeed = new System.Windows.Forms.Label();
            this.lPower = new System.Windows.Forms.Label();
            this.lRow = new System.Windows.Forms.Label();
            this.lColumn = new System.Windows.Forms.Label();
            this.lSize = new System.Windows.Forms.Label();
            this.lPtp = new System.Windows.Forms.Label();
            this.lExtend = new System.Windows.Forms.Label();
            this.tlpCutParam = new System.Windows.Forms.TableLayoutPanel();
            this.cbSpeed = new System.Windows.Forms.ComboBox();
            this.cbPower = new System.Windows.Forms.ComboBox();
            this.cbRow = new System.Windows.Forms.ComboBox();
            this.cbColumn = new System.Windows.Forms.ComboBox();
            this.cbSize = new System.Windows.Forms.ComboBox();
            this.cbPtp = new System.Windows.Forms.ComboBox();
            this.cbExtend = new System.Windows.Forms.ComboBox();
            this.tlpCutParam.SuspendLayout();
            this.SuspendLayout();
            // 
            // lSpeed
            // 
            this.lSpeed.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lSpeed.AutoSize = true;
            this.lSpeed.Location = new System.Drawing.Point(43, 19);
            this.lSpeed.Name = "lSpeed";
            this.lSpeed.Size = new System.Drawing.Size(144, 13);
            this.lSpeed.TabIndex = 0;
            this.lSpeed.Text = "运行速度（毫米/分钟）：";
            // 
            // lPower
            // 
            this.lPower.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lPower.AutoSize = true;
            this.lPower.Location = new System.Drawing.Point(43, 70);
            this.lPower.Name = "lPower";
            this.lPower.Size = new System.Drawing.Size(103, 13);
            this.lPower.TabIndex = 1;
            this.lPower.Text = "激光功率（瓦）：";
            // 
            // lRow
            // 
            this.lRow.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lRow.AutoSize = true;
            this.lRow.Location = new System.Drawing.Point(43, 121);
            this.lRow.Name = "lRow";
            this.lRow.Size = new System.Drawing.Size(43, 13);
            this.lRow.TabIndex = 2;
            this.lRow.Text = "行数：";
            // 
            // lColumn
            // 
            this.lColumn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lColumn.AutoSize = true;
            this.lColumn.Location = new System.Drawing.Point(43, 172);
            this.lColumn.Name = "lColumn";
            this.lColumn.Size = new System.Drawing.Size(43, 13);
            this.lColumn.TabIndex = 3;
            this.lColumn.Text = "列数：";
            // 
            // lSize
            // 
            this.lSize.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lSize.AutoSize = true;
            this.lSize.Location = new System.Drawing.Point(43, 223);
            this.lSize.Name = "lSize";
            this.lSize.Size = new System.Drawing.Size(103, 13);
            this.lSize.TabIndex = 4;
            this.lSize.Text = "膜大小（毫米）：";
            // 
            // lPtp
            // 
            this.lPtp.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lPtp.AutoSize = true;
            this.lPtp.Location = new System.Drawing.Point(43, 274);
            this.lPtp.Name = "lPtp";
            this.lPtp.Size = new System.Drawing.Size(103, 13);
            this.lPtp.TabIndex = 5;
            this.lPtp.Text = "点间距（毫米）：";
            // 
            // lExtend
            // 
            this.lExtend.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lExtend.AutoSize = true;
            this.lExtend.Location = new System.Drawing.Point(43, 327);
            this.lExtend.Name = "lExtend";
            this.lExtend.Size = new System.Drawing.Size(103, 13);
            this.lExtend.TabIndex = 6;
            this.lExtend.Text = "延长线（毫米）：";
            // 
            // tlpCutParam
            // 
            this.tlpCutParam.ColumnCount = 4;
            this.tlpCutParam.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpCutParam.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCutParam.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCutParam.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpCutParam.Controls.Add(this.lSpeed, 1, 0);
            this.tlpCutParam.Controls.Add(this.lPower, 1, 1);
            this.tlpCutParam.Controls.Add(this.lRow, 1, 2);
            this.tlpCutParam.Controls.Add(this.lColumn, 1, 3);
            this.tlpCutParam.Controls.Add(this.lSize, 1, 4);
            this.tlpCutParam.Controls.Add(this.lPtp, 1, 5);
            this.tlpCutParam.Controls.Add(this.lExtend, 1, 6);
            this.tlpCutParam.Controls.Add(this.cbSpeed, 2, 0);
            this.tlpCutParam.Controls.Add(this.cbPower, 2, 1);
            this.tlpCutParam.Controls.Add(this.cbRow, 2, 2);
            this.tlpCutParam.Controls.Add(this.cbColumn, 2, 3);
            this.tlpCutParam.Controls.Add(this.cbSize, 2, 4);
            this.tlpCutParam.Controls.Add(this.cbPtp, 2, 5);
            this.tlpCutParam.Controls.Add(this.cbExtend, 2, 6);
            this.tlpCutParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCutParam.Location = new System.Drawing.Point(0, 0);
            this.tlpCutParam.Name = "tlpCutParam";
            this.tlpCutParam.RowCount = 7;
            this.tlpCutParam.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpCutParam.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tlpCutParam.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tlpCutParam.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tlpCutParam.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tlpCutParam.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tlpCutParam.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tlpCutParam.Size = new System.Drawing.Size(384, 361);
            this.tlpCutParam.TabIndex = 14;
            // 
            // cbSpeed
            // 
            this.cbSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSpeed.FormattingEnabled = true;
            this.cbSpeed.Items.AddRange(new object[] {
            "2200",
            "2100",
            "2000",
            "1900",
            "1800",
            "1700",
            "1600",
            "1500"});
            this.cbSpeed.Location = new System.Drawing.Point(195, 15);
            this.cbSpeed.Name = "cbSpeed";
            this.cbSpeed.Size = new System.Drawing.Size(146, 21);
            this.cbSpeed.TabIndex = 14;
            this.cbSpeed.SelectedIndexChanged += new System.EventHandler(this.cbSpeed_SelectedIndexChanged);
            // 
            // cbPower
            // 
            this.cbPower.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPower.FormattingEnabled = true;
            this.cbPower.Items.AddRange(new object[] {
            "7900",
            "7800",
            "7700",
            "7600",
            "7500",
            "7400",
            "7300",
            "7200",
            "7100",
            "7000",
            "6900",
            "6800",
            "6700",
            "6600",
            "6500",
            "6400",
            "6300",
            "6200",
            "6100",
            "6000",
            "5900",
            "5800",
            "5700",
            "5600",
            "5500",
            "5400",
            "5300",
            "5200",
            "5100",
            "5000",
            "4900",
            "4800",
            "4700",
            "4600",
            "4500",
            "4400",
            "4300",
            "4200",
            "4100",
            "4000",
            "3900"});
            this.cbPower.Location = new System.Drawing.Point(195, 66);
            this.cbPower.Name = "cbPower";
            this.cbPower.Size = new System.Drawing.Size(146, 21);
            this.cbPower.TabIndex = 15;
            this.cbPower.SelectedIndexChanged += new System.EventHandler(this.cbPower_SelectedIndexChanged);
            // 
            // cbRow
            // 
            this.cbRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbRow.FormattingEnabled = true;
            this.cbRow.Items.AddRange(new object[] {
            "30",
            "29",
            "28",
            "27",
            "26",
            "25",
            "24",
            "23",
            "22",
            "21",
            "20",
            "19",
            "18",
            "17",
            "16",
            "15",
            "14",
            "13",
            "12",
            "11",
            "10",
            "9",
            "8",
            "7",
            "6",
            "5",
            "4",
            "3",
            "2"});
            this.cbRow.Location = new System.Drawing.Point(195, 117);
            this.cbRow.Name = "cbRow";
            this.cbRow.Size = new System.Drawing.Size(146, 21);
            this.cbRow.TabIndex = 16;
            this.cbRow.SelectedIndexChanged += new System.EventHandler(this.cbRow_SelectedIndexChanged);
            // 
            // cbColumn
            // 
            this.cbColumn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbColumn.FormattingEnabled = true;
            this.cbColumn.Items.AddRange(new object[] {
            "20",
            "19",
            "18",
            "17",
            "16",
            "15",
            "14",
            "13",
            "12",
            "11",
            "10",
            "9",
            "8",
            "7",
            "6",
            "5",
            "4",
            "3",
            "2"});
            this.cbColumn.Location = new System.Drawing.Point(195, 168);
            this.cbColumn.Name = "cbColumn";
            this.cbColumn.Size = new System.Drawing.Size(146, 21);
            this.cbColumn.TabIndex = 17;
            this.cbColumn.SelectedIndexChanged += new System.EventHandler(this.cbColumn_SelectedIndexChanged);
            // 
            // cbSize
            // 
            this.cbSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSize.FormattingEnabled = true;
            this.cbSize.Items.AddRange(new object[] {
            "10",
            "9.95",
            "9.9",
            "9.85",
            "9.8",
            "9.75",
            "9.7",
            "9.65",
            "9.6",
            "9.55",
            "9.5",
            "9.45",
            "9.4",
            "9.35",
            "9.3",
            "9.25",
            "9.2",
            "9.15",
            "9.1",
            "9.05",
            "9"});
            this.cbSize.Location = new System.Drawing.Point(195, 219);
            this.cbSize.Name = "cbSize";
            this.cbSize.Size = new System.Drawing.Size(146, 21);
            this.cbSize.TabIndex = 18;
            this.cbSize.SelectedIndexChanged += new System.EventHandler(this.cbSize_SelectedIndexChanged);
            // 
            // cbPtp
            // 
            this.cbPtp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPtp.FormattingEnabled = true;
            this.cbPtp.Items.AddRange(new object[] {
            "1.75",
            "1.7",
            "1.65",
            "1.6",
            "1.55",
            "1.5",
            "1.45",
            "1.4",
            "1.35",
            "1.3",
            "1.25",
            "1.2",
            "1.15",
            "1.1",
            "1.05",
            "1",
            "0.95",
            "0.9",
            "0.85",
            "0.8",
            "0.75"});
            this.cbPtp.Location = new System.Drawing.Point(195, 270);
            this.cbPtp.Name = "cbPtp";
            this.cbPtp.Size = new System.Drawing.Size(146, 21);
            this.cbPtp.TabIndex = 19;
            this.cbPtp.SelectedIndexChanged += new System.EventHandler(this.cbPtp_SelectedIndexChanged);
            // 
            // cbExtend
            // 
            this.cbExtend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbExtend.FormattingEnabled = true;
            this.cbExtend.Items.AddRange(new object[] {
            "10",
            "9.5",
            "9",
            "8.5",
            "8",
            "7.5",
            "7",
            "6.5",
            "6",
            "5.5",
            "5",
            "4.5",
            "4",
            "3.5",
            "3",
            "2.5",
            "2",
            "1.5",
            "1",
            "0.5",
            "0"});
            this.cbExtend.Location = new System.Drawing.Point(195, 323);
            this.cbExtend.Name = "cbExtend";
            this.cbExtend.Size = new System.Drawing.Size(146, 21);
            this.cbExtend.TabIndex = 20;
            this.cbExtend.SelectedIndexChanged += new System.EventHandler(this.cbExtend_SelectedIndexChanged);
            // 
            // CutParamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.tlpCutParam);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CutParamForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "裁膜参数";
            this.tlpCutParam.ResumeLayout(false);
            this.tlpCutParam.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lSpeed;
        private System.Windows.Forms.Label lPower;
        private System.Windows.Forms.Label lRow;
        private System.Windows.Forms.Label lColumn;
        private System.Windows.Forms.Label lSize;
        private System.Windows.Forms.Label lPtp;
        private System.Windows.Forms.Label lExtend;
        private System.Windows.Forms.TableLayoutPanel tlpCutParam;
        private System.Windows.Forms.ComboBox cbSpeed;
        private System.Windows.Forms.ComboBox cbPower;
        private System.Windows.Forms.ComboBox cbRow;
        private System.Windows.Forms.ComboBox cbColumn;
        private System.Windows.Forms.ComboBox cbSize;
        private System.Windows.Forms.ComboBox cbPtp;
        private System.Windows.Forms.ComboBox cbExtend;
    }
}