using UnityEngine;
using UnityEngine.UI;

namespace Script.Exp
{
    public class ExpView:MonoBehaviour
    {
        public int expCount;
        public Image expImage;
        
        private void Awake()
        {
        }

        public void ChangeExpRate(float expRate)
        {
            expImage.fillAmount =Mathf.Clamp01(expRate);
        }
        
    }
}