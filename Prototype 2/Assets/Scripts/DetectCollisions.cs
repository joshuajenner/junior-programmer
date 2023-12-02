using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectCollisions : MonoBehaviour
{
    public UnityEvent hitDetected = new UnityEvent();
    public bool isAggressive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (isAggressive)
            {
                Debug.Log("Game Over!");
            }
        }
        else
        {
            hitDetected.Invoke();
            Destroy(other.gameObject);
        }

        
    }
}
