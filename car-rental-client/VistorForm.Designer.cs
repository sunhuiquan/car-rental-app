
namespace car_rental_client
{
    partial class VistorForm
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
            this.back_button = new System.Windows.Forms.Button();
            this.parking_information_button = new System.Windows.Forms.Button();
            this.information_view = new System.Windows.Forms.ListView();
            this.location = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.time_start = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.time_end = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // back_button
            // 
            this.back_button.Location = new System.Drawing.Point(126, 12);
            this.back_button.Name = "back_button";
            this.back_button.Size = new System.Drawing.Size(96, 23);
            this.back_button.TabIndex = 0;
            this.back_button.Text = "退出登录";
            this.back_button.UseVisualStyleBackColor = true;
            this.back_button.Click += new System.EventHandler(this.back_button_Click);
            // 
            // parking_information_button
            // 
            this.parking_information_button.Location = new System.Drawing.Point(12, 12);
            this.parking_information_button.Name = "parking_information_button";
            this.parking_information_button.Size = new System.Drawing.Size(96, 23);
            this.parking_information_button.TabIndex = 1;
            this.parking_information_button.Text = "浏览所有车位信息";
            this.parking_information_button.UseVisualStyleBackColor = true;
            this.parking_information_button.Click += new System.EventHandler(this.parking_information_button_Click);
            // 
            // information_view
            // 
            this.information_view.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.location,
            this.price,
            this.time_start,
            this.time_end});
            this.information_view.HideSelection = false;
            this.information_view.Location = new System.Drawing.Point(12, 41);
            this.information_view.Name = "information_view";
            this.information_view.Size = new System.Drawing.Size(592, 397);
            this.information_view.TabIndex = 2;
            this.information_view.UseCompatibleStateImageBehavior = false;
            this.information_view.View = System.Windows.Forms.View.Details;
            // 
            // location
            // 
            this.location.Text = "车位位置";
            this.location.Width = 283;
            // 
            // time_start
            // 
            this.time_start.DisplayIndex = 1;
            this.time_start.Text = "空闲时间起点";
            this.time_start.Width = 101;
            // 
            // time_end
            // 
            this.time_end.DisplayIndex = 2;
            this.time_end.Text = "空闲时间终点";
            this.time_end.Width = 127;
            // 
            // price
            // 
            this.price.Text = "价格(小时)";
            this.price.Width = 77;
            // 
            // VistorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 450);
            this.Controls.Add(this.information_view);
            this.Controls.Add(this.parking_information_button);
            this.Controls.Add(this.back_button);
            this.Name = "VistorForm";
            this.Text = "VistorForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button back_button;
        private System.Windows.Forms.Button parking_information_button;
        private System.Windows.Forms.ListView information_view;
        private System.Windows.Forms.ColumnHeader location;
        private System.Windows.Forms.ColumnHeader price;
        private System.Windows.Forms.ColumnHeader time_start;
        private System.Windows.Forms.ColumnHeader time_end;
    }
}