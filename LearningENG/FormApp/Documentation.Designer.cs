using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LearningENG.FormApp
{
    partial class Documentation
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

            this._searchBar.Location = new System.Drawing.Point(10, 10);
            this._searchBar.Size = new System.Drawing.Size(380, 30);
            this._searchBar.BorderStyle = BorderStyle.FixedSingle;
            this._searchBar.Font = fontNomalSmall;
            this._searchBar.TextChanged += OnSearchBarChanged;
            toolTip.SetToolTip(this._searchBar, "Search here");

            this._grammar.Location = new System.Drawing.Point(10, 50);
            this._grammar.Size = new System.Drawing.Size(380, 240);
            this._grammar.AutoGenerateColumns = false;
            this._grammar.RowHeadersVisible = false;
            this._grammar.ColumnHeadersVisible = false;
            this._grammar.AllowUserToAddRows = false;
            this._grammar.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this._grammar.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this._grammar.Font = fontNomalSmall;
            this._grammar.SelectionChanged += OnSelectedGridView;
            toolTip.SetToolTip(this._grammar, "List grammar");

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Text = "Documentation";
            this.Controls.Add(_searchBar);
            this.Controls.Add(_grammar);
        }

        #endregion
        System.Windows.Forms.TextBox _searchBar;
        System.Windows.Forms.DataGridView _grammar;
    }
}