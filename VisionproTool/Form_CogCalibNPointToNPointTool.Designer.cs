namespace VisionproTool
{
    partial class Form_CogCalibNPointToNPointTool
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
            this.cogCalibNPointToNPointEditV21 = new Cognex.VisionPro.CalibFix.CogCalibNPointToNPointEditV2();
            ((System.ComponentModel.ISupportInitialize)(this.cogCalibNPointToNPointEditV21)).BeginInit();
            this.SuspendLayout();
            // 
            // cogCalibNPointToNPointEditV21
            // 
            this.cogCalibNPointToNPointEditV21.Location = new System.Drawing.Point(12, 12);
            this.cogCalibNPointToNPointEditV21.MinimumSize = new System.Drawing.Size(489, 0);
            this.cogCalibNPointToNPointEditV21.Name = "cogCalibNPointToNPointEditV21";
            this.cogCalibNPointToNPointEditV21.Size = new System.Drawing.Size(748, 428);
            this.cogCalibNPointToNPointEditV21.SuspendElectricRuns = false;
            this.cogCalibNPointToNPointEditV21.TabIndex = 0;
            this.cogCalibNPointToNPointEditV21.Load += new System.EventHandler(this.cogCalibNPointToNPointEditV21_Load);
            // 
            // Form_CogCalibNPointToNPointTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 585);
            this.Controls.Add(this.cogCalibNPointToNPointEditV21);
            this.Name = "Form_CogCalibNPointToNPointTool";
            this.Text = "Form_CogCalibNPointToNPointTool";
            this.Load += new System.EventHandler(this.Form_CogCalibNPointToNPointTool_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cogCalibNPointToNPointEditV21)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Cognex.VisionPro.CalibFix.CogCalibNPointToNPointEditV2 cogCalibNPointToNPointEditV21;
    }
}