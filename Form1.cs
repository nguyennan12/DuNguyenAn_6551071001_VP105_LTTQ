using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace DuNguyenAn_6551071001_VP105_LTTQ;

public partial class Form1 : Form
{
    // ConnectionString DataBase DuLieu_ThietBi
    private readonly string connStr = @"Data Source=.;Initial Catalog=DuLieu_ThietBi;Integrated Security=True;TrustServerCertificate=True";

    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        LoadData();
        TrangThaiBanDau();
    }

    private void LoadData()
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlDataAdapter da = new SqlDataAdapter("SELECT MaThietBi, TenThietBi, DonGia FROM ThietBi", conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvDanhSachThietBi.DataSource = dt;

                if (dgvDanhSachThietBi.Columns["MaThietBi"] != null)
                {
                    dgvDanhSachThietBi.Columns["MaThietBi"]!.HeaderText = "Mã Thiết bị";
                    dgvDanhSachThietBi.Columns["MaThietBi"]!.Width = 110;
                }
                if (dgvDanhSachThietBi.Columns["TenThietBi"] != null)
                {
                    dgvDanhSachThietBi.Columns["TenThietBi"]!.HeaderText = "Tên thiết bị";
                    dgvDanhSachThietBi.Columns["TenThietBi"]!.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                if (dgvDanhSachThietBi.Columns["DonGia"] != null)
                {
                    dgvDanhSachThietBi.Columns["DonGia"]!.HeaderText = "Đơn giá (VND)";
                    dgvDanhSachThietBi.Columns["DonGia"]!.Width = 130;
                }
            }

            dgvDanhSachThietBi.ClearSelection();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void TrangThaiBanDau()
    {
        btnSua.Enabled = false;
        btnXoa.Enabled = false;
        btnThem.Enabled = true;
        btnThoat.Enabled = true;

        txtMaThietBi.Enabled = true;
        XoaRongTextBox();

        if (dgvDanhSachThietBi.Rows.Count > 0)
        {
            dgvDanhSachThietBi.ClearSelection();
        }
    }

    private void XoaRongTextBox()
    {
        txtMaThietBi.Clear();
        txtTenThietBi.Clear();
        txtDonGia.Clear();
    }

    private bool KiemTraTrungMa(string maTB)
    {
        using (SqlConnection conn = new SqlConnection(connStr))
        using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM ThietBi WHERE MaThietBi = @MaTB", conn))
        {
            cmd.Parameters.AddWithValue("@MaTB", maTB);
            conn.Open();
            int count = (int)cmd.ExecuteScalar();
            return count > 0;
        }
    }

    private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (char.IsControl(e.KeyChar))
        {
            return;
        }

        if (char.IsDigit(e.KeyChar))
        {
            return;
        }

        if ((e.KeyChar == '.' || e.KeyChar == ',') && !txtDonGia.Text.Contains('.') && !txtDonGia.Text.Contains(','))
        {
            return;
        }

        e.Handled = true;
    }

    private void btnThoat_Click(object sender, EventArgs e)
    {
        DialogResult result = MessageBox.Show(
            "Bạn có muốn thoát không",
            "Thông báo",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        );

        if (result == DialogResult.Yes)
        {
            this.Close();
        }
    }

    private void btnThem_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtMaThietBi.Text))
        {
            MessageBox.Show("Vui lòng nhập Mã thiết bị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtMaThietBi.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(txtTenThietBi.Text))
        {
            MessageBox.Show("Vui lòng nhập Tên thiết bị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTenThietBi.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(txtDonGia.Text))
        {
            MessageBox.Show("Vui lòng nhập Đơn giá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtDonGia.Focus();
            return;
        }

        string maTB = txtMaThietBi.Text.Trim();
        string tenTB = txtTenThietBi.Text.Trim();
        string donGia = txtDonGia.Text.Trim();

        string chuanHoaDonGia = donGia.Replace(',', '.');
        if (!double.TryParse(chuanHoaDonGia, NumberStyles.Any, CultureInfo.InvariantCulture, out double dgVal) || dgVal < 0)
        {
            MessageBox.Show("Đơn giá phải là số thực hoặc số nguyên hợp lệ và không âm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtDonGia.Focus();
            txtDonGia.SelectAll();
            return;
        }

        try
        {
            if (KiemTraTrungMa(maTB))
            {
                MessageBox.Show("Mã thiết bị đã tồn tại! Vui lòng nhập lại mã thiết bị khác.", "Thông báo trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaThietBi.Focus();
                txtMaThietBi.SelectAll();
                return;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("INSERT INTO ThietBi (MaThietBi, TenThietBi, DonGia) VALUES (@MaTB, @TenTB, @DonGia)", conn))
            {
                cmd.Parameters.AddWithValue("@MaTB", maTB);
                cmd.Parameters.AddWithValue("@TenTB", tenTB);
                cmd.Parameters.AddWithValue("@DonGia", donGia);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadData();

            XoaRongTextBox();
            btnThem.Enabled = false;

            MessageBox.Show("Thêm thiết bị thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi khi thêm thiết bị: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void dgvDanhSachThietBi_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.RowIndex >= dgvDanhSachThietBi.Rows.Count)
        {
            return;
        }

        DataGridViewRow row = dgvDanhSachThietBi.Rows[e.RowIndex];
        if (row.Cells["MaThietBi"].Value == null || row.Cells["MaThietBi"].Value == DBNull.Value)
        {
            return;
        }

        txtMaThietBi.Text = row.Cells["MaThietBi"].Value?.ToString() ?? "";
        txtTenThietBi.Text = row.Cells["TenThietBi"].Value?.ToString() ?? "";
        txtDonGia.Text = row.Cells["DonGia"].Value?.ToString() ?? "";

        txtMaThietBi.Enabled = false;

        btnSua.Enabled = true;
        btnXoa.Enabled = true;
        btnThem.Enabled = false;
    }

    private void btnXoa_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtMaThietBi.Text))
        {
            MessageBox.Show("Vui lòng chọn thiết bị dưới danh sách để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        DialogResult dialog = MessageBox.Show(
            "Bạn có muốn xóa thiết bị này không?",
            "Thông báo",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        );

        if (dialog == DialogResult.Yes)
        {
            try
            {
                string maTB = txtMaThietBi.Text.Trim();
                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand("DELETE FROM ThietBi WHERE MaThietBi = @MaTB", conn))
                {
                    cmd.Parameters.AddWithValue("@MaTB", maTB);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                LoadData();
                MessageBox.Show("Xóa thiết bị thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa thiết bị: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        XoaRongTextBox();
        txtMaThietBi.Enabled = true;
        btnSua.Enabled = false;
        btnXoa.Enabled = false;
        btnThem.Enabled = true;
        dgvDanhSachThietBi.ClearSelection();
    }
    private void btnSua_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtMaThietBi.Text))
        {
            MessageBox.Show("Vui lòng chọn một thiết bị dưới danh sách để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (string.IsNullOrWhiteSpace(txtTenThietBi.Text))
        {
            MessageBox.Show("Vui lòng nhập Tên thiết bị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTenThietBi.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(txtDonGia.Text))
        {
            MessageBox.Show("Vui lòng nhập Đơn giá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtDonGia.Focus();
            return;
        }

        string maTB = txtMaThietBi.Text.Trim();
        string tenTB = txtTenThietBi.Text.Trim();
        string donGia = txtDonGia.Text.Trim();

        string chuanHoaDonGia = donGia.Replace(',', '.');
        if (!double.TryParse(chuanHoaDonGia, NumberStyles.Any, CultureInfo.InvariantCulture, out double dgVal) || dgVal < 0)
        {
            MessageBox.Show("Đơn giá phải là số thực hoặc số nguyên hợp lệ và không âm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtDonGia.Focus();
            txtDonGia.SelectAll();
            return;
        }

        try
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("UPDATE ThietBi SET TenThietBi = @TenTB, DonGia = @DonGia WHERE MaThietBi = @MaTB", conn))
            {
                cmd.Parameters.AddWithValue("@MaTB", maTB);
                cmd.Parameters.AddWithValue("@TenTB", tenTB);
                cmd.Parameters.AddWithValue("@DonGia", donGia);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadData();
            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi khi cập nhật thiết bị: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        XoaRongTextBox();
        txtMaThietBi.Enabled = true;
        btnSua.Enabled = false;
        btnXoa.Enabled = false;
        btnThem.Enabled = true;
        dgvDanhSachThietBi.ClearSelection();
    }

    private void txtMaThietBi_Enter(object sender, EventArgs e)
    {
        if (txtMaThietBi.Enabled)
        {
            btnThem.Enabled = true;
        }
    }

    private void txtMaThietBi_TextChanged(object sender, EventArgs e)
    {

    }

    private void dgvDanhSachThietBi_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }
}
