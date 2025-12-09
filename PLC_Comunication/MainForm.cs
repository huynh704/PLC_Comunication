using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLC_Comunication
{
    public partial class MainForm : Form
    {
        CLogin dlgLogin = new CLogin();
        CPlcAct dlgPlcAct = new CPlcAct();
        CPlcData dlgPlcData = new CPlcData();

        private Thread plcThread;
        private Thread uiThread;
        private int ioTact = 0;
        private CPlc.PLCInformation plcInfo;
        private bool ThreadPause = false;
        public MainForm()
        {
            InitializeComponent();
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (CPlc.IsOpen) CPlc.Close();
            else
            {
                CPlc.SetConfig((int)numLogicStationNum.Value);
                CPlc.Open();
                if (!CPlc.IsOpen)
                {
                    MessageBox.Show("Kết nối PLC thất bại!\n\r0x" + CPlc.ReturnCode.ToString("X8"), "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (CPlc.IsOpen)
            {
                plcThread = new Thread(main);
                plcThread.IsBackground = true;
                plcThread.Start();
            }
            else if (plcThread != null && plcThread.IsAlive)
            {
                plcThread.Abort();
            }
        }
        private void MainForm_Shown(object sender, EventArgs e)
        {
            uiThread = new Thread(ui);
            uiThread.IsBackground = true;
            uiThread.Start();
        }
        private void ui()
        {
            while (true)
            {
                Thread.Sleep(100);
                //if (ThreadPause) continue;
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        this.Text = "PLC communication" + (dlgLogin.LoginUserName == string.Empty ? "" : " - " + dlgLogin.LoginUserName);

                        btnConnect.Text = CPlc.IsOpen ? "Ngắt kết nối" : "Kết nối";
                        btnConnect.BackColor = CPlc.IsOpen ? Color.Green : Color.Transparent;
                        btnConnect.ForeColor = CPlc.IsOpen ? Color.White : Color.Black;
                        numLogicStationNum.Enabled = !CPlc.IsOpen;
                        txtPassword.Enabled = !CPlc.IsOpen;

                        lbCpuType.Text = plcInfo.CpuType;
                        lbPlcTime.Text = plcInfo.PlcTime != DateTime.MinValue ? plcInfo.PlcTime.ToString("yyyy/MM/dd HH:mm:ss") : "N/A";
                        lbIOTact.Text = ioTact.ToString() + " ms";
                    }));
                }
            }
        }
        private void main()
        {
            while (true)
            {
                while (CPlc.IsOpen)
                {
                    Thread.Sleep(1);
                    //if (ThreadPause) continue;
                    int startTime = Environment.TickCount;

                    plcInfo = CPlc.GetPlcInformation();

                    ioTact = Environment.TickCount - startTime;
                }
                CPlc.Close();
                Thread.Sleep(100);
                CPlc.Open();
            }
        }
        private void lstLogAdd(string log)
        {
            string message = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " - " + log;
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    lstAppLog.Items.Add(message);
                    lstAppLog.SelectedIndex = lstAppLog.Items.Count - 1;
                    lstAppLog.SelectedIndex = -1;
                }));
            }
            else
            {
                lstAppLog.Items.Add(message);
                lstAppLog.SelectedIndex = lstAppLog.Items.Count - 1;
                lstAppLog.SelectedIndex = -1;
            }
            CFileIO.WriteLog(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\PLC_Comunication.log", log);
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (uiThread != null && uiThread.IsAlive)
            {
                uiThread.Abort();
            }
            if (plcThread != null && plcThread.IsAlive)
            {
                plcThread.Abort();
            }
            CPlc.Close();
        }
        private void btnFuntion_Click(object sender, EventArgs e)
        {
            Button btnClick = (Button)sender;
            ThreadPause = true;
            if (!CPlc.IsOpen)
            {
                MessageBox.Show("Thực hiện kết nối trước khi sử dụng chức năng này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult loginResult = DialogResult.None;
            loginResult = dlgLogin.ShowDialog();
            if (loginResult == DialogResult.OK)
            {
                lstLogAdd("Tài khoản '" + dlgLogin.LoginUserName + "' đã đăng nhập");
            }
            else return;
            switch (btnClick.Name)
            {
                case "btnPlcFuntion":
                    dlgPlcAct.ShowDialog();
                    break;
                case "btnData":
                    dlgPlcData.ShowDialog();
                    break;
            }
            ThreadPause = false;
        }
    }
}
