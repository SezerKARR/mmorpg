using System;
using System.Collections;
using System.Collections.Generic;
using Script.Anim;
using Script.Bonus;
using Script.Player.Character;
using Script.ScriptableObject.Player;
using UnityEngine;

namespace Script.Player.PlayerState
{
    public class PlayerStateManager : CharacterStateManager
    {
        protected override void Awake()
        {
            base.Awake();
            //characterModel.stats[StatType.MinAttack] = 5;
            InputPlayer.OnMovePressed += CanChangeStateToMove;
            InputPlayer.OnNormalAttackPressed += CanChangeStateToAttack;
            InputPlayer.OnMoveCancel += MoveCanceled;
            InputPlayer.OnShootCancel += ShootCanceled;
        }


       
       
    }
}