using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazooka : MonoBehaviour
{
    public GameObject bazooka;
    public GameObject BazookaBAnimation;

    public AudioSource shootSound;

    bool canShoot = false;
    int count = 0;
    public float shootSpeed, shootTimer;
    private bool isShooting;
    public Transform shootPos;
    public GameObject bomb;

    void Start()
    {
        bazooka.GetComponent<Renderer>().enabled = false;
        BazookaBAnimation.GetComponent<Renderer>().enabled = false;
        StartCoroutine(renderBazooka());
        isShooting = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            BazookaBAnimation.GetComponent<Renderer>().enabled = true;
        }
        if(Input.GetButtonDown("Fire1") && !isShooting && canShoot)   
        {
            shootSound.Play();
            StartCoroutine(Shoot());
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            canShoot = true;
            count += 2;
        }

        if (count == 4 && Input.GetKeyDown(KeyCode.W))
        {
            canShoot = false;
            count -= 4;
        }
    }
    IEnumerator Shoot()
    {
        int direction()
        {
            if(transform.localScale.x < 0f)
            {
                return -1;
            }
            else
            {
                return +1;
            }
        }

        isShooting = true;
        GameObject newBomb = Instantiate(bomb, shootPos.position, Quaternion.identity);
        newBomb.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * direction() * Time.fixedDeltaTime, 0f);
        newBomb.transform.localScale = new Vector2(newBomb.transform.localScale.x * direction(), newBomb.transform.localScale.y);

        yield return new WaitForSeconds(shootTimer);
        isShooting = false;
    }

    private IEnumerator renderBazooka()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            yield return new WaitForSeconds(1.0f);
            BazookaBAnimation.GetComponent<Renderer>().enabled = true;
        }
    }
}
