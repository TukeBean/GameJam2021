using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrazyBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void setMaxPower(int power)
    {
        slider.maxValue = power;
        slider.value = power;
        fill.color = gradient.Evaluate(1f);
    }
    public void setMaxPowerBoss(int power)
    {
        slider.maxValue = power;
    }
    public void SetValue(int power)
    {
        slider.value = power;

        EvaluateSlider();
    }
    public void IncrementBar(int power)
    {
        slider.value += power;

        EvaluateSlider();
    }
    public void DecrementBar(int power)
    {
        slider.value -= power;

        EvaluateSlider();
    }

    // change the colour of the bar based on the gradient ref
    public void EvaluateSlider()
    {
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
