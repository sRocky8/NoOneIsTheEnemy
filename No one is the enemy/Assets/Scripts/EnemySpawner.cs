using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Public Variables


    //Private Variables
    [SerializeField] private float secondsToSpawn;
    [SerializeField] private float radius;
    [SerializeField] private float noSpawnRadius;
    [SerializeField] private float enemyHeight;
    [SerializeField] private GameObject[] enemy;
    private Vector3 newEnemyTransform;
    private Vector3 newEnemyPosition;

    void Start()
    {
        StartCoroutine(SpawnEnemyCoRoutine());
    }

    void Update()
    {
        
    }

    private IEnumerator SpawnEnemyCoRoutine()
    {
        secondsToSpawn = Random.Range(1, 4);
        yield return new WaitForSeconds(secondsToSpawn);
        newEnemyTransform = Random.insideUnitSphere * radius;
        if(newEnemyTransform.x < noSpawnRadius * radius)
        {
            Mathf.CeilToInt(newEnemyTransform.x);
        }
        if (newEnemyTransform.z < noSpawnRadius * radius)
        {
            Mathf.CeilToInt(newEnemyTransform.z);
        }
        newEnemyPosition = new Vector3(newEnemyTransform.x, enemyHeight, newEnemyTransform.z);
        Instantiate(enemy[Random.Range(0,9)], newEnemyPosition, Quaternion.identity);
        StartCoroutine(SpawnEnemyCoRoutine());
    }
}
