using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlideControl : MonoBehaviour
{
    int count = 0;

    public GameObject Slide1;
    public GameObject Slide2;
    public GameObject Slide3;
    public GameObject Portal;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.LeftControl))
        {
            count += 1;
        }

        if(count == 1)
        {
            Slide1.SetActive(false);
            Slide2.SetActive(true);
        }
        else if(count == 2)
        {
            Slide2.SetActive(false);
            Slide3.SetActive(true);
            Portal.SetActive(true);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Portal"))
        {
            SceneManager.LoadScene("MainGame");
        }
    }
}
