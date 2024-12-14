namespace LearningENG.FormApp
{
    partial class NewWord
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
            //Define
            Font fontBold = new Font(this.Font.FontFamily, 13, FontStyle.Bold);
            Font fontboldSmall = new Font(this.Font.FontFamily, 10, FontStyle.Bold);
            Font fontNomal = new Font(this.Font.FontFamily, 13);
            Font fontNomalSmall = new Font(this.Font.FontFamily, 10);

            System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();

            this._english.Location = new System.Drawing.Point(10, 10);
            this._english.Size = new System.Drawing.Size(270, 30);
            this._english.BorderStyle = BorderStyle.FixedSingle;
            this._english.Font = fontNomalSmall;
            toolTip.SetToolTip(this._english, "Enter English word");
            this._english.Enter += OnEnterTextBox;

            this._vietnamese.Location = new System.Drawing.Point(10, 50);
            this._vietnamese.Size = new System.Drawing.Size(270, 30);
            this._vietnamese.BorderStyle = BorderStyle.FixedSingle;
            this._vietnamese.Font = fontNomalSmall;
            toolTip.SetToolTip(this._vietnamese, "Enter Vietnamese meaning");
            this._vietnamese.Enter += OnEnterTextBox;

            this._okBtn.Text = "Add";
            this._okBtn.Location = new System.Drawing.Point(288, 30);
            this._okBtn.Size = new System.Drawing.Size(100, 30);
            this._okBtn.Font = fontNomalSmall;
            this._okBtn.Click += OnClickBtnOK;

            this._status.Location = new System.Drawing.Point(0, 80);
            this._status.Size = new System.Drawing.Size(400, 30);
            this._status.TextAlign = ContentAlignment.MiddleCenter;
            this._status.Visible = false;
            this._status.Font = fontNomalSmall;

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 120);
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Text = "NewWord";
            this.Controls.Add(_english);
            this.Controls.Add(_vietnamese);
            this.Controls.Add(_status);
            this.Controls.Add(_okBtn);
        }

        #endregion
        System.Windows.Forms.TextBox _english;
        System.Windows.Forms.TextBox _vietnamese;
        System.Windows.Forms.Label _status;
        System.Windows.Forms.Button _okBtn;
    }
}