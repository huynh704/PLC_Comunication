using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLC_Comunication
{
    public partial class CPlcData : Form
    {
        public CPlcData()
        {
            InitializeComponent();
        }
        private void lstLogAdd(string message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    lstParamList.Items.Add(DateTime.Now.ToString("HH:mm:ss") + " - " + message);
                    lstParamList.SelectedIndex = lstParamList.Items.Count - 1;
                    lstParamList.ClearSelected();
                }));
            }
            else
            {
                lstParamList.Items.Add(DateTime.Now.ToString("HH:mm:ss") + " - " + message);
                lstParamList.SelectedIndex = lstParamList.Items.Count - 1;
                lstParamList.ClearSelected();
            }
            CFileIO.WriteLog(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\PLC_Data.log", message);
        }
    }
}
