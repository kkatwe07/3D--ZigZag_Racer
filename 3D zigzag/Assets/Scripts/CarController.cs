using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] float Speed = 5f;

    bool movingLeft = true;
    bool firstTap = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameStarted)
        {
            Move();
            CheckInput();
        }

        if(transform.position.y <= -2f)
        {
            GameManager.instance.GameOver();
        }
    }

    void Move()
    {
        transform.position += transform.forward * Speed * Time.deltaTime;
    }

    void CheckInput()
    {
        if (firstTap)
        {
            firstTap = false;
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        if (movingLeft) 
        {
            movingLeft = false;
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else
        {
            movingLeft = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    
}
