using QuanLyThuVien.BLL;
using QuanLyThuVien.Model;
using QuanLyThuVien.QLTV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QuanLyThuVien.QLTV.DetailForm;

namespace QuanLyThuVien
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            loadCBB();
        }

        private void loadCBB()
        {
            List<CBBItem> cBBItems = BorrowRecord_BLL.Instance.getBook();
            cBBItems.Add(new CBBItem("0", "All"));
            cbbBook.Items.Clear();
            cbbSort.Items.Clear();
            cbbBook.Items.AddRange(cBBItems.ToArray());
            cbbSort.Items.AddRange(new string[]
            {
                "MSSV",
                "Name",
                "Title",
                "BorrowRecordID"
            });
        }

        private void reload()
        {
            dataGridView1.DataSource = BorrowRecord_BLL.Instance.getBorrowRecords("0");
            loadCBB();
        }

        private void cbbBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id_book = (cbbBook.SelectedItem as CBBItem).Value;
            dataGridView1.DataSource = BorrowRecord_BLL.Instance.getBorrowRecords(id_book);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string search = tbSearch.Text;
            dataGridView1.DataSource = BorrowRecord_BLL.Instance.searchBorrowRecords(search);
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            string sort = cbbSort.SelectedItem.ToString();
            dataGridView1.DataSource = BorrowRecord_BLL.Instance.Sort(sort);
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                DialogResult result = MessageBox.Show("Do you want to delete records?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }
                string borrow_id = row.Cells["BorrowRecordID"].Value.ToString();
                BorrowRecord_BLL.Instance.delBorrowRecord(borrow_id);
            }
            reload();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            DetailForm detailForm = new DetailForm();
            detailForm.ShowDialog();
            if (detailForm.IsDisposed)
            {
                reload();
            }
        }
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            DetailForm detailForm = new DetailForm();
            detailForm.Send(dataGridView1.SelectedRows[0]);
            detailForm.ShowDialog();
            if (detailForm.IsDisposed)
            {
               reload();
            }
        }
    }
}
