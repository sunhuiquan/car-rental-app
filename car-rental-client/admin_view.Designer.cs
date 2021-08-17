
namespace car_rental_client
{
    partial class admin_view
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
            this.register_control_button = new System.Windows.Forms.Button();
            this.user_manage_button = new System.Windows.Forms.Button();
            this.message_manage_button = new System.Windows.Forms.Button();
            this.announce_button = new System.Windows.Forms.Button();
            this.order_manage_button = new System.Windows.Forms.Button();
            this.parking_manage_button = new System.Windows.Forms.Button();
            this.go_back_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // register_control_button
            // 
            this.register_control_button.Location = new System.Drawing.Point(13, 13);
            this.register_control_button.Name = "register_control_button";
            this.register_control_button.Size = new System.Drawing.Size(97, 23);
            this.register_control_button.TabIndex = 0;
            this.register_control_button.Text = "审批用户注册";
            this.register_control_button.UseVisualStyleBackColor = true;
            // 
            // user_manage_button
            // 
            this.user_manage_button.Location = new System.Drawing.Point(13, 43);
            this.user_manage_button.Name = "user_manage_button";
            this.user_manage_button.Size = new System.Drawing.Size(97, 23);
            this.user_manage_button.TabIndex = 1;
            this.user_manage_button.Text = "用户管理";
            this.user_manage_button.UseVisualStyleBackColor = true;
            this.user_manage_button.Click += new System.EventHandler(this.user_manage_button_Click);
            // 
            // message_manage_button
            // 
            this.message_manage_button.Location = new System.Drawing.Point(13, 73);
            this.message_manage_button.Name = "message_manage_button";
            this.message_manage_button.Size = new System.Drawing.Size(97, 23);
            this.message_manage_button.TabIndex = 2;
            this.message_manage_button.Text = "留言管理";
            this.message_manage_button.UseVisualStyleBackColor = true;
            // 
            // announce_button
            // 
            this.announce_button.Location = new System.Drawing.Point(13, 103);
            this.announce_button.Name = "announce_button";
            this.announce_button.Size = new System.Drawing.Size(97, 23);
            this.announce_button.TabIndex = 3;
            this.announce_button.Text = "发布公告";
            this.announce_button.UseVisualStyleBackColor = true;
            // 
            // order_manage_button
            // 
            this.order_manage_button.Location = new System.Drawing.Point(13, 133);
            this.order_manage_button.Name = "order_manage_button";
            this.order_manage_button.Size = new System.Drawing.Size(97, 23);
            this.order_manage_button.TabIndex = 4;
            this.order_manage_button.Text = "订单管理";
            this.order_manage_button.UseVisualStyleBackColor = true;
            this.order_manage_button.Click += new System.EventHandler(this.order_manage_button_Click);
            // 
            // parking_manage_button
            // 
            this.parking_manage_button.Location = new System.Drawing.Point(13, 163);
            this.parking_manage_button.Name = "parking_manage_button";
            this.parking_manage_button.Size = new System.Drawing.Size(97, 23);
            this.parking_manage_button.TabIndex = 5;
            this.parking_manage_button.Text = "车位管理";
            this.parking_manage_button.UseVisualStyleBackColor = true;
            this.parking_manage_button.Click += new System.EventHandler(this.parking_manage_button_Click);
            // 
            // go_back_button
            // 
            this.go_back_button.Location = new System.Drawing.Point(13, 193);
            this.go_back_button.Name = "go_back_button";
            this.go_back_button.Size = new System.Drawing.Size(97, 23);
            this.go_back_button.TabIndex = 6;
            this.go_back_button.Text = "返回";
            this.go_back_button.UseVisualStyleBackColor = true;
            this.go_back_button.Click += new System.EventHandler(this.go_back_button_Click);
            // 
            // admin_view
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 224);
            this.Controls.Add(this.go_back_button);
            this.Controls.Add(this.parking_manage_button);
            this.Controls.Add(this.order_manage_button);
            this.Controls.Add(this.announce_button);
            this.Controls.Add(this.message_manage_button);
            this.Controls.Add(this.user_manage_button);
            this.Controls.Add(this.register_control_button);
            this.Name = "admin_view";
            this.Text = "admin_view";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button register_control_button;
        private System.Windows.Forms.Button user_manage_button;
        private System.Windows.Forms.Button message_manage_button;
        private System.Windows.Forms.Button announce_button;
        private System.Windows.Forms.Button order_manage_button;
        private System.Windows.Forms.Button parking_manage_button;
        private System.Windows.Forms.Button go_back_button;
    }
}