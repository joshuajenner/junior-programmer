using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public bool isAggressive = false;

    private float topBound = 30;
    private float lowerBound = -10;
    private float horizontalBound = 25;

    void Update()
    {
        if (transform.position.z > topBound)
        {
            GameManager.DecrementLives();
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound)
        {
            GameManager.DecrementLives();
            Destroy(gameObject);
        }
        if (Mathf.Abs(transform.position.x) > horizontalBound)
        {
            Destroy(gameObject);
        }

    }
}
