namespace VisionproTool
{
    partial class Form_CogCreateSegmentTool
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
            this.cogCreateSegmentEditV21 = new Cognex.VisionPro.Dimensioning.CogCreateSegmentEditV2();
            ((System.ComponentModel.ISupportInitialize)(this.cogCreateSegmentEditV21)).BeginInit();
            this.SuspendLayout();
            // 
            // cogCreateSegmentEditV21
            // 
            this.cogCreateSegmentEditV21.Location = new System.Drawing.Point(12, 12);
            this.cogCreateSegmentEditV21.MinimumSize = new System.Drawing.Size(489, 0);
            this.cogCreateSegmentEditV21.Name = "cogCreateSegmentEditV21";
            this.cogCreateSegmentEditV21.Size = new System.Drawing.Size(748, 280);
            this.cogCreateSegmentEditV21.SuspendElectricRuns = false;
            this.cogCreateSegmentEditV21.TabIndex = 0;
            // 
            // Form_CogCreateSegmentTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 608);
            this.Controls.Add(this.cogCreateSegmentEditV21);
            this.Name = "Form_CogCreateSegmentTool";
            this.Text = "Form_CogCreateSegmentTool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_CogCreateSegmentTool_FormClosing);
            this.Load += new System.EventHandler(this.Form_CogCreateSegmentTool_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cogCreateSegmentEditV21)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Cognex.VisionPro.Dimensioning.CogCreateSegmentEditV2 cogCreateSegmentEditV21;
    }
}