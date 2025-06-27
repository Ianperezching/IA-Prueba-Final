using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
[TaskCategory("MyAI/Action")]
public class ActionNodeCantAttack : ActionNodeAction
{
     

    public override void OnAwake()
    {
        base.OnAwake();
    }
    public override TaskStatus OnUpdate()
    {
        if (_IACharacterVehiculo.health.IsDead)
            return TaskStatus.Failure;

        if (_IACharacterVehiculo.ThirdPersonAnimation is ThirdPersonAnimationCombatBody combatBody && combatBody.CantAttack())
        {
            return TaskStatus.Success;
        }
            

        return TaskStatus.Failure;

    }
    void SwitchUnit()
    {


        switch (_UnitGame)
        {
            case UnitGame.Zombie:
                if (_IACharacterActions is IACharacterActionsZombie)
                {
                    ((IACharacterActionsZombie)_IACharacterActions).Attack();
                }

                break;
             
            case UnitGame.golem:
                if (_IACharacterActions is IACharacterActionsGolem)
                {
                    ((IACharacterActionsGolem)_IACharacterActions).Attack();
                }
                break;
            case UnitGame.None:
                break;
            default:
                break;
        }



    }
}