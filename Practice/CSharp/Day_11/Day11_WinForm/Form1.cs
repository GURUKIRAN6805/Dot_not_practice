using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Day11_WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_click_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome to windows");
            TextBox1.Text = "GURUKIRAN";
        }
    }
}
