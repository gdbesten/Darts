using System.Linq;
using Darts.Model;

namespace Darts.ViewPresenter
{
    public class DartsFormPresenter : IDartsFormPresenter
    {
        private IDartsFormView _view { get; set; }
        private Player _player1;
        private Player _player2;
        private int _turn;

        public DartsFormPresenter(IDartsFormView view)
        {
            _view = view;
        }

        public void StartNewGame(string namePlayer1, string namePlayer2)
        {
            _player1 = new Player(namePlayer1);
            _player2 = new Player(namePlayer2);

            _view.SetScoreListPlayer1(_player1.ScoreList);
            _view.SetScorePlayer1(501);
            _view.SetScoreListPlayer2(_player2.ScoreList);
            _view.SetScorePlayer2(501);

            _turn = 1;
        }

        public void ChangeNamePlayer1(string namePlayer)
        {
            _player1.Name = namePlayer;
        }

        public void ChangeNamePlayer2(string namePlayer)
        {
            _player2.Name = namePlayer;
        }

        public void CancelLastScore()
        {
            if (_turn == 1)
            {
                if (_player1.ScoreList.Any())
                {
                    var lastItem = _player1.ScoreList.Last();
                    _view.RemoveScoreToPlayerList1(lastItem);
                }
                _view.SetScorePlayer1(501 - _player1.ScoreList.Sum(x => x.Points));
                _turn = 2;
                return;
            }
            if (_turn == 2)
            {
                if (_player2.ScoreList.Any())
                {
                    var lastItem = _player2.ScoreList.Last();
                    _view.RemoveScoreToPlayerList2(lastItem);
                }
                _view.SetScorePlayer2(501 - _player2.ScoreList.Sum(x => x.Points));
                _turn = 1;
            }
        }

        public void AddScore(string scoreText)
        {
            if (string.IsNullOrWhiteSpace(scoreText))
                return;

            if (_turn == 1 && ValidScoreText(scoreText, _player1.ScoreList.Sum(x => x.Points)))
            {
                var score = new Score
                {
                    SequenceNumber = _player1.ScoreList.Count + 1,
                    Points = int.Parse(scoreText)
                };
                _view.AddScoreToPlayerList1(score);
                _view.SetScorePlayer1(501 - _player1.ScoreList.Sum(x => x.Points));
                _view.ClearScore();
                _turn = 2;
                return;
            }
            if (_turn == 2 && ValidScoreText(scoreText, _player2.ScoreList.Sum(x => x.Points)))
            {
                var score =
                    new Score
                    {
                        SequenceNumber = _player2.ScoreList.Count + 1,
                        Points = int.Parse(scoreText)
                    };
                _view.AddScoreToPlayerList2(score);
                _view.SetScorePlayer2(501 - _player2.ScoreList.Sum(x => x.Points));
                _view.ClearScore();
                _turn = 1;
                return;
            }
            _view.ClearScore();

        }

        private bool ValidScoreText(string scoreText, int totalScore)
        {
            var inputOK = false;
            var score = 0;
            if (int.TryParse(scoreText, out score))
            {
                if (totalScore - score < 0)
                    inputOK = true;
                if (score > 180)
                    inputOK = false;
            }

            return inputOK;
        }
    }
}