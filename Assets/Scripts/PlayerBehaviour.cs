using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    Rigidbody2D _player;
    private Vector3 _touchPos;
    public GameObject shootPoint;

    //for debugging on desktop
    Vector3 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<Rigidbody2D>();        
      //  Instantiate(shootPoint,transform);       
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mousePos.x > GameManager.screenDimension.x || mousePos.y > GameManager.screenDimension.y
           || mousePos.x < -GameManager.screenDimension.x || mousePos.y < -GameManager.screenDimension.y)
            Debug.Log("Out of screen");
        else
            transform.position = new Vector2(mousePos.x, mousePos.y);
           /// Shoot();

        if (Input.touchCount > 0)
            PlayerMovement();
            
    }

    void PlayerMovement()
    {
        _touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

        if (_touchPos.x > GameManager.screenDimension.x || _touchPos.y > GameManager.screenDimension.y
           || _touchPos.x < -GameManager.screenDimension.x || _touchPos.y < -GameManager.screenDimension.y)
            Debug.Log("Out of screen");
        else
            transform.position = new Vector2(_touchPos.x, _touchPos.y);
    }


   
}
