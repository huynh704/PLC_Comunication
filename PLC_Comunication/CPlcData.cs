using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Activation;
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

        private void btn_Click(object sender, EventArgs e)
        {
            Button btnClick = (Button)sender;
            switch (btnClick.Name)
            {
                case "btnBrowse":
                    FileDialog dlg = new OpenFileDialog();
                    dlg.Filter = "DAT File (*.dat)|*.dat|All Files (*.*)|*.*";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        txtImportPath.Text = dlg.FileName;
                        string[] rawFile = File.ReadAllLines(dlg.FileName);
                        string[] decFile = CAesCrypt.FileDecryptString(rawFile);
                    }
                    break;
                case "btnWritePLC":

                    break;
                case "btnReadPLC":

                    break;
                case "btnExport":

                    break;
                case "btnComparePLC":

                    break;
            }
        }
    }
    public class PlcParam
    {
        public enum eDataType
        {
            STRING,
            INT,
            DINT,
            BOOL
        }
        public PlcParam()
        {
            ParamName = string.Empty;
            PlcAddress = string.Empty;
            DataType = eDataType.INT;
            Value = string.Empty;
        }
        public PlcParam(string paramName, string plcAddress, eDataType dataType, string value = "0")
        {
            ParamName = paramName;
            PlcAddress = plcAddress;
            DataType = dataType;
            Value = value;
        }
        public string ParamName { get; set; }
        public string PlcAddress { get; set; }
        public eDataType DataType { get; set; }
        public string Value { get; set; }
        public bool IsValid
        {
            get
            {
                if (string.IsNullOrEmpty(ParamName) || string.IsNullOrEmpty(Value) || !CPlc.IsValidDevice(PlcAddress)) return false;
                return true;
            }
        }
    }
}
