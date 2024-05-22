using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : SingletonBase<GameManager>
{
    public float Timer;
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
            Timer += Time.deltaTime;
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
        Timer = 0;
        var sceneManager = GameObject.Find("SceneManager").GetComponent<SceneChanager>();
        sceneManager.SceneChange(_startSceneName);
    }
}
