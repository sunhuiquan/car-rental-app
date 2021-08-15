
namespace car_rental_client
{
    partial class user_view
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
            this.list_parking_information_button = new System.Windows.Forms.Button();
            this.go_back_button = new System.Windows.Forms.Button();
            this.search_button = new System.Windows.Forms.Button();
            this.location_text = new System.Windows.Forms.TextBox();
            this.rent_days_text = new System.Windows.Forms.TextBox();
            this.time_strat_text = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.price_text = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.informatino_listview = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.location = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.time_start = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.time_end = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.reflush_button = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.account_label = new System.Windows.Forms.Label();
            this.username_label = new System.Windows.Forms.Label();
            this.score_label = new System.Windows.Forms.Label();
            this.order_button = new System.Windows.Forms.Button();
            this.release_parking_button = new System.Windows.Forms.Button();
            this.buy_button = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.message_button = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.money = new System.Windows.Forms.Label();
            this.charge_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // list_parking_information_button
            // 
            this.list_parking_information_button.Location = new System.Drawing.Point(119, 188);
            this.list_parking_information_button.Name = "list_parking_information_button";
            this.list_parking_information_button.Size = new System.Drawing.Size(87, 23);
            this.list_parking_information_button.TabIndex = 0;
            this.list_parking_information_button.Text = "浏览全部车位";
            this.list_parking_information_button.UseVisualStyleBackColor = true;
            this.list_parking_information_button.Click += new System.EventHandler(this.list_parking_information_button_Click);
            // 
            // go_back_button
            // 
            this.go_back_button.Location = new System.Drawing.Point(291, 158);
            this.go_back_button.Name = "go_back_button";
            this.go_back_button.Size = new System.Drawing.Size(121, 23);
            this.go_back_button.TabIndex = 1;
            this.go_back_button.Text = "退出登录";
            this.go_back_button.UseVisualStyleBackColor = true;
            this.go_back_button.Click += new System.EventHandler(this.go_back_button_Click);
            // 
            // search_button
            // 
            this.search_button.Location = new System.Drawing.Point(12, 188);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(75, 23);
            this.search_button.TabIndex = 2;
            this.search_button.Text = "查询按钮";
            this.search_button.UseVisualStyleBackColor = true;
            this.search_button.Click += new System.EventHandler(this.search_button_Click);
            // 
            // location_text
            // 
            this.location_text.Location = new System.Drawing.Point(13, 24);
            this.location_text.Name = "location_text";
            this.location_text.Size = new System.Drawing.Size(167, 21);
            this.location_text.TabIndex = 3;
            // 
            // rent_days_text
            // 
            this.rent_days_text.Location = new System.Drawing.Point(12, 106);
            this.rent_days_text.Name = "rent_days_text";
            this.rent_days_text.Size = new System.Drawing.Size(168, 21);
            this.rent_days_text.TabIndex = 4;
            // 
            // time_strat_text
            // 
            this.time_strat_text.Location = new System.Drawing.Point(12, 67);
            this.time_strat_text.Name = "time_strat_text";
            this.time_strat_text.Size = new System.Drawing.Size(168, 21);
            this.time_strat_text.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "位置(可少不可多写)";
            // 
            // price_text
            // 
            this.price_text.Location = new System.Drawing.Point(12, 149);
            this.price_text.Name = "price_text";
            this.price_text.Size = new System.Drawing.Size(168, 21);
            this.price_text.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "租用时间(YYYY-MM-DD格式)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "租用天数";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "最高价格(每天)";
            // 
            // informatino_listview
            // 
            this.informatino_listview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.location,
            this.price,
            this.time_start,
            this.time_end,
            this.cost});
            this.informatino_listview.HideSelection = false;
            this.informatino_listview.Location = new System.Drawing.Point(13, 217);
            this.informatino_listview.Name = "informatino_listview";
            this.informatino_listview.Size = new System.Drawing.Size(540, 372);
            this.informatino_listview.TabIndex = 11;
            this.informatino_listview.UseCompatibleStateImageBehavior = false;
            this.informatino_listview.View = System.Windows.Forms.View.Details;
            // 
            // id
            // 
            this.id.Text = "id";
            this.id.Width = 99;
            // 
            // location
            // 
            this.location.Text = "位置";
            this.location.Width = 146;
            // 
            // price
            // 
            this.price.Text = "价格(每天)";
            this.price.Width = 75;
            // 
            // time_start
            // 
            this.time_start.Text = "开始时间";
            this.time_start.Width = 73;
            // 
            // time_end
            // 
            this.time_end.Text = "结束时间";
            this.time_end.Width = 82;
            // 
            // cost
            // 
            this.cost.Text = "总花费";
            // 
            // reflush_button
            // 
            this.reflush_button.Location = new System.Drawing.Point(198, 129);
            this.reflush_button.Name = "reflush_button";
            this.reflush_button.Size = new System.Drawing.Size(75, 23);
            this.reflush_button.TabIndex = 12;
            this.reflush_button.Text = "刷新信息";
            this.reflush_button.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(196, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "个人中心：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(211, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "账号：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(211, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "用户名：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(211, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 17;
            this.label8.Text = "积分：";
            // 
            // account_label
            // 
            this.account_label.AutoSize = true;
            this.account_label.Location = new System.Drawing.Point(273, 27);
            this.account_label.Name = "account_label";
            this.account_label.Size = new System.Drawing.Size(0, 12);
            this.account_label.TabIndex = 18;
            // 
            // username_label
            // 
            this.username_label.AutoSize = true;
            this.username_label.Location = new System.Drawing.Point(273, 48);
            this.username_label.Name = "username_label";
            this.username_label.Size = new System.Drawing.Size(0, 12);
            this.username_label.TabIndex = 19;
            // 
            // score_label
            // 
            this.score_label.AutoSize = true;
            this.score_label.Location = new System.Drawing.Point(273, 70);
            this.score_label.Name = "score_label";
            this.score_label.Size = new System.Drawing.Size(0, 12);
            this.score_label.TabIndex = 20;
            // 
            // order_button
            // 
            this.order_button.Location = new System.Drawing.Point(234, 188);
            this.order_button.Name = "order_button";
            this.order_button.Size = new System.Drawing.Size(88, 23);
            this.order_button.TabIndex = 21;
            this.order_button.Text = "查询用户订单";
            this.order_button.UseVisualStyleBackColor = true;
            // 
            // release_parking_button
            // 
            this.release_parking_button.Location = new System.Drawing.Point(341, 188);
            this.release_parking_button.Name = "release_parking_button";
            this.release_parking_button.Size = new System.Drawing.Size(136, 23);
            this.release_parking_button.TabIndex = 22;
            this.release_parking_button.Text = "发布订单(进入新窗口)";
            this.release_parking_button.UseVisualStyleBackColor = true;
            // 
            // buy_button
            // 
            this.buy_button.Location = new System.Drawing.Point(225, 619);
            this.buy_button.Name = "buy_button";
            this.buy_button.Size = new System.Drawing.Size(75, 23);
            this.buy_button.TabIndex = 23;
            this.buy_button.Text = "预约订单";
            this.buy_button.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(13, 619);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 21);
            this.textBox5.TabIndex = 24;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(119, 619);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 21);
            this.textBox6.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 604);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 26;
            this.label9.Text = "id:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(119, 603);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 27;
            this.label10.Text = "租用天数:";
            // 
            // message_button
            // 
            this.message_button.Location = new System.Drawing.Point(291, 129);
            this.message_button.Name = "message_button";
            this.message_button.Size = new System.Drawing.Size(117, 23);
            this.message_button.TabIndex = 28;
            this.message_button.Text = "留言(进入新窗口)";
            this.message_button.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(211, 91);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 29;
            this.label11.Text = "金额：";
            // 
            // money
            // 
            this.money.AutoSize = true;
            this.money.Location = new System.Drawing.Point(273, 91);
            this.money.Name = "money";
            this.money.Size = new System.Drawing.Size(0, 12);
            this.money.TabIndex = 30;
            // 
            // charge_button
            // 
            this.charge_button.Location = new System.Drawing.Point(198, 159);
            this.charge_button.Name = "charge_button";
            this.charge_button.Size = new System.Drawing.Size(75, 23);
            this.charge_button.TabIndex = 31;
            this.charge_button.Text = "充值";
            this.charge_button.UseVisualStyleBackColor = true;
            // 
            // user_view
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 659);
            this.Controls.Add(this.charge_button);
            this.Controls.Add(this.money);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.message_button);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.buy_button);
            this.Controls.Add(this.release_parking_button);
            this.Controls.Add(this.order_button);
            this.Controls.Add(this.score_label);
            this.Controls.Add(this.username_label);
            this.Controls.Add(this.account_label);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.reflush_button);
            this.Controls.Add(this.informatino_listview);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.price_text);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.time_strat_text);
            this.Controls.Add(this.rent_days_text);
            this.Controls.Add(this.location_text);
            this.Controls.Add(this.search_button);
            this.Controls.Add(this.go_back_button);
            this.Controls.Add(this.list_parking_information_button);
            this.Name = "user_view";
            this.Text = "user_view";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button list_parking_information_button;
        private System.Windows.Forms.Button go_back_button;
        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.TextBox location_text;
        private System.Windows.Forms.TextBox rent_days_text;
        private System.Windows.Forms.TextBox time_strat_text;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox price_text;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView informatino_listview;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader location;
        private System.Windows.Forms.ColumnHeader price;
        private System.Windows.Forms.ColumnHeader time_start;
        private System.Windows.Forms.ColumnHeader time_end;
        private System.Windows.Forms.ColumnHeader cost;
        private System.Windows.Forms.Button reflush_button;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label account_label;
        private System.Windows.Forms.Label username_label;
        private System.Windows.Forms.Label score_label;
        private System.Windows.Forms.Button order_button;
        private System.Windows.Forms.Button release_parking_button;
        private System.Windows.Forms.Button buy_button;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button message_button;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label money;
        private System.Windows.Forms.Button charge_button;
    }
}