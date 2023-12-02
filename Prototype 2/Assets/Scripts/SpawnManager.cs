using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 15;
    private float spawnPosZ = 20;

    private float startDelay = 2;
    private float spawnInterval = 1f;

    private void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    private void SpawnRandomAnimal()
    {
        int horiOrVert = Random.Range(0, 2);
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        Vector3 spawnPosition;
        Vector3 spawnRotation;
        bool isAggressive = false;

        if (horiOrVert == 1)
        {
            // Spawn on top
            spawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            spawnRotation = new Vector3(0, 180, 0);
        }
        else
        {
            // Spawn on side
            int leftOrRight = Random.Range(0, 2);
            isAggressive = true;
            if (leftOrRight == 1)
            {
                spawnPosition = new Vector3(20, 0, Random.Range(0, 5));
                spawnRotation = new Vector3(0, -90, 0);
            }
            else
            {
                spawnPosition = new Vector3(-20, 0, Random.Range(0, 5));
                spawnRotation = new Vector3(0, 90, 0);
            }
        }

        GameObject newAnimal = Instantiate(animalPrefabs[animalIndex], spawnPosition, animalPrefabs[animalIndex].transform.rotation);
        newAnimal.transform.eulerAngles = spawnRotation;
        DetectCollisions animalDetect = newAnimal.GetComponent<DetectCollisions>();
        DestroyOutOfBounds animalBounds = newAnimal.GetComponent<DestroyOutOfBounds>();
        animalBounds.isAggressive = isAggressive;
        animalDetect.isAggressive = isAggressive;
    }
}
