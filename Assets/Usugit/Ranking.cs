using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{ 
    [SerializeField] List<RankingInfo> _ranking = new List<RankingInfo>();
    [SerializeField] Text[] _rankingText = new Text[3];
    [SerializeField] float _time = 0;
    [SerializeField] InputField _nameInput = null;
    [SerializeField] Text _myScore = null;
    bool _isRanking = false;
    int _rankingIndex = 0;

    private void Start()
    {
        _nameInput.gameObject.SetActive(false);
        IsRankin(_time);
        if (_isRanking)
        {
            _nameInput.gameObject.SetActive(true);
        }
        LoadRanking();
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
    }
    
    public void SetRanking()
    {
        _ranking[_rankingIndex].Time = _time;
        _ranking[_rankingIndex].Name = _nameInput.text;
        _nameInput.gameObject.SetActive(false);
        ShowRanking();
        SaveRanking();
    }
    
    public void SaveRanking()
    {
        var json = JsonUtility.ToJson(this);
        PlayerPrefs.SetString("Ranking", json);
        PlayerPrefs.Save();
    }
    
    public void LoadRanking()
    {
        var json = PlayerPrefs.GetString("Ranking");
        if (string.IsNullOrEmpty(json)) return;
        JsonUtility.FromJsonOverwrite(json, this);
    }
}

[Serializable]
public class RankingInfo
{
    [SerializeField] public float Time = 0;
    [SerializeField] public string Name = "AAA";
}
