using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject player = collision.gameObject;
            SoundManager._instance.PlaySE(SESoundData.SE.Rain);
            // バフ処理
            var manager = collision.gameObject.GetComponent<SoundManager>();
        }
    }
}
