using System;
using System.Numerics;
using System.Text;
using Script.Player;
using Script.ScriptableObject;
using UnityEngine;

namespace Script.Exp
{
    public class ExpController:MonoBehaviour
    {
        public ExpView[] expViews;
        public ExpSo expSo;
        private BigInteger _exp;
        private void Awake()
        {
            
        }

        public void ChangeExp((int level, float exp) obj)
        {
            _exp+=(BigInteger)obj.exp;
            if (_exp >= BigInteger.Parse(expSo.exps[obj.level - 1].exp))
            {
                PlayerEvent.OnLevelUp?.Invoke();
                Debug.Log("level Up");
            }
            float index = (float.Parse((_exp*(BigInteger)10000/BigInteger.Parse(expSo.exps[obj.level-1].exp)).ToString()))  ;
            index = index / 100;
            foreach (var expView in expViews)
            {
                expView.expImage.fillAmount = (float)index/25 ;
                index -=25;
            }
            // Kalan (Modulus)
            // Sonuçları yazdır
            Debug.Log($"Bölme Sonucu: {index}");

        }
        

    }
}