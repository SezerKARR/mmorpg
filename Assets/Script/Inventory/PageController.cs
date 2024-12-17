using System;
using System.Collections.Generic;
using System.Linq;
using Script.Inventory;
using Script.Inventory.Objects;
using Script.ScriptableObject.Prefab;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;
using Object = UnityEngine.Object;

namespace Script.Inventory
{

//usage
    public class PageController:MonoBehaviour
    {
       
        public List<List<float>> twoDimensionalList = new List<List<float>>();
        public ItemPrefabList objectsPrefab;
        
        private ObjectController _currentObjectController;
        public static Action<ObjectAbstract,int> OnObjectAddToPage;
        [SerializeField] PageView _pageView;
        [SerializeField] PageModel _pageModel;
        
        public int rowCount,columnCount;
        public PageModel PageModel => _pageModel;
        
        public void CreateObjectModel(List<int2> cellInt2, ObjectAbstract inventorObjectable, int howMany)
        {
            GameObject objectControllerGameObject= Instantiate(objectsPrefab.GetPrefabByType(inventorObjectable.Type));
            
            objectControllerGameObject.GetComponent<ObjectController>().Place(inventorObjectable,this.transform,cellInt2,howMany,
                _pageView._height,_pageView._width);
            _pageModel.AddObjectToPage(objectControllerGameObject.GetComponent<ObjectController>(),cellInt2);
            OnObjectAddToPage?.Invoke(inventorObjectable,howMany);
        }
       
        public void ClosePage()
        {
            _pageView.ClosePage();

        }
        public void OpenPage()
        {
           _pageView.OpenPage();

        }
        
        
      
        
        
       

       
    }
}