
using Zenject;

public class UntitledInstaller : MonoInstaller
{
    // ReSharper disable Unity.PerformanceAnalysis
    public override void InstallBindings()
    {
        Container.Bind<InventoryManagerMvc>().FromComponentInHierarchy().AsSingle();
        Container.Bind<InventoryView>().FromComponentInHierarchy().AsSingle();
        Container.Bind<PickUpDetector>().FromComponentInHierarchy().AsSingle();
    }
}