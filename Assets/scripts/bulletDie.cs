using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDie : MonoBehaviour
{
    public GameObject explosion;
    public GameObject hitBox;
    public Transform hitBoxPlace;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if (!collisionGameObject.CompareTag ("Player"))
        {
            GameObject newBomb = Instantiate(hitBox, hitBoxPlace.position, Quaternion.identity);    
            Die();
        }
    }
    void Die()
    {
        if (explosion != null)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
