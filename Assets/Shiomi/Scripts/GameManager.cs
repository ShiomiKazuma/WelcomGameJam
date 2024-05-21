using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : SingletonBase<GameManager>
{
    float _time;
    bool IsStart = false;
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

    public void Start()
    {
        IsStart = true;
    }
    public void Goal()
    {
        IsStart = false;
    }


}
