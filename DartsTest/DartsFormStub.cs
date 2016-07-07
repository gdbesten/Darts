using System.Collections.Generic;
using Darts.Model;
using Darts.ViewPresenter;

namespace DartsTest
{
    public class DartsFormStub : IDartsFormView
    {
        _
        public void SetScoreListPlayer1(IList<Score> scoreList)
        {
            ScoreListPlayer1 = scoreList;
        }

        public void SetScoreListPlayer2(IList<Score> scoreList)
        {
            throw new System.NotImplementedException();
        }

        public void SetScorePlayer1(int score)
        {
            throw new System.NotImplementedException();
        }

        public void SetScorePlayer2(int score)
        {
            throw new System.NotImplementedException();
        }

        public void AddScoreToPlayerList1(Score score)
        {
            throw new System.NotImplementedException();
        }

        public void AddScoreToPlayerList2(Score score)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveScoreToPlayerList1(Score lastItem)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveScoreToPlayerList2(Score lastItem)
        {
            throw new System.NotImplementedException();
        }

        public void ClearScore()
        {
            throw new System.NotImplementedException();
        }
    }
}