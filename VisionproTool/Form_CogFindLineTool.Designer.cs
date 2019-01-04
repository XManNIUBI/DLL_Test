namespace VisionproTool
{
    partial class Form_CogFindLineTool
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
            this.cogFindLineEditV21 = new Cognex.VisionPro.Caliper.CogFindLineEditV2();
            ((System.ComponentModel.ISupportInitialize)(this.cogFindLineEditV21)).BeginInit();
            this.SuspendLayout();
            // 
            // cogFindLineEditV21
            // 
            this.cogFindLineEditV21.Location = new System.Drawing.Point(27, 35);
            this.cogFindLineEditV21.MinimumSize = new System.Drawing.Size(489, 0);
            this.cogFindLineEditV21.Name = "cogFindLineEditV21";
            this.cogFindLineEditV21.Size = new System.Drawing.Size(748, 399);
            this.cogFindLineEditV21.SuspendElectricRuns = false;
            this.cogFindLineEditV21.TabIndex = 0;
            // 
            // Form_CogFindLineTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 544);
            this.Controls.Add(this.cogFindLineEditV21);
            this.Name = "Form_CogFindLineTool";
            this.Text = "Form_CogFindLineTool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_CogFindLineTool_FormClosing);
            this.Load += new System.EventHandler(this.Form_CogFindLineTool_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cogFindLineEditV21)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Cognex.VisionPro.Caliper.CogFindLineEditV2 cogFindLineEditV21;
    }
}