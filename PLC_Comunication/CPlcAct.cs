using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLC_Comunication
{
    public partial class CPlcAct : Form
    {
        public CPlcAct()
        {
            InitializeComponent();
        }
        private void CPlcAct_Shown(object sender, EventArgs e)
        {
            if (cbxAction.SelectedIndex < 0) cbxAction.SelectedIndex = 0;
        }
        private void cbxAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            byte[] txtVisible = new byte[] { 0x02, 0x02, 0x02, 0x03, 0x03, 0x06, 0x06, 0x07, 0x07, 0x06, 0x03, 0x03, 0x02, 0x02, 0x07, 0x07, 0x07, 0x07, 0x06 };
            if (cbxAction.SelectedIndex < 0) return;
            lbS1.Visible = txtSource.Visible = ((txtVisible[cbxAction.SelectedIndex] >> 2) & 0x01) != 0;
            lbS2.Visible = txtDestination.Visible = ((txtVisible[cbxAction.SelectedIndex] >> 1) & 0x01) != 0;
            lbS3.Visible = txtNumber.Visible = (txtVisible[cbxAction.SelectedIndex] & 0x01) != 0;

            lbS1.Text = "Nguồn";
            lbS2.Text = "Điểm đến";
            lbS3.Text = "Số lượng";

            if (cbxAction.SelectedIndex >= 14 && cbxAction.SelectedIndex <= 17)
            {
                lbS1.Text = "Số thứ 1";
                lbS2.Text = "Số thứ 2";
                lbS3.Text = "Kết quả";
            }
        }
        private void btnExcute_Click(object sender, EventArgs e)
        {
            int iResult = -1;
            if(cbxAction.SelectedIndex != 18)
            {
                txtSource.Text = txtSource.Text.Trim().ToUpper();
                txtDestination.Text = txtDestination.Text.Trim().ToUpper();
                txtNumber.Text = txtNumber.Text.Trim().ToUpper();
            }
            switch (cbxAction.SelectedIndex)
            {
                case 0: //SET
                    iResult = CPlc.SET(txtDestination.Text);
                    break;
                case 1: //RST
                    iResult = CPlc.RST(txtDestination.Text);
                    break;
                case 2: //FF
                    iResult = CPlc.FF(txtDestination.Text);
                    break;
                case 3: //BSET
                    iResult = CPlc.BSET(txtDestination.Text, txtNumber.Text);
                    break;
                case 4: //BRST
                    iResult = CPlc.BRST(txtDestination.Text, txtNumber.Text);
                    break;
                case 5: //MOV
                    iResult = CPlc.MOV(txtSource.Text, txtDestination.Text);
                    break;
                case 6:
                    iResult = CPlc.DMOV(txtSource.Text, txtDestination.Text);
                    break;
                case 7: //BMOV
                    iResult = CPlc.BMOV(txtSource.Text, txtDestination.Text, txtNumber.Text);
                    break;
                case 8: //FMOV
                    iResult = CPlc.FMOV(txtSource.Text, txtDestination.Text, txtNumber.Text);
                    break;
                case 9: //DBL
                    iResult = CPlc.DBL(txtSource.Text, txtDestination.Text);
                    break;
                case 10: //SFL
                    iResult = CPlc.SFL(txtDestination.Text, txtNumber.Text);
                    break;
                case 11: //SFR
                    iResult = CPlc.SFR(txtDestination.Text, txtNumber.Text);
                    break;
                case 12: //INC
                    iResult = CPlc.INC(txtDestination.Text);
                    break;
                case 13: //DEC
                    iResult = CPlc.DEC(txtDestination.Text);
                    break;
                case 14: //ADD
                    iResult = CPlc.ADD(txtSource.Text, txtDestination.Text, txtNumber.Text);
                    break;
                case 15: //SUB
                    iResult = CPlc.SUB(txtSource.Text, txtDestination.Text, txtNumber.Text);
                    break;
                case 16: //MUL
                    iResult = CPlc.MUL(txtSource.Text, txtDestination.Text, txtNumber.Text);
                    break;
                case 17: //DIV
                    iResult = CPlc.DIV(txtSource.Text, txtDestination.Text, txtNumber.Text);
                    break;
                case 18: //sMOV
                    iResult = CPlc.sMOV(txtSource.Text, txtDestination.Text);
                    break;
            }
            string messge = "Thực hiện lệnh " + cbxAction.Text;
            //messge += "_" + txtSource.Text + "_" + txtDestination.Text + "_" + txtNumber.Text;
            if(txtSource.Visible) messge += "_" + txtSource.Text;
            if(txtDestination.Visible) messge += "_" + txtDestination.Text;
            if(txtNumber.Visible) messge += "_" + txtNumber.Text;
            if (iResult != 0)
            {
                messge += " không thành công! Mã lỗi: 0x" + iResult.ToString("X8");
                //MessageBox.Show(messge, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                messge += " thành công!";
                //MessageBox.Show(messge, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            lstLogAdd(messge);
        }
        private void lstLogAdd(string message)
        {
            string lstItem = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " - " + message;
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    lstActLog.Items.Add(lstItem);
                    lstActLog.SelectedIndex = lstActLog.Items.Count - 1;
                    lstActLog.SelectedIndex = -1;
                }));
            }
            else
            {
                lstActLog.Items.Add(lstItem);
                lstActLog.SelectedIndex = lstActLog.Items.Count - 1;
                lstActLog.SelectedIndex = -1;
            }
            CFileIO.WriteLog(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\PLC_Action.log", message);
        }
    }
}
