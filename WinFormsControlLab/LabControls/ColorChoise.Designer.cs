
namespace LabControls
{
    partial class ColorChoise
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.decRadio = new System.Windows.Forms.RadioButton();
            this.hexRadio = new System.Windows.Forms.RadioButton();
            this.colorBox = new System.Windows.Forms.PictureBox();
            this.txtBlue = new LabControls.RGBText(this.components);
            this.txtGreen = new LabControls.RGBText(this.components);
            this.txtRed = new LabControls.RGBText(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.colorBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Красный:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.Location = new System.Drawing.Point(13, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Зеленый";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label3.Location = new System.Drawing.Point(13, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Синий:";
            // 
            // decRadio
            // 
            this.decRadio.AutoSize = true;
            this.decRadio.Location = new System.Drawing.Point(16, 89);
            this.decRadio.Name = "decRadio";
            this.decRadio.Size = new System.Drawing.Size(45, 17);
            this.decRadio.TabIndex = 7;
            this.decRadio.Text = "Dec";
            this.decRadio.UseVisualStyleBackColor = true;
            this.decRadio.CheckedChanged += new System.EventHandler(this.decRadio_CheckedChanged);
            // 
            // hexRadio
            // 
            this.hexRadio.AutoSize = true;
            this.hexRadio.Location = new System.Drawing.Point(80, 89);
            this.hexRadio.Name = "hexRadio";
            this.hexRadio.Size = new System.Drawing.Size(44, 17);
            this.hexRadio.TabIndex = 8;
            this.hexRadio.Text = "Hex";
            this.hexRadio.UseVisualStyleBackColor = true;
            this.hexRadio.CheckedChanged += new System.EventHandler(this.hexRadio_CheckedChanged);
            // 
            // colorBox
            // 
            this.colorBox.Location = new System.Drawing.Point(150, 8);
            this.colorBox.Name = "colorBox";
            this.colorBox.Size = new System.Drawing.Size(100, 100);
            this.colorBox.TabIndex = 9;
            this.colorBox.TabStop = false;
            // 
            // txtBlue
            // 
            this.txtBlue.Location = new System.Drawing.Point(80, 64);
            this.txtBlue.Name = "txtBlue";
            this.txtBlue.Size = new System.Drawing.Size(64, 20);
            this.txtBlue.TabIndex = 12;
            this.txtBlue.Text = "0";
            this.txtBlue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBlue.Value = 0;
            // 
            // txtGreen
            // 
            this.txtGreen.Location = new System.Drawing.Point(80, 37);
            this.txtGreen.Name = "txtGreen";
            this.txtGreen.Size = new System.Drawing.Size(64, 20);
            this.txtGreen.TabIndex = 11;
            this.txtGreen.Text = "0";
            this.txtGreen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGreen.Value = 0;
            // 
            // txtRed
            // 
            this.txtRed.Location = new System.Drawing.Point(80, 10);
            this.txtRed.Name = "txtRed";
            this.txtRed.Size = new System.Drawing.Size(64, 20);
            this.txtRed.TabIndex = 10;
            this.txtRed.Text = "0";
            this.txtRed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRed.Value = 0;
            // 
            // ColorChoise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtBlue);
            this.Controls.Add(this.txtGreen);
            this.Controls.Add(this.txtRed);
            this.Controls.Add(this.hexRadio);
            this.Controls.Add(this.decRadio);
            this.Controls.Add(this.colorBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ColorChoise";
            this.Size = new System.Drawing.Size(261, 117);
            this.Load += new System.EventHandler(this.ColorChoise_Load);
            ((System.ComponentModel.ISupportInitialize)(this.colorBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton decRadio;
        private System.Windows.Forms.RadioButton hexRadio;
        private System.Windows.Forms.PictureBox colorBox;
        private RGBText txtRed;
        private RGBText txtGreen;
        private RGBText txtBlue;
    }
}
