using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUpdate : MonoBehaviour
{
    [SerializeField] Text _text;

    // Update is called once per frame
    void Update()
    {
        _text.text = "Time�F" + GameManager.Instatnce.Timer.ToString("f2");
    }
}
