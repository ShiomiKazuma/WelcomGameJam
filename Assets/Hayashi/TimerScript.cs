using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    [SerializeField] Text timertext;
    float elapsedTime;
    bool counter_flag = false;
    private void Start()
    {
        timertext.text = $"タイム：{elapsedTime.ToString("F2")}秒";
    }
    void Update()
    {

        if (counter_flag == true)
        {
            elapsedTime += Time.deltaTime;
            timertext.text = $"タイム：{elapsedTime.ToString("F2")}秒";
            Debug.Log("計測中： " + (elapsedTime).ToString());
        }
    }

    public void CountStart()
    {
        counter_flag = true;
    }
    public void CountEnd()
    {
        counter_flag = false;
    }
}
