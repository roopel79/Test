using UnityEngine;
using System.Collections.Generic;

// 메모리 풀
// 싱글톤 : 게임내에서 메모리가 1개만 존재한다.
public class EnemyPoolManager : MonoBehaviour
{
    public static EnemyPoolManager Instance { get; private set; }

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int initialPoolSize = 10; // 초기 풀 크기

    private Queue<Enemy> enemyPool = new Queue<Enemy>();

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        // enemy memory pool
        InitializePool();
    }

    private void InitializePool()
    {
        for(int i = 0; i < initialPoolSize; i++)
        {
            CreateNewEnemy();
        }
    }

    private void CreateNewEnemy()
    {
        GameObject enemyObject = Instantiate(enemyPrefab); // 새로운 메모리를 만든다.
        Enemy enemy = enemyObject.GetComponent<Enemy>();
        //enemyObject.AddComponent<Enemy>();
        enemy.Deactive();
        enemyPool.Enqueue(enemy);
    }

    public Enemy GetEnemy(Vector3 position)
    {
        if(enemyPool.Count == 0)
        {
            CreateNewEnemy();
        }

        Enemy enemy = enemyPool.Dequeue();
        enemy.Initialize(position);
        return enemy;
    }

    public void ReturnEnemy(Enemy enemy)
    {
        enemy.Deactive();
        enemyPool.Enqueue(enemy);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
