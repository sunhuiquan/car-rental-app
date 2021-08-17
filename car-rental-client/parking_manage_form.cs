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
    public partial class parking_manage_form : Form
    {
        public parking_manage_form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            informatino_listview.Items.Clear();
            string[] parking_information_array = CarRentalSearch.list_parking_information();
            if (parking_information_array == null)
            {
                MessageBox.Show("获取失败");
            }
            else
            {
                for (int i = 0; i < parking_information_array.Length & parking_information_array[i] != null; ++i)
                {
                    string[] str_array = parking_information_array[i].Split(' ');
                    ListViewItem item = new ListViewItem(str_array[6]);
                    item.SubItems.Add(str_array[0]);
                    item.SubItems.Add(str_array[1]);
                    item.SubItems.Add(str_array[2]);
                    item.SubItems.Add(str_array[4]);
                    if (int.Parse(str_array[7]) == 0)
                        item.SubItems.Add("未租借");
                    else
                        item.SubItems.Add("已被租借");
                    informatino_listview.Items.Add(item);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // BAN_PARKING ID \r\n
            if (textBox1.Text == null || textBox1.Text.Length == 0)
            {
                MessageBox.Show("未输入要删除的车位id");
                return;
            }
            CarRentalClient.send("BAN_PARKING " + textBox1.Text + " \r\n");
            int is_closed = 0;
            string str = CarRentalClient.receive(ref is_closed);
            if (str.Split(' ')[0].Equals("SUCCESS"))
            {
                MessageBox.Show("删除成功(或本来就没有该车位)");

                informatino_listview.Items.Clear();
                string[] parking_information_array = CarRentalSearch.list_parking_information();
                if (parking_information_array == null)
                {
                    MessageBox.Show("刷新失败");
                }
                else
                {
                    for (int i = 0; i < parking_information_array.Length & parking_information_array[i] != null; ++i)
                    {
                        string[] str_array = parking_information_array[i].Split(' ');
                        ListViewItem item = new ListViewItem(str_array[6]);
                        item.SubItems.Add(str_array[0]);
                        item.SubItems.Add(str_array[1]);
                        item.SubItems.Add(str_array[2]);
                        item.SubItems.Add(str_array[4]);
                        informatino_listview.Items.Add(item);
                    }
                }
            }
            else
                MessageBox.Show("失败");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            admin_view.avf.Show();
        }
    }
}
