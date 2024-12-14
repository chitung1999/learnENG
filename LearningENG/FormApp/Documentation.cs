using Newtonsoft.Json;
using System.Data;
namespace LearningENG.FormApp
{
    public partial class Documentation : Form
    {
        public Documentation()
        {
            this._searchBar = new TextBox();
            this._grammar = new DataGridView();

            _grammar.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Title",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 30
            });
            _grammar.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Content",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 70
            });
            InitializeData();
            InitializeComponent();
        }

        private void InitializeData()
        {
            try
            {
                string path = GlobalVariables.DatabaseInstance.configApp.pathGrammar;
                string jsonData = File.ReadAllText(path);
                if (jsonData != null)
                {
                    List<GrammarItem> grammars = JsonConvert.DeserializeObject<List<GrammarItem>>(jsonData);
                    if (grammars != null)
                    {
                        GlobalVariables.DatabaseInstance.lstGrammar = grammars;
                        foreach (var item in grammars)
                        {
                            this._grammar.Rows.Add(item.form, item.structure);
                        }
                        return;
                    }
                }
                MessageBox.Show("Can not read JSON file: " + path);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail to initialize data!");
            }
        }

        public void SetPosition(int x, int y)
        {
            this.Location = new Point(x, y);
        }

        private void OnSearchBarChanged(object sender, EventArgs e)
        {
            this._grammar.Rows.Clear();
            if (this._searchBar.Text == string.Empty)
            {
                foreach (var item in GlobalVariables.DatabaseInstance.lstGrammar)
                {
                    this._grammar.Rows.Add(item.form, item.structure);
                }
            } 
            else
            {
                string text = this._searchBar.Text.ToLower();
                foreach (var item in GlobalVariables.DatabaseInstance.lstGrammar)
                {
                    if(item.form.ToLower().Contains(text) || item.structure.ToLower().Contains(text))
                    {
                        this._grammar.Rows.Add(item.form, item.structure);
                    }
                }
            }
        }

        private void OnSelectedGridView(object sender, EventArgs e)
        {
            this._grammar.ClearSelection();
        }
    }
}
