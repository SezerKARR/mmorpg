using System.Collections.Generic;



public class EquipmentStat
{
    public Dictionary<StatType, float> Modifiers { get; private set; } = new Dictionary<StatType, float>();

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