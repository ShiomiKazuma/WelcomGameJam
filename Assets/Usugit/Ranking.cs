using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{ 
    RankingInfo[] _ranking = new RankingInfo[3];
    Text[] _rankingText = new Text[3];

    public void ShowRanking()
    {
        for (int i = 0; i < _ranking.Length; i++)
        {
            _rankingText[i].text = $"{i + 1}位 {_ranking[i].Name} {_ranking[i].Time}秒";
        }
    }
    
    public void SaveScore(RankingInfo info)
    {
        for (int i = 0; i < _ranking.Length; i++)
        {
            if (_ranking[i].Time > info.Time)
            {
                RankingInfo temp = _ranking[i];
                _ranking[i] = info;
                info = temp;
            }
        }
}

public class RankingInfo
{
    public int Time { get; set; }
    public string Name { get; set; }
}
