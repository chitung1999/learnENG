using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
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
    public class Database
    {
        public Database() 
        {
            _lstQuestions = new List<QuestionItem>();
            _pathFile = string.Empty;
            isModify = false;
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
            _pathFile = string.Empty;
        }

        public List<QuestionItem> GetAllItem()
        {
            return _lstQuestions;
        }

        public int Size()
        {
            return _lstQuestions.Count;
        }

        public void SetPath(string path)
        {
            _pathFile = path;
        }

        public string getPath()
        {
            return _pathFile;
        }

        private List<QuestionItem> _lstQuestions;
        private string _pathFile;
        public bool isModify;
    }
}
