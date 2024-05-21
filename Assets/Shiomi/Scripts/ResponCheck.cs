using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponCheck : MonoBehaviour
{
    ResponManager respon;
    bool IsActive = true;
    void Start()
    {
        respon = GameObject.Find("ResponManager").GetComponent<ResponManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(IsActive)
        {
            if (collision.gameObject.tag == "Player")
            {
                respon.ResponChange();
                IsActive = false;
            }
        } 
    }
}
