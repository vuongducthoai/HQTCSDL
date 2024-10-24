namespace HQTCSDL
{
    partial class FDanhMuc
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.LinkProductToCategory = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.UpdateCategory = new System.Windows.Forms.Button();
            this.DeleteCategory = new System.Windows.Forms.Button();
            this.AddCategory = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Id = new System.Windows.Forms.TextBox();
            this.cbox_DanhMuc = new System.Windows.Forms.ComboBox();
            this.Danh_Muc = new System.Windows.Forms.Label();
            this.SP_DanhMuc = new System.Windows.Forms.Panel();
            this.DanhMuc_SanPham = new System.Windows.Forms.DataGridView();
            this.All_Product = new System.Windows.Forms.Panel();
            this.dgv_ALLProduct = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SP_DanhMuc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DanhMuc_SanPham)).BeginInit();
            this.All_Product.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ALLProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LinkProductToCategory);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.SP_DanhMuc);
            this.panel1.Controls.Add(this.All_Product);
            this.panel1.Location = new System.Drawing.Point(-2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1028, 541);
            this.panel1.TabIndex = 0;
            // 
            // LinkProductToCategory
            // 
            this.LinkProductToCategory.Location = new System.Drawing.Point(835, 491);
            this.LinkProductToCategory.Name = "LinkProductToCategory";
            this.LinkProductToCategory.Size = new System.Drawing.Size(126, 39);
            this.LinkProductToCategory.TabIndex = 3;
            this.LinkProductToCategory.Text = "Liên kết SP";
            this.LinkProductToCategory.UseVisualStyleBackColor = true;
            this.LinkProductToCategory.Click += new System.EventHandler(this.LinkProductToCategory_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.UpdateCategory);
            this.panel5.Controls.Add(this.DeleteCategory);
            this.panel5.Controls.Add(this.AddCategory);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Location = new System.Drawing.Point(531, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(494, 109);
            this.panel5.TabIndex = 2;
            // 
            // UpdateCategory
            // 
            this.UpdateCategory.Location = new System.Drawing.Point(363, 34);
            this.UpdateCategory.Name = "UpdateCategory";
            this.UpdateCategory.Size = new System.Drawing.Size(124, 43);
            this.UpdateCategory.TabIndex = 3;
            this.UpdateCategory.Text = "Sửa";
            this.UpdateCategory.UseVisualStyleBackColor = true;
            this.UpdateCategory.Click += new System.EventHandler(this.UpdateCategory_Click);
            // 
            // DeleteCategory
            // 
            this.DeleteCategory.Location = new System.Drawing.Point(183, 34);
            this.DeleteCategory.Name = "DeleteCategory";
            this.DeleteCategory.Size = new System.Drawing.Size(120, 44);
            this.DeleteCategory.TabIndex = 2;
            this.DeleteCategory.Text = "Xóa";
            this.DeleteCategory.UseVisualStyleBackColor = true;
            this.DeleteCategory.Click += new System.EventHandler(this.DeleteCategory_Click);
            // 
            // AddCategory
            // 
            this.AddCategory.Location = new System.Drawing.Point(20, 36);
            this.AddCategory.Name = "AddCategory";
            this.AddCategory.Size = new System.Drawing.Size(111, 40);
            this.AddCategory.TabIndex = 1;
            this.AddCategory.Text = "Thêm";
            this.AddCategory.UseVisualStyleBackColor = true;
            this.AddCategory.Click += new System.EventHandler(this.AddCategory_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txt_Name);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.txt_Id);
            this.panel4.Controls.Add(this.cbox_DanhMuc);
            this.panel4.Controls.Add(this.Danh_Muc);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(512, 109);
            this.panel4.TabIndex = 1;
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(276, 64);
            this.txt_Name.Multiline = true;
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(233, 42);
            this.txt_Name.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(204, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Id";
            // 
            // txt_Id
            // 
            this.txt_Id.Location = new System.Drawing.Point(84, 64);
            this.txt_Id.Multiline = true;
            this.txt_Id.Name = "txt_Id";
            this.txt_Id.Size = new System.Drawing.Size(83, 42);
            this.txt_Id.TabIndex = 4;
            // 
            // cbox_DanhMuc
            // 
            this.cbox_DanhMuc.FormattingEnabled = true;
            this.cbox_DanhMuc.Location = new System.Drawing.Point(188, 12);
            this.cbox_DanhMuc.Name = "cbox_DanhMuc";
            this.cbox_DanhMuc.Size = new System.Drawing.Size(146, 28);
            this.cbox_DanhMuc.TabIndex = 2;
            this.cbox_DanhMuc.SelectedIndexChanged += new System.EventHandler(this.cbox_DanhMuc_SelectedIndexChanged);
            // 
            // Danh_Muc
            // 
            this.Danh_Muc.AutoSize = true;
            this.Danh_Muc.Location = new System.Drawing.Point(11, 15);
            this.Danh_Muc.Name = "Danh_Muc";
            this.Danh_Muc.Size = new System.Drawing.Size(82, 20);
            this.Danh_Muc.TabIndex = 3;
            this.Danh_Muc.Text = "Danh Mục";
            // 
            // SP_DanhMuc
            // 
            this.SP_DanhMuc.Controls.Add(this.DanhMuc_SanPham);
            this.SP_DanhMuc.Location = new System.Drawing.Point(3, 118);
            this.SP_DanhMuc.Name = "SP_DanhMuc";
            this.SP_DanhMuc.Size = new System.Drawing.Size(512, 423);
            this.SP_DanhMuc.TabIndex = 1;
            // 
            // DanhMuc_SanPham
            // 
            this.DanhMuc_SanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DanhMuc_SanPham.Location = new System.Drawing.Point(1, 4);
            this.DanhMuc_SanPham.Name = "DanhMuc_SanPham";
            this.DanhMuc_SanPham.RowHeadersWidth = 62;
            this.DanhMuc_SanPham.RowTemplate.Height = 28;
            this.DanhMuc_SanPham.Size = new System.Drawing.Size(508, 416);
            this.DanhMuc_SanPham.TabIndex = 0;
            // 
            // All_Product
            // 
            this.All_Product.Controls.Add(this.dgv_ALLProduct);
            this.All_Product.Location = new System.Drawing.Point(531, 118);
            this.All_Product.Name = "All_Product";
            this.All_Product.Size = new System.Drawing.Size(494, 351);
            this.All_Product.TabIndex = 1;
            // 
            // dgv_ALLProduct
            // 
            this.dgv_ALLProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ALLProduct.Location = new System.Drawing.Point(3, 4);
            this.dgv_ALLProduct.Name = "dgv_ALLProduct";
            this.dgv_ALLProduct.RowHeadersWidth = 62;
            this.dgv_ALLProduct.RowTemplate.Height = 28;
            this.dgv_ALLProduct.Size = new System.Drawing.Size(488, 344);
            this.dgv_ALLProduct.TabIndex = 1;
            this.dgv_ALLProduct.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ALLProduct_CellContentClick);
            // 
            // FDanhMuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 544);
            this.Controls.Add(this.panel1);
            this.Name = "FDanhMuc";
            this.Text = "FDanhMuc";
            this.Load += new System.EventHandler(this.FDanhMuc_Load);
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.SP_DanhMuc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DanhMuc_SanPham)).EndInit();
            this.All_Product.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ALLProduct)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel SP_DanhMuc;
        private System.Windows.Forms.Panel All_Product;
        private System.Windows.Forms.ComboBox cbox_DanhMuc;
        private System.Windows.Forms.Label Danh_Muc;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button DeleteCategory;
        private System.Windows.Forms.Button AddCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button LinkProductToCategory;
        private System.Windows.Forms.Button UpdateCategory;
        private System.Windows.Forms.TextBox txt_Id;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.DataGridView DanhMuc_SanPham;
        private System.Windows.Forms.DataGridView dgv_ALLProduct;
    }
}