using System;
using Script.Inventory.Objects;

namespace Script.Inventory
{
    public class InventoryStorage
    {
        public InventoryPage[] inventoryPage;
        public HaveObjects haveObjects=new HaveObjects();
        [Serializable]
        public class HaveObjects : UnityDictionary<ObjectAbstract, int> { };
        
        public void AddObjectsToInventory(ObjectAbstract inventorObjectable, int howMany)
        {
            if (haveObjects.ContainsKey(inventorObjectable))
            {
                // Eğer key mevcutsa, listenin sonuna item ekle
                haveObjects[inventorObjectable]+=howMany;
                return;
            }
            haveObjects.Add(inventorObjectable, howMany);
        }
        public bool ControlChangePos(ItemController unEquipObject)
        {
       
            foreach (InventoryPage page in inventoryPage)
            {
           
                return page.ControlChangePos(unEquipObject);
            
            }

            return false;
      
        }
        public void ChangePos(ObjectController objectController)
        {
            ObjectController temp = objectController;
        
        }
        public bool Add(ObjectAbstract inventorObjectAble,int howMany)
        {

            if (CanAddStack(inventorObjectAble, howMany)) {return true;}
        
            return CanAdd(inventorObjectAble, howMany);

        }
        public bool CanAdd(ObjectAbstract inventorObjectAble, int howMany)
        {
            foreach (InventoryPage page in inventoryPage)
            {
           
                if( page.ControlAdd(inventorObjectAble, howMany)){return true;};
            
            }

            return false;
        }
        public bool CanAddStack(ObjectAbstract inventorObjectAble, int howMany)
        {
            if (inventorObjectAble.stackLimit > 1)
            {
                foreach (InventoryPage page in inventoryPage)
                {

          
                    if(page.AddStack(inventorObjectAble, howMany))
                    {
                        return true;
                    }
                }
            
            }
            return false;   
        }
        // public void DropObject()
        // {
        //     if (objectController.inventorObjectable is IDropable dropable)
        //     {
        //         if (dropable.GetPlayerCanDrop())
        //         {
        //             string confirmText = $"{dropable.GetDropName()} yere atmak istedi�ine emin misin";
        //             UIManager.Instance.OpenConfirm(confirmText,this);
        //         }
        //         else { Debug.Log("bu obje yere at�lamaz"); }
        //     }
        // }
    }
   
}