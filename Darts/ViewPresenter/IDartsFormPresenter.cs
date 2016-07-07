namespace Darts.ViewPresenter
{
    public interface IDartsFormPresenter
    {
        void StartNewGame(string namePlayer1, string namePlayer2);
        void ChangeNamePlayer1(string name);
        void ChangeNamePlayer2(string name);
        void CancelLastScore();
        void AddScore(string scoreText);
    }
}