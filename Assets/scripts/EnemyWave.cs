using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    [SerializeField] private TimerSO Stop;

    public GameObject exclemationmarkR;
    public GameObject exclemationmarkL;
    bool rightOn;
    public GameObject WallR;
    public GameObject WallL;

    void Start()
    {
        WallR.SetActive(true);
        WallL.SetActive(true);

        StartCoroutine(EnemySpawnR());
        IEnumerator EnemySpawnR()
        {
            yield return new WaitForSeconds(1f);
            WallR.SetActive(false);
            WallL.SetActive(false);
            Enable();
        }
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
        yield return new WaitForSeconds(Random.Range(1f, 5f));
        WallR.SetActive(true);
        exclemationmarkL.SetActive(true);
        StartCoroutine(exclemationmarkLStop());
    }
    IEnumerator exclemationmarkSpawnR()
    {
        yield return new WaitForSeconds(Random.Range(1f, 5f));
        WallL.SetActive(true);
        exclemationmarkR.SetActive(true);
        StartCoroutine(exclemationmarkRStop());
    }



    IEnumerator exclemationmarkLStop()
    {
        yield return new WaitForSeconds(Random.Range(2f, 5f));
        exclemationmarkL.SetActive(false);
        WallR.SetActive(false);
        Enable();
    }
    IEnumerator exclemationmarkRStop()
    {
        yield return new WaitForSeconds(Random.Range(2f, 5f));
        exclemationmarkR.SetActive(false);
        WallL.SetActive(false);
        Enable();
    }
    private void Update()
    {
        if(Stop.StopTimer == true)
        {
            WallL.SetActive(true);
            WallR.SetActive(true);
            exclemationmarkL.SetActive(false);
            exclemationmarkR.SetActive(false);
        }
    }
}
