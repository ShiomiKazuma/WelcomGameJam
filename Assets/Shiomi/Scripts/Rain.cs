using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
<<<<<<< HEAD
=======
<<<<<<< HEAD

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject player = collision.gameObject;
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        rb.AddForce(-transform.forward);
=======
    [SerializeField] float _focePower = 100f;
>>>>>>> 7ae32b059f9aa8eb4d930b48ed4e1dfbad9169c0
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
>>>>>>> 51afb274cd7933f0f8bc559aecd07602feb3fb48
    }
}
