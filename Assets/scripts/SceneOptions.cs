using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOptions : MonoBehaviour
{
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene("Explanation Game");
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            SceneManager.LoadScene("MainGame");
        }
    }
}
