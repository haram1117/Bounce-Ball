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
    Rigidbody2D rigid_s;
    Rigidbody2D rigid_b;

    private AudioSource die_audio;
    public AudioClip die_AC;
    // Start is called before the first frame update
    void Start()
    {
        rigid_s = GameObject.Find("Star").GetComponent<Rigidbody2D>();
        rigid_b = GameObject.Find("Ball").GetComponent<Rigidbody2D>();
        nowStage = SceneManager.GetActiveScene().buildIndex;
        die_audio = GameObject.Find("Ball").GetComponent<AudioSource>();
        
    }
    float bounce = 30f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rigid_b.velocity = Vector2.zero;
        
        Vector2 JumpVelocity = new Vector2(0, bounce);
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "DisappearGround")
        {
            Debug.Log("1");
            rigid_b.AddForce(JumpVelocity, ForceMode2D.Impulse);
            
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
        if (isDash)
        {
            rigid_b.velocity = Vector2.right * dashSpeed;
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                rigid_b.gravityScale = 2;
                isDash = false;
            }

        }
        else
        {
            hori = Input.GetAxis("Horizontal");
            rigid_b.velocity = new Vector2(hori * moveSpeed, rigid_b.velocity.y);
        }
        if(gameObject.transform.position.y < -8.84 && gameObject.transform.position.y > -9.5)
        {
            die_audio.clip = die_AC;
            die_audio.loop = false;
            die_audio.PlayOneShot(die_AC);
            Invoke("Respawn", 1f);
        }
    }
    void Respawn()
    {
        SceneManager.LoadScene(nowStage);
    }

}
