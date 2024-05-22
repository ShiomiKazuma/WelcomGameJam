using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instatnce.StageStart();
        var player = GameObject.FindWithTag("Player");
        var manager = player.GetComponent<PlayerManager>();
        manager.Up();
    }
}
