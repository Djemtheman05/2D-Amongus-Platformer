using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
public class StopPortal : MonoBehaviour
{
    [SerializeField] VisualEffect Portal;

    void Start()
    {
        StartCoroutine(RemoveSpawn());
        IEnumerator RemoveSpawn()
        {
            yield return new WaitForSeconds(0.2f);
            Portal.Stop();
        }
        StartCoroutine(DestroySpawn());
        IEnumerator DestroySpawn()
        {
            yield return new WaitForSeconds(10f);
            Destroy(gameObject);
        }
    }
}
