using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muzeum
{
    public partial class SellerForm : Form
    {
        public SellerForm()
        {
            InitializeComponent();
        }

        private void SellerForm_Load(object sender, EventArgs e)
        {
            LoadGrid();
            tbClose.Visible = false;
        }
        private void LoadGrid()
        {
            dataGrid.DataSource = DataBaseCore.Query("select idSeller as id, FIO as ФИО, NumPhone as [Номер телефона] from Sellers where Status = 'no'");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataBaseCore.Query($"insert into Sellers(FIO,NumPhone,Status) values ('{tbFIO.Text}','{tbNum.Text}', 'no')");
            MessageBox.Show("Запись о продавце добавлена","Запись добавлена", MessageBoxButtons.OK, 
            MessageBoxIcon.Information);
            LoadGrid();
        }
        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataBaseCore.Query($"insert into Sellers(FIO,NumPhone,Status) values ('{tbFIO.Text}','{tbNum.Text}', 'no')");
            MessageBox.Show("Запись о продавце добавлена", "Запись добавлена", MessageBoxButtons.OK,
            MessageBoxIcon.Information);
            LoadGrid();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataBaseCore.Query($@"update Sellers set FIO = '{tbFIO.Text}', NumPhone='{tbNum.Text}'
            where idSeller = " + dataGrid.CurrentRow.Cells[0].Value.ToString());
            MessageBox.Show("Запись о продавце изменена","Запись добавлена", MessageBoxButtons.OK,
            MessageBoxIcon.Information);
            LoadGrid();
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataBaseCore.Query($@"update Sellers set FIO = '{tbFIO.Text}', NumPhone='{tbNum.Text}'
            where idSeller = " + dataGrid.CurrentRow.Cells[0].Value.ToString());
            MessageBox.Show("Запись о продавце изменена", "Запись добавлена", MessageBoxButtons.OK,
            MessageBoxIcon.Information);
            LoadGrid();
        }

        private void пометитьНаУдалениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataBaseCore.Query($@"update Sellers set Status = 'yes'
            where idSeller =  " + dataGrid.CurrentRow.Cells[0].Value.ToString());
            MessageBox.Show("Запись изменена ","Сообщение",
            MessageBoxButtons.OK,MessageBoxIcon.Information);
            LoadGrid();
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void сброситьПоляToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbNum.Text = "";
            tbFIO.Text = "";
        }

        private void dataGrid_DoubleClick(object sender, EventArgs e)
        {
            tbFIO.Text = dataGrid.CurrentRow.Cells[0].Value.ToString();
            tbNum.Text = dataGrid.CurrentRow.Cells[1].Value.ToString();
        }

        private void выставкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ExpositionForm().Show();
            this.Hide();
        }

        private void билетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new MainForm().Show();
            this.Hide();
        }

        private void типыБилетовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new TypeForm().Show();
            this.Hide();
        }

        private void просмотретьУдаленныеТаблицыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGrid.DataSource = DataBaseCore.Query("select * from Sellers where Status ='yes'" );
            tbClose.Visible = true;
        }

        private void tbDelete_Click(object sender, EventArgs e)
        {
            DataBaseCore.Query("delete from Sellers where idSeller = "+ dataGrid.CurrentRow.Cells[0].Value.ToString());
            dataGrid.DataSource = DataBaseCore.Query("select idSeller as id, FIO as ФИО, NumPhone as [Номер телефона] from Sellers where Status = 'yes'");

        }
    }
}
