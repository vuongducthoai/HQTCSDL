namespace HQTCSDL.Forms.ManagerInforUser
{
    partial class FInfor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FInfor));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textAge = new System.Windows.Forms.NumericUpDown();
            this.btn1 = new System.Windows.Forms.Button();
            this.btnS = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textAddress = new System.Windows.Forms.RichTextBox();
            this.textID = new System.Windows.Forms.TextBox();
            this.Role = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textAge)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Aquamarine;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.textAge);
            this.panel1.Controls.Add(this.btn1);
            this.panel1.Controls.Add(this.btnS);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textAddress);
            this.panel1.Controls.Add(this.textID);
            this.panel1.Controls.Add(this.Role);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(151, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(622, 509);
            this.panel1.TabIndex = 15;
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.Image = global::HQTCSDL.Properties.Resources.istockphoto_1337144146_612x612;
            this.pictureBox1.Location = new System.Drawing.Point(64, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(156, 119);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // textAge
            // 
            this.textAge.Enabled = false;
            this.textAge.Location = new System.Drawing.Point(260, 245);
            this.textAge.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.textAge.Name = "textAge";
            this.textAge.Size = new System.Drawing.Size(109, 22);
            this.textAge.TabIndex = 14;
            // 
            // btn1
            // 
            this.btn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn1.Location = new System.Drawing.Point(249, 106);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(95, 38);
            this.btn1.TabIndex = 1;
            this.btn1.Text = "Nhập";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Visible = false;
            this.btn1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnS
            // 
            this.btnS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnS.Location = new System.Drawing.Point(249, 441);
            this.btnS.Name = "btnS";
            this.btnS.Size = new System.Drawing.Size(95, 38);
            this.btnS.TabIndex = 13;
            this.btnS.Text = "Sửa";
            this.btnS.UseVisualStyleBackColor = true;
            this.btnS.Click += new System.EventHandler(this.btnS_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(168, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mã :";
            // 
            // textAddress
            // 
            this.textAddress.Enabled = false;
            this.textAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textAddress.Location = new System.Drawing.Point(258, 286);
            this.textAddress.Name = "textAddress";
            this.textAddress.Size = new System.Drawing.Size(179, 96);
            this.textAddress.TabIndex = 12;
            this.textAddress.Text = "";
            // 
            // textID
            // 
            this.textID.Enabled = false;
            this.textID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textID.Location = new System.Drawing.Point(258, 162);
            this.textID.Name = "textID";
            this.textID.Size = new System.Drawing.Size(100, 27);
            this.textID.TabIndex = 3;
            // 
            // Role
            // 
            this.Role.AutoSize = true;
            this.Role.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Role.Location = new System.Drawing.Point(255, 396);
            this.Role.Name = "Role";
            this.Role.Size = new System.Drawing.Size(109, 25);
            this.Role.TabIndex = 11;
            this.Role.Text = "Nhân viên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(98, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Họ và Tên :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(130, 396);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "Vai trò :";
            // 
            // textName
            // 
            this.textName.Enabled = false;
            this.textName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textName.Location = new System.Drawing.Point(260, 195);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(177, 27);
            this.textName.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(133, 285);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Địa chỉ :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(156, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tuổi :";
            // 
            // FInfor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(906, 530);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FInfor";
            this.Text = "FInfor";
            this.Load += new System.EventHandler(this.FInfor_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textAge)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Role;
        private System.Windows.Forms.RichTextBox textAddress;
        private System.Windows.Forms.Button btnS;
        private System.Windows.Forms.NumericUpDown textAge;
    }
}