using UnityEngine;
using UnityEngine.Serialization;

namespace Script.ScriptableObject
{
    public enum ItemPlace
    {
        None,
        Inventory,
        Equipment,
        Shop,
        Ground,
        Storage,
    }
    public enum ObjectType
    {
        None,
        RightclickStack,
        LeftClickStack,
        Stack,
        Item,
    
    }



    public abstract class ObjectAbstract : UnityEngine.ScriptableObject
    {
        [FormerlySerializedAs("Place")] public ItemPlace place;
        [FormerlySerializedAs("Image")] public Sprite ımage;
        [FormerlySerializedAs("ItemName")] public string ıtemName;
        public string dropsFrom;
        [FormerlySerializedAs("DropMetins")] public string dropMetins;
        public string info;
        public bool playerCanDrop = true;
        public bool canEveryBodyTake=true;
        public int stackLimit=1;
        public int weightInInventory = 1;
        [FormerlySerializedAs("DropName")] public string dropName;
        public int howMany;
        public abstract ObjectType Type { get; }
    
        // public virtual void SetDropName()
        // {
        //     DropName= ItemName;
        //     
        // }

        // public string GetName()
        // {
        //     return ItemName;
        // }
        //
        // public Sprite GetSprite()
        // {
        //     return Image; 
        // }
        //
        // public abstract ObjectType GetTypeController();
        // public ItemPlace GetItemPlace()
        // {
        //     return Place;
        // }
        //
        // public void SetItemPlace(ItemPlace itemPlace)
        // {
        //     Place = itemPlace;
        // }
        //
        // public ScriptableObject GetScriptableObject()
        // {
        //     return this;
        // }
        //
        // public virtual int GetWeightInInventory()
        // {
        //     return weightInInventory;
        // }
        //
        // public int GetStackLimit()
        // {
        //     return stackLimit;
        // }
        //
        // public virtual string GetDropName()
        // {
        //         return ItemName;
        //     
        // }
        // public bool GetPlayerCanDrop()
        // {
        //     return playerCanDrop;
        // }
        //
        // public bool GetCanEveryBodyTake()
        // {
        //     return canEveryBodyTake;
        // }


    
    }
}