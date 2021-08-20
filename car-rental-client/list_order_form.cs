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
    public partial class list_order_form : Form
    {
        public list_order_form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            user_view.uv_form.Show();
        }

         private void button_list_Click(object sender, EventArgs e)
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
                    if (str_array[0].Equals(user_view.account)) {
                        ListViewItem item = new ListViewItem(str_array[0]);
                        item.SubItems.Add(str_array[1]);
                        item.SubItems.Add(str_array[2]);
                        item.SubItems.Add(str_array[5]);
                        item.SubItems.Add(str_array[8]);
                        informatino_listview.Items.Add(item);
                    }
                }
            }
        }
    }
}
