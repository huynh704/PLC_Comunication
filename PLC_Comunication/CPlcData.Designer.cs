namespace PLC_Comunication
{
    partial class CPlcData
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtImportPath = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnWritePLC = new System.Windows.Forms.Button();
            this.btnReadPLC = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnComparePLC = new System.Windows.Forms.Button();
            this.lstParamList = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Controls.Add(this.txtImportPath);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(620, 50);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Đường dẫn tập tin";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(539, 18);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Duyệt";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btn_Click);
            // 
            // txtImportPath
            // 
            this.txtImportPath.Location = new System.Drawing.Point(7, 19);
            this.txtImportPath.Name = "txtImportPath";
            this.txtImportPath.Size = new System.Drawing.Size(526, 20);
            this.txtImportPath.TabIndex = 0;
            this.txtImportPath.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImportPath_KeyPress);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.13513F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.86487F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lstParamList, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 70);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(620, 375);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.btnWritePLC, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnReadPLC, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnExport, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnComparePLC, 0, 3);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(530, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(87, 173);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btnWritePLC
            // 
            this.btnWritePLC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnWritePLC.Location = new System.Drawing.Point(6, 3);
            this.btnWritePLC.Name = "btnWritePLC";
            this.btnWritePLC.Size = new System.Drawing.Size(75, 37);
            this.btnWritePLC.TabIndex = 1;
            this.btnWritePLC.Text = "Ghi vào PLC";
            this.btnWritePLC.UseVisualStyleBackColor = true;
            this.btnWritePLC.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnReadPLC
            // 
            this.btnReadPLC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnReadPLC.Location = new System.Drawing.Point(6, 46);
            this.btnReadPLC.Name = "btnReadPLC";
            this.btnReadPLC.Size = new System.Drawing.Size(75, 37);
            this.btnReadPLC.TabIndex = 1;
            this.btnReadPLC.Text = "Đọc từ PLC";
            this.btnReadPLC.UseVisualStyleBackColor = true;
            this.btnReadPLC.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExport.Location = new System.Drawing.Point(6, 89);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 37);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Xuất ra file";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnComparePLC
            // 
            this.btnComparePLC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnComparePLC.Location = new System.Drawing.Point(6, 132);
            this.btnComparePLC.Name = "btnComparePLC";
            this.btnComparePLC.Size = new System.Drawing.Size(75, 37);
            this.btnComparePLC.TabIndex = 1;
            this.btnComparePLC.Text = "So sánh với PLC";
            this.btnComparePLC.UseVisualStyleBackColor = true;
            this.btnComparePLC.Click += new System.EventHandler(this.btn_Click);
            // 
            // lstParamList
            // 
            this.lstParamList.FormattingEnabled = true;
            this.lstParamList.HorizontalScrollbar = true;
            this.lstParamList.Location = new System.Drawing.Point(3, 3);
            this.lstParamList.Name = "lstParamList";
            this.lstParamList.Size = new System.Drawing.Size(521, 368);
            this.lstParamList.TabIndex = 1;
            this.lstParamList.DoubleClick += new System.EventHandler(this.lstParamList_DoubleClick);
            this.lstParamList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstParamList_KeyPress);
            // 
            // CPlcData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 451);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "CPlcData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sao lưu phục hồi dữ liệu";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtImportPath;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnWritePLC;
        private System.Windows.Forms.Button btnReadPLC;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnComparePLC;
        private System.Windows.Forms.ListBox lstParamList;
    }
}