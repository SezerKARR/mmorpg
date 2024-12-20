using System.Collections;
using System.Collections.Generic;
using Script.Player;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    public static PlayerStateManager Instance;
    private PlayerState currentState;
    private PlayerMovement PlayerMovement;
    public Animator animator;
    [HideInInspector]
    public int animValue;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        PlayerMovement = GetComponent<PlayerMovement>();
        Instance = this;
        InputPlayer.OnMovePressed += CanChangeStateToMove;
        InputPlayer.OnNormalAttackPressed += CanChangeStateToAttack;
        InputPlayer.OnIdlePerformed += CanChangeStateToIdle;
    }
    void Start()
    {
        // Durumlar� olu�tur

        //states.Add(PlayerStateType.Jump, new JumpState(this));
        //states.Add(PlayerStateType.Dodge, new DodgeState(this));

        // �lk durumu ayarla
        currentState = new IdleState(this);
        currentState.EnterState();
    }
    private void Update()
    {
        if (currentState == null)
        {
            currentState = new IdleState(this);
            currentState.EnterState();
        }
        currentState.UpdateState();
    }
    public void CanChangeStateToMove(Vector2 walkDirection)
    {
        ChangeState(new MoveState(this, walkDirection));
    }
    public void CanChangeStateToIdle()
    {
        ChangeState(new IdleState(this));
    }
    public void CanChangeStateToAttack()
    {
        ChangeState(new AttackState(this));

    }
    public void StartPlayerCoroutine(IEnumerator routine)
    {
        StartCoroutine(routine); // Coroutine'i ba�lat
    }
    public void ChangeState(PlayerState newState)
    {
        if (currentState.CanTransitionTo(newState))
        {
            currentState.ExitState();
            currentState = newState;
            currentState.EnterState();
        }
    }

    public PlayerState GetState(PlayerState stateType)
    {
        return stateType;
    }
}