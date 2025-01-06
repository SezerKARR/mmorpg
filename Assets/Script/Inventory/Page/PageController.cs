using System;
using Script.Inventory.Objects;
using Script.ScriptableObject;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script.Inventory
{
    public class PageController:MonoBehaviour
    {
        private ObjectController _currentObjectController;
        public static Action<ObjectAbstract,int> OnObjectAddToPage;
        [FormerlySerializedAs("_pageView")] [SerializeField] private PageView pageView;
        [FormerlySerializedAs("_pageModel")] [SerializeField] private PageModel pageModel;
        
        public int rowCount,columnCount;
        public PageModel PageModel => pageModel;
        public Transform PageViewTransform => pageView.GetComponent<Transform>();

        private void Awake()
        {
            pageView.OnClick += OnClick;
        }

        private void OnClick(Vector2 position)
        {
            PageEvent.OnClickPage?.Invoke(position,pageModel.pageIndex);
        }

        public void ClosePage()
        {
            pageView.ClosePage();

        }
        public void OpenPage()
        {
           pageView.OpenPage();

        }
    }
}