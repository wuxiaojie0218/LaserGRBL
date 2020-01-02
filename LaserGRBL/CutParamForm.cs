using System;
using System.Configuration;
using System.Windows.Forms;

namespace LaserGRBL
{
    /// <summary>
    /// 裁膜界面
    /// Author:wuxiaojie
    /// 2020/01/02
    /// </summary>
    public partial class CutParamForm : Form
    {
        public CutParamForm()
        {
            InitializeComponent();
            cbSpeed.SelectedItem = ConfigurationManager.AppSettings.Get("speed");
            cbPower.SelectedItem = ConfigurationManager.AppSettings.Get("power");
            cbRow.SelectedItem = ConfigurationManager.AppSettings.Get("row");
            cbColumn.SelectedItem = ConfigurationManager.AppSettings.Get("column");
            cbSize.SelectedItem = ConfigurationManager.AppSettings.Get("size");
            cbPtp.SelectedItem = ConfigurationManager.AppSettings.Get("ptp");
            cbExtend.SelectedItem = ConfigurationManager.AppSettings.Get("extend");
        }

        /// <summary>
        /// 运行速度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfigurationManager.AppSettings.Set("speed", cbSpeed.SelectedItem.ToString());
        }

        /// <summary>
        /// 激光功率
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbPower_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfigurationManager.AppSettings.Set("power", cbPower.SelectedItem.ToString());
        }

        /// <summary>
        /// 行数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbRow_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfigurationManager.AppSettings.Set("row", cbRow.SelectedItem.ToString());
        }

        /// <summary>
        /// 列数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfigurationManager.AppSettings.Set("column", cbColumn.SelectedItem.ToString());
        }

        /// <summary>
        /// 膜大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfigurationManager.AppSettings.Set("size", cbSize.SelectedItem.ToString());
        }

        /// <summary>
        /// 点间距
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbPtp_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfigurationManager.AppSettings.Set("ptp", cbPtp.SelectedItem.ToString());
        }

        /// <summary>
        /// 延长线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbExtend_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfigurationManager.AppSettings.Set("extend", cbExtend.SelectedItem.ToString());
        }
    }
}
