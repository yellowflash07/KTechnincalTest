using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject[] enemies;
    public static int enemyCount;
    public int count;

    public List<GameObject> activeEnemies =new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        // RightSlant();
        InverseCurvy();
       // Instantiate(enemies[1]);
    }

    // Update is called once per frame
    void Update()
    {
        count = enemyCount;
        if (activeEnemies.Count < 6 && !GameManager.isRespawning)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        int randomNum = Random.Range(0, 4);
        switch (randomNum)
        {
            case 0:
                RightSlant();
                break;
            case 1:
                LeftSlant();
                break;
            case 2:
                Curvy();
                break;
            case 3:
                InverseCurvy();
                break;
            default:
                break;
        }

    }

    public void RightSlant()
    {        
        for (int i = 0; i < 6; i++)
        {
            var newPos = new Vector2(-GameManager.screenDimension.x + i, GameManager.screenDimension.y - i + 10f);
            var enemy = Instantiate(enemies[0], newPos,Quaternion.identity);
            activeEnemies.Add(enemy);
            enemyCount++;
        }
    }

    public void LeftSlant()
    {
        for (int i = 0; i < 6; i++)
        {
            var newPos = new Vector2(GameManager.screenDimension.x - i, GameManager.screenDimension.y - i + 10f);
            var enemy= Instantiate(enemies[0], newPos,Quaternion.identity);
            activeEnemies.Add(enemy);
            enemyCount++;
        }
    }

    public void Curvy()
    {
        for (int i = 0; i < 6; i++)
        {
            var newPos = new Vector2(enemies[1].transform.position.x + (i*0.5f), enemies[1].transform.position.y + i);
            var enemy = Instantiate(enemies[1], newPos, Quaternion.identity);
            activeEnemies.Add(enemy);
            enemyCount++;
        }
    }

    void InverseCurvy()
    {
        for (int i = 0; i < 6; i++)
        {
            var newPos = new Vector2(enemies[2].transform.position.x - (i * 0.5f), enemies[2].transform.position.y + i);
            var enemy = Instantiate(enemies[2], newPos, Quaternion.identity);
            activeEnemies.Add(enemy);
            enemyCount++;
        }
    }

}
