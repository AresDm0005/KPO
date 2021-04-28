
namespace NotebookClient
{
    partial class AddChangePersonForm
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
            this.okBtn = new System.Windows.Forms.Button();
            this.cnclBtn = new System.Windows.Forms.Button();
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.surnameTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateBirthDTP = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // okBtn
            // 
            this.okBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.okBtn.Location = new System.Drawing.Point(127, 138);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(100, 30);
            this.okBtn.TabIndex = 0;
            this.okBtn.Text = "button1";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cnclBtn
            // 
            this.cnclBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cnclBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cnclBtn.Location = new System.Drawing.Point(233, 138);
            this.cnclBtn.Name = "cnclBtn";
            this.cnclBtn.Size = new System.Drawing.Size(100, 30);
            this.cnclBtn.TabIndex = 1;
            this.cnclBtn.Text = "Отмена";
            this.cnclBtn.UseVisualStyleBackColor = true;
            this.cnclBtn.Click += new System.EventHandler(this.cnclBtn_Click);
            // 
            // nameTxt
            // 
            this.nameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.nameTxt.Location = new System.Drawing.Point(147, 16);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(186, 23);
            this.nameTxt.TabIndex = 2;
            // 
            // surnameTxt
            // 
            this.surnameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.surnameTxt.Location = new System.Drawing.Point(147, 57);
            this.surnameTxt.Name = "surnameTxt";
            this.surnameTxt.Size = new System.Drawing.Size(186, 23);
            this.surnameTxt.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(24, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Имя:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(24, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Фамилия:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(24, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Дата рождения:";
            // 
            // dateBirthDTP
            // 
            this.dateBirthDTP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dateBirthDTP.Location = new System.Drawing.Point(147, 99);
            this.dateBirthDTP.Name = "dateBirthDTP";
            this.dateBirthDTP.Size = new System.Drawing.Size(186, 23);
            this.dateBirthDTP.TabIndex = 7;
            // 
            // AddChangePersonForm
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cnclBtn;
            this.ClientSize = new System.Drawing.Size(348, 182);
            this.Controls.Add(this.dateBirthDTP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.surnameTxt);
            this.Controls.Add(this.nameTxt);
            this.Controls.Add(this.cnclBtn);
            this.Controls.Add(this.okBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddChangePersonForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cnclBtn;
        private System.Windows.Forms.TextBox nameTxt;
        private System.Windows.Forms.TextBox surnameTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateBirthDTP;
    }
}