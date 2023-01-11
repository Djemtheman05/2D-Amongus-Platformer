using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BazookaAM : MonoBehaviour
{
    Animator moveBazooka;

    void Start()
    {
        moveBazooka = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveBazooka.SetTrigger("Move");
        }
    }
}
