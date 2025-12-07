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
        private List<PlcParam> plcParamList = new List<PlcParam>();
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
        private void loadDataFromFile(string filePath)
        {
            try
            {
                string[] rawFile = File.ReadAllLines(filePath);
                string[] decFile = CAesCrypt.FileDecryptString(rawFile);
                plcParamList.Clear();
                foreach (string dec in decFile)
                {
                    if (PlcParam.TryParse(dec, out PlcParam templValue, out string error))
                    {
                        plcParamList.Add(templValue);
                    }
                    else
                    {
                        CFileIO.WriteLog(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\PLC_Data.log", dec + ". " + error + ". Bỏ qua");
                        continue;
                    }
                }
                lstParamList.Items.Clear();
                lstParamList.Items.AddRange(plcParamList.Select(p => p.GetString).ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error import file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                        loadDataFromFile(dlg.FileName);
                    }
                    break;
                case "btnWritePLC":
                    if(MessageBox.Show("Xác nhận ghi các tham số vào PLC?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                    foreach (PlcParam param in plcParamList)
                    {
                        string strParam = string.Format("Ghi tham số '{0}' vào địa chỉ '{1}' với giá trị '{2}'", param.ParamName, param.PlcAddress, param.Value);
                        if (!param.WriteToPlc(out string error))
                        {
                            CFileIO.WriteLog(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\PLC_Data.log", strParam + " thất bại: " + error);
                        }
                        else
                        {
                           CFileIO.WriteLog(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\PLC_Data.log", strParam + " thành công");
                        }
                    }
                    break;
                case "btnReadPLC":
                    if(MessageBox.Show("Xác nhận đọc các tham số từ PLC?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                    foreach (PlcParam param in plcParamList)
                    {
                        string strParam = string.Format("Đọc tham số '{0}' từ địa chỉ '{1}'", param.ParamName, param.PlcAddress);
                        if (!param.ReadFromPlc(out string error))
                        {
                            CFileIO.WriteLog(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\PLC_Data.log", strParam + " thất bại: " + error);
                        }
                        else
                        {
                            CFileIO.WriteLog(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\PLC_Data.log", strParam + " thành công. Giá trị: " + param.Value);
                        }
                    }
                    lstParamList.Items.Clear();
                    lstParamList.Items.AddRange(plcParamList.Select(p => p.GetString).ToArray());
                    break;
                case "btnExport":
                    FileDialog dlgSave = new SaveFileDialog();
                    dlgSave.Filter = "DAT File (*.dat)|*.dat|All Files (*.*)|*.*";
                    if (dlgSave.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            string[] encFile = CAesCrypt.FileEncryptString(lstParamList.Items.Cast<string>().ToArray());
                            File.WriteAllLines(dlgSave.FileName, encFile);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Xảy ra lỗi khi xuất tập tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    break;
                case "btnComparePLC":

                    break;
            }
        }
        private void lstParamList_DoubleClick(object sender, EventArgs e)
        {
            CEditParam editParamDlg = new CEditParam();
            if (lstParamList.SelectedIndex < 0 || lstParamList.SelectedIndex >= plcParamList.Count) editParamDlg.ParamValue = new PlcParam();
            else editParamDlg.ParamValue = plcParamList[lstParamList.SelectedIndex];

            if (editParamDlg.ShowDialog() == DialogResult.OK)
            {
                if (plcParamList.Count <= 0 || lstParamList.SelectedIndex < 0)
                {
                    plcParamList.Add(editParamDlg.ParamValue);
                }
                else
                {
                    plcParamList[lstParamList.SelectedIndex] = editParamDlg.ParamValue;
                }
                lstParamList.Items.Clear();
                lstParamList.Items.AddRange(plcParamList.Select(p => p.GetString).ToArray());
            }
            lstParamList.ClearSelected();
        }
        private void lstParamList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
            {
                if (lstParamList.SelectedIndex < 0) return;
                plcParamList.RemoveAt(lstParamList.SelectedIndex);
                lstParamList.Items.Clear();
                lstParamList.Items.AddRange(plcParamList.Select(p => p.GetString).ToArray());
                lstParamList.ClearSelected();
            }
            else if(e.KeyChar == (char)Keys.Escape)
            {
                lstParamList.ClearSelected();
            }
        }
        private void txtImportPath_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                loadDataFromFile(txtImportPath.Text);
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
        public PlcParam(string paramName, string plcAddress, eDataType dataType, string value = "K0")
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
        public string GetString
        {
            get { return string.Format("{0},{1},{2},{3}", ParamName, PlcAddress, DataType.ToString(), Value); }
        }
        public static bool TryParse(string paraData, out PlcParam plcParam, out string errorMessage)
        {
            plcParam = null;
            errorMessage = null;
            try
            {
                string[] arrData = paraData.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (arrData.Length < 4)
                {
                    errorMessage = "Định dạng không chính xác Length = " + arrData.Length;
                    return false;
                }
                string paramName = arrData[0].Trim();
                string plcAddress = arrData[1].Trim();
                if (!CPlc.IsValidDevice(plcAddress))
                {
                    errorMessage = "Địa chỉ PLC không hợp lệ: " + plcAddress;
                    return false;
                }
                PlcParam.eDataType dataType = (PlcParam.eDataType)Enum.Parse(typeof(PlcParam.eDataType), arrData[2].Trim().ToUpper());
                string value = arrData[3].Trim();
                if (dataType != eDataType.STRING)
                {
                    if (CPlc.GetValue32(value, out int tempValue) != 0)
                    {
                        errorMessage = "Giá trị không hợp lệ: " + value;
                        return false;
                    }
                }
                plcParam = new PlcParam(paramName, plcAddress, dataType, value);
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }
        public bool WriteToPlc(out string errorMessage)
        {
            errorMessage = null;
            int iResultCode = -1;
            try
            {
                switch (DataType)
                {
                    case eDataType.BOOL:
                    case eDataType.INT:
                        iResultCode = CPlc.SetValue16(Value, PlcAddress);
                        break;
                    case eDataType.DINT:
                        iResultCode = CPlc.SetValue32(Value, PlcAddress);
                        break;
                    case eDataType.STRING:
                        iResultCode = CPlc.sMOV(Value, PlcAddress);
                        break;
                }
                errorMessage = CPlc.LastErrorMessage;
                return CPlc.LastErrorType != CPlc.ErrorType.Error;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }
        public bool ReadFromPlc(out string errorMessage)
        {
            errorMessage = null;
            int iResultCode = -1;
            char cValueCode = Value[0];
            try
            {
                switch (DataType)
                {
                    case eDataType.BOOL:
                    case eDataType.INT:
                        iResultCode = CPlc.GetValue16(PlcAddress, out short tempValue16);
                        if (iResultCode == 0) Value = cValueCode + tempValue16.ToString((cValueCode == 'H' ? "X" : ""));
                        break;
                    case eDataType.DINT:
                        iResultCode = CPlc.GetValue32(PlcAddress, out int tempValue32);
                        if (iResultCode == 0) Value = cValueCode + tempValue32.ToString((cValueCode == 'H' ? "X" : ""));
                        break;
                    case eDataType.STRING:
                        int iSize = Value.Length / 2;
                        iSize += Value.Length % 2;
                        iResultCode = CPlc.GetString(PlcAddress, "K" + iSize, out string tempString);
                        if(iResultCode == 0) Value = tempString;
                        break;
                }
                errorMessage = CPlc.LastErrorMessage;
                return CPlc.LastErrorType != CPlc.ErrorType.Error;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }
    }
}
