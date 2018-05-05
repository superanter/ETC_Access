namespace ETC_Access
{
    partial class Form1
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
            this.btnAddRount = new System.Windows.Forms.Button();
            this.txtA003_2 = new System.Windows.Forms.TextBox();
            this.txtA003_3 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(29, 26);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(585, 206);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnAddRount
            // 
            this.btnAddRount.Location = new System.Drawing.Point(556, 251);
            this.btnAddRount.Name = "btnAddRount";
            this.btnAddRount.Size = new System.Drawing.Size(75, 23);
            this.btnAddRount.TabIndex = 1;
            this.btnAddRount.Text = "增加";
            this.btnAddRount.UseVisualStyleBackColor = true;
            this.btnAddRount.Click += new System.EventHandler(this.btnAddRount_Click);
            // 
            // txtA003_2
            // 
            this.txtA003_2.Location = new System.Drawing.Point(165, 254);
            this.txtA003_2.Name = "txtA003_2";
            this.txtA003_2.Size = new System.Drawing.Size(100, 21);
            this.txtA003_2.TabIndex = 2;
            // 
            // txtA003_3
            // 
            this.txtA003_3.Location = new System.Drawing.Point(433, 254);
            this.txtA003_3.Name = "txtA003_3";
            this.txtA003_3.Size = new System.Drawing.Size(100, 21);
            this.txtA003_3.TabIndex = 3;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 254);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 334);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.txtA003_3);
            this.Controls.Add(this.txtA003_2);
            this.Controls.Add(this.btnAddRount);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAddRount;
        private System.Windows.Forms.TextBox txtA003_2;
        private System.Windows.Forms.TextBox txtA003_3;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

