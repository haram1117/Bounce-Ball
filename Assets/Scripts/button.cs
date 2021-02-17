using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Setting");
        Debug.Log("Setup");
    }
}
