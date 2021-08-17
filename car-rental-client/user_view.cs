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
        public static user_view uv_form = null;
        public static string account = null;
        public user_view()
        {
            InitializeComponent();
            uv_form = this;
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
                    if (int.Parse(str_array[7]) == 0)
                    {
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
                    if (int.Parse(str_array[7]) == 0)
                    {
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

        private void release_parking_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            rental_form rf = new rental_form();
            rf.Show();
        }

        private void charge_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            chage_form cf = new chage_form();
            cf.Show();
        }

        private void reflush_button_Click(object sender, EventArgs e)
        {
            if (user_view.account == null)
            {
                MessageBox.Show("错误account为null");
                return;
            }
            string[] user_information = CarRentalUser.get_user_information(user_view.account);
            if (user_information == null || user_information.Length != 6)
            {
                MessageBox.Show("无此账号，请确认输入的是正确的account");
            }
            else
            {
                // USER_INFORMATION ACCOUNT USERNAME SCORE MONEY \r\n
                MessageBox.Show("刷新成功");
                account_label.Text = user_information[1];
                username_label.Text = user_information[2];
                score_label.Text = user_information[3];
                money_label.Text = user_information[4];
            }
        }

        private void user_view_Load(object sender, EventArgs e)
        {
            if (user_view.account == null || account.Length == 0)
            {
                MessageBox.Show("错误account为空");
                return;
            }
            string[] user_information = CarRentalUser.get_user_information(user_view.account);
            if (user_information == null || user_information.Length != 6)
            {
                MessageBox.Show("无此账号，请确认输入的是正确的account");
            }
            else
            {
                // USER_INFORMATION ACCOUNT USERNAME SCORE MONEY \r\n
                account_label.Text = user_information[1];
                username_label.Text = user_information[2];
                score_label.Text = user_information[3];
                money_label.Text = user_information[4];
            }
        }

        private void buy_button_Click(object sender, EventArgs e)
        {
            if (text1.Text == null || text1.Text.Length == 0
                || text2.Text == null || text2.Text.Length == 0
                || text3.Text == null || text3.Text.Length == 0)
            {
                MessageBox.Show("租借条件不足，请输入信息");
                return;
            }

            // ORDER ACCOUNT ID TIME_START DAYS \r\n
            CarRentalClient.send("ORDER " + user_view.account + " "
                + text1.Text + " " + text2.Text + " " + text3.Text + " \r\n");

            int i = 0;
            string rec = CarRentalClient.receive(ref i);
            if (rec.Split(' ')[0].Equals("SUCCESS"))
                MessageBox.Show("成功");
            else if (rec.Split(' ')[0].Equals("ID_OR_DATE_WRONG"))
                MessageBox.Show("无此id的车或者无法满足日期要求错误");
            else if (rec.Split(' ')[0].Equals("MONEY_WRONG"))
                MessageBox.Show("余额不足");
            else if(rec.Split(' ')[0].Equals("HAS_ORDERED_WRONG"))
                MessageBox.Show("该车位已经被订购");
            else
                MessageBox.Show("其他错误");

            // 刷新用户信息(主要是刷新余额和积分)
            if (user_view.account == null || account.Length == 0)
            {
                MessageBox.Show("错误account为空");
                return;
            }
            string[] user_information = CarRentalUser.get_user_information(user_view.account);
            if (user_information == null || user_information.Length != 6)
            {
                MessageBox.Show("无此账号，请确认输入的是正确的account");
            }
            else
            {
                // USER_INFORMATION ACCOUNT USERNAME SCORE MONEY \r\n
                account_label.Text = user_information[1];
                username_label.Text = user_information[2];
                score_label.Text = user_information[3];
                money_label.Text = user_information[4];
            }
        }

        private void order_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            list_order_form lof = new list_order_form();
            lof.Show();
        }
    }
}
