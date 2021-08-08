using System;
using System.Windows.Forms;

namespace car_rental_client
{
    public enum LOGIN_TYPE { VISITOR, USER, ADMINISTRATOR }

    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        // 游客登录
        private void visitor_login_button_Click(object sender, EventArgs e)
        {
            login_check(CarRentalLogin.login(LOGIN_TYPE.VISITOR));
        }

        // 用户登录
        private void user_login_button_Click(object sender, EventArgs e)
        {
            login_check(CarRentalLogin.login(LOGIN_TYPE.USER, account_text.Text, passwork_text.Text));
        }

        // 管理员登录
        private void administrator_login_button_Click(object sender, EventArgs e)
        {
            login_check(CarRentalLogin.login(LOGIN_TYPE.ADMINISTRATOR, account_text.Text, passwork_text.Text));
        }

        private void login_check(LOGIN_RESULT login_result)
        {
            if (login_result == LOGIN_RESULT.LOGIN_SUCCESS)
            {
                MessageBox.Show("登录成功");
            }
            else
            {
                account_text.Clear();
                passwork_text.Clear();
                if (login_result == LOGIN_RESULT.ACCOUNT_NOT_FOUND)
                {
                    MessageBox.Show("账号不存在");
                }
                else if (login_result == LOGIN_RESULT.PASSWORD_WRONG)
                {
                    MessageBox.Show("密码错误");
                }
                else
                {
                    MessageBox.Show("其他错误(可能是网络错误)");
                }
            }
        }

        // 退出
        private void quit_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
