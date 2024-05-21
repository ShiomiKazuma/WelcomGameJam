using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : SingletonBase<GameManager>
{
    public static float _time;
    bool IsStart = false;
    [SerializeField] private string _startSceneName;
    [SerializeField] private string _resultSceneName;
    [SerializeField] private string _ingameSceneName;
    protected override void DoAwake()
    {
        
    }

    private void Update()
    {
        if(IsStart)
        {
            _time += Time.deltaTime;
        }
    }

    /// <summary>
    /// インゲームのシーン遷移
    /// </summary>
    public void IngameScene()
    {
        var sceneManager = GameObject.Find("SceneManager").GetComponent<SceneChanager>();
        sceneManager.SceneChange(_ingameSceneName);
    }

    /// <summary>
    /// スタート開始
    /// </summary>
    public void StageStart()
    {
        IsStart = true;
    }

    /// <summary>
    /// ゴールした時の処理
    /// </summary>
    public void Goal()
    {
        var sceneManager = GameObject.Find("SceneManager").GetComponent<SceneChanager>();
        IsStart = false;
        sceneManager.SceneChange(_resultSceneName);
    }

    /// <summary>
    /// スタートシーンに戻る時
    /// </summary>
    public void StartScene()
    {
        _time = 0;
        var sceneManager = GameObject.Find("SceneManager").GetComponent<SceneChanager>();
        sceneManager.SceneChange(_startSceneName);
    }
}
