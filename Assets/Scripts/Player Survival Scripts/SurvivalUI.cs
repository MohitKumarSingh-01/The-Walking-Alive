using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurvivalUI : MonoBehaviour
{
    [SerializeField] private Image healthMeter, hungerMeter, thirstMeter;

    private void Update()
    {
        healthMeter.fillAmount = SurvivalManager.instance.HealthPercent;
        hungerMeter.fillAmount = SurvivalManager.instance.HungerPercent;
        thirstMeter.fillAmount = SurvivalManager.instance.ThirstPercent;
    }
}
