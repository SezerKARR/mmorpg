
using System.Collections.Generic;
using Script.Player;
using Script.Player.Character;

namespace Script.Exp
{
    public class PlayerExp:CharacterExp
    {
        protected Dictionary<int, ExpView> _expViews=new Dictionary<int, ExpView>();
        
        public PlayerExp(PlayerController playerController):base(playerController)
        {
            ExpView[] expViews = playerController.expViews;
            foreach (var expView in expViews)
            {
                _expViews.Add(expView.expCount,expView);
            }

            ChangeExpViews(_characterModel.expRate);
        }
        
        
        public override void ChangeExp(int enemyLevel, long enemyExp)
        {
            base.ChangeExp(enemyLevel,enemyExp);
            ChangeExpViews( expRate);

        }
        private void ChangeExpViews(float expRate)
        {
            int count = _expViews.Count;
            float rateForViews=100f/(float)count;
            expRate=expRate/rateForViews;
            for (int i = 0; i < count; i++)
            {
                _expViews[i].ChangeExpRate(expRate);
                
                expRate--;
            }
            
        }

    }
}