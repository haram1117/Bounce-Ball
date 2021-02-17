using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class play : MonoBehaviour
{
    public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.FindWithTag("playB");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnMouseEnter()
    {
        obj.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/01-02");
    }
    private void OnMouseExit()
    {
        obj.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/01-01");
    }
    private void OnMouseDown()
    {
        SceneManager.LoadScene("LoginRegister");
    }

}
