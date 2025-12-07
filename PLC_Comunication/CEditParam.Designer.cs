namespace PLC_Comunication
{
    partial class CEditParam
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtParamName = new System.Windows.Forms.TextBox();
            this.txtParamAddr = new System.Windows.Forms.TextBox();
            this.txtParamValue = new System.Windows.Forms.TextBox();
            this.cbxDataType = new System.Windows.Forms.ComboBox();
            this.btnParamSave = new System.Windows.Forms.Button();
            this.btnParamCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtParamName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtParamAddr, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtParamValue, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbxDataType, 2, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 13);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(502, 66);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Địa chỉ";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(282, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Kiểu dữ liệu";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(421, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Giá trị";
            // 
            // txtParamName
            // 
            this.txtParamName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtParamName.Location = new System.Drawing.Point(4, 39);
            this.txtParamName.Name = "txtParamName";
            this.txtParamName.Size = new System.Drawing.Size(118, 20);
            this.txtParamName.TabIndex = 1;
            this.txtParamName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txte_KeyPress);
            // 
            // txtParamAddr
            // 
            this.txtParamAddr.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtParamAddr.Location = new System.Drawing.Point(129, 39);
            this.txtParamAddr.Name = "txtParamAddr";
            this.txtParamAddr.Size = new System.Drawing.Size(118, 20);
            this.txtParamAddr.TabIndex = 2;
            // 
            // txtParamValue
            // 
            this.txtParamValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtParamValue.Location = new System.Drawing.Point(379, 39);
            this.txtParamValue.Name = "txtParamValue";
            this.txtParamValue.Size = new System.Drawing.Size(119, 20);
            this.txtParamValue.TabIndex = 4;
            // 
            // cbxDataType
            // 
            this.cbxDataType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDataType.FormattingEnabled = true;
            this.cbxDataType.Items.AddRange(new object[] {
            "STRING",
            "INT",
            "DINT",
            "BOOL"});
            this.cbxDataType.Location = new System.Drawing.Point(254, 38);
            this.cbxDataType.Name = "cbxDataType";
            this.cbxDataType.Size = new System.Drawing.Size(118, 21);
            this.cbxDataType.TabIndex = 3;
            // 
            // btnParamSave
            // 
            this.btnParamSave.Location = new System.Drawing.Point(267, 85);
            this.btnParamSave.Name = "btnParamSave";
            this.btnParamSave.Size = new System.Drawing.Size(119, 35);
            this.btnParamSave.TabIndex = 5;
            this.btnParamSave.Text = "Lưu";
            this.btnParamSave.UseVisualStyleBackColor = true;
            this.btnParamSave.Click += new System.EventHandler(this.btnParamSave_Click);
            // 
            // btnParamCancel
            // 
            this.btnParamCancel.Location = new System.Drawing.Point(390, 85);
            this.btnParamCancel.Name = "btnParamCancel";
            this.btnParamCancel.Size = new System.Drawing.Size(121, 35);
            this.btnParamCancel.TabIndex = 6;
            this.btnParamCancel.Text = "Thoát";
            this.btnParamCancel.UseVisualStyleBackColor = true;
            this.btnParamCancel.Click += new System.EventHandler(this.btnParamCancel_Click);
            // 
            // CEditParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 125);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnParamCancel);
            this.Controls.Add(this.btnParamSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "CEditParam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sửa đổi tham số";
            this.Shown += new System.EventHandler(this.CEditParam_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtParamName;
        private System.Windows.Forms.TextBox txtParamAddr;
        private System.Windows.Forms.TextBox txtParamValue;
        private System.Windows.Forms.ComboBox cbxDataType;
        private System.Windows.Forms.Button btnParamCancel;
        private System.Windows.Forms.Button btnParamSave;
    }
}