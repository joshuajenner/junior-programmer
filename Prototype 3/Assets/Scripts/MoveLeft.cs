using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float currentSpeed = 15f;
    private float dashSpeed = 30f;
    private float baseSpeed = 15f;
    private float leftBound = -15;
    private PlayerController playerControllerScript;

    private void Start()
    {
       playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (playerControllerScript.isDashing)
        {
            currentSpeed = dashSpeed;
        }
        else
        {
            currentSpeed = baseSpeed;
        }

        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * currentSpeed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
