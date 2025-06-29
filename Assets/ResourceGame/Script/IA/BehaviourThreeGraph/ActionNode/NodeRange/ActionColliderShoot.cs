using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
[TaskCategory("MyAI/Range")]
public class ActionColliderShoot : ActionNodeRange
{
     public override void OnAwake()
    {
        base.OnAwake();
    }
    public override TaskStatus OnUpdate()
    {
        if(_IACharacterVehiculo.AIEye.ViewEnemy==null)
          return TaskStatus.Failure;
        IAEyeShoot _IAEyeShoot = ((IAEyeShoot)_IACharacterVehiculo.AIEye);
        if (_IAEyeShoot != null && _IAEyeShoot.ShootDataView.Sight)
            return TaskStatus.Success;

        return TaskStatus.Failure;
    }


}