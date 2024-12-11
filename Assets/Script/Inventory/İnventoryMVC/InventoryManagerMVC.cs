
using System.Collections.Generic;
using Script.Inventory.İnventoryMVC;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class InventoryManagerMvc : MonoBehaviour
{
    public InventoryPageMvc[] inventoryPageMvc;
    public void AddObject(IInventorObjectable inventorObjectAble,int howMany,GameObject destroyIfPickUp=null)
    {
        
        if(Add(inventorObjectAble,howMany))Destroy(destroyIfPickUp);
    }
    public bool Add(IInventorObjectable inventorObjectAble,int howMany)
    {
        

        foreach (InventoryPageMvc page in inventoryPageMvc)
        {

            if (inventorObjectAble.GetStackLimit() > 1)
            {
                if(page.AddStack(inventorObjectAble, howMany))
                {
                    int index = itemsInInventory.FindIndex(x => x.Item1 == inventorObjectAble);
                    if (index != -1)
                    {
                        itemsInInventory[index] = (itemsInInventory[index].inventorObject, itemsInInventory[index].howMany + howMany);
                    }
                    return true;
                }
            }
            if (page.CanGetObject(inventorObjectAble, howMany)) {

                itemsInInventory.Add((inventorObjectAble, howMany));
                return true;
            }
        }
        return false;

    }
}
