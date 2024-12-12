
using Zenject;

public class UntitledInstaller : MonoInstaller
{
    // ReSharper disable Unity.PerformanceAnalysis
    public override void InstallBindings()
    {
        Container.Bind<InventoryManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<ObjectView>().FromComponentInHierarchy().AsSingle();
        Container.Bind<PickUpDetector>().FromComponentInHierarchy().AsSingle();
        Container.Bind<ItemController>().FromComponentInHierarchy().AsSingle();
    }
}