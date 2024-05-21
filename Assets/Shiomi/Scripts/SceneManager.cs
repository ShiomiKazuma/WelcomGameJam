<<<<<<< HEAD
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
=======
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
>>>>>>> 51afb274cd7933f0f8bc559aecd07602feb3fb48
