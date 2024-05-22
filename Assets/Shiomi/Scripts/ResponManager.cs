using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponManager : MonoBehaviour
{
    [SerializeField] List<Transform> _respon = new List<Transform>();
    int _responNum;

    private void Start()
    {
        _responNum = 0;
    }
    public void ResponChange()
    {
        _responNum++;
    }

    public void Respon()
    {
        var player = GameObject.FindWithTag("Player");
        player.transform.position = _respon[_responNum].transform.position;
    }
}
