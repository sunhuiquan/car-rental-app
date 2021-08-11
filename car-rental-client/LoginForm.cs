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

        // 加载窗口开始TCP连接
        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (CarRentalClient.connect() == -1)
            {
                MessageBox.Show("网络连接失败");
                Application.Exit();
            }
        }

        // 游客登录
        private void visitor_login_button_Click(object sender, EventArgs e)
        {
            login_check(CarRentalLogin.login(LOGIN_TYPE.VISITOR));
        }

        // 用户登录
        private void user_login_button_Click(object sender, EventArgs e)
        {
            if (account_text.Text.Length > 20 || passwork_text.Text.Length > 20)
            {
                MessageBox.Show("账号或者密码过长(超过20字符)");
            }
            else
            {
                login_check(CarRentalLogin.login(LOGIN_TYPE.USER, account_text.Text, passwork_text.Text));
            }
        }

        // 管理员登录
        private void administrator_login_button_Click(object sender, EventArgs e)
        {
            if (account_text.Text.Length > 20 || passwork_text.Text.Length > 20)
            {
                MessageBox.Show("账号或者密码过长(超过20字符)");
            }
            else
            {
                login_check(CarRentalLogin.login(LOGIN_TYPE.ADMINISTRATOR, account_text.Text, passwork_text.Text));
            }
        }

        // 这个函数只是对登录结果进行解析并显示而已，登录实现看login
        private void login_check(RESPONSE_RESULT login_result)
        {
            if (login_result == RESPONSE_RESULT.LOGIN_SUCCESS)
            {
                MessageBox.Show("登录成功");

                // to do 进入下一个界面
            }
            else
            {
                account_text.Clear();
                passwork_text.Clear();
                if (login_result == RESPONSE_RESULT.ACCOUNT_NOT_FOUND)
                {
                    MessageBox.Show("账号不存在");
                }
                else if (login_result == RESPONSE_RESULT.PASSWORD_WRONG)
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
            CarRentalClient.close();
            Application.Exit();
        }
    }
}
