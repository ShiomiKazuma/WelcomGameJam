using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject player = collision.gameObject;
            SoundManager._instance.PlaySE(SESoundData.SE.Rain);
            // バフ処理
            
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
