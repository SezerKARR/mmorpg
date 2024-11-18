using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class ScriptableItemsAbstact : ScriptableObject
{

    /*public enum canUseCharacter
    {
        Warrior,Shaman,Sura,Ninja
    }*/
    [System.Serializable]
    public  class Upgrade
    {
        public ScriptableObject[] itemsRequirementForUpgrade;
        public int moneyRequirementForUpgrade;
        
    }

    public Sprite Image;
    public int level;
}
