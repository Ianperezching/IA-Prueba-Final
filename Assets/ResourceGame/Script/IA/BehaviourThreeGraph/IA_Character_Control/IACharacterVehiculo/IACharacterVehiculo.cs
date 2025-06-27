using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class IACharacterVehiculo : IACharacterControl
{
    
    public float speedRotation = 0;

    public float RangeWander;
    Vector3 positionWander;
    float FrameRate = 0;
    float Rate = 4;

    public bool IsDrawGizmo;
    public override void LoadComponent()
    {
        base.LoadComponent();
        positionWander = RandoWander(transform.position, RangeWander);
    }
    
    public virtual void LookPosition(Vector3 position)
    {

        Vector3 dir = (position - transform.position).normalized;
        Quaternion rot = Quaternion.LookRotation(dir);
        rot.x = 0;
        rot.z = 0;
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime * speedRotation);
    }
    public virtual void LookRotationCollider()
    {

        //if (_CalculateDiffuse.Collider)
        //{
        //    speedRotation = _CalculateDiffuse.speedRotation;

        //    Vector3 posNormal = _CalculateDiffuse.hit.point + _CalculateDiffuse.hit.normal * 2;

        //    LookPosition(posNormal);
        //}
    }

    public virtual void MoveToPosition(Vector3 pos)
    {
        agent.SetDestination(pos);
    }
    public virtual void MoveToEnemy()
    {
        if (AIEye.ViewEnemy == null) return;
        if (_LogicDiffuse != null && AIEye.DistanceEnemy>0)
        {
            agent.speed = _LogicDiffuse.SpeedDependDistanceEnemy.CalculateFuzzy(AIEye.DistanceEnemy);
        }
        MoveToPosition(AIEye.ViewEnemy.transform.position);
    }
    public virtual void MoveToAllied()
    {
        if (AIEye.ViewAllie == null) return;
        CalculateAgentSpeedAllied();
        MoveToPosition(AIEye.ViewAllie.transform.position);
    }

    private void CalculateAgentSpeedAllied()
    {
        if (_LogicDiffuse != null && AIEye.DistanceEnemy > 0)
        {
            agent.speed = _LogicDiffuse.SpeedDependDistanceAllied.CalculateFuzzy(AIEye.DistanceAllied);
        }
    }

    public virtual void MoveToItem()
    {
        if (AIEye.ViewItem == null) return;
        CalculateAgentSpeedItem();
        MoveToPosition(AIEye.ViewItem.transform.position);
    }

    private void CalculateAgentSpeedItem()
    {
        if (_LogicDiffuse != null && AIEye.DistanceItem > 0)
        {
            agent.speed = _LogicDiffuse.SpeedDependDistancePosition.CalculateFuzzy(AIEye.DistanceItem);
        }
    }

    public virtual void MoveToEvadEnemy()
    {
        if (AIEye.ViewEnemy == null) return;
        CalculateAgentSpeedEvadeEnemy();

        Vector3 dir = (transform.position - AIEye.ViewEnemy.transform.position).normalized;
        Vector3 newPosition = transform.position + dir * 5f;
        MoveToPosition(newPosition);
    }

    private void CalculateAgentSpeedEvadeEnemy()
    {
        if (_LogicDiffuse != null && AIEye.DistanceEnemy > 0)
        {
            if (_LogicDiffuse is LogicDiffuseVillager viller)
            {
                agent.speed = viller.EvadeSpeedDistanceEnemy.CalculateFuzzy(AIEye.DistanceEnemy);
            }
        }
    }

    Vector3 RandoWander(Vector3 position, float range)
    {
        Vector3 randP = Random.insideUnitSphere * range;
        randP.y = transform.position.y;
        NavMeshHit navHit;

        for (int i = 0; i < 20; i++)
        {
            if (NavMesh.SamplePosition(randP, out navHit, range, NavMesh.AllAreas))
            {
                return navHit.position;
            }
            else {
                randP = Random.insideUnitSphere * range;
                randP.y = transform.position.y;
            }
        }
         
        return position ;
    }
    public virtual void MoveToWander()
    {
        if (AIEye.ViewEnemy != null) return;

        float distance = (transform.position - positionWander).magnitude;

        if(distance<2)
        {
            positionWander = RandoWander(transform.position, RangeWander);
        }

        if(FrameRate>Rate)
        {
            FrameRate = 0;
            positionWander = RandoWander(transform.position, RangeWander);
        }
        FrameRate += Time.deltaTime;


        MoveToPosition(positionWander);
    }
    public void DrawGizmos()
    {
        if (!IsDrawGizmo) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, RangeWander);
        Gizmos.DrawWireSphere(positionWander, 0.5f);
        Gizmos.DrawLine(transform.position, positionWander);
    }

}
