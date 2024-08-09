using QuanLyThuVien.BLL;
using QuanLyThuVien.DAL.Entities;
using QuanLyThuVien.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.QLTV
{
    
    public partial class DetailForm : Form
    {
        public delegate void SendData(DataGridViewRow row);
        public SendData Send { get; set; }

        public DetailForm()
        {
            InitializeComponent();
            loadCBB();
            Send += new SendData(ReceiveData);
        }
        
        private void loadCBB()
        {
            List<CBBItem> cBBItems = Book_BLL.Instance.getBook();
            cbbBook.Items.AddRange(cBBItems.ToArray());
            List<CBBItem> cBBItem = SV_BLL.Instance.getSV();
            cbbName.Items.AddRange(cBBItem.ToArray());
        }
        public void ReceiveData(DataGridViewRow row)
        {
            tbRecordId.Text = row.Cells["BorrowRecordID"].Value.ToString();
            foreach(CBBItem item in cbbBook.Items)
            {
                if (item.Text == row.Cells["Title"].Value.ToString())
                {
                    cbbBook.SelectedItem = item;
                    break;
                }
            }
            foreach (CBBItem item in cbbName.Items)
            {
                if (item.Text == row.Cells["Name"].Value.ToString())
                {
                    cbbName.SelectedItem = item;
                    break;
                }
            }
            dateTimePicker1.Value = DateTime.Parse(row.Cells["BorrowDate"].Value.ToString());
            if (row.Cells["IsReturn"].Value.ToString() == "Yes")
            {
                radioButtonYes.Checked = true;
            }
            else
            {
                radioButtonNo.Checked = true;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (tbRecordId.Text == "" || ((CBBItem)cbbName.SelectedItem).Value == null || ((CBBItem)cbbBook.SelectedItem).Value == null || (!radioButtonYes.Checked && !radioButtonNo.Checked))
            {
                MessageBox.Show("Please fill all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            BorrowRecord record = new BorrowRecord
            {
                BorrowRecordID = tbRecordId.Text,
                MSSV = ((CBBItem)cbbName.SelectedItem).Value,
                Id_Book = ((CBBItem)cbbBook.SelectedItem).Value,
                BorrowDate = dateTimePicker1.Value,
                IsReturn = radioButtonYes.Checked ? "Yes" : "No"
            };
            BorrowRecord_BLL.Instance.Update(record);
            this.Dispose();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
