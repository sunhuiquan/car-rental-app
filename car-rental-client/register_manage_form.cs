using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace car_rental_client
{
    public partial class register_manage_form : Form
    {
        private string account = null;

        public register_manage_form()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (account == null)
            {
                MessageBox.Show("无待审批用户");
                return;
            }

            // REGISTER_APPROVE ACCOUNT \r\n
            if (CarRentalRegister.register_approve(account))
                MessageBox.Show("成功");
            else
                MessageBox.Show("错误");

            get_next();

        }



        private void button2_Click(object sender, EventArgs e)
        {
            if (account == null)
            {
                MessageBox.Show("无待审批用户");
                return;
            }

            // REGISTER_FAIL ACCOUNT \r\n
            if (CarRentalRegister.register_fail(account))
                MessageBox.Show("成功");
            else
                MessageBox.Show("错误");

            get_next();
        }

        private void register_manage_form_Load(object sender, EventArgs e)
        {
            get_next();
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            this.Close();
            admin_view.avf.Show();
        }

        private void get_next()
        {
            string[] args = new string[3];
            REGISTER_TYPE ret = CarRentalRegister.get_next(ref args);
            if (ret == REGISTER_TYPE.SUCCESS)
            {
                a.Text = args[0];
                account = args[0];
                b.Text = args[1];
                c.Text = args[2];
                pic.Image = Image.FromFile(CarRentalRegister.path);
            }
            else if (ret == REGISTER_TYPE.EMPTY)
            {
                account = null;
                a.Text = "";
                b.Text = "";
                c.Text = "";
                pic.Image = null;
                MessageBox.Show("无待审批注册用户");
            }
            else
            {
                account = null;
                a.Text = "";
                b.Text = "";
                c.Text = "";
                pic.Image = null;
                MessageBox.Show("错误");
            }
        }
    }
}
