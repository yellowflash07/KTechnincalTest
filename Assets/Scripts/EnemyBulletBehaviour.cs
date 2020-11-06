using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBehaviour : MonoBehaviour
{
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        GetComponent<Rigidbody2D>().AddRelativeForce(transform.TransformDirection(-Vector2.up) * -1000);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > GameManager.screenDimension.y)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !GameManager.isGameOver)
        {
            gameManager.RespawnCoroutine();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.tag == "EndGame")
        {
            Destroy(gameObject);
        }
    }
}
