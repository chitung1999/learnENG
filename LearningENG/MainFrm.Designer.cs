using System.Reflection.Emit;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LearningENG
{
    partial class MainFrm
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
            //Font bold
            Font fontBold = new Font(this.Font.FontFamily, 13, FontStyle.Bold);
            Font fontboldSmall = new Font(this.Font.FontFamily, 10, FontStyle.Bold);
            //Font nomal
            Font fontNomal = new Font(this.Font.FontFamily, 13);
            Font fontNomalSmall = new Font(this.Font.FontFamily, 10);

            //MenuStrip
            MenuStrip menuStrip = new MenuStrip();
            ToolStripMenuItem menuFile = new ToolStripMenuItem("File");
            ToolStripMenuItem menuOpen = new ToolStripMenuItem("Open");
            ToolStripMenuItem menuSave = new ToolStripMenuItem("Save");
            ToolStripMenuItem menuClose = new ToolStripMenuItem("Close");

            menuFile.DropDownItems.Add(menuOpen);
            menuFile.DropDownItems.Add(menuSave);
            menuFile.DropDownItems.Add(menuClose);

            menuOpen.Click += new EventHandler(ClickBtnOpenFile);
            menuSave.Click += new EventHandler(ClickBtnSaveFile);
            menuClose.Click += new EventHandler(ClickBtnCloseFile);
            menuStrip.Items.Add(menuFile);

            //Question component
            this._listQuestion.Location = new System.Drawing.Point(10, 35);
            this._listQuestion.Size = new System.Drawing.Size(200, 420);
            this._listQuestion.DrawMode = DrawMode.OwnerDrawFixed;
            this._listQuestion.ItemHeight = 40;
            this._listQuestion.DrawItem += drawItemListBox;
            this._listQuestion.SelectedIndexChanged += selectQuestion;
            this._listQuestion.Visible = false;

            //Content component

            //Header
            _totalQuestion.Location = new System.Drawing.Point(80, 10);
            _totalQuestion.Size = new System.Drawing.Size(80, 20);
            _totalQuestion.Font = fontNomalSmall;

            PictureBox iconTotalNone = new PictureBox();
            iconTotalNone.Image = _iconNone;
            iconTotalNone.Size = new System.Drawing.Size(16, 16);
            iconTotalNone.Location = new System.Drawing.Point(170, 10);

            _totalNone.Location = new System.Drawing.Point(190, 10);
            _totalNone.Size = new System.Drawing.Size(60, 20);
            _totalNone.Font = fontNomalSmall;

            PictureBox iconTotalTrue = new PictureBox();
            iconTotalTrue.Image = _iconTrue;
            iconTotalTrue.Size = new System.Drawing.Size(16, 16);
            iconTotalTrue.Location = new System.Drawing.Point(250, 10);

            _totalTrue.Location = new System.Drawing.Point(270, 10);
            _totalTrue.Size = new System.Drawing.Size(60, 20);
            _totalTrue.Font = fontNomalSmall;

            PictureBox iconTotalFalse = new PictureBox();
            iconTotalFalse.Image = _iconFalse;
            iconTotalFalse.Size = new System.Drawing.Size(16, 16);
            iconTotalFalse.Location = new System.Drawing.Point(330, 10);

            _totalFalse.Location = new System.Drawing.Point(350, 10);
            _totalFalse.Size = new System.Drawing.Size(60, 20);
            _totalFalse.Font = fontNomalSmall;

            PictureBox iconTotalReview = new PictureBox();
            iconTotalReview.Image = _iconReviewed;
            iconTotalReview.Size = new System.Drawing.Size(16, 16);
            iconTotalReview.Location = new System.Drawing.Point(410, 10);

            _totalReview.Location = new System.Drawing.Point(430, 10);
            _totalReview.Size = new System.Drawing.Size(60, 20);
            _totalReview.Font = fontNomalSmall;

            // Question
            this._questionContent.Location = new System.Drawing.Point(10, 50);
            this._questionContent.Multiline = true;
            this._questionContent.Size = new Size(550, 80);
            this._questionContent.Font = fontBold;
            this._questionContent.BackColor = Color.PowderBlue;
            this._questionContent.ReadOnly = true;
            this._questionContent.TextAlign = HorizontalAlignment.Center;

            this._answerContent.Location = new System.Drawing.Point(10, 150);
            this._answerContent.Size = new System.Drawing.Size(250, 40);
            this._answerContent.Font = fontNomal;

            this._correctContent.Location = new System.Drawing.Point(310, 150);
            this._correctContent.Size = new Size(250, 40);
            this._correctContent.Font = fontBold;
            this._correctContent.BackColor = Color.PowderBlue;
            this._correctContent.ReadOnly = true;
            this._correctContent.TextAlign = HorizontalAlignment.Center;

            this._noteContent.Location = new System.Drawing.Point(10, 200);
            this._noteContent.Size = new System.Drawing.Size(550, 120);
            this._noteContent.Multiline = true;
            this._noteContent.Font = fontNomal;

            this._reviewedBtn.Text = "Reviewed";
            this._reviewedBtn.Location = new System.Drawing.Point(10, 340);
            this._reviewedBtn.Size = new System.Drawing.Size(250, 50);
            this._reviewedBtn.Font = fontNomal;
            this._reviewedBtn.Click += ClickBtnReviewed;

            this._okBtn.Text = "OK";
            this._okBtn.Location = new System.Drawing.Point(310, 340);
            this._okBtn.Size = new System.Drawing.Size(250, 50);
            this._okBtn.Font = fontNomal;
            this._okBtn.Click += ClickBtnOK;

            this._content.Location = new System.Drawing.Point(220, 35);
            this._content.Size = new System.Drawing.Size(570, 405);
            this._content.Visible = false;
            this._content.Controls.Add(_totalQuestion);
            this._content.Controls.Add(iconTotalNone);
            this._content.Controls.Add(iconTotalTrue);
            this._content.Controls.Add(iconTotalFalse);
            this._content.Controls.Add(iconTotalReview);
            this._content.Controls.Add(_totalNone);
            this._content.Controls.Add(_totalTrue);
            this._content.Controls.Add(_totalFalse);
            this._content.Controls.Add(_totalReview);
            this._content.Controls.Add(_questionContent);
            this._content.Controls.Add(_answerContent);
            this._content.Controls.Add(_correctContent);
            this._content.Controls.Add(_noteContent);
            this._content.Controls.Add(_reviewedBtn);
            this._content.Controls.Add(_okBtn);
            this._content.BorderStyle = BorderStyle.FixedSingle;

            // Main frame
            this.Controls.Add(menuStrip);
            this.Controls.Add(this._listQuestion);
            this.Controls.Add(this._content);
            this.components = new System.ComponentModel.Container();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.KeyPreview = true;
            this.FormClosing += ClickBtnCloseApp;
            this.KeyDown += OnPressKey;
            this.Text = "LearningENG";
        }

        #endregion
        System.Windows.Forms.ListBox _listQuestion;
        System.Windows.Forms.Panel _content;
        System.Windows.Forms.Label _totalQuestion;
        System.Windows.Forms.Label _totalNone;
        System.Windows.Forms.Label _totalTrue;
        System.Windows.Forms.Label _totalFalse;
        System.Windows.Forms.Label _totalReview;
        System.Windows.Forms.TextBox _questionContent;
        System.Windows.Forms.TextBox _answerContent;
        System.Windows.Forms.TextBox _correctContent;
        System.Windows.Forms.TextBox _noteContent;
        System.Windows.Forms.Button _reviewedBtn;
        System.Windows.Forms.Button _okBtn;

        Image _iconNone;
        Image _iconTrue;
        Image _iconFalse;
        Image _iconReviewed;
    }
}
