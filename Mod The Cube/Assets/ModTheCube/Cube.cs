using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    float red = 0f;
    float green = 0f;
    float blue = 0f;

    float redWeight = 0f;
    float greenWeight = 0f;
    float blueWeight = 0f;

    bool redIncreasing = true;
    bool greenIncreasing = true;
    bool blueIncreasing = true;

    void Start()
    {
        transform.position = new Vector3(-3,2,0);
        int scale = UnityEngine.Random.Range(1, 5);
        transform.localScale = Vector3.one * scale;
        GenerateNewWeights();
    }
    
    void Update()
    {
        transform.Rotate(0.0f, 50.0f * Time.deltaTime, 0.0f);

        UpdateColour();
    }

    private void UpdateColour() 
    {
        red += ChangeValue(redWeight, redIncreasing);
        green += ChangeValue(greenWeight, greenIncreasing);
        blue += ChangeValue(blueWeight, blueIncreasing);

        if (red >= 1)
        {
            redIncreasing = false;
            red = 1;
        }
        else if (red <= 0)
        {
            redIncreasing = true;
            red = 0;
        }

        if (green >= 1)
        {
            greenIncreasing = false;
            green = 1;
        }
        else if (green <= 0)
        {
            greenIncreasing = true;
            green = 0;
        }

        if (blue >= 1)
        {
            blueIncreasing = false;
            blue = 1;
        }
        else if (blue <= 0)
        {
            blueIncreasing = true;
            blue = 0;
        }

        Material material = Renderer.material;
        material.color = new Color(red, green, blue, 0.8f);
    }

    private float ChangeValue(float amount, bool isIncreasing)
    {
        if (isIncreasing)
        {
            return amount;
        }
        else
        {
            return -amount;
        }
    }

    private void GenerateNewWeights()
    {
        redWeight = Random.Range(0f, 0.001f);
        greenWeight = Random.Range(0f, 0.001f);
        blueWeight = Random.Range(0f, 0.001f);
    }
}
