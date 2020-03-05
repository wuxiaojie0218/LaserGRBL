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
            cbXPower.SelectedItem = ConfigurationManager.AppSettings.Get("xpower");
            cbYPower.SelectedItem = ConfigurationManager.AppSettings.Get("ypower");
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
            AddUpdateAppSettings("speed", cbSpeed.SelectedItem.ToString());
        }

        /// <summary>
        /// X轴激光功率
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbXPower_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddUpdateAppSettings("xpower", cbXPower.SelectedItem.ToString());
        }

        /// <summary>
        /// Y轴激光功率
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbYPower_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddUpdateAppSettings("ypower", cbYPower.SelectedItem.ToString());
        }

        /// <summary>
        /// 行数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbRow_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddUpdateAppSettings("row", cbRow.SelectedItem.ToString());
        }

        /// <summary>
        /// 列数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddUpdateAppSettings("column", cbColumn.SelectedItem.ToString());
        }

        /// <summary>
        /// 膜大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddUpdateAppSettings("size", cbSize.SelectedItem.ToString());
        }

        /// <summary>
        /// 点间距
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbPtp_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddUpdateAppSettings("ptp", cbPtp.SelectedItem.ToString());
        }

        /// <summary>
        /// 延长线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbExtend_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddUpdateAppSettings("extend", cbExtend.SelectedItem.ToString());
        }

        /// <summary>
        /// 新增或更新配置文件键值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private static void AddUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                MessageBox.Show("修改配置文件出错！");
            }
        }
    }
}
