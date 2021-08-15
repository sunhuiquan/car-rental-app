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
    public partial class user_view : Form
    {
        public user_view()
        {
            InitializeComponent();
        }

        private void list_parking_information_button_Click(object sender, EventArgs e)
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
                    informatino_listview.Items.Add(item);
                }
            }
        }

        private void go_back_button_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm.login_form.Show();
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            string[] args = new string[4];
            args[0] = location_text.Text;
            args[1] = time_strat_text.Text;
            args[2] = rent_days_text.Text;
            args[3] = price_text.Text;

            informatino_listview.Items.Clear();
            string[] parking_information_array = CarRentalSearch.search_parking_information(args);
            if (parking_information_array == null)
            {
                MessageBox.Show("无符合项或者格式错误");
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
    }
}
