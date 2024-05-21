using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    [SerializeField] Image _panel;
    
    public void SceneChange(string sceneName)
    {
        _panel.gameObject.SetActive(true);
        audioSource.PlayOneShot(audioclip);
        _panel.DOFade(1, 3.0f).OnComplete(() => SceneManager.LoadScene(sceneName));
    }
}
