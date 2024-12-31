using System;
using System.Linq;
using System.Numerics;
using Script.Player.Character;
using Script.ScriptableObject;
using UnityEngine;

namespace Script.Exp
{
    public  class CharacterExp: IDamager
    {
        public string GetName()
        {
            throw new NotImplementedException();
        }
        protected  ExpSo _expSo = Resources.Load<ExpSo>("ExpForLevel");
        protected  long _exp;
        protected  int _level;
        public  ExpPerLevelSO expPer = Resources.Load<ExpPerLevelSO>("ExpPerLevel");
        private float _gainedExpOldDecimal;
        public CharacterExp(ref int level, ref long exp)
        {
            _level =  level;
            _exp =  exp;
            
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
        public virtual void ChangeExp(int level, long exp)
        {
            float expRate = ExpRateCalculate(level-_level);
            float gainedExp=exp*expRate/100;
            float gainedExpDecimal=gainedExp-(int)gainedExp;
            _gainedExpOldDecimal+=gainedExpDecimal;
            if (_gainedExpOldDecimal > 1f)
            {
                gainedExp ++;
                _gainedExpOldDecimal--;
            }
            _exp=_exp+exp* (long)gainedExp;
            if (_exp >= long.Parse(_expSo.exps[level - 1].exp))
            {
                CharacterEvent.OnLevelUp?.Invoke();
                Debug.Log("level Up");
            }
            float index = (float.Parse((_exp*(long)10000/long.Parse(_expSo.exps[level-1].exp)).ToString()))  ;
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

        

        public Action<int, long> onEnemyKilled { get; set; }
    }
}