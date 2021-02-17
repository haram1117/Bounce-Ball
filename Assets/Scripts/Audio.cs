using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    AudioSource ballAudio;
    public AudioClip ballClip;

    AudioSource starAudio;
    public AudioClip starClip;
    // Start is called before the first frame update
    void Start()
    {
        ballAudio = GetComponent<AudioSource>();
        starAudio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "DisappearGround")
        {
            
            ballAudio.clip = ballClip;
            ballAudio.loop = false;
            ballAudio.PlayOneShot(ballClip);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Star")
        {
            starAudio.clip = starClip;
            starAudio.loop = false;
            starAudio.PlayOneShot(starClip);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
