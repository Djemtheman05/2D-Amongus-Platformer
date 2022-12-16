using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.VFX;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private DestroyEnemySO KillEnemys;
    [SerializeField] private TimerSO Stop;

    float currentTime;
    float startingTime = 20f;
    bool StopTimer = false;

    [SerializeField] VisualEffect BigSnow;
    [SerializeField] TextMeshProUGUI countdownText;

    void Start()
    {
        currentTime = startingTime;
        BigSnow.Stop();
    }

    void Update()
    {
        if(StopTimer == false && Stop.StopTimer == false)
        {
            currentTime -= 1 * Time.deltaTime;
            countdownText.text = currentTime.ToString("0");
        }

        if (currentTime <= 0)
        {
            KillEnemys.DestroyEnemy = true;
            StopTimer = true;
            currentTime = 0;
            BigSnow.Play();
            TheEnd();
        }
    }
    void TheEnd()
    {
        StartCoroutine(RemoveSpawn());
    }
    IEnumerator RemoveSpawn()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Victory");
    }
}
