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
    public partial class rental_form : Form
    {
        public rental_form()
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
            if (textBox1.Text == null || textBox1.Text.Length == 0 ||
                textBox2.Text == null || textBox2.Text.Length == 0 ||
                textBox3.Text == null || textBox3.Text.Length == 0 ||
                textBox4.Text == null || textBox4.Text.Length == 0)
                MessageBox.Show("信息不能为空");

            string str = "RENTAL ";
            str += textBox1.Text + " " + textBox2.Text + " " +
                textBox3.Text + " " + textBox4.Text + " \r\n";
            CarRentalClient.send(str);

            int is_closed = 0;
            string response = CarRentalClient.receive(ref is_closed);
            string[] result_arrays = response.Split(' ');
            if (result_arrays[0].Equals("SUCCESS"))
                MessageBox.Show("出租成功");
            else
                MessageBox.Show("出租失败,请仔细检查格式是否错误");
        }
    }
}
