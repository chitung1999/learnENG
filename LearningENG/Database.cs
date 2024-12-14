using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LearningENG
{
    public enum QuestionStatus
    {
        NONE = 0,
        TRUE,
        FALSE,
        REVIEWED
    }
    public class QuestionItem
    {
        public string question { get; set; }

        public string correct_answer { get; set; }
        public string answer { get; set; }
        public string note { get; set; }
        public int status { get; set; }

        public QuestionItem()
        {
            question = string.Empty;
            correct_answer = string.Empty;  
            answer = string.Empty;
            note = string.Empty;
            status = (int)QuestionStatus.NONE;
        }
    }

    public class ConfigApp
    {
        public string pathGrammar { get; set; }

        public string pathNewword { get; set; }

        public ConfigApp()
        {
            pathGrammar = string.Empty;
            pathNewword = string.Empty;
        }
    }

    public class GrammarItem
    {
        public string form { get; set; }

        public string structure { get; set; }

        public GrammarItem()
        {
            form = string.Empty;
            structure = string.Empty;
        }
    }

    public class NewWordItem
    {
        public List<string> keys { get; set; }

        public List<string> means { get; set; }

        public string notes { get; set; }

        public NewWordItem()
        {
            keys = new List<string>();
            means = new List<string>();
            notes = string.Empty;
        }
    }

    public class Database
    {
        public Database() 
        {
            _lstQuestions = new List<QuestionItem>();
            lstGrammar = new List<GrammarItem>();
            configApp = new ConfigApp();
            _pathQuestion = string.Empty;
            isModify = false;
            _pathConfig = Application.StartupPath + "\\Data\\config.json";
        }

        public void AddItem(QuestionItem questionItem)
        {
            isModify = true;
            _lstQuestions.Add(questionItem);
        }

        public QuestionItem GetItem(int index)
        {
            return _lstQuestions[index];
        }

        public void UpdateItem(int index, QuestionItem newQuestionItem)
        {
            isModify = true;
            if (index >= 0 && index < _lstQuestions.Count)
            {
                _lstQuestions[index] = newQuestionItem;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
            }
        }

        public void Init(List<QuestionItem> list) 
        {
            _lstQuestions = list;
        }

        public void Clear()
        {
            _lstQuestions.Clear();
            _pathQuestion = string.Empty;
        }

        public List<QuestionItem> GetAllItem()
        {
            return _lstQuestions;
        }

        public int Size()
        {
            return _lstQuestions.Count;
        }

        public void setPathQuestion(string path)
        {
            _pathQuestion = path;
        }

        public string getPathQuestion()
        {
            return _pathQuestion;
        }

        public string getPathConfig()
        {
            return _pathConfig;
        }

        private List<QuestionItem> _lstQuestions;
        public List<GrammarItem> lstGrammar;
        public ConfigApp configApp;
        private string _pathQuestion;
        public string _pathConfig;
        public bool isModify;
    }
}
