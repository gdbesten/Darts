using Darts.Model;

namespace Darts.ViewPresenter
{
    public interface IDartsFormPresenter
    {
        void StartNewGame(string namePlayer1, string namePlayer2);
        void ChangeNamePlayer1(string namePlayer);
        void ChangeNamePlayer2(string namePlayer);
        void CancelLastScore();
        void AddScore(string scoreText);
    }
}