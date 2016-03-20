using System;
using System.Linq;
using System.Windows.Forms;

namespace Darts
{
    public partial class DartsForm : Form
    {
        private Player _player1;
        private Player _player2;
        private int _turn = 1;

        public DartsForm()
        {
            InitializeComponent();
        }

        private void DartsForm_Load(object sender, EventArgs e)
        {
            StartNewGame();
        }

        private void StartNewGame()
        {
            _player1 = new Player(textEditPlayer1.Text);
            _player2 = new Player(textEditPlayer2.Text);

            bindingSourcePlayer1.DataSource = _player1.ScoreList;
            bindingSourcePlayer2.DataSource = _player2.ScoreList;

            textEditPlayer1.Text = "501";
            textEditPlayer2.Text = "501";

            _turn = 1;
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            _player1.Name = textEdit1.Text;
        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {
            _player2.Name = textEdit2.Text;
        }

        private void simpleButtonOK_Click(object sender, EventArgs e)
        {
            if (_turn == 1)
            {
                _turn = 2;
                var score = new Score
                    {
                        SequenceNumber = _player1.ScoreList.Count + 1,
                        Points = int.Parse(textEditScore.Text)
                    };
                var newScore = (Score) bindingSourcePlayer1.AddNew();
                newScore.SequenceNumber = score.SequenceNumber;
                newScore.Points = score.Points;
                textEditScore.Text = "";
                textEditPlayer1.Text = (501 - _player1.ScoreList.Sum(x => x.Points)).ToString();
                bindingSourcePlayer1.DataSource = _player1.ScoreList;
                gridControlPlayer1.Refresh();
                return;
            }
            if (_turn == 2)
            {
                _turn = 1;
                var score =
                    new Score
                    {
                        SequenceNumber = _player2.ScoreList.Count + 1,
                        Points = int.Parse(textEditScore.Text)
                    };
                var newScore = (Score)bindingSourcePlayer2.AddNew();
                newScore.SequenceNumber = score.SequenceNumber;
                newScore.Points = score.Points;
                textEditScore.Text = "";
                textEditPlayer2.Text = (501 - _player2.ScoreList.Sum(x => x.Points)).ToString();
                bindingSourcePlayer2.DataSource = _player2.ScoreList;
                gridControlPlayer2.Refresh();
            }

        }

        private void simpleButtonNew_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            if (_turn == 1)
            {
                _turn = 2;
                if (_player1.ScoreList.Any())
                {
                    var lastItem = _player1.ScoreList.Last();
                    _player1.ScoreList.Remove(lastItem);
                }
                textEditPlayer1.Text = (501 - _player1.ScoreList.Sum(x => x.Points)).ToString();
                gridControlPlayer1.Refresh();
                return;
            }
            if (_turn == 2)
            {
                _turn = 1;
                if (_player2.ScoreList.Any())
                {
                    var lastItem = _player2.ScoreList.Last();
                    _player2.ScoreList.Remove(lastItem);
                }
                textEditPlayer2.Text = (501 - _player2.ScoreList.Sum(x => x.Points)).ToString();
                gridControlPlayer2.Refresh();
            }
        }
    }
}