public interface IEquipmentAble
{
    void Equip(IItemable ScriptableItemsAbstact);
    void UnEquip();
    EquipmentType GetEquipmentType();   
    IItemable GetItemable();
}
