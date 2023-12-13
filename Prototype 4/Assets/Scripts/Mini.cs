using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mini : MonoBehaviour
{
    private Rigidbody enemyRb;

    public float speed;
    private Vector3 moveDirection;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        StartCoroutine(RemoveSelf());
    }

    public void SetDirection(Vector3 targetVector)
    {
        moveDirection = targetVector.normalized;
    }

    void Update()
    {
        enemyRb.AddForce(moveDirection * speed);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator RemoveSelf()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
