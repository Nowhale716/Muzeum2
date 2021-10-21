using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muzeum
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new TypeForm().Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new MainForm().Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new ExpositionForm().Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new SellerForm().Show();
            this.Hide();
        }
    }
}
