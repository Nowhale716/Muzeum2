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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
            LoadGrid();
        }

        private void LoadGrid()
        {
            dataGrid.DataSource =  DataBaseCore.Query("select * from Tickets where Status = 'no'");

            cbType.DataSource = DataBaseCore.Query(@"SELECT TypeOfTickets.Name AS [Тип билета], Tickets.TypeTickets
            FROM TypeOfTickets INNER JOIN Tickets ON TypeOfTickets.idType = Tickets.TypeTickets");
            cbType.DisplayMember = "Тип билета";
            cbType.ValueMember = "TypeTickets";

            cbExpo.DataSource = DataBaseCore.Query(@"SELECT Expositions.NameExpoition, Tickets.Exposition FROM
            Expositions INNER JOIN Tickets ON Expositions.[№_exposition] = Tickets.Exposition");

            cbExpo.DisplayMember = "NameExpoition";
            cbExpo.ValueMember = "Exposition";

            cbSeller.DataSource = DataBaseCore.Query(@"SELECT Sellers.FIO AS ФИО, Tickets.Seller FROM Sellers INNER JOIN
            Tickets ON Sellers.idSeller = Tickets.Seller");
            cbSeller.DisplayMember = "ФИО";
            cbSeller.ValueMember = "Seller";
        }

        private void билетыToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void выставкиToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void продавцыToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void типыБилетовToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
           dataGrid.DataSource =  DataBaseCore.Query($@" select TypeTickets as [Тип билета],Event as Мероприятие,Exposition as Выставка,
                               Seller as Продавец from Tickets  where Exposition like '%{tbSearch.Text}%' ");
        }

        private void выставкиToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            new ExpositionForm().Show();
            this.Hide();
        }

        private void продавцыToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            new SellerForm().Show();
            this.Hide();
        }

        private void типыБилетовToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            new TypeForm().Show();
            this.Hide();
        }

        private void сброситьПоляToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbEvent.Text = "";
            tbSearch.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataBaseCore.Query($@"insert into Tickets(TypeTickets,Event,Exposition,Seller) values ('{cbType.Text}','{tbEvent.Text}','{cbExpo.Text}','{cbSeller.Text}'");
            MessageBox.Show("Запись добавлена","Добавление",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataBaseCore.Query($@"insert into Tickets(TypeTickets,Event,Exposition,Seller) values ('{cbType.Text}','{tbEvent.Text}','{cbExpo.Text}','{cbSeller.Text}')");
            MessageBox.Show("Запись добавлена", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataBaseCore.Query($@"update Tickets set TypeTickets = '{cbType.Text}',Event ='{tbEvent.Text}', Exposition = {cbExpo.Text}, Seller='{cbSeller.Text}'
                               where idTickets = "+dataGrid.CurrentRow.Cells[0].Value.ToString());
            MessageBox.Show("Запись изменена", "Изменение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void пометитьНаУдаленииToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
