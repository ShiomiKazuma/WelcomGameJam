using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject player = collision.gameObject;
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        rb.AddForce(-transform.forward);
    }
}
