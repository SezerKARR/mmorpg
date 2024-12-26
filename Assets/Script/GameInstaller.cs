using Script.Equipment;
using Script.Inventory;
using Script.Player;
using Zenject;

namespace Script
{
    public class GameInstaller : MonoInstaller
    {
    
        public override void InstallBindings()
        {
            Container.Bind<InventoryManager>().FromComponentInHierarchy().AsSingle();
            Container.Bind<ObjectView>().FromComponentInHierarchy().AsSingle();
            Container.Bind<PickUpDetector>().FromComponentInHierarchy().AsSingle();
            Container.Bind<EquipmentManager>().FromComponentInHierarchy().AsSingle();
            Container.Bind<PlayerController>().FromComponentInHierarchy().AsSingle();
            Container.Bind<CreaturesGroupsHolder>().FromComponentInHierarchy().AsSingle();
        }
    }
}
