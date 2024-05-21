using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private SpriteRenderer playerSpriteRenderer;
    public PlayerState _playerState;
    public enum PlayerState
    {
        Flog,
        WetFlog
    }

    [SerializeField] private float flogSpeed;
    [SerializeField] private float flogBoundForce;
    [SerializeField] private float wallJumpForce;

    [SerializeField] private float JumpPowerChargelimit;
    [SerializeField] private float JumpPowerCharge;
    [SerializeField] private float WetJumpPowerBuff;

    [SerializeField] private float WetBuff;
    private float goAxis;
    private float horizontal;

    [SerializeField] private Sprite flogSprite;

    void Start()
    {
        playerSpriteRenderer.sprite = flogSprite;
        JumpPowerCharge = 1;
        WetBuff = WetJumpPowerBuff;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //カエルが地面に触れた時
        if(collision.gameObject.CompareTag("Ground"))
        {
            Vector2 collisionNormal = collision.contacts[0].normal;

            if (flogSpeed > Mathf.Abs(playerRB.velocity.x) && collisionNormal.y >= 0.7f)
            {
                playerRB.velocity = new Vector2(goAxis * flogSpeed, playerRB.velocity.y);
            }

            if (Mathf.Abs(collisionNormal.x) >= 0.7f)
            {
                if (!(collisionNormal.x > 0 && goAxis < 0) && !(collisionNormal.x < 0 && goAxis > 0))
                {
                    playerRB.AddForce(new Vector2(flogBoundForce * collisionNormal.x, flogBoundForce * wallJumpForce));

                    Debug.Log("壁ジャンプ成功");
                } else
                {
                    playerRB.AddForce(new Vector2(playerRB.velocity.x * goAxis * 100, 0));
                    Debug.Log("壁ジャンプ失敗");
                }
            } else
            {
                playerRB.AddForce(new Vector2(flogBoundForce * collisionNormal.x, flogBoundForce * collisionNormal.y * JumpPowerCharge));
            }

            JumpPowerCharge = 0.5f;
        }
    }

    public IEnumerator waterHit()
    {
        _playerState = PlayerState.WetFlog;
        WetBuff = 1;

        Debug.Log("waterHit作動");
        yield return new WaitForSeconds(3);

        _playerState = PlayerState.Flog;
        WetBuff = WetJumpPowerBuff;
    }

    void Update()
    {
        //キャラ切り替えボタンは左Shiftボタン


        horizontal = Input.GetAxisRaw("Horizontal");
        if(horizontal != 0)
        {
            if (horizontal > 0)
            {
                playerSpriteRenderer.flipX = true;
            } else if( horizontal < 0)
            {
                playerSpriteRenderer.flipX = false;
            }

            goAxis = horizontal;
        }
        
        if(Input.GetKey(KeyCode.Space) && JumpPowerCharge < JumpPowerChargelimit * WetJumpPowerBuff / WetBuff)
        {
            if(_playerState == PlayerState.Flog)
            {
                JumpPowerCharge += Time.deltaTime * 2;
            } else
            {
                JumpPowerCharge += Time.deltaTime * 4;
            }
        }

        if(Input.GetKeyDown(KeyCode.M))
        {
            StartCoroutine(waterHit());

        }
    }
}
