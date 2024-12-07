using System.Collections.Generic;


public class EquipmentStat
{
    public Dictionary<StatType, float> Modifiers { get; private set; } = new Dictionary<StatType, float>();

    // Constructor, boþ veya baþlangýç modifiyerleriyle oluþturmayý destekler.
   

    // Yeni bir modifiye ekler veya mevcut modifiyeri günceller
    public void AddModifier(StatType statType, float modifierValue)
    {
        if (Modifiers.ContainsKey(statType))
        {
            Modifiers[statType] += modifierValue; // Mevcut deðere ekler
        }
        else
        {
            Modifiers.Add(statType, modifierValue); // Yeni modifiye ekler
        }
        UnityEngine.Debug.Log(Modifiers[statType]);
    }

    // Bir modifiyeri kaldýrýr
    public void RemoveModifier(StatType statType, float decreaseValue)
    {
        if (Modifiers.ContainsKey(statType))
        {
            Modifiers[statType] -= decreaseValue;

        }
    }

    // Bir modifiyerin deðerini döner, yoksa varsayýlan bir deðer döner (örneðin 0)
    /*public int GetModifierValue(StatType statType)
    {
        return Modifiers.TryGetValue(statType, out int value) ? value : 0;
    }*/
}