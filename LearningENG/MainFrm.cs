using Newtonsoft.Json;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace LearningENG
{
    public static class GlobalVariables
    {
        public static Database DatabaseInstance { get; set; } = new Database();
    }

    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            _listQuestion = new ListBox();
            _content = new Panel();
            _totalQuestion = new Label();
            _totalNone = new Label();
            _totalTrue = new Label();
            _totalFalse = new Label();
            _totalReview = new Label();
            _questionContent = new TextBox();
            _answerContent = new TextBox();
            _correctContent = new TextBox();
            _noteContent = new TextBox();
            _reviewedBtn = new Button();
            _okBtn = new Button();

            var assembly = Assembly.GetExecutingAssembly();
            var stream = assembly.GetManifestResourceStream("LearningENG.Resources.question.png");
            if (stream != null)
            {
                _iconNone = System.Drawing.Image.FromStream(stream);
            }

            stream = assembly.GetManifestResourceStream("LearningENG.Resources.true.png");
            if (stream != null)
            {
                _iconTrue = System.Drawing.Image.FromStream(stream);
            }

            stream = assembly.GetManifestResourceStream("LearningENG.Resources.false.png");
            if (stream != null)
            {
                _iconFalse = System.Drawing.Image.FromStream(stream);
            }

            stream = assembly.GetManifestResourceStream("LearningENG.Resources.reviewed.png");
            if (stream != null)
            {
                _iconReviewed = System.Drawing.Image.FromStream(stream);
            }

            this.Icon = new Icon("Resources/icon_app.ico");

            InitializeComponent();
        }

        private void ClickBtnOpenFile(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                openFile.Title = "Select JSON file";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string path = openFile.FileName;
                        GlobalVariables.DatabaseInstance.SetPath(path);

                        List<QuestionItem> questions;
                        string jsonData = File.ReadAllText(path);
                        if (jsonData != null) 
                        {
                            questions = JsonConvert.DeserializeObject<List<QuestionItem>>(jsonData);

                            if (questions != null && questions.Count > 0)
                            {
                                GlobalVariables.DatabaseInstance.Init(questions);
                                InitQuestion(questions);
                                InitContent(questions[0]);
                                InitHeader();
                                this._listQuestion.SetSelected(0, true);
                                this._listQuestion.Visible = true;
                                this._content.Visible = true;
                            }
                            else
                            {
                                MessageBox.Show("Empty JSON file!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Can not read JSON file!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error reading JSON file: " + ex.Message);
                    }
                }
            }
        }

        private void ClickBtnSaveFile(object sender, EventArgs e)
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(GlobalVariables.DatabaseInstance.GetAllItem(), Formatting.Indented);
                string pathFile = GlobalVariables.DatabaseInstance.getPath();
                File.WriteAllText(pathFile, jsonData);
                MessageBox.Show("Writing data to JSON file successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GlobalVariables.DatabaseInstance.isModify = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Writing data to JSON file failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClickBtnCloseFile(object sender, EventArgs e)
        {
            if (GlobalVariables.DatabaseInstance.isModify)
            {
                DialogResult ret = MessageBox.Show("Do you want to save data?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (ret == DialogResult.Yes)
                {
                    ClickBtnSaveFile(sender, e);
                }
            }

            this._listQuestion.Visible = false;
            this._content.Visible = false;
            GlobalVariables.DatabaseInstance.Clear();
        }

        private void ClickBtnCloseApp(object sender, EventArgs e)
        {
            ClickBtnCloseFile(sender, e);
        }

        private void ClickBtnReviewed(object sender, EventArgs e)
        {
            int index = this._listQuestion.SelectedIndex;

            QuestionItem item = GlobalVariables.DatabaseInstance.GetItem(index);
            switch (item.status)
            {
                case 0: //QuestionStatus::NONE
                    //MessageBox.Show("This question has not been answered yet!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return;
                case 1: //QuestionStatus::TRUE
                case 2: //QuestionStatus::FALSE
                    item.status = 3;
                    break;
                case 3: //QuestionStatus::REVIEWED
                    if (item.answer == string.Empty) {
                        item.status = 0;
                    } else if (item.answer.ToLower() == item.correct_answer.ToLower()) 
                    {
                        item.status = 1;
                    } else
                    {
                        item.status = 2;
                    }
                    break;
            }

            //Update database
            GlobalVariables.DatabaseInstance.UpdateItem(index, item);

            //UI
            this._listQuestion.Invalidate();
        }

        private void ClickBtnOK(object sender, EventArgs e)
        {
            if (this._answerContent.Text == string.Empty)
            {
                MessageBox.Show("Empty answer!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int index = this._listQuestion.SelectedIndex;
            QuestionItem item = GlobalVariables.DatabaseInstance.GetItem(index);
            item.answer = this._answerContent.Text;
            item.note = this._noteContent.Text;

            this._correctContent.Text = item.correct_answer;
            this._correctContent.Visible = true;

            if (this._answerContent.Text.ToLower() == item.correct_answer.ToLower())
            {
                item.status = 1;
                this._correctContent.ForeColor = Color.Green;
            }
            else
            {
                item.status = 2;
                this._correctContent.ForeColor = Color.Red;
            }

            //Update database
            GlobalVariables.DatabaseInstance.UpdateItem(index, item);

            //UI
            this._listQuestion.Invalidate();
        }

        private void OnPressKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (_answerContent.Focused) 
                {
                    ClickBtnOK(sender, e);
                    this._listQuestion.Focus();
                } else
                {
                    int index = this._listQuestion.SelectedIndex + 1;
                    if (index != ListBox.NoMatches)
                    {
                        this._listQuestion.SetSelected(index, true);
                    }
                }    
            }
        }

        private void drawItemListBox(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            Image img;
            int status = GlobalVariables.DatabaseInstance.GetItem(e.Index).status;
            switch (status)
            {
                case 0: //QuestionStatus::NONE
                    img = _iconNone;
                    break;
                case 1: //QuestionStatus::TRUE
                    img = _iconTrue;
                    break;
                case 2: //QuestionStatus::FALSE
                    img = _iconFalse;
                    break;
                case 3: //QuestionStatus::REVIEWED
                    img = _iconReviewed;
                    break;
                default:
                    img = _iconNone;
                    break;
            }

            if (e.Index >= 0 && img != null)
            {
                e.Graphics.DrawImage(img, e.Bounds.Left + 5, e.Bounds.Top + 12, 16, 16);
                using (Font font = new Font(this.Font.FontFamily, 13))
                {
                    e.Graphics.DrawString(_listQuestion.Items[e.Index].ToString(), font, Brushes.Black, e.Bounds.Left + 30, e.Bounds.Top + 8);
                }
            }
            e.DrawFocusRectangle();
        }

        private void selectQuestion(object sender, EventArgs e)
        {

            int index = this._listQuestion.SelectedIndex;
            if (index != ListBox.NoMatches)
            {
                InitContent(GlobalVariables.DatabaseInstance.GetItem(index));
                InitHeader();
            }
        }

        private void InitHeader()
        {
            int total = GlobalVariables.DatabaseInstance.Size();
            int totalNone = 0;
            int totalTrue = 0;
            int totalFalse = 0;
            int totalReviewed = 0;
            
            foreach(var item in GlobalVariables.DatabaseInstance.GetAllItem())
            {
                switch (item.status)
                {
                    case 0: //QuestionStatus::NONE
                        totalNone++;
                        break;
                    case 1: //QuestionStatus::TRUE
                        totalTrue++;
                        break;
                    case 2: //QuestionStatus::FALSE
                        totalFalse++;
                        break;
                    case 3: //QuestionStatus::REVIEWED
                        totalReviewed++;
                        if(item.answer == item.correct_answer) 
                        {
                            totalTrue++;
                        } else
                        {
                            totalFalse++;
                        }

                        break;
                }
            }

            this._totalQuestion.Text = "Total: " + total.ToString();
            this._totalNone.Text = totalNone.ToString();
            this._totalTrue.Text = totalTrue.ToString();
            this._totalFalse.Text = totalFalse.ToString();
            this._totalReview.Text = totalReviewed.ToString();
        }

        public void InitQuestion(List<QuestionItem> list)
        {
            int i = 0;
            foreach (var item in list)
            {
                _listQuestion.Items.Add(++i + ". " + item.question);
            }
        }

        public void InitContent(QuestionItem item)
        {
            this._questionContent.Text = item.question;
            this._answerContent.Text = item.answer;
            this._noteContent.Text = item.note;
            this._correctContent.Text = item.correct_answer;

            this._answerContent.Focus();

            switch (item.status)
            {
                case 0: //QuestionStatus::NONE
                    this._correctContent.Visible = false;
                    break;
                case 1: //QuestionStatus::TRUE
                    this._correctContent.Visible = true;
                    this._correctContent.ForeColor = Color.Green;
                    break;
                case 2: //QuestionStatus::FALSE
                    this._correctContent.Visible = true;
                    this._correctContent.ForeColor = Color.Red;
                    break;
                case 3: //QuestionStatus::REVIEWED
                    this._correctContent.Visible = true;
                    this._correctContent.ForeColor = Color.Blue;
                    break;
            }
        }
    }
}
