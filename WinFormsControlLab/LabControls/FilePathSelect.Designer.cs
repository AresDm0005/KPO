
namespace LabControls
{
    partial class FilePathSelect
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
            this.btnSelectPath = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSelectPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnSelectPath.Location = new System.Drawing.Point(292, 3);
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new System.Drawing.Size(39, 23);
            this.btnSelectPath.TabIndex = 0;
            this.btnSelectPath.Text = "...";
            this.btnSelectPath.UseVisualStyleBackColor = true;
            this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // txtPath
            // 
            this.txtPath.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtPath.Location = new System.Drawing.Point(3, 5);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(283, 20);
            this.txtPath.TabIndex = 1;
            // 
            // FilePathSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.btnSelectPath);
            this.Name = "FilePathSelect";
            this.Size = new System.Drawing.Size(334, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectPath;
        private System.Windows.Forms.TextBox txtPath;
    }
}
