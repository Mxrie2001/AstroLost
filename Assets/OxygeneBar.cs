using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygeneBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxOxygene(int oxygene){
        slider.maxValue = oxygene;
        slider.value = oxygene;
    }

    public void SetOxygene(int oxygene){
        slider.value = oxygene;
    }
}
