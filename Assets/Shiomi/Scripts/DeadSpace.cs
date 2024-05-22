using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadSpace : MonoBehaviour
{
    [SerializeField] ResponManager _responManager;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _responManager.Respon();
        }
    }


}
