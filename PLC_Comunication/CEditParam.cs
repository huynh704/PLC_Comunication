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
