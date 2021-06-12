using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void setMaxHealth(int hp)
    {
        Debug.Log("set max hp");
        this.slider.maxValue = hp;
        this.slider.value = hp;
        fill.color = gradient.Evaluate(1f);
    }

    public void setMaxHealthEnemy(int hp)
    {
        this.slider.maxValue = hp;
    }

    public void incrementBar(int hp)
    {
        this.slider.value += hp;
        EvaluateSlider();
    }
    public void DecrementBar(int hp)
    {
        this.slider.value -= hp;
        EvaluateSlider();
    }

    public void EvaluateSlider()
    {
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
