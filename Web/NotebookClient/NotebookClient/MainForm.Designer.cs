
namespace NotebookClient
{
    partial class MainForm
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
            this.listView = new System.Windows.Forms.ListView();
            this.clmFirstName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmSecondName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmBirthDay = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dsplBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.cngBtn = new System.Windows.Forms.Button();
            this.delBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmFirstName,
            this.clmSecondName,
            this.clmBirthDay});
            this.listView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(12, 29);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(596, 283);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // clmFirstName
            // 
            this.clmFirstName.Text = "Имя";
            this.clmFirstName.Width = 150;
            // 
            // clmSecondName
            // 
            this.clmSecondName.Text = "Фамилия";
            this.clmSecondName.Width = 200;
            // 
            // clmBirthDay
            // 
            this.clmBirthDay.Text = "Дата рождения";
            this.clmBirthDay.Width = 120;
            // 
            // dsplBtn
            // 
            this.dsplBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dsplBtn.Location = new System.Drawing.Point(12, 326);
            this.dsplBtn.Name = "dsplBtn";
            this.dsplBtn.Size = new System.Drawing.Size(119, 46);
            this.dsplBtn.TabIndex = 1;
            this.dsplBtn.Text = "Отобразить";
            this.dsplBtn.UseVisualStyleBackColor = true;
            this.dsplBtn.Click += new System.EventHandler(this.dsplBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.addBtn.Location = new System.Drawing.Point(181, 326);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(119, 46);
            this.addBtn.TabIndex = 2;
            this.addBtn.Text = "Добавить";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // cngBtn
            // 
            this.cngBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cngBtn.Location = new System.Drawing.Point(336, 326);
            this.cngBtn.Name = "cngBtn";
            this.cngBtn.Size = new System.Drawing.Size(119, 46);
            this.cngBtn.TabIndex = 3;
            this.cngBtn.Text = "Изменить";
            this.cngBtn.UseVisualStyleBackColor = true;
            this.cngBtn.Click += new System.EventHandler(this.cngBtn_Click);
            // 
            // delBtn
            // 
            this.delBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.delBtn.Location = new System.Drawing.Point(489, 326);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(119, 46);
            this.delBtn.TabIndex = 4;
            this.delBtn.Text = "Удалить";
            this.delBtn.UseVisualStyleBackColor = true;
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 384);
            this.Controls.Add(this.delBtn);
            this.Controls.Add(this.cngBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.dsplBtn);
            this.Controls.Add(this.listView);
            this.Name = "MainForm";
            this.Text = "Клиент";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Button dsplBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button cngBtn;
        private System.Windows.Forms.Button delBtn;
        private System.Windows.Forms.ColumnHeader clmFirstName;
        private System.Windows.Forms.ColumnHeader clmSecondName;
        private System.Windows.Forms.ColumnHeader clmBirthDay;
    }
}

