namespace HQTCSDL
{
    partial class FOrder
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
            this.tabImportGoods = new System.Windows.Forms.TabControl();
            this.importGood = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanelProduct = new System.Windows.Forms.FlowLayoutPanel();
            this.cbxCatalog = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.cbxVoucher = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.btnCheck = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxCustomers = new System.Windows.Forms.ComboBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dtgrvOrderBill = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.tabManageImport = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnDeleteOrder = new System.Windows.Forms.Button();
            this.panel12 = new System.Windows.Forms.Panel();
            this.dtgrvOrderDetail = new System.Windows.Forms.DataGridView();
            this.dtgrvDetailImport = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpkTo = new System.Windows.Forms.DateTimePicker();
            this.dtpkFrom = new System.Windows.Forms.DateTimePicker();
            this.panel13 = new System.Windows.Forms.Panel();
            this.dtgrvManageOrder = new System.Windows.Forms.DataGridView();
            this.btnHoanTat = new System.Windows.Forms.Button();
            this.tabImportGoods.SuspendLayout();
            this.importGood.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrvOrderBill)).BeginInit();
            this.tabManageImport.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrvOrderDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrvDetailImport)).BeginInit();
            this.panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrvManageOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // tabImportGoods
            // 
            this.tabImportGoods.Controls.Add(this.importGood);
            this.tabImportGoods.Controls.Add(this.tabManageImport);
            this.tabImportGoods.Location = new System.Drawing.Point(6, 10);
            this.tabImportGoods.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabImportGoods.Name = "tabImportGoods";
            this.tabImportGoods.SelectedIndex = 0;
            this.tabImportGoods.Size = new System.Drawing.Size(901, 416);
            this.tabImportGoods.TabIndex = 1;
            // 
            // importGood
            // 
            this.importGood.Controls.Add(this.panel2);
            this.importGood.Location = new System.Drawing.Point(4, 25);
            this.importGood.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.importGood.Name = "importGood";
            this.importGood.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.importGood.Size = new System.Drawing.Size(893, 387);
            this.importGood.TabIndex = 0;
            this.importGood.Text = "Đơn Hàng";
            this.importGood.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.flowLayoutPanelProduct);
            this.panel2.Controls.Add(this.cbxCatalog);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Location = new System.Drawing.Point(3, 5);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(890, 386);
            this.panel2.TabIndex = 2;
            // 
            // flowLayoutPanelProduct
            // 
            this.flowLayoutPanelProduct.AutoScroll = true;
            this.flowLayoutPanelProduct.BackColor = System.Drawing.Color.LightGray;
            this.flowLayoutPanelProduct.Location = new System.Drawing.Point(6, 48);
            this.flowLayoutPanelProduct.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanelProduct.Name = "flowLayoutPanelProduct";
            this.flowLayoutPanelProduct.Size = new System.Drawing.Size(411, 330);
            this.flowLayoutPanelProduct.TabIndex = 11;
            // 
            // cbxCatalog
            // 
            this.cbxCatalog.FormattingEnabled = true;
            this.cbxCatalog.Location = new System.Drawing.Point(84, 9);
            this.cbxCatalog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxCatalog.Name = "cbxCatalog";
            this.cbxCatalog.Size = new System.Drawing.Size(112, 24);
            this.cbxCatalog.TabIndex = 10;
            this.cbxCatalog.SelectedIndexChanged += new System.EventHandler(this.cbxCatalog_SelectedIndexChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Location = new System.Drawing.Point(422, 2);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(465, 376);
            this.panel4.TabIndex = 4;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.panel10);
            this.panel7.Controls.Add(this.panel11);
            this.panel7.Location = new System.Drawing.Point(13, 318);
            this.panel7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(446, 55);
            this.panel7.TabIndex = 3;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.LightCyan;
            this.panel10.Controls.Add(this.cbxVoucher);
            this.panel10.Controls.Add(this.label2);
            this.panel10.Location = new System.Drawing.Point(3, 3);
            this.panel10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(262, 50);
            this.panel10.TabIndex = 7;
            // 
            // cbxVoucher
            // 
            this.cbxVoucher.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxVoucher.FormattingEnabled = true;
            this.cbxVoucher.Location = new System.Drawing.Point(76, 4);
            this.cbxVoucher.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxVoucher.Name = "cbxVoucher";
            this.cbxVoucher.Size = new System.Drawing.Size(172, 27);
            this.cbxVoucher.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ưu Đãi:";
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel11.Controls.Add(this.btnCheck);
            this.panel11.Location = new System.Drawing.Point(263, 2);
            this.panel11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(183, 50);
            this.panel11.TabIndex = 8;
            // 
            // btnCheck
            // 
            this.btnCheck.AutoSize = true;
            this.btnCheck.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnCheck.Location = new System.Drawing.Point(3, 1);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(183, 50);
            this.btnCheck.TabIndex = 5;
            this.btnCheck.Text = "Thanh Toán";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.cbxCustomers);
            this.panel5.Location = new System.Drawing.Point(11, 9);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(452, 41);
            this.panel5.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Khách Hàng:";
            // 
            // cbxCustomers
            // 
            this.cbxCustomers.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxCustomers.FormattingEnabled = true;
            this.cbxCustomers.Location = new System.Drawing.Point(132, 6);
            this.cbxCustomers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxCustomers.Name = "cbxCustomers";
            this.cbxCustomers.Size = new System.Drawing.Size(129, 27);
            this.cbxCustomers.TabIndex = 1;
            this.cbxCustomers.TextUpdate += new System.EventHandler(this.cbxCustomers_TextUpdate);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dtgrvOrderBill);
            this.panel6.Location = new System.Drawing.Point(11, 54);
            this.panel6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(452, 259);
            this.panel6.TabIndex = 4;
            // 
            // dtgrvOrderBill
            // 
            this.dtgrvOrderBill.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgrvOrderBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrvOrderBill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.size,
            this.color,
            this.price,
            this.quantity,
            this.total,
            this.btnDelete});
            this.dtgrvOrderBill.Location = new System.Drawing.Point(3, 2);
            this.dtgrvOrderBill.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtgrvOrderBill.Name = "dtgrvOrderBill";
            this.dtgrvOrderBill.ReadOnly = true;
            this.dtgrvOrderBill.RowHeadersWidth = 62;
            this.dtgrvOrderBill.RowTemplate.Height = 28;
            this.dtgrvOrderBill.Size = new System.Drawing.Size(446, 254);
            this.dtgrvOrderBill.TabIndex = 1;
            this.dtgrvOrderBill.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgrvOrderBill_CellClick);
            // 
            // id
            // 
            this.id.FillWeight = 53.26534F;
            this.id.HeaderText = "Id";
            this.id.MinimumWidth = 8;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 47;
            // 
            // name
            // 
            this.name.FillWeight = 109.3043F;
            this.name.HeaderText = "Tên";
            this.name.MinimumWidth = 8;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 60;
            // 
            // size
            // 
            this.size.FillWeight = 109.3043F;
            this.size.HeaderText = "Kích Thước";
            this.size.MinimumWidth = 8;
            this.size.Name = "size";
            this.size.ReadOnly = true;
            this.size.Width = 102;
            // 
            // color
            // 
            this.color.FillWeight = 109.3043F;
            this.color.HeaderText = "Màu sắc";
            this.color.MinimumWidth = 8;
            this.color.Name = "color";
            this.color.ReadOnly = true;
            this.color.Width = 87;
            // 
            // price
            // 
            this.price.FillWeight = 109.3043F;
            this.price.HeaderText = "Giá";
            this.price.MinimumWidth = 8;
            this.price.Name = "price";
            this.price.ReadOnly = true;
            this.price.Width = 57;
            // 
            // quantity
            // 
            this.quantity.FillWeight = 109.3043F;
            this.quantity.HeaderText = "Số Lượng";
            this.quantity.MinimumWidth = 8;
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            this.quantity.Width = 93;
            // 
            // total
            // 
            this.total.FillWeight = 109.3043F;
            this.total.HeaderText = "Thành Tiền";
            this.total.MinimumWidth = 8;
            this.total.Name = "total";
            this.total.ReadOnly = true;
            this.total.Width = 104;
            // 
            // btnDelete
            // 
            this.btnDelete.FillWeight = 90.9091F;
            this.btnDelete.HeaderText = "";
            this.btnDelete.MinimumWidth = 8;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ReadOnly = true;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Width = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Danh mục:";
            // 
            // btnSearch
            // 
            this.btnSearch.AutoSize = true;
            this.btnSearch.Location = new System.Drawing.Point(348, 6);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 34);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(201, 9);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(142, 30);
            this.txtSearch.TabIndex = 7;
            // 
            // tabManageImport
            // 
            this.tabManageImport.Controls.Add(this.panel1);
            this.tabManageImport.Location = new System.Drawing.Point(4, 25);
            this.tabManageImport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabManageImport.Name = "tabManageImport";
            this.tabManageImport.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabManageImport.Size = new System.Drawing.Size(893, 387);
            this.tabManageImport.TabIndex = 1;
            this.tabManageImport.Text = "Quản Lí";
            this.tabManageImport.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightCyan;
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(884, 380);
            this.panel1.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.panel9);
            this.panel8.Controls.Add(this.label6);
            this.panel8.Controls.Add(this.label5);
            this.panel8.Controls.Add(this.dtpkTo);
            this.panel8.Controls.Add(this.dtpkFrom);
            this.panel8.Controls.Add(this.panel13);
            this.panel8.Controls.Add(this.btnHoanTat);
            this.panel8.Location = new System.Drawing.Point(-3, -3);
            this.panel8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(890, 386);
            this.panel8.TabIndex = 3;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.panel9.Controls.Add(this.btnDeleteOrder);
            this.panel9.Controls.Add(this.panel12);
            this.panel9.Location = new System.Drawing.Point(453, 12);
            this.panel9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(430, 376);
            this.panel9.TabIndex = 9;
            // 
            // btnDeleteOrder
            // 
            this.btnDeleteOrder.AutoSize = true;
            this.btnDeleteOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDeleteOrder.Location = new System.Drawing.Point(333, 8);
            this.btnDeleteOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeleteOrder.Name = "btnDeleteOrder";
            this.btnDeleteOrder.Size = new System.Drawing.Size(93, 41);
            this.btnDeleteOrder.TabIndex = 6;
            this.btnDeleteOrder.Text = "Hủy Đơn";
            this.btnDeleteOrder.UseVisualStyleBackColor = false;
            this.btnDeleteOrder.Click += new System.EventHandler(this.btnDeleteOrder_Click);
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.dtgrvOrderDetail);
            this.panel12.Controls.Add(this.dtgrvDetailImport);
            this.panel12.Location = new System.Drawing.Point(11, 54);
            this.panel12.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(416, 320);
            this.panel12.TabIndex = 4;
            // 
            // dtgrvOrderDetail
            // 
            this.dtgrvOrderDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrvOrderDetail.Location = new System.Drawing.Point(3, 2);
            this.dtgrvOrderDetail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtgrvOrderDetail.Name = "dtgrvOrderDetail";
            this.dtgrvOrderDetail.RowHeadersWidth = 62;
            this.dtgrvOrderDetail.RowTemplate.Height = 28;
            this.dtgrvOrderDetail.Size = new System.Drawing.Size(411, 308);
            this.dtgrvOrderDetail.TabIndex = 1;
            // 
            // dtgrvDetailImport
            // 
            this.dtgrvDetailImport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrvDetailImport.Location = new System.Drawing.Point(3, 2);
            this.dtgrvDetailImport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtgrvDetailImport.Name = "dtgrvDetailImport";
            this.dtgrvDetailImport.RowHeadersWidth = 62;
            this.dtgrvDetailImport.RowTemplate.Height = 28;
            this.dtgrvDetailImport.Size = new System.Drawing.Size(411, 310);
            this.dtgrvDetailImport.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 19);
            this.label6.TabIndex = 8;
            this.label6.Text = "To    :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 19);
            this.label5.TabIndex = 7;
            this.label5.Text = "From:";
            // 
            // dtpkTo
            // 
            this.dtpkTo.Location = new System.Drawing.Point(63, 38);
            this.dtpkTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpkTo.Name = "dtpkTo";
            this.dtpkTo.Size = new System.Drawing.Size(253, 22);
            this.dtpkTo.TabIndex = 6;
            // 
            // dtpkFrom
            // 
            this.dtpkFrom.Location = new System.Drawing.Point(63, 6);
            this.dtpkFrom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpkFrom.Name = "dtpkFrom";
            this.dtpkFrom.Size = new System.Drawing.Size(253, 22);
            this.dtpkFrom.TabIndex = 5;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel13.Controls.Add(this.dtgrvManageOrder);
            this.panel13.Location = new System.Drawing.Point(3, 64);
            this.panel13.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(442, 314);
            this.panel13.TabIndex = 3;
            // 
            // dtgrvManageOrder
            // 
            this.dtgrvManageOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrvManageOrder.Location = new System.Drawing.Point(3, 4);
            this.dtgrvManageOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtgrvManageOrder.Name = "dtgrvManageOrder";
            this.dtgrvManageOrder.RowHeadersWidth = 62;
            this.dtgrvManageOrder.RowTemplate.Height = 28;
            this.dtgrvManageOrder.Size = new System.Drawing.Size(436, 308);
            this.dtgrvManageOrder.TabIndex = 0;
            this.dtgrvManageOrder.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgrvManageOrder_CellClick);
            // 
            // btnHoanTat
            // 
            this.btnHoanTat.AutoSize = true;
            this.btnHoanTat.Location = new System.Drawing.Point(337, 6);
            this.btnHoanTat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHoanTat.Name = "btnHoanTat";
            this.btnHoanTat.Size = new System.Drawing.Size(97, 50);
            this.btnHoanTat.TabIndex = 2;
            this.btnHoanTat.Text = "Hoàn Tất";
            this.btnHoanTat.UseVisualStyleBackColor = true;
            this.btnHoanTat.Click += new System.EventHandler(this.btnHoanTat_Click);
            // 
            // FOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 435);
            this.Controls.Add(this.tabImportGoods);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FOrder";
            this.Text = "Quản Lí Đơn Hàng";
            this.Load += new System.EventHandler(this.FOrder_Load);
            this.tabImportGoods.ResumeLayout(false);
            this.importGood.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgrvOrderBill)).EndInit();
            this.tabManageImport.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgrvOrderDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrvDetailImport)).EndInit();
            this.panel13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgrvManageOrder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabImportGoods;
        private System.Windows.Forms.TabPage importGood;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TabPage tabManageImport;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpkTo;
        private System.Windows.Forms.DateTimePicker dtpkFrom;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Button btnHoanTat;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button btnDeleteOrder;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.DataGridView dtgrvDetailImport;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.ComboBox cbxCatalog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelProduct;
        public System.Windows.Forms.ComboBox cbxCustomers;
        private System.Windows.Forms.DataGridView dtgrvOrderBill;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn size;
        private System.Windows.Forms.DataGridViewTextBoxColumn color;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewButtonColumn btnDelete;
        public System.Windows.Forms.ComboBox cbxVoucher;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dtgrvManageOrder;
        private System.Windows.Forms.DataGridView dtgrvOrderDetail;
    }
}