using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySlime : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 20f);
    }

}
