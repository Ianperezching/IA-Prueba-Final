using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
[TaskCategory("MyAI/Range")]
public class ActionColliderAttack : ActionNodeRange
{
    public override void OnAwake()
    {
        base.OnAwake();
    }
    public override TaskStatus OnUpdate()
    {
        if(_IACharacterVehiculo.AIEye.ViewEnemy==null)
          return TaskStatus.Failure;

        switch (_UnitGame)
        {
            case UnitGame.Zombie:
                if (_IACharacterVehiculo.AIEye is IAEyeAttack)
                {
                    IAEyeAttack _IAEyeAttack = ((IAEyeAttack)_IACharacterVehiculo.AIEye);
                    if (_IAEyeAttack != null && _IAEyeAttack.AttackDataView.Sight)
                        return TaskStatus.Success;
                }
                break;
            case UnitGame.Soldier:
                if (_IACharacterVehiculo.AIEye is IAEyeShootAttack)
                {
                    IAEyeShootAttack _IAEyeShootAttack = ((IAEyeShootAttack)_IACharacterVehiculo.AIEye);
                    if (_IAEyeShootAttack != null && _IAEyeShootAttack.AttackDataView.Sight)
                        return TaskStatus.Success;
                }
                break;
            case UnitGame.Villager:
                break;
            case UnitGame.golem:
                if (_IACharacterVehiculo is IACharacterVehiculoGolem golem)
                {
                    if (golem.AIEye is IAEyeAttack)
                    {
                        IAEyeAttack _IAEyeAttack = ((IAEyeAttack)golem.AIEye);
                        if (_IAEyeAttack != null && _IAEyeAttack.AttackDataView.Sight)
                            return TaskStatus.Success;
                    }
                }
                break;
            case UnitGame.None:
                break;
            default:
                break;
        }
        
        return TaskStatus.Failure;
    }


}