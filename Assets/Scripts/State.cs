using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State
{
    public enum STATE
    {
        IDLE, PATROL, PURSUE, ATTACK, SAFE
    }

    public enum EVENT
    {
        ENTER, UPDATE, EXIT
    };

    public STATE name;
    protected EVENT stage;
    protected GameObject npc;
    protected Animator anim;
    protected Transform player;
    protected State nextState;
    protected NavMeshAgent agent;

    float visDistance = 10.0f;
    float visAngle = 30.0f;
    float shootDistance = 7.0f;
    float dangerSenseAngle = 30.0f;
    float dangerSenseDis = 2.0f;

    public State(GameObject npcObj, NavMeshAgent navAgent, Animator animator, Transform playerTran)
    {
        npc = npcObj;
        agent = navAgent;
        anim = animator;
        stage = EVENT.ENTER;
        player = playerTran;
    }

    public virtual void Enter()
    {
        stage = EVENT.UPDATE;
    }

    public virtual void Update()
    {
        stage = EVENT.UPDATE;
    }

    public virtual void Exit()
    {
        stage = EVENT.EXIT;
    }

    //Progress the state through each of the different stages.
    public State Process()
    {
        if(stage == EVENT.ENTER)
        {
            Enter();
        }

        if (stage == EVENT.UPDATE)
        {
            Update();
        }

        if (stage == EVENT.EXIT)
        {
            Exit();
            return nextState;
        }

        return this;
    }

    public bool CanSeePlayer()
    {
        if (DirectionOfPlayer().magnitude <= visDistance && AngleOfPlayer(DirectionOfPlayer()) <= visAngle)
        {
            return true;
        }
        return false;
    }

    public bool CanAttackPlayer()
    {
        if (DirectionOfPlayer().magnitude < shootDistance)
        {
            return true;
        }
        return false;
    }
    
    public bool CanSenseDanger()
    {
        if (DirectionOfPlayer().magnitude <= dangerSenseDis && AngleOfPlayer(-DirectionOfPlayer()) <= dangerSenseAngle)
        {
            return true;
        }
        return false;
    }

    protected Vector3 DirectionOfPlayer()
    {
        return (player.position - npc.transform.position);
    }

    protected float AngleOfPlayer(Vector3 direction)
    {
        return Vector3.Angle(direction, npc.transform.forward);
    }
}
