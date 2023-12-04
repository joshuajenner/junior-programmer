using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    private Rigidbody enemyRb;

    public float speed;
    private Vector3 moveDirection;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        moveDirection = -transform.position.normalized;
    }

    void Update()
    {
        enemyRb.AddForce(moveDirection * speed);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
