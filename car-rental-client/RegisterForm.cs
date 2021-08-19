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
    public partial class RegisterForm : Form
    {
        private string pic_file_name = null;

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void pic_choose_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.RestoreDirectory = true;
            DialogResult result = fileDialog.ShowDialog();
            string[] name = fileDialog.FileName.Split('.');

            if (result == DialogResult.OK && (name[name.Length - 1].Equals("jpg") || name[name.Length - 1].Equals("png")))
            {
                pic_file_name = fileDialog.FileName;
                pic.Image = Image.FromFile(fileDialog.FileName);
            }
            else
            {
                MessageBox.Show("只能识别.jpg和.png后缀图片");
            }
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm.login_form.Show();
        }

        private void register_button_Click(object sender, EventArgs e)
        {
            if (pic_file_name == null)
            {
                MessageBox.Show("未选择图片");
            }
            else if (account_text.Text == null || account_text.Text.Length == 0)
            {
                MessageBox.Show("账号不能为空");
            }
            else if (password_text.Text == null || password_text.Text.Length == 0)
            {
                MessageBox.Show("密码不能为空");
            }
            else if (username_text.Text == null || username_text.Text.Length == 0)
            {
                MessageBox.Show("用户名不能为空");
            }
            else if (phone_text.Text == null || phone_text.Text.Length == 0)
            {
                MessageBox.Show("电话不能为空");
            }
            else if (password2.Text == null || password2.Text.Length == 0)
            {
                MessageBox.Show("请重复密码");
            }
            else if (password_text.Text.Equals(password2.Text) == false)
            {
                MessageBox.Show("两次输入密码不同");
            }
            else
            {
                if (CarRentalRegister.register(account_text.Text, password_text.Text,
                    username_text.Text, phone_text.Text, pic_file_name) == false)
                {
                    MessageBox.Show("注册请求失败");
                }
                else
                {
                    MessageBox.Show("注册请求已发送，请等待管理员审批");
                }
                this.Close();
                LoginForm.login_form.Show();
            }
        }
    }
}
