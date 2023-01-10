using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] private CharacterDatabase charDB;

    public string unitName;
    public int Damage;
    public int maxHP;
    public int currentHP;

    private void OnEnable()
    {
        if(unitName == "Player") currentHP = charDB.charHealth;
    }

    private void OnDisable()
    {
        if (unitName == "Player") charDB.charHealth = currentHP;
    }

    public bool TakeDamage(int Dmg)
    {
        currentHP -= Dmg;

        if(currentHP <= 0)
            return true;
        else
            return false;
    }
    
}
