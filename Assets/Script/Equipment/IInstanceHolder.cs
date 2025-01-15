using Script.InventorySystem.inventory;
using Script.ObjectInstances;

namespace Script.Equipment
{
    public interface IInstanceHolder <T>
    {
        void AddObject(ObjectInstance objectToAdd, CellsInfo cellsInfo);
        void RemoveObject(ObjectInstance objectToRemove);
    }
}