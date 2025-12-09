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
    public partial class CEditParam : Form
    {
        public PlcParam ParamValue = new PlcParam();
        private ToolTip tTipInput = new ToolTip();
        public CEditParam()
        {
            InitializeComponent();
        }
        private void CEditParam_Shown(object sender, EventArgs e)
        {
            txtParamName.Text = ParamValue.ParamName;
            txtParamAddr.Text = ParamValue.PlcAddress;
            txtParamValue.Text = ParamValue.Value;
            cbxDataType.SelectedIndex = cbxDataType.Items.IndexOf(ParamValue.DataType.ToString());
            tTipInput.SetToolTip(txtParamName, "Điền vào tên tham số");
            tTipInput.SetToolTip(txtParamAddr, "Điền vào địa chỉ PLC.\nVD: D0, R0, Z0 ...");
            tTipInput.SetToolTip(txtParamValue, "Điền vào giá trị. \nVD: K10, H10, D0\nhoặc 1 chuỗi đối với kiểu STRING");
        }
        private void btnParamSave_Click(object sender, EventArgs e)
        {
            if(PlcParam.TryParse(string.Format("{0},{1},{2},{3}", txtParamName.Text, txtParamAddr.Text, cbxDataType.SelectedItem.ToString(), txtParamValue.Text), out PlcParam tempParam, out string error))
            {
                ParamValue = tempParam;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnParamCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void txte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Escape)
            {
                btnParamCancel_Click(sender, e);
            }
        }
    }
}
