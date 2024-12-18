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
        
        
        private ObjectController _currentObjectController;
        public static Action<ObjectAbstract,int> OnObjectAddToPage;
        [SerializeField] PageView _pageView;
        [SerializeField] PageModel _pageModel;
        
        public int rowCount,columnCount;
        public PageModel PageModel => _pageModel;
        
        
       
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