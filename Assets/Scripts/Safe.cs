using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Safe : State
{  
    public Safe(GameObject npcObj, NavMeshAgent navAgent, Animator animator, Transform playerTran)
        : base(npcObj, navAgent, animator, playerTran)
    {
        name = STATE.SAFE;
        agent.speed = 7;
        agent.isStopped = false;
    }

    public override void Enter()
    {
        anim.SetTrigger("isRunning");
        base.Enter();
    }

    public override void Update()
    {
        agent.SetDestination(GameEnvironment.Singleton.SafeZone.transform.position);
        if (agent.hasPath)
        {
            if (agent.remainingDistance < 1)
            {
                nextState = new Idle(npc, agent, anim, player);
                stage = EVENT.EXIT;
            }
        }
    }

    public override void Exit()
    {
        anim.ResetTrigger("isRunning");
        base.Exit();
    }
}
