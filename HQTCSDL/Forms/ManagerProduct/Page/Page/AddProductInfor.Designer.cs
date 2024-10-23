namespace HQTCSDL.Forms.ManagerProduct.Page.Page
{
    partial class AddProductInfor
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
            this.btnCreate = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textSize = new System.Windows.Forms.NumericUpDown();
            this.textColor = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.textSize)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(134, 131);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(109, 31);
            this.btnCreate.TabIndex = 39;
            this.btnCreate.Text = "Tạo";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(28, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 35;
            this.label5.Text = "Màu sắc:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(35, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 33;
            this.label4.Text = "Kích cỡ:";
            // 
            // textSize
            // 
            this.textSize.Location = new System.Drawing.Point(123, 36);
            this.textSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.textSize.Name = "textSize";
            this.textSize.Size = new System.Drawing.Size(120, 22);
            this.textSize.TabIndex = 40;
            this.textSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // textColor
            // 
            this.textColor.Location = new System.Drawing.Point(123, 76);
            this.textColor.Name = "textColor";
            this.textColor.Size = new System.Drawing.Size(222, 22);
            this.textColor.TabIndex = 41;
            // 
            // AddProductInfor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 201);
            this.Controls.Add(this.textColor);
            this.Controls.Add(this.textSize);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Name = "AddProductInfor";
            this.Text = "Thêm biến thể";
            this.Load += new System.EventHandler(this.AddProductInfor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown textSize;
        private System.Windows.Forms.TextBox textColor;
    }
}