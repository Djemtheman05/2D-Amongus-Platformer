using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    public Collider2D hitBox;
    float stopSound = 3f;
    float stopCollider = 0.1f;
    void Start()
    {
        StartCoroutine(stopsound());
        StartCoroutine(stopcollider());
    }
    IEnumerator stopcollider()
    {
        yield return new WaitForSeconds(stopCollider);
        Destroy(hitBox);
    }
    IEnumerator stopsound()
    {
        yield return new WaitForSeconds(stopSound);
        Destroy(gameObject);
    }
}
