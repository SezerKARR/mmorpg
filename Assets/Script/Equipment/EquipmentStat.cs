using System;
using System.Collections.Generic;
using Script;
using Script.Bonus;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;


public class EquipmentStat
{
    [SerializeField]
    public Stats  Modifiers=new Stats();
    [Serializable]
    public class Stats : UnityDictionary<StatType, float> { }
    
    // Constructor, bo� veya ba�lang�� modifiyerleriyle olu�turmay� destekler.
   

    // Yeni bir modifiye ekler veya mevcut modifiyeri g�nceller
    public void AddModifier(StatType statType, float modifierValue)
    {

        if (Modifiers.ContainsKey(statType))
        {
            Modifiers[statType] += modifierValue; // Mevcut de�ere ekler
        }
        else
        {
            Modifiers.Add(statType, modifierValue); // Yeni modifiye ekler
        }
     
    }

    // Bir modifiyeri kald�r�r
    public void RemoveModifier(StatType statType, float decreaseValue)
    {
        if (Modifiers.ContainsKey(statType))
        {
            Modifiers[statType] -= decreaseValue;

        }
    }

    // Bir modifiyerin de�erini d�ner, yoksa varsay�lan bir de�er d�ner (�rne�in 0)
    /*public int GetModifierValue(StatType statType)
    {
        return Modifiers.TryGetValue(statType, out int value) ? value : 0;
    }*/
}