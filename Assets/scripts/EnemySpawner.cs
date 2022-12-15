using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    float minTrasR = -50;
    float maxTrasR = -30;

    float minTrasL = 20;
    float maxTrasL = 40;

    [SerializeField] GameObject[] ZombiePrefab;
    [SerializeField] float secondSpawnA;

    void Start()
    {
        StartCoroutine(ZombieLSpawn());
        IEnumerator ZombieLSpawn()
        {
            while (true)
            {
                var wanted = Random.Range(minTrasL, maxTrasL);
                var position = new Vector3(wanted, transform.position.y);
                secondSpawnA = Random.Range(1f, 4f);
                GameObject gameObject = Instantiate(ZombiePrefab[Random.Range(0, ZombiePrefab.Length)],
                position, Quaternion.identity);
                yield return new WaitForSeconds(secondSpawnA);
            }
        }
        StartCoroutine(ZombieRSpawn());
        IEnumerator ZombieRSpawn()
        {
            while (true)
            {
                var wanted = Random.Range(minTrasR, maxTrasR);
                var position = new Vector3(wanted, transform.position.y);
                secondSpawnA = Random.Range(0.5f, 3f);
                GameObject gameObject = Instantiate(ZombiePrefab[Random.Range(0, ZombiePrefab.Length)],
                position, Quaternion.identity);
                yield return new WaitForSeconds(secondSpawnA);
            }
        }
    }
}
