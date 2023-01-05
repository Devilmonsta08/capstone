using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public string unitName;
    public int Damage;
    public int maxHP;
    public int currentHP;

    public bool TakeDamage(int Dmg)
    {
        currentHP -= Dmg;

        if(currentHP <= 0)
            return true;
        else
            return false;
    }
    
}
