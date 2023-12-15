using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class Target : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody targetRb;
    public ParticleSystem explosionParticle;

    public int pointValue;

    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -2;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        Launch();
    }

    private void Launch()
    {
        targetRb = GetComponent<Rigidbody>();
        transform.position = GetRandomSpawnPosition();
        targetRb.AddForce(GetRandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(GetRandomTorque(), GetRandomTorque(), GetRandomTorque(), ForceMode.Impulse);
    }


    //private void OnMouseDown()
    //{
    //    if (gameManager.isGameActive)
    //    {
    //        gameManager.AddScore(pointValue);
    //        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
    //        Destroy(gameObject);
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.MinusLife();
        }
    }

    public void DestroyTarget()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position,
            explosionParticle.transform.rotation);
            gameManager.AddScore(pointValue);
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    private Vector3 GetRandomForce()
    {
        return Vector3.up * Random.Range(12, 16);
    }

    private float GetRandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
}
