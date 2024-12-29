using System.Linq;
using System.Numerics;
using Script.Player;
using Script.ScriptableObject;
using UnityEngine;

namespace Script.Exp
{
    public class ExpController:CharacterExp
    {
        public ExpView[] expViews;
        

        public ExpController(int level,BigInteger exp):base(level,exp)
        {
            _level = level;
            _exp = exp;
            
            Debug.Log(_expSo);

        }
        
        
        public void ChangeExp((int level, float exp) obj)
        {
            _exp+=(BigInteger)obj.exp;
            if (_exp >= BigInteger.Parse(_expSo.exps[obj.level - 1].exp))
            {
                PlayerEvent.OnLevelUp?.Invoke();
                Debug.Log("level Up");
            }
            float index = (float.Parse((_exp*(BigInteger)10000/BigInteger.Parse(_expSo.exps[obj.level-1].exp)).ToString()))  ;
            index = index / 100;
            // foreach (var expView in expViews)
            // {
            //     expView.expImage.fillAmount = (float)index/25 ;
            //     index -=25;
            // }
            // Kalan (Modulus)
            // Sonuçları yazdır
            Debug.Log($"Bölme Sonucu: {index}");

        }
        

    }
}