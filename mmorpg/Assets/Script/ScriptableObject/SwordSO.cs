using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Weapon")]
public class SwordSO : ScriptableItemsAbstact
{
    public enum TypeWeapon
    {
        Swords, TwoHandedWeapons, Blades, Fans, Bells, Daggers, Bows, Claws
    }
    public enum Character
    {
        Warrior, Sura, Ninja, Shaman, Lycan
    }
    public List<Vector2> minAndMaxAttackValue=new List<Vector2>();
    public List<Vector2> minAndMaxMagicalAttackValue = new List<Vector2>();
    public List<float> attackSpeed = new List<float>();
    public TypeWeapon typeWeapon;
    public List<Character> canUseCharacters=new List<Character>();
    public int sockets;
    public List<string> bonuses;
    public List<(string bonusName,List<float> bonusValue)> swordBonuses=new List<(string bonusName, List<float> bonusValue)>();
    public string swordName;
    public float price;
   
    public void SetSwordType(string swordType)
    {
        if (swordType.Equals("Swords") )
        {
            typeWeapon = TypeWeapon.Swords;

        }
        else if (swordType.Equals("Two Handed"))
        {
            typeWeapon = TypeWeapon.TwoHandedWeapons;

        }
        else if (swordType.Equals("Blade"))
        {
            typeWeapon = TypeWeapon.Blades;

        }
        SetCanUseCharacter();
    }
    public void SetCanUseCharacter()
    {
        if (typeWeapon == TypeWeapon.Swords)
        {
            canUseCharacters.Add(Character.Sura);
            canUseCharacters.Add(Character.Warrior);
            canUseCharacters.Add(Character.Ninja);

        }
        else if (typeWeapon == TypeWeapon.TwoHandedWeapons)
        {
            canUseCharacters.Add(Character.Warrior);
        }
        else if (typeWeapon == TypeWeapon.Bows)
        {
            canUseCharacters.Add(Character.Ninja);
        }
        else if (typeWeapon == TypeWeapon.Blades)
        {
            canUseCharacters.Add(Character.Sura);
        }
        else if (typeWeapon == TypeWeapon.Daggers)
        {
            canUseCharacters.Add(Character.Ninja);
        }
        else if (typeWeapon == TypeWeapon.Claws)
        {
            canUseCharacters.Add(Character.Lycan);
        }
        else
        {
            canUseCharacters.Add(Character.Shaman);
        }
    }
    /* silahýn tipine göre hangi karakterlerin kullanabileceði
    
     * if (typeWeapon == TypeWeapon.Swords)
          {
              canUseCharacters.Add(canUseCharacter.Sura);
              canUseCharacters.Add(canUseCharacter.Warrior);
              canUseCharacters.Add(canUseCharacter.Ninja);

          }
          else if(typeWeapon== TypeWeapon.TwoHandedWeapons)
          {
              canUseCharacters.Add(canUseCharacter.Warrior);
          }
          else if(typeWeapon== TypeWeapon.Bows)
          {
              canUseCharacters.Add(canUseCharacter.Ninja);
          }
          else if (typeWeapon == TypeWeapon.Blades)
          {
              canUseCharacters.Add(canUseCharacter.Sura);
          }
          else if (typeWeapon == TypeWeapon.Daggers)
          {
              canUseCharacters.Add(canUseCharacter.Ninja);
          }
          else
          {
              canUseCharacters.Add(canUseCharacter.Shaman);
          }*/


}
