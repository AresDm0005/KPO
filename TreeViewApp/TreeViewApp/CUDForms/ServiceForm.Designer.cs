
namespace TreeViewApp.CUDForms
{
    partial class ServiceForm
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
            this.costTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.copiesTxt = new System.Windows.Forms.TextBox();
            this.cnclBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.sDTreeViewDataSet = new TreeViewApp.SDTreeViewDataSet();
            this.servicesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.servicesTableAdapter = new TreeViewApp.SDTreeViewDataSetTableAdapters.ServicesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sDTreeViewDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.servicesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // costTxt
            // 
            this.costTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.costTxt.Location = new System.Drawing.Point(123, 83);
            this.costTxt.Name = "costTxt";
            this.costTxt.ReadOnly = true;
            this.costTxt.Size = new System.Drawing.Size(223, 23);
            this.costTxt.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(17, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 17);
            this.label3.TabIndex = 21;
            this.label3.Text = "Стоимость:";
            // 
            // copiesTxt
            // 
            this.copiesTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.copiesTxt.Location = new System.Drawing.Point(123, 48);
            this.copiesTxt.Name = "copiesTxt";
            this.copiesTxt.Size = new System.Drawing.Size(223, 23);
            this.copiesTxt.TabIndex = 20;
            this.copiesTxt.TextChanged += new System.EventHandler(this.copiesTxt_TextChanged);
            this.copiesTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.copiesTxt_KeyPress);
            // 
            // cnclBtn
            // 
            this.cnclBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cnclBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cnclBtn.Location = new System.Drawing.Point(250, 117);
            this.cnclBtn.Name = "cnclBtn";
            this.cnclBtn.Size = new System.Drawing.Size(96, 23);
            this.cnclBtn.TabIndex = 17;
            this.cnclBtn.Text = "Отмена";
            this.cnclBtn.UseVisualStyleBackColor = true;
            // 
            // okBtn
            // 
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.okBtn.Location = new System.Drawing.Point(146, 117);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(97, 23);
            this.okBtn.TabIndex = 16;
            this.okBtn.Text = "txt1";
            this.okBtn.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(17, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "Тираж:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 19;
            this.label1.Text = "Услуга:";
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.servicesBindingSource;
            this.comboBox1.DisplayMember = "name";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(123, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(223, 24);
            this.comboBox1.TabIndex = 15;
            this.comboBox1.ValueMember = "id";
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // sDTreeViewDataSet
            // 
            this.sDTreeViewDataSet.DataSetName = "SDTreeViewDataSet";
            this.sDTreeViewDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // servicesBindingSource
            // 
            this.servicesBindingSource.DataMember = "Services";
            this.servicesBindingSource.DataSource = this.sDTreeViewDataSet;
            // 
            // servicesTableAdapter
            // 
            this.servicesTableAdapter.ClearBeforeFill = true;
            // 
            // ServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 158);
            this.Controls.Add(this.costTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.copiesTxt);
            this.Controls.Add(this.cnclBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServiceForm";
            this.Text = "Услуги";
            this.Load += new System.EventHandler(this.ServiceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sDTreeViewDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.servicesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox costTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox copiesTxt;
        private System.Windows.Forms.Button cnclBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private SDTreeViewDataSet sDTreeViewDataSet;
        private System.Windows.Forms.BindingSource servicesBindingSource;
        private SDTreeViewDataSetTableAdapters.ServicesTableAdapter servicesTableAdapter;
    }
}