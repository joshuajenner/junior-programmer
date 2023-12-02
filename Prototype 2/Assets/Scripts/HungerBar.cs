using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{
    public DetectCollisions collision;

    public int hungerAmountMax = 3;
    private int hungerAmountFilled = 0;
    public Slider hungerSlider;

    void Start()
    {
        collision.hitDetected.AddListener(IncrementHunger);

        hungerSlider.gameObject.SetActive(false);
        hungerSlider.value = 0;
        hungerSlider.maxValue = hungerAmountMax;
        hungerAmountFilled = 0;
    }

    public void IncrementHunger()
    {
        hungerSlider.gameObject.SetActive(true);
        hungerAmountFilled += 1;
        hungerSlider.value = hungerAmountFilled;

        if (hungerAmountFilled >= hungerAmountMax)
        {
            GameManager.IncrementScore();
            Destroy(collision.gameObject);
        }
    }
}