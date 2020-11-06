using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverseCurvy : Enemy,IDamageable
{
    public Transform target;
    Vector3 lookTarget;

    public Transform[] paths;
    int currentPath = 0;
    GameObject path;

    public int EnemyHealth { get; set; }
    EnemyBehaviour enemyBehaviour;
    // Start is called before the first frame update
    void Awake()
    {        
        EnemyHealth = enemyHealth;
        SetupVariables();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target, Vector2.up);
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.x-270);        

        if (currentPath < paths.Length)
        {
            transform.position = Vector2.MoveTowards(transform.position, paths[currentPath].position, enemySpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, paths[currentPath].position) < 0.01f)
            {
                currentPath++;
            } 
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EndGame")
        {
            EnemyHealth = 0;
            Damage();
        }
    }

    void SetupVariables()
    {

        target = GameObject.FindGameObjectWithTag("Player").transform;
        path = GameObject.Find("InversePath");
        for (int i = 0; i < paths.Length; i++)
        {
            paths[i] = path.transform.GetChild(i).transform;
        }

        enemyBehaviour = FindObjectOfType<EnemyBehaviour>();
    }

    public void Damage()
    {
        EnemyHealth--;
        if(EnemyHealth <= 0)
        {
            enemyBehaviour.activeEnemies.Remove(gameObject);
            EnemyBehaviour.enemyCount--;
            Destroy(gameObject);
        }
    }
}
