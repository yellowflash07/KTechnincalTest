using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBehaviour : MonoBehaviour
{
    public GameObject bulletPrefab;
    public static float bulletSpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 0, bulletSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }
}
