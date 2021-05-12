
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
            this.contactListView = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.delContactBtn = new System.Windows.Forms.Button();
            this.chgContactBtn = new System.Windows.Forms.Button();
            this.addContactBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(500, 285);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            // 
            // clmFirstName
            // 
            this.clmFirstName.Text = "Имя";
            this.clmFirstName.Width = 176;
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
            this.dsplBtn.Location = new System.Drawing.Point(12, 320);
            this.dsplBtn.Name = "dsplBtn";
            this.dsplBtn.Size = new System.Drawing.Size(100, 40);
            this.dsplBtn.TabIndex = 1;
            this.dsplBtn.Text = "Отобразить";
            this.dsplBtn.UseVisualStyleBackColor = true;
            this.dsplBtn.Click += new System.EventHandler(this.dsplBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.addBtn.Location = new System.Drawing.Point(145, 320);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(100, 40);
            this.addBtn.TabIndex = 2;
            this.addBtn.Text = "Добавить";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // cngBtn
            // 
            this.cngBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cngBtn.Location = new System.Drawing.Point(278, 320);
            this.cngBtn.Name = "cngBtn";
            this.cngBtn.Size = new System.Drawing.Size(100, 40);
            this.cngBtn.TabIndex = 3;
            this.cngBtn.Text = "Изменить";
            this.cngBtn.UseVisualStyleBackColor = true;
            this.cngBtn.Click += new System.EventHandler(this.cngBtn_Click);
            // 
            // delBtn
            // 
            this.delBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.delBtn.Location = new System.Drawing.Point(412, 320);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(100, 40);
            this.delBtn.TabIndex = 4;
            this.delBtn.Text = "Удалить";
            this.delBtn.UseVisualStyleBackColor = true;
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // contactListView
            // 
            this.contactListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader1});
            this.contactListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.contactListView.FullRowSelect = true;
            this.contactListView.GridLines = true;
            this.contactListView.HideSelection = false;
            this.contactListView.Location = new System.Drawing.Point(544, 29);
            this.contactListView.Name = "contactListView";
            this.contactListView.Size = new System.Drawing.Size(305, 331);
            this.contactListView.TabIndex = 5;
            this.contactListView.UseCompatibleStateImageBehavior = false;
            this.contactListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Тип контакта";
            this.columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Значение";
            this.columnHeader5.Width = 150;
            // 
            // delContactBtn
            // 
            this.delContactBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.delContactBtn.Location = new System.Drawing.Point(882, 182);
            this.delContactBtn.Name = "delContactBtn";
            this.delContactBtn.Size = new System.Drawing.Size(100, 40);
            this.delContactBtn.TabIndex = 9;
            this.delContactBtn.Text = "Удалить";
            this.delContactBtn.UseVisualStyleBackColor = true;
            this.delContactBtn.Click += new System.EventHandler(this.delContactBtn_Click);
            // 
            // chgContactBtn
            // 
            this.chgContactBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chgContactBtn.Location = new System.Drawing.Point(882, 121);
            this.chgContactBtn.Name = "chgContactBtn";
            this.chgContactBtn.Size = new System.Drawing.Size(100, 40);
            this.chgContactBtn.TabIndex = 8;
            this.chgContactBtn.Text = "Изменить";
            this.chgContactBtn.UseVisualStyleBackColor = true;
            this.chgContactBtn.Click += new System.EventHandler(this.chgContactBtn_Click);
            // 
            // addContactBtn
            // 
            this.addContactBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.addContactBtn.Location = new System.Drawing.Point(882, 59);
            this.addContactBtn.Name = "addContactBtn";
            this.addContactBtn.Size = new System.Drawing.Size(100, 40);
            this.addContactBtn.TabIndex = 7;
            this.addContactBtn.Text = "Добавить";
            this.addContactBtn.UseVisualStyleBackColor = true;
            this.addContactBtn.Click += new System.EventHandler(this.addContactBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(855, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Работа с контактами:";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 384);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.delContactBtn);
            this.Controls.Add(this.chgContactBtn);
            this.Controls.Add(this.addContactBtn);
            this.Controls.Add(this.contactListView);
            this.Controls.Add(this.delBtn);
            this.Controls.Add(this.cngBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.dsplBtn);
            this.Controls.Add(this.listView);
            this.Name = "MainForm";
            this.Text = "Клиент";
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.ListView contactListView;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button delContactBtn;
        private System.Windows.Forms.Button chgContactBtn;
        private System.Windows.Forms.Button addContactBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}

