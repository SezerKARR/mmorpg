using System.Collections;
using System.Collections.Generic;
using Script.Equipment;
using Script.Inventory.Objects;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    
    public override void InstallBindings()
    {
        Container.Bind<InventoryManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<ObjectView>().FromComponentInHierarchy().AsSingle();
        Container.Bind<PickUpDetector>().FromComponentInHierarchy().AsSingle();
        Container.Bind<EquipmentManager>().FromComponentInHierarchy().AsSingle();
           
    }
}
