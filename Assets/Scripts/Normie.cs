using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normie : Enemy, IDamageable
{
    PolygonCollider2D polygonCollider;

    public int EnemyHealth { get; set; }

    EnemyBehaviour enemyBehaviour;
    // Start is called before the first frame update
    void Start()
    {
        EnemyHealth = enemyHealth;
        polygonCollider = GetComponent<PolygonCollider2D>();
        enemyBehaviour = FindObjectOfType<EnemyBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(EnemyHealth);
        transform.Translate(Vector3.down * enemySpeed * Time.deltaTime);

        if (transform.position.y > GameManager.screenDimension.y)
            polygonCollider.enabled = false;
        else
            polygonCollider.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EndGame")
        {
            Damage();
        }
    }

    public void Damage()
    {
        Debug.Log("Damaged");
        EnemyHealth--;
        if (EnemyHealth <= 0)
        {
            enemyBehaviour.activeEnemies.Remove(gameObject);
            EnemyBehaviour.enemyCount--;
            Destroy(gameObject);
        }        
    }
}
