using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootBehaviour : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 0.5f;
    int randomBulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        randomBulletSpeed = Random.Range(2, 4);
        InvokeRepeating("Shoot", 0, randomBulletSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        var enemyBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        // enemyBullet.transform.eulerAngles = new Vector2(transform.eulerAngles.x, -transform.eulerAngles.y);
        enemyBullet.transform.eulerAngles = transform.eulerAngles;
    }
}
