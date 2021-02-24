
namespace TestControlsApplication
{
    partial class Form1
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
            this.colorChoise1 = new LabControls.ColorChoise();
            this.filePathSelect1 = new LabControls.FilePathSelect();
            this.numberBox1 = new LabControls.NumberBox(this.components);
            this.checkLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // colorChoise1
            // 
            this.colorChoise1.Color = System.Drawing.SystemColors.Control;
            this.colorChoise1.Location = new System.Drawing.Point(133, 209);
            this.colorChoise1.Name = "colorChoise1";
            this.colorChoise1.Size = new System.Drawing.Size(261, 117);
            this.colorChoise1.TabIndex = 2;
            // 
            // filePathSelect1
            // 
            this.filePathSelect1.FileName = "";
            this.filePathSelect1.Location = new System.Drawing.Point(88, 66);
            this.filePathSelect1.Name = "filePathSelect1";
            this.filePathSelect1.Size = new System.Drawing.Size(330, 30);
            this.filePathSelect1.TabIndex = 1;
            // 
            // numberBox1
            // 
            this.numberBox1.ForeColor = System.Drawing.Color.Red;
            this.numberBox1.Location = new System.Drawing.Point(209, 26);
            this.numberBox1.Name = "numberBox1";
            this.numberBox1.Size = new System.Drawing.Size(100, 20);
            this.numberBox1.TabIndex = 0;
            // 
            // checkLabel
            // 
            this.checkLabel.AutoSize = true;
            this.checkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.checkLabel.Location = new System.Drawing.Point(218, 365);
            this.checkLabel.Name = "checkLabel";
            this.checkLabel.Size = new System.Drawing.Size(51, 20);
            this.checkLabel.TabIndex = 3;
            this.checkLabel.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkLabel);
            this.Controls.Add(this.colorChoise1);
            this.Controls.Add(this.filePathSelect1);
            this.Controls.Add(this.numberBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LabControls.NumberBox numberBox1;
        private LabControls.FilePathSelect filePathSelect1;
        private LabControls.ColorChoise colorChoise1;
        private System.Windows.Forms.Label checkLabel;
    }
}

