using System;
using System.Collections.Generic;
using Script;
using Script.Bonus;
using UnityEngine;


public class EquipmentStat
{
    [SerializeField]
    public CharStat  modifiers=new CharStat();
    
    
    // Constructor, bo� veya ba�lang�� modifiyerleriyle olu�turmay� destekler.
   

    // Yeni bir modifiye ekler veya mevcut modifiyeri g�nceller
    public void AddModifier(StatType statType, float modifierValue)
    {

        if (modifiers.ContainsKey(statType))
        {
            modifiers[statType] += modifierValue; // Mevcut de�ere ekler
        }
        else
        {
            modifiers.Add(statType, modifierValue); // Yeni modifiye ekler
        }
     
    }

    // Bir modifiyeri kald�r�r
    public void RemoveModifier(StatType statType, float decreaseValue)
    {
        if (modifiers.ContainsKey(statType))
        {
            modifiers[statType] -= decreaseValue;

        }
    }

    // Bir modifiyerin de�erini d�ner, yoksa varsay�lan bir de�er d�ner (�rne�in 0)
    /*public int GetModifierValue(StatType statType)
    {
        return Modifiers.TryGetValue(statType, out int value) ? value : 0;
    }*/
}