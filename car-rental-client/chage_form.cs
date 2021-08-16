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
    public partial class chage_form : Form
    {
        public chage_form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            user_view.uv_form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox1.Text.Length == 0 || user_view.account == null)
            {
                MessageBox.Show("格式或其他错误");
                return;
            }

            try
            {
                int.Parse(textBox1.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("格式错误");
                return;
            }

            // CHARGE_MONEY VALUE \r\n
            CarRentalClient.send("CHARGE_MONEY " + user_view.account + " " + textBox1.Text + " \r\n");
            int i = 0;
            string rec = CarRentalClient.receive(ref i);
            if (rec.Split(' ')[0].Equals("SUCCESS"))
                MessageBox.Show("充值成功");
            else
                MessageBox.Show("充值失败");
        }
    }
}
