using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backButton : MonoBehaviour
{
    public GameObject effect, sound, back;
    int effect_n = 0, sound_n = 0;
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
            effect_n++;
            if(effect_n%2 == 1)
            {
                effect.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/effect02");
            }
            else
                effect.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/effect01");
        }
        else if(gameObject.name == "sound")
        {
            sound_n++;
            if(sound_n%2 == 1)
            {
                sound.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/sound02");

            }
            else
                sound.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/sound01");

        }
        else if(gameObject.name == "back")
        {
            SceneManager.LoadScene("Main");
        }
    }
}
