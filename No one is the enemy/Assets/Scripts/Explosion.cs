using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float timeTillDestroy;

    void Start()
    {
        StartCoroutine(DestroyOverTimeCoRoutine());
    }

    private IEnumerator DestroyOverTimeCoRoutine()
    {
        yield return new WaitForSeconds(timeTillDestroy);
        Destroy(gameObject);
    }
}
