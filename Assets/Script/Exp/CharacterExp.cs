using System.Linq;
using System.Numerics;
using Script.Player.Character;
using Script.ScriptableObject;
using UnityEngine;

namespace Script.Exp
{
    public  class CharacterExp
    {
        protected ExpSo _expSo = Resources.Load<ExpSo>("ExpForLevel");
        protected BigInteger _exp;
        protected int _level;
        public  ExpPerLevelSO expPer = Resources.Load<ExpPerLevelSO>("ExpPerLevel");
        
        public CharacterExp(int level,BigInteger exp)
        {
            _level = level;
            _exp = exp;
            
            Debug.Log(_expSo);

        }
        public  float ExpRateCalculate(int levelDiff)
        {
            if (levelDiff >= expPer.levelDiff[0])
            {
                return expPer.expRate[0];
            }
            else if (levelDiff <= expPer.levelDiff[expPer.levelDiff.Length - 1])
            {
                return expPer.expRate[expPer.expRate.Length - 1];
            }
            else
            {
                int i = 0;
                foreach (var exp in expPer.levelDiff.Skip(1).Take(expPer.levelDiff.Length - 2))
                {
                    if (levelDiff == exp)
                    {
                        return expPer.expRate[i];
                    }
                    i++;

                }
            }
            return expPer.expRate[expPer.expRate.Length - 1];
        }
        public virtual void ChangeExp((int level, float exp) obj)
        {
            _exp+=(BigInteger)obj.exp;
            if (_exp >= BigInteger.Parse(_expSo.exps[obj.level - 1].exp))
            {
                CharacterEvent.OnLevelUp?.Invoke();
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