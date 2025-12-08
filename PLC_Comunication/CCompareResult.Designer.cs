namespace PLC_Comunication
{
    partial class CCompareResult
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
            this.dgwCompareResult = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgwCompareResult)).BeginInit();
            this.SuspendLayout();
            // 
            // dgwCompareResult
            // 
            this.dgwCompareResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgwCompareResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwCompareResult.Location = new System.Drawing.Point(4, 2);
            this.dgwCompareResult.Name = "dgwCompareResult";
            this.dgwCompareResult.ReadOnly = true;
            this.dgwCompareResult.Size = new System.Drawing.Size(708, 425);
            this.dgwCompareResult.TabIndex = 0;
            // 
            // CCompareResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 430);
            this.Controls.Add(this.dgwCompareResult);
            this.MaximizeBox = false;
            this.Name = "CCompareResult";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kết quả so sánh";
            this.Shown += new System.EventHandler(this.CCompareResult_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgwCompareResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwCompareResult;
    }
}