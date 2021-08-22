using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;

namespace GUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            SetGUI();
        }
        public void SetGUI()
        {
            cbbSort.SelectedIndex = 1;
            foreach( var i in BLL_QLMA.Instance.GetAllMonAn())
            cbbMonAn.Items.Add(i);
            cbbMonAn.SelectedIndex = 0;
            dataGridView1.DataSource = BLL_QLMA.Instance.GetNLMonAn(cbbMonAn.SelectedItem.ToString());
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Model1 db = new Model1();
            DetailForm form = new DetailForm();
            form.LoadInfor(cbbMonAn.SelectedItem.ToString());
            form.ShowList += new DetailForm.del(SetGUI);
            form.Show();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            String id = (dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            BLL_QLMA.Instance.DeleteRecord_MANL(id);
            dataGridView1.DataSource  = BLL_QLMA.Instance.GetNLMonAn(cbbMonAn.SelectedItem.ToString());
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Model1 db = new Model1();
            DetailForm form = new DetailForm();
            MonAn_NguyenLieu item = BLL_QLMA.Instance.GetNguyenLieuMA_ByID(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            form.LoadInfor(cbbMonAn.Text, 1, item);
            form.ShowList += new DetailForm.del(SetGUI);
            form.Show();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            int field = int.Parse(cbbSort.SelectedIndex.ToString()) +1;
            dataGridView1.DataSource = BLL_QLMA.Instance.Sort(cbbMonAn.SelectedItem.ToString(), field);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if(txtSearch.Text == "") dataGridView1.DataSource = BLL_QLMA.Instance.GetNLMonAn(cbbMonAn.SelectedItem.ToString());
            else dataGridView1.DataSource = BLL_QLMA.Instance.SearchRecords(txtSearch.Text , cbbMonAn.Text);
        }

        private void cbbMonAn_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLL_QLMA.Instance.GetNLMonAn(cbbMonAn.SelectedItem.ToString());
        }
    }
}
