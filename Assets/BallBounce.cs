using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallBounce : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float dashSpeed;
    private int nowStage;
    private bool isDash = false;
    private float hori;
    public int star;
    bool nextLevel = false;
    GameObject ball;
    Rigidbody2D rigid_s;
    Rigidbody2D rigid_b;
    bool isAlive;

    private AudioSource die_audio;
    public AudioClip die_AC;
    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        ball = GameObject.Find("Ball");
        rigid_s = GameObject.Find("Star").GetComponent<Rigidbody2D>();
        rigid_b = GameObject.Find("Ball").GetComponent<Rigidbody2D>();
        nowStage = SceneManager.GetActiveScene().buildIndex;
        die_audio = GameObject.Find("Ball").GetComponent<AudioSource>();
        
    }
    float bounce = 30f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isAlive) //공이 살아있을 때만 이벤트들 실행
        {
            rigid_b.velocity = Vector2.zero;

            Vector2 JumpVelocity = new Vector2(0, bounce);
            if (collision.gameObject.tag == "Ground") //일반 땅 (그냥 계속 바운스)
            {
                Debug.Log("1");
                Debug.Log(ball.transform.position.y - collision.transform.position.y);
                rigid_b.AddForce(JumpVelocity, ForceMode2D.Impulse);
            }
            else if (collision.gameObject.tag == "DisappearGround" && ball.transform.position.y >= collision.transform.position.y)
            { //한 번 밟으면 사라지는 땅

                rigid_b.AddForce(JumpVelocity, ForceMode2D.Impulse);
                GameObject.Destroy(collision.gameObject);
            }
            else if (collision.gameObject.tag == "JumpGround" && ball.transform.position.y >= collision.transform.position.y)
            {// 밟았을 때 높게 뛸 수 있는 땅
                Vector2 JumpVelocity_j = new Vector2(0, 1.5f * bounce);
                rigid_b.AddForce(JumpVelocity_j, ForceMode2D.Impulse);
            }
            else if (collision.gameObject.tag == "DieGround" && ball.transform.position.y >= collision.transform.position.y)
            {// 밟았을 때 죽는 땅 (가시땅)
                isAlive = false;
                die_audio.clip = die_AC;
                die_audio.loop = false;
                die_audio.PlayOneShot(die_AC);
                Invoke("Respawn", 1f);
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Star")
        {
            GameObject.Destroy(collision.gameObject);
            star--;
            if (star == 0)
            {
                nextLevel = true;
                Invoke("NextLevel", 1);
              
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void NextLevel()
    {
        if (nextLevel == true)
            SceneManager.LoadScene(nowStage + 1);
    }

    private void FixedUpdate()
    {
        if (isDash)//
        {
            rigid_b.velocity = Vector2.right * dashSpeed;
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                rigid_b.gravityScale = 2;
                isDash = false;
            }

        }
        else
        {//horizontal 키 입력에 따라 공의 방향 바뀜
            hori = Input.GetAxis("Horizontal");
            rigid_b.velocity = new Vector2(hori * moveSpeed, rigid_b.velocity.y);
        }
        if(gameObject.transform.position.y < -8.84 && gameObject.transform.position.y > -9.5)
        {//맵 밑으로 떨어졌을 때
            isAlive = false;
            die_audio.clip = die_AC;
            die_audio.loop = false;
            die_audio.PlayOneShot(die_AC);
            Invoke("Respawn", 1f);
        }
    }
    void Respawn()
    {   
        if(!isAlive)
            SceneManager.LoadScene(nowStage);
    }

}
