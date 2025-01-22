using Script.ScriptableObject.Objects.Equipment;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Script.UpgradePanel
{
    public class RequireIcon : MonoBehaviour
    {
        public Image icon;
        public TextMeshProUGUI text;
        public void HandleIcons(Require require)
        {
           if(require==null) this.gameObject.SetActive(false);
           if (require != null)
           {
               icon.sprite = require.upgradeItem.image;
               text.text = require.upgradeItem.itemName + " x" + require.howMany;
                   this.gameObject.SetActive(true);
           }
        }
    }
}
