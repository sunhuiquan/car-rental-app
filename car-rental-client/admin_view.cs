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
    public partial class admin_view : Form
    {
        public static admin_view avf = null;

        public admin_view()
        {
            InitializeComponent();
            avf = this;
        }

        private void go_back_button_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm.login_form.Show();
        }

        private void user_manage_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            user_manage_form umf = new user_manage_form();
            umf.Show();
        }

        private void parking_manage_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            parking_manage_form pmf = new parking_manage_form();
            pmf.Show();
        }

        private void order_manage_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            order_manage_form omf = new order_manage_form();
            omf.Show();
        }

        private void announce_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            announcement_form af = new announcement_form();
            af.Show();
        }
    }
}
