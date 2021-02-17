using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backButton : MonoBehaviour
{
    public GameObject effect, sound, back;
    public AudioSource audio;
    bool sound_b = true;
    bool effect_b = true;
    // Start is called before the first frame update
    private void Start()
    {
        back = GameObject.Find("back");
        effect = GameObject.Find("effect");
        sound = GameObject.Find("sound");
    }
    void OnMouseDown()
    {
        if(gameObject.name == "effect")
        {
            if (effect_b)
            {
                effect_b = false;
                effect.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/effect02");//EFFECTS OFF
            }
            else
            {
                effect_b = true;
                effect.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/effect01");//EFFECTS ON
            }
        }
        else if(gameObject.name == "sound")
        {
            if (sound_b)
            {
                sound_b = false;
                audio.mute = true;
                sound.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/sound02");//SOUND OFF
            }
            else
            {
                sound_b = true;
                audio.mute = false;
                sound.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/sound01");//SOUND ON
            }
        }
        else if(gameObject.name == "back")
        {
            SceneManager.LoadScene("Main");
        }
    }
    public void SeeRanking()
    {
        SceneManager.LoadScene("Ranking");
    }
}
