using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
[TaskCategory("MyAI/Move")]

public class ActionReturnToDefend : ActionNodeVehicle
{
   public override void OnAwake()
    {
        base.OnAwake();
    } 
    public override TaskStatus OnUpdate()
     {
          if (_IACharacterVehiculo.health.IsDead)
                return TaskStatus.Failure;
    
          SwitchUnit();
    
          return TaskStatus.Success;
     }
    void SwitchUnit()
    {
        switch (_UnitGame)
        {
            case UnitGame.Zombie:
               
                break;
             
            case UnitGame.Villager:
                
                break;
            case UnitGame.golem:
                if (_IACharacterVehiculo is IACharacterVehiculoGolem golem)
                {
                    golem.MoveToPosition(golem.InitialPosition);
                    golem.LookPosition(golem.InitialPosition);
                }
                break;
            case UnitGame.None:
                break;
            default:
                break;
        }
    }

}
