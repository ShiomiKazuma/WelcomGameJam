using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{ 
    [SerializeField] List<RankingInfo> _ranking = new List<RankingInfo>();
    [SerializeField] Text[] _rankingText;
    [SerializeField] float _time = 0;
    [SerializeField] InputField _nameInput = null;
    [SerializeField] Text _myScore = null;
    [SerializeField] GameObject[] _rankingObject;
    bool _isRanking = false;
    int _rankingIndex = 0;

    private void Start()
    {
        _nameInput.gameObject.SetActive(false);
        _rankingObject.ToList().ForEach(x => x.SetActive(false));
        IsRankin(_time);
        if (_isRanking)
        {
            _nameInput.gameObject.SetActive(true);
        }
        
        var tempRanking = RankingManager.LoadRanking();
        if (tempRanking.Count != 0)
            _ranking = RankingManager.LoadRanking();
        ShowRanking();
    }
    
    public void IsRankin(float time)
    {
        for (int i = 0; i < _ranking.Count; i++)
        {
            if (time < _ranking[i].Time)
            {
                _isRanking = true;
                _rankingIndex = i;
                return;
            }
        }
    }

    public void ShowRanking()
    {
        _ranking.Sort((a, b) => a.Time.CompareTo(b.Time));
        for (int i = 0; i < _ranking.Count; i++)
        {
            _rankingText[i].text = $"{i + 1}位 {_ranking[i].Time:F2}秒 {_ranking[i].Name}";
        }
        _myScore.text = $"あなたのタイム {_time:F2}秒";

        StartCoroutine( ShowRankingCoroutine());
    }
    
    IEnumerator ShowRankingCoroutine()
    {
        foreach (var rankingText in _rankingText)
        {   //テキストの移動開始地点の設定
            var rect = rankingText.GetComponent<RectTransform>();
            rect.position = new Vector3(rect.position.x, rect.position.y - 140, 0 );
        }

        foreach (var rankingText in _rankingText)
        {   //テキストの移動
            var rect = rankingText.GetComponent<RectTransform>();
            rect.DOMoveY(rect.position.y + 140, 1);
            yield return new WaitForSeconds(1);
        }
        
        foreach (var rankingObject in _rankingObject)
        {   //オブジェクトの移動
            rankingObject.SetActive(true);
            yield return new WaitForSeconds(1);
        }
    }

    void ShowRankingInstantly()
    {
        _ranking.Sort((a, b) => a.Time.CompareTo(b.Time));
        for (int i = 0; i < _ranking.Count; i++)
        {
            _rankingText[i].text = $"{i + 1}位 {_ranking[i].Time:F2}秒 {_ranking[i].Name}";
        }
        _myScore.text = $"あなたのタイム {_time:F2}秒";
    }
    
    public void SetRanking()
    {
        _ranking.Insert(_rankingIndex, new RankingInfo() { Time = _time, Name = _nameInput.text});
        _ranking.RemoveAt(_ranking.Count - 1);
        _nameInput.gameObject.SetActive(false);
        ShowRankingInstantly();
        RankingManager.SaveRanking(_ranking);
    }
}

[Serializable]
public class RankingInfo
{
    [SerializeField] public float Time = 0;
    [SerializeField] public string Name = "AAA";
}

public static class RankingManager
{
    private static string rankingKey = "ranking";

    public static void SaveRanking(List<RankingInfo> rankings)
    {
        string json = JsonUtility.ToJson(new RankingList { Rankings = rankings });
        PlayerPrefs.SetString(rankingKey, json);
        PlayerPrefs.Save();
    }

    public static List<RankingInfo> LoadRanking()
    {
        string json = PlayerPrefs.GetString(rankingKey, string.Empty);
        if (string.IsNullOrEmpty(json))
        {
            return new List<RankingInfo>();
        }
        return JsonUtility.FromJson<RankingList>(json).Rankings;
    }
}

[System.Serializable]
public class RankingList
{
    public List<RankingInfo> Rankings;
}