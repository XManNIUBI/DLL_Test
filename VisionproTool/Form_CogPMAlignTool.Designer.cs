namespace VisionproTool
{
    partial class Form_CogPMAlignTool
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
            this.cogPMAlignEditV21 = new Cognex.VisionPro.PMAlign.CogPMAlignEditV2();
            ((System.ComponentModel.ISupportInitialize)(this.cogPMAlignEditV21)).BeginInit();
            this.SuspendLayout();
            // 
            // cogPMAlignEditV21
            // 
            this.cogPMAlignEditV21.Location = new System.Drawing.Point(0, 1);
            this.cogPMAlignEditV21.MinimumSize = new System.Drawing.Size(489, 0);
            this.cogPMAlignEditV21.Name = "cogPMAlignEditV21";
            this.cogPMAlignEditV21.Size = new System.Drawing.Size(748, 456);
            this.cogPMAlignEditV21.SuspendElectricRuns = false;
            this.cogPMAlignEditV21.TabIndex = 0;
            // 
            // Form_CogPMAlignTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 605);
            this.Controls.Add(this.cogPMAlignEditV21);
            this.Name = "Form_CogPMAlignTool";
            this.Text = "Form_CogPMAlignTool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_CogPMAlignTool_FormClosing);
            this.Load += new System.EventHandler(this.Form_CogPMAlignTool_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cogPMAlignEditV21)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Cognex.VisionPro.PMAlign.CogPMAlignEditV2 cogPMAlignEditV21;
    }
}