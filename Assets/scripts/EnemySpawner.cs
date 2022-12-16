using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    float minTrasL = -34;
    float maxTrasL = -35;

    float minTrasR = 17;
    float maxTrasR = 18;

    [SerializeField] GameObject[] EnemyPrefab;
    [SerializeField] GameObject[] BigEnemyPrefab;
    [SerializeField] float secondSpawnA;
    [SerializeField] float secondSpawnB;

    void Start()
    {
        StartCoroutine(EnemySpawnR());
        IEnumerator EnemySpawnR()
        {
            while (true)
            {
                var wanted = Random.Range(minTrasR, maxTrasR);
                var position = new Vector3(wanted, transform.position.y);
                secondSpawnA = Random.Range(1f, 4f);
                GameObject gameObject = Instantiate(EnemyPrefab[Random.Range(0, EnemyPrefab.Length)],
                position, Quaternion.identity);
                yield return new WaitForSeconds(secondSpawnA);
            }
        }
        StartCoroutine(EnemySpawnL());
        IEnumerator EnemySpawnL()
        {
            while (true)
            {
                var wanted = Random.Range(minTrasL, maxTrasL);
                var position = new Vector3(wanted, transform.position.y);
                secondSpawnA = Random.Range(1f, 4f);
                GameObject gameObject = Instantiate(EnemyPrefab[Random.Range(0, EnemyPrefab.Length)],
                position, Quaternion.identity);
                yield return new WaitForSeconds(secondSpawnA);
            }
        }

        StartCoroutine(BigEnemySpawnL());
        IEnumerator BigEnemySpawnL()
        {
            while (true)
            {
                var wanted = Random.Range(minTrasL, maxTrasL);
                var position = new Vector3(wanted, transform.position.y);
                secondSpawnB = Random.Range(5f, 20f);
                GameObject gameObject = Instantiate(BigEnemyPrefab[Random.Range(0, BigEnemyPrefab.Length)],
                position, Quaternion.identity);
                yield return new WaitForSeconds(secondSpawnB);
            }
        }
        StartCoroutine(BigEnemySpawnR());
        IEnumerator BigEnemySpawnR()
        {
            while (true)
            {
                var wanted = Random.Range(minTrasR, maxTrasR);
                var position = new Vector3(wanted, transform.position.y);
                secondSpawnB = Random.Range(5f, 20f);
                GameObject gameObject = Instantiate(BigEnemyPrefab[Random.Range(0, BigEnemyPrefab.Length)],
                position, Quaternion.identity);
                yield return new WaitForSeconds(secondSpawnB);
            }
        }
    }
}
