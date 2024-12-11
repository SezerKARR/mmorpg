
using Zenject;

public class UntitledInstaller : MonoInstaller
{
    // ReSharper disable Unity.PerformanceAnalysis
    public override void InstallBindings()
    {
        Container.Bind<InventoryManagerCvs>().FromComponentInHierarchy().AsSingle();
        Container.Bind<InventoryView>().FromComponentInHierarchy().AsSingle();
    }
}