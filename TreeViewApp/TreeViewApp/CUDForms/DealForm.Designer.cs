
namespace TreeViewApp.CUDForms
{
    partial class DealForm
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
            this.components = new System.ComponentModel.Container();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.clientsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sDTreeViewDataSet = new TreeViewApp.SDTreeViewDataSet();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.okBtn = new System.Windows.Forms.Button();
            this.cnclBtn = new System.Windows.Forms.Button();
            this.clientsTableAdapter = new TreeViewApp.SDTreeViewDataSetTableAdapters.ClientsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.clientsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sDTreeViewDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.clientsBindingSource;
            this.comboBox1.DisplayMember = "name";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(161, 17);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(223, 24);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.ValueMember = "id";
            // 
            // clientsBindingSource
            // 
            this.clientsBindingSource.DataMember = "Clients";
            this.clientsBindingSource.DataSource = this.sDTreeViewDataSet;
            // 
            // sDTreeViewDataSet
            // 
            this.sDTreeViewDataSet.DataSetName = "SDTreeViewDataSet";
            this.sDTreeViewDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Клиент:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dateTimePicker1.Location = new System.Drawing.Point(161, 49);
            this.dateTimePicker1.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker1.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(223, 23);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(20, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Дата оформления:";
            // 
            // okBtn
            // 
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.okBtn.Location = new System.Drawing.Point(184, 81);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(97, 23);
            this.okBtn.TabIndex = 2;
            this.okBtn.Text = "txt1";
            this.okBtn.UseVisualStyleBackColor = true;
            // 
            // cnclBtn
            // 
            this.cnclBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cnclBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cnclBtn.Location = new System.Drawing.Point(288, 81);
            this.cnclBtn.Name = "cnclBtn";
            this.cnclBtn.Size = new System.Drawing.Size(96, 23);
            this.cnclBtn.TabIndex = 3;
            this.cnclBtn.Text = "Отмена";
            this.cnclBtn.UseVisualStyleBackColor = true;
            // 
            // clientsTableAdapter
            // 
            this.clientsTableAdapter.ClearBeforeFill = true;
            // 
            // DealForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 115);
            this.Controls.Add(this.cnclBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DealForm";
            this.Text = "Заказы";
            this.Load += new System.EventHandler(this.DealForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clientsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sDTreeViewDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cnclBtn;
        private SDTreeViewDataSet sDTreeViewDataSet;
        private System.Windows.Forms.BindingSource clientsBindingSource;
        private SDTreeViewDataSetTableAdapters.ClientsTableAdapter clientsTableAdapter;
    }
}