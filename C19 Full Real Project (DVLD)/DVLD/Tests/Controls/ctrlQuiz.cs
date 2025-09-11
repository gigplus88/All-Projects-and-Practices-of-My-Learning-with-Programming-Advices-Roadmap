using System.Windows.Forms;

namespace DVLD.Tests.Controls
{
    public partial class ctrlQuiz : UserControl
    {
        public int QuizNumber;
        public string QuizText;

        public ctrlQuiz()
        {
            InitializeComponent();
            lblQuizeNumber.Text = QuizNumber.ToString();
            lblQuizText.Text = QuizText;
        }
    }
}
