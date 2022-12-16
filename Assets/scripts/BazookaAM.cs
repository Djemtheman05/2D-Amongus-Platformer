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
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            moveBazooka.SetTrigger("Move");
        }
    }
}
