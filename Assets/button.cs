using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour
{
    void OnMouseDown()
    {
        SceneManager.LoadScene("Setting");
    }
}
