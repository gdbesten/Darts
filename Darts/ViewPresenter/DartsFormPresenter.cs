using System.Linq;
using Darts.Model;

namespace Darts.ViewPresenter
{
    public class DartsFormPresenter : IDartsFormPresenter
    {
        private readonly IDartsFormView _view;
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
            _view.HighestAveragePlayer1(0, 0);
            _view.HighestAveragePlayer2(0, 0);

            _turn = 1;
        }

        public void ChangeNamePlayer1(string namePlayer)
        {
        }

        public void ChangeNamePlayer2(string namePlayer)
        {
        }

        public void CancelLastScore()
        {
            if (_turn == 1)
            {
                RemoveLastEntryPlayer2();
                _turn = 2;
                return;
            }
            if (_turn == 2)
            {
                RemoveLastEntryPlayer1();
                _turn = 1;
            }
        }

        private void RemoveLastEntryPlayer1()
        {
            if (_player1.ScoreList.Any())
            {
                var lastItem = _player1.ScoreList.Last();
                _view.RemoveScoreToPlayerList1(lastItem);
            }
            var sum = SumHighestAndAverage(_player1, out var highest, out var average);
            _view.SetScorePlayer1(501 - sum);
            _view.HighestAveragePlayer1(highest, average);
        }


        private void RemoveLastEntryPlayer2()
        {
            if (_player2.ScoreList.Any())
            {
                var lastItem = _player2.ScoreList.Last();
                _view.RemoveScoreToPlayerList2(lastItem);
            }
            _view.SetScorePlayer1(501 - _player2.ScoreList.Sum(x => x.Points));
            var sum = SumHighestAndAverage(_player2, out var highest, out var average);
            _view.SetScorePlayer2(501 - sum);
            _view.HighestAveragePlayer2(highest, average);
        }

        public void AddScore(string scoreText)
        {
            int highest;
            int average;
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
                var sum = SumHighestAndAverage(_player1, out highest, out average);
                _view.SetScorePlayer1(501 - sum);
                _view.HighestAveragePlayer1(highest, average);
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
                var sum = SumHighestAndAverage(_player2, out highest, out average);
                _view.SetScorePlayer2(501 - sum);
                _view.HighestAveragePlayer2(highest, average);
                _view.ClearScore();
                _turn = 1;
                return;
            }
            _view.ClearScore();
        }

        private int SumHighestAndAverage(Player player, out int highest, out int average)
        {
            var sum = player.ScoreList.Sum(x => x.Points);
            var count = player.ScoreList.Count;
            highest = count > 0 ? player.ScoreList.Max(x => x.Points) : 0;
            average = count > 0 ? sum / count : 0;
            return sum;
        }

        private bool ValidScoreText(string scoreText, int totalScore)
        {
            var inputOk = false;
            if (!int.TryParse(scoreText, out var score)) return false;
            if (totalScore + score <= 501)
                inputOk = true;
            if (score > 180)
                inputOk = false;

            return inputOk;
        }
    }
}