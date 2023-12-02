using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    private bool canSendDog = true;
    private float reloadTime = 0.3f;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canSendDog)
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                canSendDog = false;
                Invoke("ResetDog", reloadTime);
            }

        }
    }

    void ResetDog()
    {
        canSendDog = true;
    }
}
