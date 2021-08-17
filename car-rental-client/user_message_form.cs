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
    public partial class user_message_form : Form
    {
        public user_message_form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            user_view.uv_form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string message = CarRentalMessage.get_user_message(user_view.account);
            if (message == null)
                MessageBox.Show("查看失败");
            else
            {
                MessageBox.Show("查看成功(空代表无留言)");
                textBox1.Text = message;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == null || textBox2.Text.Length == 0)
            {
                MessageBox.Show("请输入足够信息");
                return;
            }

            if (CarRentalMessage.put_message_to_admin(user_view.account,textBox2.Text) == 0)
                MessageBox.Show("留言成功");
            else
                MessageBox.Show("留言失败");
        }
    }
}
