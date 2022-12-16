using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.VFX;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    float currentTime;
    float startingTime = 10f;
    bool EndScreen = false;

    [SerializeField] VisualEffect BigSnow;
    [SerializeField] TextMeshProUGUI countdownText;

    void Start()
    {
        currentTime = startingTime;
        BigSnow.Stop();
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
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
        Debug.Log("Endscreen");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Victory");
    }
}
