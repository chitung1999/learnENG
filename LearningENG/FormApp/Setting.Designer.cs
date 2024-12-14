namespace LearningENG.FormApp
{
    partial class Setting
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
            System.Windows.Forms.Label newWordPath = new System.Windows.Forms.Label();
            newWordPath.Location = new System.Drawing.Point(10, 20);
            newWordPath.Text = "New word path:";

            this._newWordPath.Location = new System.Drawing.Point(110, 16);
            this._newWordPath.Size = new System.Drawing.Size(300, 30);
            this._newWordPath.BorderStyle = BorderStyle.FixedSingle;
            this._newWordPath.ReadOnly = true;

            System.Windows.Forms.Button newWordBtn = new System.Windows.Forms.Button();
            newWordBtn.Text = "...";
            newWordBtn.Location = new System.Drawing.Point(420, 14);
            newWordBtn.Size = new System.Drawing.Size(50, 27);
            newWordBtn.Click += OnSetNewWordPath;

            System.Windows.Forms.Label grammarPath = new System.Windows.Forms.Label();
            grammarPath.Location = new System.Drawing.Point(10, 60);
            grammarPath.Text = "Grammar path:";

            this._grammarPath.Location = new System.Drawing.Point(110, 56);
            this._grammarPath.Size = new System.Drawing.Size(300, 30);
            this._grammarPath.BorderStyle = BorderStyle.FixedSingle;
            this._grammarPath.ReadOnly = true;

            System.Windows.Forms.Button grammarBtn = new System.Windows.Forms.Button();
            grammarBtn.Text = "...";
            grammarBtn.Location = new System.Drawing.Point(420, 54);
            grammarBtn.Size = new System.Drawing.Size(50, 27);
            grammarBtn.Click += OnSetGrammarPath;

            System.Windows.Forms.Button okBtn = new System.Windows.Forms.Button();
            okBtn.Text = "OK";
            okBtn.Location = new System.Drawing.Point(390, 260);
            okBtn.Size = new System.Drawing.Size(100, 30);
            okBtn.Click += OnSaveSetting;

            System.Windows.Forms.Panel panel = new System.Windows.Forms.Panel();
            panel.Location = new System.Drawing.Point(10, 10);
            panel.Size = new System.Drawing.Size(480, 240);
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Controls.Add(newWordPath);
            panel.Controls.Add(newWordBtn);
            panel.Controls.Add(this._newWordPath);
            panel.Controls.Add(grammarPath);
            panel.Controls.Add(this._grammarPath);
            panel.Controls.Add(grammarBtn);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 300);
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Text = "Setting";
            this.Controls.Add(panel);
            this.Controls.Add(okBtn);
        }

        #endregion
        System.Windows.Forms.TextBox _newWordPath;
        System.Windows.Forms.TextBox _grammarPath;
    }
}