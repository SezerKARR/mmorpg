using System.Collections;
using System.Collections.Generic;
using Script.ScriptableObject.Equipment;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
	This component is derived from CharacterStats. It adds two things:
		- Gaining modifiers when equipping items
		- Restarting the game when dying
*/

public class PlayerStats : CharacterStats
{

    // Use this for initialization
    public override void Start()
    {

        base.Start();
        
    }
    void OnEquipmentChanged(IItemable newItem, IItemable oldItem)
    {
        /*if (newItem != null)
        {
            armor.AddModifier(newItem.armorModifier());
            damage.AddModifier(newItem.damageModifier);
        }

        if (oldItem != null)
        {
            armor.RemoveModifier(oldItem.armorModifier);
            damage.RemoveModifier(oldItem.armorModifier);
        }*/

    }




}