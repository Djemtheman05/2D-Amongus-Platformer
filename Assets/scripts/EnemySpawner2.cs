using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner2 : MonoBehaviour
{
    float minTras = 20;
    float maxTras = 40;

    [SerializeField] GameObject[] ZombiePrefab;
    [SerializeField] float secondSpawnA;

    void Start()
    {
        StartCoroutine(appleSpawn());
        IEnumerator appleSpawn()
        {
            while (true)
            {
                var wanted = Random.Range(minTras, maxTras);
                var position = new Vector3(wanted, transform.position.y);
                secondSpawnA = Random.Range(0.2f, 1f);
                GameObject gameObject = Instantiate(ZombiePrefab[Random.Range(0, ZombiePrefab.Length)],
                position, Quaternion.identity);
                yield return new WaitForSeconds(secondSpawnA);
            }
        }
    }
}
