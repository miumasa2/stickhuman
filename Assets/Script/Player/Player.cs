using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float flap = 1000f;
    [SerializeField] float scroll = 5f;
    [SerializeField] float dex; // 速さ
    private int rev = 1;
    private float direction = 0f, invincibleTime, x;
    Rigidbody2D rb2d;
    public bool jump { get; set; }          // ジャンプ
    public bool carry { get; set; }         // 運ぶ
    public bool go { get; set; }            // 一時停止時の反転防止
    private bool have = false;              // 所持
    private bool dash = false;              // ダッシュ
    private bool invincible = false;
    private HP hp;                          // HPクラス
    private int speed = 1;                  // スピード
    private bool stopper = false;           // ストッパー
    [SerializeField] Animator animator;     // Animatorを取得
    [SerializeField] Sprite ps;
    private SpriteRenderer psr;
    private AudioSource audioSource;
    [SerializeField] AudioClip Jump;
    //追加
    [SerializeField] AudioClip Humu;
    [SerializeField] AudioClip Dameagi;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        GameObject HP = GameObject.Find("H");                               // HPをオブジェクトの名前から取得して変数に格納
        hp = HP.GetComponent<HP>();                                         // HPの中にあるHPを取得して変数に格納
        psr = gameObject.GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Vector3 scale = transform.localScale;       // スケール値取り出し

        if (Input.GetKey("left shift") || Input.GetKey("joystick button 0"))         // ダッシュ時のスピード値
        {
            if (!have && jump && Mathf.Abs(x) == 1 && !invincible)
            {
                speed = 3;
                animator.SetBool("dash", true);
                dash = true;
            }
        }

        if (!Input.GetKey("left shift") && !Input.GetKey("joystick button 0"))           // 歩き時のスピード値
        {
            if (!stopper && !invincible)
            {
                speed = 1;
                animator.SetBool("dash", false);
                dash = false;
            }
        }

        x = Input.GetAxisRaw("Horizontal");

        if (Mathf.Abs(x) == 1 && !invincible)
        {
            animator.SetBool("walk", true);
            scale.x = x;
            direction = x * speed;
        }
        else
        {
            animator.SetBool("walk", false);
            direction = x * speed;
            speed = 1;
        }

        /*if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("walk", true);
            scale.x = 1;        // 右を向く
            direction = 1f * speed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("walk", true);
            scale.x = -1;       // 左を向く
            direction = -1f * speed;
        }
        else
        {
            direction = 0f;     // 静止
            animator.SetBool("walk", false);
        }*/

        // 代入し直す
        if (!go == true)
            transform.localScale = scale;

        //キャラのy軸のdirection方向にscrollの力をかける
        rb2d.velocity = new Vector2(scroll * direction, rb2d.velocity.y);

        // ジャンプ判定
        if (Input.GetKeyDown("space") || Input.GetKeyDown("joystick button 1"))
        {
            if (jump && !invincible)
            {
                audioSource.PlayOneShot(Jump);
                if (dash)
                {
                    rb2d.AddForce(Vector2.up * (flap / 0.8f));
                }
                else
                {
                    rb2d.AddForce(Vector2.up * (flap * 1.1f));
                    animator.SetBool("jump", true);
                }
            }
        }



        if (invincible)
        {
            invincibleTime -= Time.deltaTime;
            if (invincibleTime >= 0.0f)
            {
                // rb2d.AddForce(Vector2.right * 100f * -this.gameObject.transform.localScale.x, ForceMode2D.Force);
                speedManager(0);
                transform.position -= new Vector3(0.04f * transform.localScale.x, 0, 0);
            }
            else
            {
                speedManager(1);
                invincible = false;
                animator.SetBool("damage", false);

            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && jump && !invincible)
        {
            invincibleTime = 0.7f;
            animator.SetBool("damage", true);
            invincible = true;
            hp.Damage();    // ダメージ判定
            audioSource.PlayOneShot(Dameagi);
        }
        else if (other.gameObject.CompareTag("Enemy") && !jump)
        {
            rb2d.AddForce(Vector2.up * (flap * 1.2f));
            animator.SetBool("jump", true);
            //追加
            audioSource.PlayOneShot(Humu);
        }



    }

    public void startPlayer()
    {
        psr.sprite = ps;
    }

    public bool getHave
    {
        get { return this.have; }
    }

    public void setHave(bool have)
    {
        this.have = have;
    }

    public bool getDash
    {
        get { return this.dash; }
    }

    public void speedManager(int speed)
    {
        this.speed = speed;
        if (speed == 0)
            stopper = true;
        else
            stopper = false;
    }

}
