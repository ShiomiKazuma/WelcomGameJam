using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainGenerator : MonoBehaviour
{
    [SerializeField] float _startTime = 0.0f;
    [SerializeField] float _interval = 3.0f;
    [SerializeField] GameObject _rain;
    private float _timer;
    bool IsStart = false;

    private void Start()
    {
        _timer = 0;
        IsStart = false;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if(IsStart)
        {
            if(_timer > _interval)
            {
                _timer = 0;
                Instantiate(_rain, this.transform.position, Quaternion.identity);
            }
        }
        else
        {
            if(_timer > GameManager.Instatnce.Timer) 
            {
                _timer = 0;
                Instantiate(_rain, this.transform.position, Quaternion.identity);
            }
        }

    }
}
