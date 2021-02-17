using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stageSelect : MonoBehaviour
{

    public GameObject s_obj;
    // Start is called before the first frame update
    void Start()
    {
        s_obj = GameObject.FindWithTag("stage");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (s_obj.name == "stage")
            SceneManager.LoadScene("level1");

    }
}
