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
    public partial class register_manage_form : Form
    {
        public register_manage_form()
        {
            InitializeComponent();
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            this.Close();
            admin_view.avf.Show();
        }

        private void register_manage_form_Load(object sender, EventArgs e)
        {
            // 自动获取下一个
            // GET_UNSURE_USER /r/n
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 获取下一个
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 通过
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 不通过
        }
    }
}
