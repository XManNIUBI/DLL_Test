namespace VisionproTool
{
    partial class Form_CogBlobTool
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
            this.cogBlobEditV21 = new Cognex.VisionPro.Blob.CogBlobEditV2();
            ((System.ComponentModel.ISupportInitialize)(this.cogBlobEditV21)).BeginInit();
            this.SuspendLayout();
            // 
            // cogBlobEditV21
            // 
            this.cogBlobEditV21.Location = new System.Drawing.Point(122, 38);
            this.cogBlobEditV21.MinimumSize = new System.Drawing.Size(489, 0);
            this.cogBlobEditV21.Name = "cogBlobEditV21";
            this.cogBlobEditV21.Size = new System.Drawing.Size(748, 402);
            this.cogBlobEditV21.SuspendElectricRuns = false;
            this.cogBlobEditV21.TabIndex = 0;
            // 
            // Form_CogBlobTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 507);
            this.Controls.Add(this.cogBlobEditV21);
            this.Name = "Form_CogBlobTool";
            this.Text = "Form_CogBlobTool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_CogBlobTool_FormClosing);
            this.Load += new System.EventHandler(this.Form_CogBlobTool_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cogBlobEditV21)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Cognex.VisionPro.Blob.CogBlobEditV2 cogBlobEditV21;
    }
}