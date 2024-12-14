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

namespace LearningENG.FormApp
{
    public partial class Setting : Form
    {
        public Setting()
        {
            this._newWordPath = new TextBox();
            this._newWordPath.Text = GlobalVariables.DatabaseInstance.configApp.pathNewword;

            this._grammarPath = new TextBox();
            this._grammarPath.Text = GlobalVariables.DatabaseInstance.configApp.pathGrammar;
            InitializeComponent();
        }

        public void SetPosition(int x, int y)
        {
            this.Location = new Point(x, y);
        }

        private void OnSetNewWordPath(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                openFile.Title = "Select JSON file";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    this._newWordPath.Text = openFile.FileName;
                }
            }
        }

        private void OnSetGrammarPath(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                openFile.Title = "Select JSON file";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    this._grammarPath.Text = openFile.FileName;
                }
            }
        }

        private void OnSaveSetting(object sender, EventArgs e)
        {
            try
            {
                ConfigApp config = new ConfigApp();
                config.pathNewword = this._newWordPath.Text;
                config.pathGrammar = this._grammarPath.Text;

                string jsonData = JsonConvert.SerializeObject(config, Formatting.Indented);
                string path = GlobalVariables.DatabaseInstance.getPathConfig();
                File.WriteAllText(path, jsonData);
                GlobalVariables.DatabaseInstance.configApp = config;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail to save setting!");
            }
        }
    }
}
