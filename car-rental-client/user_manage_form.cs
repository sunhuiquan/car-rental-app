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
    public partial class user_manage_form : Form
    {
        public user_manage_form()
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
            string[] parking_information_array = CarRentalUser.list_user_information();
            if (parking_information_array == null)
            {
                MessageBox.Show("获取失败");
            }
            else
            {
                for (int i = 0; i < parking_information_array.Length & parking_information_array[i] != null; ++i)
                {
                    // account, username, phone, money, score
                    string[] str_array = parking_information_array[i].Split(' ');
                    ListViewItem item = new ListViewItem(str_array[0]);
                    item.SubItems.Add(str_array[1]);
                    item.SubItems.Add(str_array[2]);
                    item.SubItems.Add(str_array[3]);
                    item.SubItems.Add(str_array[4]);
                    informatino_listview.Items.Add(item);
                }
            }
        }
    }
}
