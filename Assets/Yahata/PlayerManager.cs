using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private SpriteRenderer playerSpriteRenderer;
    [SerializeField] private Image JumpChargeSlider;

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
    private float JumpPowerCharge;

    [SerializeField] private bool waterHitting;
    [SerializeField] private float waterHittingTimer;
    [SerializeField] private float WetBuffTime;
    [SerializeField] private float WetJumpPowerBuff;
    [SerializeField] private float WetBuff;
    private float goAxis;
    private float horizontal;

    [SerializeField] private Sprite flogSprite;

    void Start()
    {
        goAxis = 1;
        playerSpriteRenderer.sprite = flogSprite;
        JumpPowerCharge = 0;
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
                    playerRB.AddForce(new Vector2(-goAxis * 100, (flogBoundForce * (JumpPowerCharge + 0.5f)) * 0.2f));
                    Debug.Log(flogBoundForce * collisionNormal.y * (JumpPowerCharge + 0.5f));
                }
            } else
            {
                playerRB.AddForce(new Vector2(flogBoundForce * collisionNormal.x, flogBoundForce * collisionNormal.y * (JumpPowerCharge + 0.5f)));
            }

            JumpPowerCharge = 0;
            JumpChargeSlider.fillAmount = 0;
        }
    }

    public void waterHit()
    {
        waterHittingTimer = WetBuffTime;
        StartCoroutine(waterHitBuff());
    }


    private IEnumerator waterHitBuff()
    {
        if(!waterHitting)
        {
            waterHitting = true;
            _playerState = PlayerState.WetFlog;
            WetBuff = 1;

        }

        yield return new WaitUntil(() => waterHittingTimer <= 0 );

        _playerState = PlayerState.Flog;
        WetBuff = WetJumpPowerBuff;
        waterHitting = false;
        
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
                JumpPowerCharge += Time.deltaTime * 4;
            } else
            {
                JumpPowerCharge += Time.deltaTime * 6;
            }

            JumpChargeSlider.fillAmount = JumpPowerCharge / JumpPowerChargelimit;
        }

        if(Input.GetKeyDown(KeyCode.M))
        {
            waterHit();
        }
        if(waterHittingTimer > 0)
        {
            waterHittingTimer -= Time.deltaTime;
        }
    }


}
