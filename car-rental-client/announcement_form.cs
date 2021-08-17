using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace car_rental_client
{
    public partial class announcement_form : Form
    {
        public announcement_form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            admin_view.avf.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CarRentalMessage.announce(textBox1.Text) != 0)
                MessageBox.Show("发出错误");
            else
                MessageBox.Show("成功");
            textBox1.Clear();
        }
    }
}
