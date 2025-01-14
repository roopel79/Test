using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Vector3 spawnPosition = spawnPoints[spawnIndex].position;

        Enemy enemy = EnemyPoolManager.Instance.GetEnemy(spawnPosition);
        Debug.Log($"Spawned Enemy at {spawnPosition}");

        //EnemyPoolManager.Instance.ReturnEnemy(enemy);
        List<List<float>> csv = new List<List<float>>();
        StartCoroutine(SpawnCount(csv, 3.0f));
    }

    IEnumerator SpawnCount(List<List<float>> positionCsv, float delay)
    {
        yield return new WaitForSeconds(delay);
    }
}
