using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    public GameObject exclemationmarkR;
    public GameObject exclemationmarkL;
    bool rightOn;

    void Start()
    {
        Enable();
    }
    void Enable()
    {
        rightOn = Random.Range(0, 2) < 1;
        if (rightOn)
        {
            StartCoroutine(exclemationmarkSpawnR());
        }
        else
        {
            StartCoroutine(exclemationmarkSpawnL());
        }
    }

    IEnumerator exclemationmarkSpawnL()
    {
        yield return new WaitForSeconds(Random.Range(1f, 10f));
        exclemationmarkL.SetActive(true);
        StartCoroutine(exclemationmarkLStop());
    }
    IEnumerator exclemationmarkSpawnR()
    {
        yield return new WaitForSeconds(Random.Range(1f, 10f));
        exclemationmarkR.SetActive(true);
        StartCoroutine(exclemationmarkRStop());
    }



    IEnumerator exclemationmarkLStop()
    {
        yield return new WaitForSeconds(Random.Range(5f, 20f));
        exclemationmarkL.SetActive(false);
        Enable();
    }
    IEnumerator exclemationmarkRStop()
    {
        yield return new WaitForSeconds(Random.Range(5f, 20f));
        exclemationmarkR.SetActive(false);
        Enable();
    }
}
