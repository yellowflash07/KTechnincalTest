using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public static Sprite bulletSprite;
    public static Sprite defaultbulletSprite;

    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * 1000);
        GetComponent<SpriteRenderer>().sprite = bulletSprite;
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
        if (collision.tag == "Enemy")
        {
            GameManager.score++;
            IDamageable enemy = collision.GetComponent<IDamageable>();
            enemy.Damage();
            Destroy(gameObject);
        }
    }
}
