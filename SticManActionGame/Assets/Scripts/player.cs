using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // インスペクターで設定
    public float speed;
    public GroundCheck ground;

    // プライベート変数
    private Animator anim = null;
    private Rigidbody2D rb = null;
    private bool isGround = false;

    // Start is called before the first frame update
    void Start()
    {
        // コンポーネントのインスタンスを捕まえる
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // 接地判定を受け取る
        isGround = ground.IsGround();

        // キー入力に関する処理
        float horizontalKey = Input.GetAxis("Horizontal");
        float xSpeed = 0.0f;

        if(horizontalKey > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("run", true);
            xSpeed = speed;
        }
        else if(horizontalKey < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("run", true);
            xSpeed = -speed;
        }
        else
        {
            anim.SetBool("run", false);
            xSpeed = 0.0f;
        }
        rb.velocity = new Vector2(xSpeed, rb.velocity.y);
    }
}
