
namespace car_rental_client
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.account_text = new System.Windows.Forms.TextBox();
            this.passwork_text = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.user_login_button = new System.Windows.Forms.Button();
            this.administrator_login_button = new System.Windows.Forms.Button();
            this.visitor_login_button = new System.Windows.Forms.Button();
            this.quit_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // account_text
            // 
            this.account_text.Location = new System.Drawing.Point(60, 23);
            this.account_text.Name = "account_text";
            this.account_text.Size = new System.Drawing.Size(221, 21);
            this.account_text.TabIndex = 0;
            // 
            // passwork_text
            // 
            this.passwork_text.Location = new System.Drawing.Point(59, 59);
            this.passwork_text.Name = "passwork_text";
            this.passwork_text.Size = new System.Drawing.Size(222, 21);
            this.passwork_text.TabIndex = 1;
            this.passwork_text.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "账号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "密码：";
            // 
            // user_login_button
            // 
            this.user_login_button.Location = new System.Drawing.Point(82, 89);
            this.user_login_button.Name = "user_login_button";
            this.user_login_button.Size = new System.Drawing.Size(61, 24);
            this.user_login_button.TabIndex = 3;
            this.user_login_button.Text = "用户登录";
            this.user_login_button.UseVisualStyleBackColor = true;
            this.user_login_button.Click += new System.EventHandler(this.user_login_button_Click);
            // 
            // administrator_login_button
            // 
            this.administrator_login_button.Location = new System.Drawing.Point(149, 89);
            this.administrator_login_button.Name = "administrator_login_button";
            this.administrator_login_button.Size = new System.Drawing.Size(80, 24);
            this.administrator_login_button.TabIndex = 4;
            this.administrator_login_button.Text = "管理员登录";
            this.administrator_login_button.UseVisualStyleBackColor = true;
            this.administrator_login_button.Click += new System.EventHandler(this.administrator_login_button_Click);
            // 
            // visitor_login_button
            // 
            this.visitor_login_button.Location = new System.Drawing.Point(15, 89);
            this.visitor_login_button.Name = "visitor_login_button";
            this.visitor_login_button.Size = new System.Drawing.Size(61, 23);
            this.visitor_login_button.TabIndex = 2;
            this.visitor_login_button.Text = "游客登陆";
            this.visitor_login_button.UseVisualStyleBackColor = true;
            this.visitor_login_button.Click += new System.EventHandler(this.visitor_login_button_Click);
            // 
            // quit_button
            // 
            this.quit_button.Location = new System.Drawing.Point(235, 89);
            this.quit_button.Name = "quit_button";
            this.quit_button.Size = new System.Drawing.Size(46, 24);
            this.quit_button.TabIndex = 5;
            this.quit_button.Text = "退出";
            this.quit_button.UseVisualStyleBackColor = true;
            this.quit_button.Click += new System.EventHandler(this.quit_button_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 133);
            this.Controls.Add(this.quit_button);
            this.Controls.Add(this.visitor_login_button);
            this.Controls.Add(this.administrator_login_button);
            this.Controls.Add(this.user_login_button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passwork_text);
            this.Controls.Add(this.account_text);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox account_text;
        private System.Windows.Forms.TextBox passwork_text;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button user_login_button;
        private System.Windows.Forms.Button administrator_login_button;
        private System.Windows.Forms.Button visitor_login_button;
        private System.Windows.Forms.Button quit_button;
    }
}