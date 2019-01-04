namespace VisionproTool
{
    partial class Form_CogCaliperTool
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
            this.cogCaliperEditV21 = new Cognex.VisionPro.Caliper.CogCaliperEditV2();
            ((System.ComponentModel.ISupportInitialize)(this.cogCaliperEditV21)).BeginInit();
            this.SuspendLayout();
            // 
            // cogCaliperEditV21
            // 
            this.cogCaliperEditV21.Location = new System.Drawing.Point(71, 36);
            this.cogCaliperEditV21.MinimumSize = new System.Drawing.Size(489, 0);
            this.cogCaliperEditV21.Name = "cogCaliperEditV21";
            this.cogCaliperEditV21.Size = new System.Drawing.Size(748, 399);
            this.cogCaliperEditV21.SuspendElectricRuns = false;
            this.cogCaliperEditV21.TabIndex = 0;
            // 
            // Form_CogCaliperTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 523);
            this.Controls.Add(this.cogCaliperEditV21);
            this.Name = "Form_CogCaliperTool";
            this.Text = "Form_CogCaliperTool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_CogCaliperTool_FormClosing);
            this.Load += new System.EventHandler(this.Form_CogCaliperTool_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cogCaliperEditV21)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Cognex.VisionPro.Caliper.CogCaliperEditV2 cogCaliperEditV21;
    }
}