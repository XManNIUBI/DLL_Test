namespace VisionproTool
{
    partial class Form_CogFindCircleTool
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
            this.cogFindCircleEditV21 = new Cognex.VisionPro.Caliper.CogFindCircleEditV2();
            ((System.ComponentModel.ISupportInitialize)(this.cogFindCircleEditV21)).BeginInit();
            this.SuspendLayout();
            // 
            // cogFindCircleEditV21
            // 
            this.cogFindCircleEditV21.Location = new System.Drawing.Point(26, 12);
            this.cogFindCircleEditV21.MinimumSize = new System.Drawing.Size(489, 0);
            this.cogFindCircleEditV21.Name = "cogFindCircleEditV21";
            this.cogFindCircleEditV21.Size = new System.Drawing.Size(748, 399);
            this.cogFindCircleEditV21.SuspendElectricRuns = false;
            this.cogFindCircleEditV21.TabIndex = 0;
            // 
            // Form_CogFindCircleTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 623);
            this.Controls.Add(this.cogFindCircleEditV21);
            this.Name = "Form_CogFindCircleTool";
            this.Text = "Form_CogFindCircleTool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_CogFindCircleTool_FormClosing);
            this.Load += new System.EventHandler(this.Form_CogFindCircleTool_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cogFindCircleEditV21)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Cognex.VisionPro.Caliper.CogFindCircleEditV2 cogFindCircleEditV21;
    }
}