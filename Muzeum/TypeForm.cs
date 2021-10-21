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
    public partial class TypeForm : Form
    {
        public TypeForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoadGrid()
        {
            dataGrid.DataSource = DataBaseCore.Query("select idType, Name as [Название типа], Price as [Цена билета] from TypeOfTickets");
            dataGrid.Columns[0].Visible = false;
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void TypeForm_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void билетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new MainForm().Show();
            this.Hide();
        }

        private void выставкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ExpositionForm().Show();
            this.Hide();
        }

        private void продавцыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SellerForm().Show();
            this.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataBaseCore.Query($"insert into TypeOfTickets(name, price) values('{tbName.Text}', '{tbPrice.Text}')");
            MessageBox.Show("Запись добавлена","Добавление записи",
            MessageBoxButtons.OK,MessageBoxIcon.Information);
            LoadGrid();

        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataBaseCore.Query($"insert into TypeOfTickets(name,price) values('{tbName.Text}','{tbPrice.Text}')");
            MessageBox.Show("Запись добавлена", "Добавление записи",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadGrid();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataBaseCore.Query($"update TypeOfTickets set Name = '{tbName.Text}', Price = '{tbPrice.Text}' where idType = " + dataGrid.CurrentRow.Cells[0].Value.ToString());
            MessageBox.Show("Запись изменена", "Изменение записи",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadGrid();

        }

        private void dataGrid_DoubleClick(object sender, EventArgs e)
        {
            tbName.Text = dataGrid.CurrentRow.Cells[1].Value.ToString();
            tbPrice.Text= dataGrid.CurrentRow.Cells[2].Value.ToString(); 
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataBaseCore.Query($"update TypeOfTickets set Name = '{tbName.Text}', Price = '{tbPrice.Text}' where idType = " + dataGrid.CurrentRow.Cells[0].Value.ToString());
            MessageBox.Show("Запись изменена", "Изменение записи",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadGrid();
        }

        private void пометитьНаУдалениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataBaseCore.Query($"update TypeOfTickets set Name = ('{tbName.Text}' + ' Пометка на удаление') where idType =  " + dataGrid.CurrentRow.Cells[0].Value.ToString());
            MessageBox.Show("Запись изменена ",
            "Сообщение",MessageBoxButtons.OK,MessageBoxIcon.Information);
            LoadGrid();
        }

        private void сброситьПоляToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbName.Text = "";
            tbPrice.Text = "";
        }
    }
}
