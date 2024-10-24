namespace HQTCSDL.Forms.ManagerProduct
{
    partial class FProduct
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNhap = new System.Windows.Forms.Button();
            this.idVoucher = new System.Windows.Forms.TextBox();
            this.textId = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btn_sua = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.Price = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.textDes = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Price)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnNhap);
            this.panel2.Controls.Add(this.idVoucher);
            this.panel2.Controls.Add(this.textId);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.btn_sua);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.Price);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.textDes);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.textName);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(531, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(363, 491);
            this.panel2.TabIndex = 5;
            // 
            // btnNhap
            // 
            this.btnNhap.Location = new System.Drawing.Point(42, 165);
            this.btnNhap.Name = "btnNhap";
            this.btnNhap.Size = new System.Drawing.Size(75, 24);
            this.btnNhap.TabIndex = 21;
            this.btnNhap.Text = "Nhập";
            this.btnNhap.UseVisualStyleBackColor = true;
            this.btnNhap.Visible = false;
            this.btnNhap.Click += new System.EventHandler(this.btnNhap_Click);
            // 
            // idVoucher
            // 
            this.idVoucher.Enabled = false;
            this.idVoucher.Location = new System.Drawing.Point(40, 14);
            this.idVoucher.Name = "idVoucher";
            this.idVoucher.Size = new System.Drawing.Size(68, 22);
            this.idVoucher.TabIndex = 20;
            this.idVoucher.Visible = false;
            // 
            // textId
            // 
            this.textId.Enabled = false;
            this.textId.Location = new System.Drawing.Point(258, 100);
            this.textId.Name = "textId";
            this.textId.Size = new System.Drawing.Size(68, 22);
            this.textId.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(141, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 20);
            this.label8.TabIndex = 18;
            this.label8.Text = "Mã sản phẩm:";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(271, 439);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 24);
            this.button6.TabIndex = 17;
            this.button6.Text = "Xóa";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(145, 439);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(109, 24);
            this.button5.TabIndex = 16;
            this.button5.Text = "Xem biến thể";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btn_sua
            // 
            this.btn_sua.Location = new System.Drawing.Point(42, 439);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(75, 24);
            this.btn_sua.TabIndex = 15;
            this.btn_sua.Text = "Sửa ";
            this.btn_sua.UseVisualStyleBackColor = true;
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(145, 379);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 24);
            this.button3.TabIndex = 6;
            this.button3.Text = "Xem ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(49, 383);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Ưu đãi:";
            // 
            // Price
            // 
            this.Price.DecimalPlaces = 2;
            this.Price.Enabled = false;
            this.Price.Location = new System.Drawing.Point(145, 333);
            this.Price.Maximum = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            0});
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(120, 22);
            this.Price.TabIndex = 13;
            this.Price.ValueChanged += new System.EventHandler(this.Price_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(72, 332);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Giá:";
            // 
            // textDes
            // 
            this.textDes.Enabled = false;
            this.textDes.Location = new System.Drawing.Point(145, 208);
            this.textDes.Name = "textDes";
            this.textDes.Size = new System.Drawing.Size(181, 105);
            this.textDes.TabIndex = 11;
            this.textDes.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(52, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Mô tả:";
            // 
            // textName
            // 
            this.textName.Enabled = false;
            this.textName.Location = new System.Drawing.Point(145, 169);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(181, 22);
            this.textName.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(141, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Tên sản phẩm:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = global::HQTCSDL.Properties.Resources.Untitled_1_3;
            this.pictureBox1.Image = global::HQTCSDL.Properties.Resources.Untitled_1_3;
            this.pictureBox1.Location = new System.Drawing.Point(25, 76);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(110, 83);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(114, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 33);
            this.label3.TabIndex = 6;
            this.label3.Text = "Thông tin";
            // 
            // textSearch
            // 
            this.textSearch.Location = new System.Drawing.Point(228, 124);
            this.textSearch.Name = "textSearch";
            this.textSearch.Size = new System.Drawing.Size(139, 22);
            this.textSearch.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(25, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nhập tên hàng hóa";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(392, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Tìm kiếm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(29, 154);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(438, 291);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(168, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 33);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sản phẩm";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(282, 451);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(151, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Lọc sản phẩm";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(66, 451);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(151, 23);
            this.button7.TabIndex = 6;
            this.button7.Text = "Thêm sản phẩm mới";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textSearch);
            this.panel1.Location = new System.Drawing.Point(25, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 491);
            this.panel1.TabIndex = 4;
            // 
            // FProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(906, 530);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FProduct";
            this.Text = "FProduct";
            this.Load += new System.EventHandler(this.FProduct_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Price)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox textDes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NumericUpDown Price;
        private System.Windows.Forms.Button btn_sua;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox idVoucher;
        private System.Windows.Forms.Button btnNhap;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Panel panel1;
    }
}