namespace DuNguyenAn_6551071001_VP105_LTTQ;

partial class Form1
{

    private System.ComponentModel.IContainer components = null;


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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        lblDanhSach = new Label();
        dgvDanhSachThietBi = new DataGridView();
        lblThongTin = new Label();
        lblMaTB = new Label();
        txtMaThietBi = new TextBox();
        lblTenTB = new Label();
        txtTenThietBi = new TextBox();
        lblDonGia = new Label();
        txtDonGia = new TextBox();
        lblThaoTac = new Label();
        btnThem = new Button();
        btnThoat = new Button();
        btnSua = new Button();
        btnXoa = new Button();
        ((System.ComponentModel.ISupportInitialize)dgvDanhSachThietBi).BeginInit();
        SuspendLayout();
        // 
        // lblDanhSach
        // 
        lblDanhSach.AutoSize = true;
        lblDanhSach.Font = new Font("Segoe UI", 10F);
        lblDanhSach.Location = new Point(36, 29);
        lblDanhSach.Margin = new Padding(5, 0, 5, 0);
        lblDanhSach.Name = "lblDanhSach";
        lblDanhSach.Size = new Size(227, 37);
        lblDanhSach.TabIndex = 0;
        lblDanhSach.Text = "danh sách thiết bị";
        // 
        // dgvDanhSachThietBi
        // 
        dgvDanhSachThietBi.AllowUserToAddRows = false;
        dgvDanhSachThietBi.AllowUserToDeleteRows = false;
        dgvDanhSachThietBi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvDanhSachThietBi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvDanhSachThietBi.Location = new Point(36, 77);
        dgvDanhSachThietBi.Margin = new Padding(5);
        dgvDanhSachThietBi.MultiSelect = false;
        dgvDanhSachThietBi.Name = "dgvDanhSachThietBi";
        dgvDanhSachThietBi.ReadOnly = true;
        dgvDanhSachThietBi.RowHeadersWidth = 51;
        dgvDanhSachThietBi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvDanhSachThietBi.Size = new Size(764, 624);
        dgvDanhSachThietBi.TabIndex = 1;
        dgvDanhSachThietBi.CellClick += dgvDanhSachThietBi_CellClick;
        dgvDanhSachThietBi.CellContentClick += dgvDanhSachThietBi_CellContentClick;
        // 
        // lblThongTin
        // 
        lblThongTin.AutoSize = true;
        lblThongTin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblThongTin.Location = new Point(845, 29);
        lblThongTin.Margin = new Padding(5, 0, 5, 0);
        lblThongTin.Name = "lblThongTin";
        lblThongTin.Size = new Size(241, 37);
        lblThongTin.TabIndex = 2;
        lblThongTin.Text = "Thông tin thiết bị";
        // 
        // lblMaTB
        // 
        lblMaTB.AutoSize = true;
        lblMaTB.Font = new Font("Segoe UI", 9.5F);
        lblMaTB.Location = new Point(845, 104);
        lblMaTB.Margin = new Padding(5, 0, 5, 0);
        lblMaTB.Name = "lblMaTB";
        lblMaTB.Size = new Size(150, 36);
        lblMaTB.TabIndex = 3;
        lblMaTB.Text = "Mã Thiết bị:";
        // 
        // txtMaThietBi
        // 
        txtMaThietBi.Font = new Font("Segoe UI", 9.5F);
        txtMaThietBi.Location = new Point(1056, 99);
        txtMaThietBi.Margin = new Padding(5);
        txtMaThietBi.MaxLength = 10;
        txtMaThietBi.Name = "txtMaThietBi";
        txtMaThietBi.Size = new Size(298, 41);
        txtMaThietBi.TabIndex = 4;
        txtMaThietBi.TextChanged += txtMaThietBi_TextChanged;
        txtMaThietBi.Enter += txtMaThietBi_Enter;
        // 
        // lblTenTB
        // 
        lblTenTB.AutoSize = true;
        lblTenTB.Font = new Font("Segoe UI", 9.5F);
        lblTenTB.Location = new Point(845, 184);
        lblTenTB.Margin = new Padding(5, 0, 5, 0);
        lblTenTB.Name = "lblTenTB";
        lblTenTB.Size = new Size(149, 36);
        lblTenTB.TabIndex = 5;
        lblTenTB.Text = "Tên thiết bị:";
        // 
        // txtTenThietBi
        // 
        txtTenThietBi.Font = new Font("Segoe UI", 9.5F);
        txtTenThietBi.Location = new Point(1056, 179);
        txtTenThietBi.Margin = new Padding(5);
        txtTenThietBi.Name = "txtTenThietBi";
        txtTenThietBi.Size = new Size(298, 41);
        txtTenThietBi.TabIndex = 6;
        // 
        // lblDonGia
        // 
        lblDonGia.AutoSize = true;
        lblDonGia.Font = new Font("Segoe UI", 9.5F);
        lblDonGia.Location = new Point(845, 264);
        lblDonGia.Margin = new Padding(5, 0, 5, 0);
        lblDonGia.Name = "lblDonGia";
        lblDonGia.Size = new Size(187, 36);
        lblDonGia.TabIndex = 7;
        lblDonGia.Text = "Đơn giá (VND):";
        // 
        // txtDonGia
        // 
        txtDonGia.Font = new Font("Segoe UI", 9.5F);
        txtDonGia.Location = new Point(1056, 259);
        txtDonGia.Margin = new Padding(5);
        txtDonGia.MaxLength = 12;
        txtDonGia.Name = "txtDonGia";
        txtDonGia.Size = new Size(298, 41);
        txtDonGia.TabIndex = 8;
        txtDonGia.KeyPress += txtDonGia_KeyPress;
        // 
        // lblThaoTac
        // 
        lblThaoTac.AutoSize = true;
        lblThaoTac.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblThaoTac.Location = new Point(845, 352);
        lblThaoTac.Margin = new Padding(5, 0, 5, 0);
        lblThaoTac.Name = "lblThaoTac";
        lblThaoTac.Size = new Size(127, 37);
        lblThaoTac.TabIndex = 9;
        lblThaoTac.Text = "Thao tác";
        // 
        // btnThem
        // 
        btnThem.Font = new Font("Segoe UI", 9.5F);
        btnThem.Location = new Point(861, 416);
        btnThem.Margin = new Padding(5);
        btnThem.Name = "btnThem";
        btnThem.Size = new Size(203, 64);
        btnThem.TabIndex = 10;
        btnThem.Text = "Thêm";
        btnThem.UseVisualStyleBackColor = true;
        btnThem.Click += btnThem_Click;
        // 
        // btnThoat
        // 
        btnThoat.Font = new Font("Segoe UI", 9.5F);
        btnThoat.Location = new Point(1121, 416);
        btnThoat.Margin = new Padding(5);
        btnThoat.Name = "btnThoat";
        btnThoat.Size = new Size(203, 64);
        btnThoat.TabIndex = 11;
        btnThoat.Text = "Thoát";
        btnThoat.UseVisualStyleBackColor = true;
        btnThoat.Click += btnThoat_Click;
        // 
        // btnSua
        // 
        btnSua.Font = new Font("Segoe UI", 9.5F);
        btnSua.Location = new Point(861, 520);
        btnSua.Margin = new Padding(5);
        btnSua.Name = "btnSua";
        btnSua.Size = new Size(203, 64);
        btnSua.TabIndex = 12;
        btnSua.Text = "Sửa";
        btnSua.UseVisualStyleBackColor = true;
        btnSua.Click += btnSua_Click;
        // 
        // btnXoa
        // 
        btnXoa.Font = new Font("Segoe UI", 9.5F);
        btnXoa.Location = new Point(1121, 520);
        btnXoa.Margin = new Padding(5);
        btnXoa.Name = "btnXoa";
        btnXoa.Size = new Size(203, 64);
        btnXoa.TabIndex = 13;
        btnXoa.Text = "Xóa";
        btnXoa.UseVisualStyleBackColor = true;
        btnXoa.Click += btnXoa_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(13F, 32F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1406, 744);
        Controls.Add(btnXoa);
        Controls.Add(btnSua);
        Controls.Add(btnThoat);
        Controls.Add(btnThem);
        Controls.Add(lblThaoTac);
        Controls.Add(txtDonGia);
        Controls.Add(lblDonGia);
        Controls.Add(txtTenThietBi);
        Controls.Add(lblTenTB);
        Controls.Add(txtMaThietBi);
        Controls.Add(lblMaTB);
        Controls.Add(lblThongTin);
        Controls.Add(dgvDanhSachThietBi);
        Controls.Add(lblDanhSach);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Margin = new Padding(5);
        MaximizeBox = false;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Form1";
        Load += Form1_Load;
        ((System.ComponentModel.ISupportInitialize)dgvDanhSachThietBi).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblDanhSach;
    private DataGridView dgvDanhSachThietBi;
    private Label lblThongTin;
    private Label lblMaTB;
    private TextBox txtMaThietBi;
    private Label lblTenTB;
    private TextBox txtTenThietBi;
    private Label lblDonGia;
    private TextBox txtDonGia;
    private Label lblThaoTac;
    private Button btnThem;
    private Button btnThoat;
    private Button btnSua;
    private Button btnXoa;
}
