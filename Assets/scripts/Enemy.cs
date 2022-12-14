using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Player;
    public bool flip;
    float speed = 6f;
    bool faceright;
    Transform t;
    public GameObject DeadBody;
    public GameObject DeadBodyR;

    private void Start()
    {
        t = transform;
    }

    private void Update()
    {
        Vector3 scale = transform.localScale;

        if(Player.transform.position.x > transform.position.x)
        {
            faceright = true;
            scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1 : 1);
            transform.Translate(speed * Time.deltaTime * -1, 0, 0);
        }
        else
        {
            faceright = false;
            scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1);
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        transform.localScale = scale;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (faceright == true)
            {
                Destroy(gameObject);
                GameObject deathAnimation = Instantiate(DeadBody, t.position, Quaternion.identity);
            }
            if (faceright == false)
            {
                Destroy(gameObject);
                GameObject deathAnimation = Instantiate(DeadBodyR, t.position, DeadBodyR.transform.rotation);
            }
        }
    }
}
