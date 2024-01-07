namespace Semestralni_prace
{
    partial class Semestralni_Prace
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Generate_Button = new Button();
            SuspendLayout();
            // 
            // Generate_Button
            // 
            Generate_Button.BackColor = SystemColors.ActiveCaptionText;
            Generate_Button.Font = new Font("Segoe UI", 15F);
            Generate_Button.ForeColor = SystemColors.ButtonFace;
            Generate_Button.ImageAlign = ContentAlignment.TopCenter;
            Generate_Button.Location = new Point(12, 12);
            Generate_Button.Name = "Generate_Button";
            Generate_Button.Size = new Size(156, 56);
            Generate_Button.TabIndex = 1;
            Generate_Button.Text = "Generuj";
            Generate_Button.UseVisualStyleBackColor = false;
            Generate_Button.Click += Generate_Button_Click;
            // 
            // FormSetup
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlText;
            ClientSize = new Size(835, 903);
            Controls.Add(Generate_Button);
            Name = "FormSetup";
            Text = "Semestralni Prace";
            ResumeLayout(false);
        }

        #endregion

        private Button Generate_Button;
    }
}