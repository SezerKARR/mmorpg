using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Weapon")]
public class SwordSO : ScriptableItemsAbstact
{
    public enum TypeWeapon
    {
        Swords, TwoHandedWeapons, Blades, Fans, Bells, Daggers, Bows
    }
    public Vector2 minAndMaxAttackValue;
    public Vector2 minAndMaxMagicalAttackValue;
    public int attackSpeed;
    public TypeWeapon typeWeapon;
    public List<string> canUseCharacters;
    
    public float maxAttackRange;
    public string[] bonuses;
    
    [System.Serializable]
    public class UpgradeValueWithLevel
    {
        public Upgrade Requirement;
        [Header("UpgradeWalue")]
        public int attackValue;
        public int magicalAttackValue;
        public int attackSpeed;

    }

    public UpgradeValueWithLevel[] WithLevel  = new UpgradeValueWithLevel[9];

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
