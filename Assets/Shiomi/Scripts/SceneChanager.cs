using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanager : MonoBehaviour
{
    [SerializeField] Image _panel;
    [SerializeField] float _time = 3.0f;
    
    public void SceneChange(string sceneName)
    {
        _panel.gameObject.SetActive(true);
        _panel.DOFade(1, _time).OnComplete(() => SceneManager.LoadScene(sceneName));
    }
}