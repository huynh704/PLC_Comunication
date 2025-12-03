namespace PLC_Comunication
{
    partial class MainForm
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnPlcFuntion = new System.Windows.Forms.Button();
            this.btnData = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numLogicStationNum = new System.Windows.Forms.NumericUpDown();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lbCpuType = new System.Windows.Forms.Label();
            this.lbPlcTime = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbIOTact = new System.Windows.Forms.Label();
            this.lstAppLog = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLogicStationNum)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(425, 179);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PLC Information";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.btnConnect, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnPlcFuntion, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnData, 0, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(306, 20);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(113, 153);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnConnect.Location = new System.Drawing.Point(3, 3);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(107, 43);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnPlcFuntion
            // 
            this.btnPlcFuntion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPlcFuntion.Location = new System.Drawing.Point(3, 53);
            this.btnPlcFuntion.Name = "btnPlcFuntion";
            this.btnPlcFuntion.Size = new System.Drawing.Size(107, 43);
            this.btnPlcFuntion.TabIndex = 1;
            this.btnPlcFuntion.Text = "Ghi dữ liệu vào PLC";
            this.btnPlcFuntion.UseVisualStyleBackColor = true;
            this.btnPlcFuntion.Click += new System.EventHandler(this.btnFuntion_Click);
            // 
            // btnData
            // 
            this.btnData.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnData.Location = new System.Drawing.Point(3, 105);
            this.btnData.Name = "btnData";
            this.btnData.Size = new System.Drawing.Size(107, 43);
            this.btnData.TabIndex = 1;
            this.btnData.Text = "Sao lưu/Phục hồi dữ liệu";
            this.btnData.UseVisualStyleBackColor = true;
            this.btnData.Click += new System.EventHandler(this.btnFuntion_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.numLogicStationNum, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtPassword, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbCpuType, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbPlcTime, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbIOTact, 1, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(293, 153);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Logical station number";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "CPU Type";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "PLC Time";
            // 
            // numLogicStationNum
            // 
            this.numLogicStationNum.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numLogicStationNum.Location = new System.Drawing.Point(159, 6);
            this.numLogicStationNum.Name = "numLogicStationNum";
            this.numLogicStationNum.Size = new System.Drawing.Size(120, 20);
            this.numLogicStationNum.TabIndex = 1;
            this.numLogicStationNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPassword.Location = new System.Drawing.Point(159, 36);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(120, 20);
            this.txtPassword.TabIndex = 2;
            // 
            // lbCpuType
            // 
            this.lbCpuType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbCpuType.AutoSize = true;
            this.lbCpuType.Location = new System.Drawing.Point(204, 69);
            this.lbCpuType.Name = "lbCpuType";
            this.lbCpuType.Size = new System.Drawing.Size(30, 13);
            this.lbCpuType.TabIndex = 0;
            this.lbCpuType.Text = "Qxxx";
            this.lbCpuType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbPlcTime
            // 
            this.lbPlcTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbPlcTime.AutoSize = true;
            this.lbPlcTime.Location = new System.Drawing.Point(160, 99);
            this.lbPlcTime.Name = "lbPlcTime";
            this.lbPlcTime.Size = new System.Drawing.Size(118, 13);
            this.lbPlcTime.TabIndex = 0;
            this.lbPlcTime.Text = "dd/MM/yyyy HH:mm:ss";
            this.lbPlcTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "IO Tact";
            // 
            // lbIOTact
            // 
            this.lbIOTact.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbIOTact.AutoSize = true;
            this.lbIOTact.Location = new System.Drawing.Point(197, 130);
            this.lbIOTact.Name = "lbIOTact";
            this.lbIOTact.Size = new System.Drawing.Size(43, 13);
            this.lbIOTact.TabIndex = 0;
            this.lbIOTact.Text = "IO Tact";
            // 
            // lstAppLog
            // 
            this.lstAppLog.FormattingEnabled = true;
            this.lstAppLog.Location = new System.Drawing.Point(13, 199);
            this.lstAppLog.Name = "lstAppLog";
            this.lstAppLog.Size = new System.Drawing.Size(425, 134);
            this.lstAppLog.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 349);
            this.Controls.Add(this.lstAppLog);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PLC communication";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLogicStationNum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.NumericUpDown numLogicStationNum;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lbCpuType;
        private System.Windows.Forms.Label lbPlcTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbIOTact;
        private System.Windows.Forms.ListBox lstAppLog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnPlcFuntion;
        private System.Windows.Forms.Button btnData;
    }
}

