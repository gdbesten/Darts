﻿using System.Collections.Generic;
using Darts.Model;

namespace Darts.ViewPresenter
{
    public interface IDartsFormView
    {
        void SetScoreListPlayer1(IList<Score> scoreList);
        void SetScoreListPlayer2(IList<Score> scoreList);
        void SetScorePlayer1(int score);
        void SetScorePlayer2(int score);
        void AddScoreToPlayerList1(Score score);
        void AddScoreToPlayerList2(Score score);
        void RemoveScoreToPlayerList1(Score lastItem);
        void RemoveScoreToPlayerList2(Score lastItem);
        void ClearScore();
        void HighestAveragePlayer1(int highest, int average);
        void HighestAveragePlayer2(int highest, int average);
        void SetPlayer1Name(string playerName);
        void SetPlayer2Name(string playerName);
    }
}