using Script.InventorySystem.inventory;

namespace Script.Equipment
{
    public interface IInstanceHolder <T>
    {
        void AddObject(T objectToAdd,CellsInfo cellsInfo);
        void RemoveObject(T objectToRemove);

    }
}