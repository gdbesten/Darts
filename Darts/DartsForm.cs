using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Darts.Model;
using Darts.ViewPresenter;

namespace Darts
{
    public partial class DartsForm : Form, IDartsFormView
    {
        private string _formattableString;
        private IDartsFormPresenter DartsFormPresenter { get; set; }


        public DartsForm()
        {
            InitializeComponent();
        }

        private void DartsForm_Load(object sender, EventArgs e)
        {
            DartsFormPresenter = new DartsFormPresenter(this);
            DartsFormPresenter.StartNewGame(textEditPlayer1.Text, textEditPlayer2.Text);
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            DartsFormPresenter.ChangeNamePlayer1(textEdit1.Text);
        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {
            DartsFormPresenter.ChangeNamePlayer2(textEdit2.Text);
        }

        private void simpleButtonOK_Click(object sender, EventArgs e)
        {
            DartsFormPresenter.AddScore(textEditScore.Text);
        }

        private void simpleButtonNew_Click(object sender, EventArgs e)
        {
            DartsFormPresenter.StartNewGame(textEditPlayer1.Text, textEditPlayer2.Text);
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            DartsFormPresenter.CancelLastScore();
        }

        public void SetScoreListPlayer1(IList<Score> scoreList)
        {
            bindingSourcePlayer1.DataSource = scoreList;
        }

        public void SetScorePlayer1(int score)
        {
            textEditPlayer1.Text = score.ToString();
            gridControlPlayer1.Refresh();
        }

        public void SetScoreListPlayer2(IList<Score> scoreList)
        {
            bindingSourcePlayer2.DataSource = scoreList;
        }

        public void SetScorePlayer2(int score)
        {
            textEditPlayer2.Text = score.ToString();
            gridControlPlayer2.Refresh();
        }

        public void AddScoreToPlayerList1(Score score)
        {
            bindingSourcePlayer1.Add(score);
            textEditScore.Text = "";
        }

        public void AddScoreToPlayerList2(Score score)
        {
            bindingSourcePlayer2.Add(score);
        }

        public void RemoveScoreToPlayerList1(Score lastScore)
        {
            bindingSourcePlayer1.Remove(lastScore);
        }

        public void RemoveScoreToPlayerList2(Score lastScore)
        {
            bindingSourcePlayer2.Remove(lastScore);
        }

        public void ClearScore()
        {
            textEditScore.Text = "";
        }

        public void HighestAveragePlayer1(int highest, int average)
        {
            _formattableString = $"{highest} / {average}";
            textEditHighestAvarage1.Text = _formattableString;
        }

        public void HighestAveragePlayer2(int highest, int average)
        {
            _formattableString = $"{highest} / {average}";
            textEditHighestAvarage2.Text = _formattableString;
        }
    }
}