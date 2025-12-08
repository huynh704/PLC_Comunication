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
    public partial class CCompareResult : Form
    {
        public CCompareResult()
        {
            InitializeComponent();
        }

        private void CCompareResult_Shown(object sender, EventArgs e)
        {
            dgwCompareResult.DataSource = CPlcData.ResultList;
        }
    }
}
