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
    public partial class order_manage_form : Form
    {
        public order_manage_form()
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
            informatino_listview.Items.Clear();
            string[] parking_information_array = CarRentalUser.list_order_information();
            if (parking_information_array == null)
            {
                MessageBox.Show("获取失败");
            }
            else
            {
                for (int i = 0; i < parking_information_array.Length & parking_information_array[i] != null; ++i)
                {
                    // account, id, start_time, end_time, cost
                    string[] str_array = parking_information_array[i].Split(' ');
                    ListViewItem item = new ListViewItem(str_array[0]);
                    item.SubItems.Add(str_array[1]);
                    item.SubItems.Add(str_array[2]);
                    item.SubItems.Add(str_array[4]);
                    item.SubItems.Add(str_array[6]);
                    informatino_listview.Items.Add(item);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // BAN_ORDER ACCOUNT ID \r\n
            if (textBox1.Text == null || textBox1.Text.Length == 0 || textBox2.Text == null || textBox2.Text.Length == 0)
            {
                MessageBox.Show("请输入信息");
                return;
            }
            CarRentalClient.send("BAN_ORDER " + textBox1.Text + " " + textBox2.Text + " \r\n");
            int is_closed = 0;
            string str = CarRentalClient.receive(ref is_closed);
            if (str.Split(' ')[0].Equals("SUCCESS"))
            {
                MessageBox.Show("删除订单成功(或本来就没有该订单)");

                // 刷新列表
                informatino_listview.Items.Clear();
                string[] parking_information_array = CarRentalUser.list_order_information();
                if (parking_information_array == null)
                {
                    MessageBox.Show("获取失败");
                }
                else
                {
                    for (int i = 0; i < parking_information_array.Length & parking_information_array[i] != null; ++i)
                    {
                        // account, id, start_time, end_time, cost
                        string[] str_array = parking_information_array[i].Split(' ');
                        ListViewItem item = new ListViewItem(str_array[0]);
                        item.SubItems.Add(str_array[1]);
                        item.SubItems.Add(str_array[2]);
                        item.SubItems.Add(str_array[4]);
                        item.SubItems.Add(str_array[6]);
                        informatino_listview.Items.Add(item);
                    }
                }
            }
            else
                MessageBox.Show("失败");
        }
    }
}
