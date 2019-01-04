namespace VisionproTool
{
    partial class Form_CogCalibCheckerboardTool
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
            this.cogCalibCheckerboardEditV21 = new Cognex.VisionPro.CalibFix.CogCalibCheckerboardEditV2();
            ((System.ComponentModel.ISupportInitialize)(this.cogCalibCheckerboardEditV21)).BeginInit();
            this.SuspendLayout();
            // 
            // cogCalibCheckerboardEditV21
            // 
            this.cogCalibCheckerboardEditV21.Location = new System.Drawing.Point(1, 2);
            this.cogCalibCheckerboardEditV21.MinimumSize = new System.Drawing.Size(489, 0);
            this.cogCalibCheckerboardEditV21.Name = "cogCalibCheckerboardEditV21";
            this.cogCalibCheckerboardEditV21.Size = new System.Drawing.Size(748, 449);
            this.cogCalibCheckerboardEditV21.SuspendElectricRuns = false;
            this.cogCalibCheckerboardEditV21.TabIndex = 0;
            // 
            // Form_CogCalibCheckerboardTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 612);
            this.Controls.Add(this.cogCalibCheckerboardEditV21);
            this.Name = "Form_CogCalibCheckerboardTool";
            this.Text = "Form_CogCalibCheckerboardTool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_CogCalibCheckerboardTool_FormClosing);
            this.Load += new System.EventHandler(this.Form_CogCalibCheckerboardTool_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cogCalibCheckerboardEditV21)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Cognex.VisionPro.CalibFix.CogCalibCheckerboardEditV2 cogCalibCheckerboardEditV21;
    }
}