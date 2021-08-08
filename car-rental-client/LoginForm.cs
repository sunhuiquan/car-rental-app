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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        // 游客登录
        private void visitor_login_button_Click(object sender, EventArgs e)
        {

        }

        // 用户登录
        private void user_login_button_Click(object sender, EventArgs e)
        {
        }

        // 管理员登录
        private void administrator_login_button_Click(object sender, EventArgs e)
        {

        }

        // 退出
        private void quit_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
