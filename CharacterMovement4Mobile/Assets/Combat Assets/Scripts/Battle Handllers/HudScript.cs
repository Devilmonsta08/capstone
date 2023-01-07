using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudScript : MonoBehaviour
{
    public Slider hpSlider;

    public void HUD(Stats stats)
    {
        hpSlider.maxValue = stats.maxHP;

        hpSlider.value = stats.currentHP;

    }

    public void SetHP(int HP)
    {
        hpSlider.value = HP;
    }

}
