using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderValueSetting : MonoBehaviour
{
    Slider slider;
    void Start()
    {
        slider = this.GetComponent<Slider>();
        slider.maxValue = 0;
        slider.minValue = -80;
    }


}
