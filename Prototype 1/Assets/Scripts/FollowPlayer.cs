using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 currentOffset = new Vector3(0, 8, -8);
    private Vector3 frontOffset = new Vector3(0, 2, 0.5f);
    private Vector3 backOffset = new Vector3(0, 8, -8);
    private Vector3 backRotation = new Vector3(30, 0, 0);
    

    private bool isCameraOnBack = true;

    public void Start()
    {
        isCameraOnBack = true;
        currentOffset = backOffset;
        transform.eulerAngles = backRotation;
    }

    public void TogglePosition()
    {
        if (isCameraOnBack)
        {
            SetCameraFront();
        }
        else
        {
            SetCameraBack();
        }
    }

    public void SetCameraFront()
    {
        isCameraOnBack = false;
        currentOffset = frontOffset;
        transform.eulerAngles = Vector3.zero;
    }

    public void SetCameraBack()
    {
        isCameraOnBack = true;
        currentOffset = backOffset;
        transform.eulerAngles = backRotation;
    }


    void LateUpdate()
    {
        transform.position = (player.transform.position + currentOffset);
        if (!isCameraOnBack)
        {
            transform.eulerAngles = player.transform.eulerAngles;
        }
    }
}
