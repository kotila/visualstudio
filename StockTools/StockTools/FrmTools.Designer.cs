namespace StockTools
{
    partial class FrmTools
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cmbTableList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textSKU = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textAmount = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 133);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(874, 354);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // cmbTableList
            // 
            this.cmbTableList.FormattingEnabled = true;
            this.cmbTableList.Location = new System.Drawing.Point(143, 31);
            this.cmbTableList.Name = "cmbTableList";
            this.cmbTableList.Size = new System.Drawing.Size(215, 20);
            this.cmbTableList.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "选择数据";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(548, 27);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "SKU";
            this.label2.Visible = false;
            // 
            // textSKU
            // 
            this.textSKU.Location = new System.Drawing.Point(143, 85);
            this.textSKU.Name = "textSKU";
            this.textSKU.Size = new System.Drawing.Size(100, 21);
            this.textSKU.TabIndex = 5;
            this.textSKU.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(298, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "数量";
            this.label3.Visible = false;
            // 
            // textAmount
            // 
            this.textAmount.Location = new System.Drawing.Point(348, 85);
            this.textAmount.Name = "textAmount";
            this.textAmount.Size = new System.Drawing.Size(100, 21);
            this.textAmount.TabIndex = 7;
            this.textAmount.Visible = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(548, 83);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "修改";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // FrmTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 499);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.textAmount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textSKU);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTableList);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FrmTools";
            this.Text = "仓储系统工具";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmbTableList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textSKU;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textAmount;
        private System.Windows.Forms.Button btnUpdate;
    }
}

