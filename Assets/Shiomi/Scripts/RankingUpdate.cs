using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingUpdate : MonoBehaviour
{
    private void Awake()
    {
        GameManager.Instatnce.RankingUpdate();
    }

    public void Restart()
    {
        SoundManager._instance.PlaySE(SESoundData.SE.Buttom);
        GameManager.Instatnce.IngameScene();
    }

    public void Title()
    {
        SoundManager._instance.PlaySE(SESoundData.SE.Buttom);
        GameManager.Instatnce.StartScene();
    }
}
