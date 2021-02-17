using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_2 : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("EXIT");
        Application.Quit();
    }
}
