using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class info : MonoBehaviour
{
    public GameObject infos;

    // Start is called before the first frame update
    void Start()
    {
        infos = GameObject.FindWithTag("infosB");
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnMouseEnter()
    {
        infos.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/02-02");
    }
    private void OnMouseExit()
    {
        infos.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/02-01");
    }
    private void OnMouseDown()
    {
        SceneManager.LoadScene("InfoScene");
    }
}

