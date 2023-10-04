using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class speedscript : MonoBehaviour
{
    Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = Gamemanager.instance.pointspeed;
    }

    public void SpeedSlider()
    {
        Gamemanager.instance.pointspeed = slider.value;
    }
}
