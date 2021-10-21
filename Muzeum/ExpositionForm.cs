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
    public partial class ExpositionForm : Form
    {
        public ExpositionForm()
        {
            InitializeComponent();
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void LoadGrid()
        {
           dataGrid.DataSource = DataBaseCore.Query(@"select [№_exposition], NameExposition as [Название экспозиции], Hall as [Зал] from Expositions where Status = 'no'");
           dataGrid.Columns[0].Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataBaseCore.Query($"insert into Expositions(NameExposition, Hall, Status) values ('{tbName.Text}', '{tbZal.Text}','no')");
            MessageBox.Show("Запись добавлена: ",
            "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadGrid();
        }
        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataBaseCore.Query($"insert into Expositions(NameExposition, Hall, Status) values ('{tbName.Text}', '{tbZal.Text}','no')");
            MessageBox.Show("Запись добавлена: ",
            "Сообщение",MessageBoxButtons.OK,MessageBoxIcon.Information);
            LoadGrid();
        }
        private void ExpositionForm_Load(object sender, EventArgs e)
        {
            tbDelete.Visible = false;
            LoadGrid();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataBaseCore.Query($@"update Expositions set NameExposition = '{tbName.Text}', Hall='{tbZal.Text}', Status = 'no'
            where №_exposition = " + dataGrid.CurrentRow.Cells[0].Value.ToString());
            MessageBox.Show("Запись изменена ", "Сообщение",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadGrid();
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataBaseCore.Query($@"update Expositions set NameExposition = '{tbName.Text}', Hall='{tbZal.Text}', Status = 'no'
            where №_exposition = " + dataGrid.CurrentRow.Cells[0].Value.ToString());
            MessageBox.Show("Запись изменена ", "Сообщение",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadGrid();
        }

        private void dataGrid_DoubleClick(object sender, EventArgs e)
        {
            tbName.Text = dataGrid.CurrentRow.Cells[1].Value.ToString();
            tbZal.Text = dataGrid.CurrentRow.Cells[2].Value.ToString();
        }

        private void пометитьНаУдалениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataBaseCore.Query($@"update Expositions set Status = 'yes'
            where  [№_exposition] = " + dataGrid.CurrentRow.Cells[0].Value.ToString());
            MessageBox.Show("Запись изменена ", "Сообщение",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadGrid();
        }

        private void сброситьПоляToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbName.Text = "";
            tbZal.Text = "";
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void билетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new MainForm().Show();
            this.Hide();
        }

        private void продавцыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SellerForm().Show();
            this.Hide();
        }

        private void типыБилетовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new TypeForm().Show();
            this.Hide();
        }

        private void DeletedRecords_Click(object sender, EventArgs e)
        {
            dataGrid.DataSource = DataBaseCore.Query($@"Select [№_exposition], [NameExposition] as  [Название выставки] ,[Hall] as Зал from Expositions where Status = 'yes'");
            tbDelete.Visible = true;
            dataGrid.Columns[0].Visible = false;

        }

        private void tbDelete_Click(object sender, EventArgs e)
        {
            DataBaseCore.Query("delete from Expositions where [№_exposition] = " + dataGrid.CurrentRow.Cells[0].Value.ToString());
        }
    }
}
