using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace LearningENG.FormApp
{
    public partial class NewWord : Form
    {
        public NewWord()
        {
            _english = new System.Windows.Forms.TextBox();
            _vietnamese = new System.Windows.Forms.TextBox();
            _status = new System.Windows.Forms.Label();
            _okBtn = new System.Windows.Forms.Button();
            InitializeComponent();
        }

        public void SetPosition(int x, int y)
        {
            this.Location = new Point(x, y);
        }

        private void OnEnterTextBox(object sender, EventArgs e)
        {
            this._status.Visible = false;
        }

        private void OnClickBtnOK(object sender, EventArgs e)
        {
            
            string path = GlobalVariables.DatabaseInstance.configApp.pathNewword;
            try {
                string jsonData = File.ReadAllText(path);
                if (jsonData != null)
                {
                    List<NewWordItem> newWords = JsonConvert.DeserializeObject<List<NewWordItem>>(jsonData);

                    if(newWords != null)
                    {
                        List<string> engs = new List<string>(this._english.Text.Split(new string[] { ", " }, StringSplitOptions.None));
                        List<string> vns = new List<string>(this._vietnamese.Text.Split(new string[] { ", " }, StringSplitOptions.None));

                        NewWordItem item = new NewWordItem();
                        item.keys = engs;
                        item.means = vns;

                        newWords.Add(item);
                        jsonData = JsonConvert.SerializeObject(newWords, Formatting.Indented);
                        File.WriteAllText(path, jsonData);
                        this._english.Text = string.Empty;
                        this._vietnamese.Text = string.Empty;
                        this._status.Text = "Added successfully!";
                        this._status.ForeColor = Color.Green;
                        this._status.Visible = true;
                        return;
                    }
                }

                MessageBox.Show("Cannot add new word!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot add new word!");
            }

            this._status.Text = "Added failed!";
            this._status.ForeColor = Color.Red;
            this._status.Visible = true;
        }
    }
}
