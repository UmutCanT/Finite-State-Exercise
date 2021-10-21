using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Idle : State
{
    public Idle(GameObject npcObj, NavMeshAgent navAgent, Animator animator, Transform playerTran)
        : base(npcObj, navAgent, animator, playerTran)
    {
        name = STATE.IDLE;
    }

    public override void Enter()
    {
        anim.SetTrigger("isIdle");
        base.Enter();
    }

    public override void Update()
    {
        if (Random.Range(0, 100) < 100)
        {
            nextState = new Patrol(npc, agent, anim, player);
        }
        base.Update();
    }

    public override void Exit()
    {
        anim.ResetTrigger("isIdle");
        base.Exit();
    }
}
