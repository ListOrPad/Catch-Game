using YG;
using UnityEngine;
using YG.Utils.LB;

public class Leaderboard : MonoBehaviour
{
    private int previousRecord;

    void Start()
    {
        YandexGame.onGetLeaderboard += GetPlayerScore;
        YandexGame.GetLeaderboard("Score", 1000000, 3, 10, "42"); //change parameters to actual data
    }

    public void WriteRecord(int ScoreCount)
    {
        Debug.Log(previousRecord + "is your PREV record");

        //Adding score to the leaderboard if previous record from the leaderboard is lesser than current Score
        if (previousRecord < ScoreCount)
        {
            previousRecord = ScoreCount;
            Debug.Log(ScoreCount + "is your NEW record");
            YandexGame.NewLeaderboardScores("Score", ScoreCount);
        }
    }

    private void GetPlayerScore(LBData lbData)
    {
        string currentPlayerId = YandexGame.playerId;

        // Find the current player's data in the leaderboard
        foreach (var player in lbData.players)
        {
            if (player.name == currentPlayerId)
            {
                previousRecord = player.score;
                break;
            }
        }
    }
}
