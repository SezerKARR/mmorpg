using Script.Game;
using Script.Player.Character;
using Script.ScriptableObject.Player;
using UnityEngine;

namespace Script.Exp
{
    public   class CharacterExp
    {
       
        private float _gainedExpOldDecimal;
        protected CharacterModel _characterModel;
        protected float expRate { get => _characterModel.expRate;set => _characterModel.expRate = value; }
        protected  long exp{get=>_characterModel.exp;set=>_characterModel.exp=value;}
        protected  int level{get=>_characterModel.level;set=>_characterModel.level=value;}
        public CharacterExp(CharController charController)
        {
            _characterModel=charController.characterModel;
            
        }
        
        public virtual void ChangeExp(int enemyLevel, long enemyExp)
        {
            
            float gainExpRate = ExpHelper.ExpRateCalculate(enemyLevel-this.level);
            float gainedExp=enemyExp*gainExpRate/10;//1 rane sıfır eklenecek deneme için yaptım 
            float gainedExpDecimal=gainedExp-(int)gainedExp;
            _gainedExpOldDecimal+=gainedExpDecimal;
            if (_gainedExpOldDecimal > 1f)
            {
                gainedExp ++;
                _gainedExpOldDecimal--;
            }
            this.exp=this.exp+ (long)gainedExp;
            if (this.exp >= long.Parse(ExpHelper._expSo.exps[this.level - 1].exp))
            {
                this.exp = this.exp - long.Parse(ExpHelper._expSo.exps[this.level - 1].exp);
                this.level++;
                
                CharacterEvent.OnLevelUp?.Invoke();
                Debug.Log("enemyLevel Up");
            }
            expRate = exp*10000/long.Parse(ExpHelper._expSo.exps[level-1].exp) / 100f  ;
            
                        
            

        }

       


        public void GainExp(int enemyLevel, long enemyExp)
        {
            ChangeExp(enemyLevel,enemyExp);
        }
    }
}