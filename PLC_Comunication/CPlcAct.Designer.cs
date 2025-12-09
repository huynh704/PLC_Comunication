namespace PLC_Comunication
{
    partial class CPlcAct
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbS1 = new System.Windows.Forms.Label();
            this.lbS2 = new System.Windows.Forms.Label();
            this.lbS3 = new System.Windows.Forms.Label();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.cbxAction = new System.Windows.Forms.ComboBox();
            this.btnExcute = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lstActLog = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lstActLog, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 13);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.68657F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77.31343F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(513, 335);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbS1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbS2, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbS3, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtSource, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtDestination, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtNumber, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.cbxAction, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnExcute, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.label2, 4, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(506, 68);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chức năng";
            // 
            // lbS1
            // 
            this.lbS1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbS1.AutoSize = true;
            this.lbS1.Location = new System.Drawing.Point(132, 10);
            this.lbS1.Name = "lbS1";
            this.lbS1.Size = new System.Drawing.Size(39, 13);
            this.lbS1.TabIndex = 0;
            this.lbS1.Text = "Nguồn";
            // 
            // lbS2
            // 
            this.lbS2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbS2.AutoSize = true;
            this.lbS2.Location = new System.Drawing.Point(226, 10);
            this.lbS2.Name = "lbS2";
            this.lbS2.Size = new System.Drawing.Size(53, 13);
            this.lbS2.TabIndex = 0;
            this.lbS2.Text = "Đích đến";
            // 
            // lbS3
            // 
            this.lbS3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbS3.AutoSize = true;
            this.lbS3.Location = new System.Drawing.Point(329, 10);
            this.lbS3.Name = "lbS3";
            this.lbS3.Size = new System.Drawing.Size(49, 13);
            this.lbS3.TabIndex = 0;
            this.lbS3.Text = "Số lượng";
            // 
            // txtSource
            // 
            this.txtSource.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSource.Location = new System.Drawing.Point(105, 40);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(94, 20);
            this.txtSource.TabIndex = 1;
            // 
            // txtDestination
            // 
            this.txtDestination.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDestination.Location = new System.Drawing.Point(206, 40);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(94, 20);
            this.txtDestination.TabIndex = 1;
            // 
            // txtNumber
            // 
            this.txtNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNumber.Location = new System.Drawing.Point(307, 40);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(94, 20);
            this.txtNumber.TabIndex = 1;
            // 
            // cbxAction
            // 
            this.cbxAction.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAction.FormattingEnabled = true;
            this.cbxAction.Items.AddRange(new object[] {
            "SET",
            "RST",
            "FF",
            "BSET",
            "BRST",
            "MOV",
            "DMOV",
            "BMOV",
            "FMOV",
            "DBL",
            "SFL",
            "SFR",
            "INC",
            "DEC",
            "ADD",
            "SUB",
            "MUL",
            "DIV",
            "$MOV"});
            this.cbxAction.Location = new System.Drawing.Point(4, 40);
            this.cbxAction.Name = "cbxAction";
            this.cbxAction.Size = new System.Drawing.Size(94, 21);
            this.cbxAction.TabIndex = 2;
            this.cbxAction.SelectedIndexChanged += new System.EventHandler(this.cbxAction_SelectedIndexChanged);
            // 
            // btnExcute
            // 
            this.btnExcute.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExcute.Location = new System.Drawing.Point(408, 37);
            this.btnExcute.Name = "btnExcute";
            this.btnExcute.Size = new System.Drawing.Size(94, 27);
            this.btnExcute.TabIndex = 3;
            this.btnExcute.Text = "Thực thi";
            this.btnExcute.UseVisualStyleBackColor = true;
            this.btnExcute.Click += new System.EventHandler(this.btnExcute_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(424, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Hành động";
            // 
            // lstActLog
            // 
            this.lstActLog.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lstActLog.FormattingEnabled = true;
            this.lstActLog.HorizontalScrollbar = true;
            this.lstActLog.Location = new System.Drawing.Point(4, 80);
            this.lstActLog.Name = "lstActLog";
            this.lstActLog.Size = new System.Drawing.Size(505, 251);
            this.lstActLog.TabIndex = 2;
            // 
            // CPlcAct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 349);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "CPlcAct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ghi dữ liệu PLC";
            this.Shown += new System.EventHandler(this.CPlcAct_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbS1;
        private System.Windows.Forms.Label lbS2;
        private System.Windows.Forms.Label lbS3;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.ComboBox cbxAction;
        private System.Windows.Forms.ListBox lstActLog;
        private System.Windows.Forms.Button btnExcute;
        private System.Windows.Forms.Label label2;
    }
}