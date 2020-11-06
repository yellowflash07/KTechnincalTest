using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public GameObject[] powerUps;

    PlayerBehaviour playerBehaviour;
    PowerUp powerUp;

    public int _useTime;
    private bool powerActive,powerAvailable;
    public Sprite defaultbulletSprite;
    // Start is called before the first frame update
    void Start()
    {
        playerBehaviour = FindObjectOfType<PlayerBehaviour>();
        BulletBehaviour.bulletSprite = defaultbulletSprite;
        InvokeRepeating("UseTimer", 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (!powerActive && !powerAvailable)
        {
            StartCoroutine(RandomPowerUps());
            powerAvailable = true;
        }
    }

    IEnumerator RandomPowerUps()
    {
        float randomWaitTime = Random.Range(2, 10);
        Debug.Log("Next power up in" + randomWaitTime.ToString());
        yield return new WaitForSeconds(randomWaitTime);
        Vector2 randomPos = new Vector2(Random.Range(-GameManager.screenDimension.x/2, GameManager.screenDimension.x/2), 
                                           Random.Range(-GameManager.screenDimension.y/2, GameManager.screenDimension.y/2));
        Instantiate(powerUps[Random.Range(0, powerUps.Length)], randomPos, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PowerUp")
        {
            powerActive = true;
            powerAvailable = false;
            powerUp = collision.GetComponent<PowerUp>();
            _useTime = powerUp.useTime;               
            BulletBehaviour.bulletSprite = powerUp.bulletSprite;
            ShootBehaviour.bulletSpeed = powerUp.bulletSpeed;

            DestroyShootPoints();
            for (int i = 0; i < powerUp.bulletSpread; i++)
            {
                var shootPoint = Instantiate(playerBehaviour.shootPoint,transform);
                shootPoint.transform.position = new Vector2(playerBehaviour.transform.position.x - 0.2f + (i *0.2f),shootPoint.transform.position.y);
            }            
            Destroy(collision.gameObject);
        }
    }

    public void InvokeTimer()
    {
        InvokeRepeating("UseTimer", 0, 1);
    }

    public void UseTimer()
    {
        if (powerActive)
        {
            if (_useTime > 0)
            {
                powerActive = true;
                _useTime--;
            }
            if (_useTime <= 0)
            {
                BulletBehaviour.bulletSprite = defaultbulletSprite;
                ShootBehaviour.bulletSpeed = 0.5f;
                DestroyShootPoints();
                Instantiate(playerBehaviour.shootPoint,playerBehaviour.transform);
                powerActive = false;
            } 
        }
    }

    void DestroyShootPoints()
    {
        for (int i = 0; i < playerBehaviour.transform.childCount; i++)
        {
            Destroy(playerBehaviour.transform.GetChild(i).gameObject);
        }
    }

}
