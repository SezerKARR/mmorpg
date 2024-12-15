using Script.Equipment;
using Script.Inventory;
using Script.Inventory.Objects;
using Zenject;

namespace Script
{
    public class Zenject : MonoInstaller
    {
        // ReSharper disable Unity.PerformanceAnalysis
        public override void InstallBindings()
        {
            Container.Bind<InventoryManager>().FromComponentInHierarchy().AsSingle();
            Container.Bind<ObjectView>().FromComponentInHierarchy().AsSingle();
            Container.Bind<PickUpDetector>().FromComponentInHierarchy().AsSingle();
            Container.Bind<ItemController>().FromComponentInHierarchy().AsSingle();
            Container.Bind<EquipmentManager>().FromComponentInHierarchy().AsSingle();
           
        }
    }
}