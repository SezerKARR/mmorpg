using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
public enum TypeWeapon
{
    Swords, TwoHandedWeapons, Blades, Fans, Bells, Daggers, Bows, Claws
}
[CreateAssetMenu(menuName = "ScriptableObject/Weapon")]
public class SwordSO : ScriptableItemsAbstact
{
    
    
    public List<Vector2> minAndMaxAttackValue=new List<Vector2>();
    public List<Vector2> minAndMaxMagicalAttackValue = new List<Vector2>();
    public List<float> attackSpeed = new List<float>();
    public TypeWeapon typeWeapon;
    
    public int sockets;
   
    
    public float price;
    
    
}
