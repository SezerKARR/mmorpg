public interface IDropable:IInventorObjectable
{
    public string GetDropName();
    public bool GetPlayerCanDrop();
    public bool GetCanEveryBodyTake();
}
