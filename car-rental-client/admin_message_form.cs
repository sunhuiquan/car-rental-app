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
    public partial class admin_message_form : Form
    {
        public admin_message_form()
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
            if (textBox3.Text == null || textBox3.Text.Length == 0 ||
                textBox2.Text == null || textBox2.Text.Length == 0)
            {
                MessageBox.Show("请输入足够信息");
                return;
            }

            if (CarRentalMessage.put_message_to_user(textBox3.Text, textBox2.Text) == 0)
                MessageBox.Show("留言成功");
            else
                MessageBox.Show("留言失败");
        }
    }
}
