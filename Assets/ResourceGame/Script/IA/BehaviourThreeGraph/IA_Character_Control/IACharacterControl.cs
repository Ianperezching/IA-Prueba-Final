using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class IACharacterControl : MonoBehaviour
{
    public NavMeshAgent agent { get; set; }
    public Health health { get; set; }
    public IAEyeBase AIEye { get; set; }
    protected ThirdPersonAnimationBase _ThirdPersonAnimationBase;
    public ThirdPersonAnimationBase ThirdPersonAnimation { get => _ThirdPersonAnimationBase; }
    protected LogicDiffuse _LogicDiffuse;
    public virtual void LoadComponent()
    {
        agent = GetComponent<NavMeshAgent>();
        health = GetComponent<Health>();
        AIEye = GetComponent<IAEyeBase>();
        _ThirdPersonAnimationBase = GetComponent<ThirdPersonAnimationBase>();
        _LogicDiffuse = GetComponent<LogicDiffuse>();
    }
    public virtual void LookEnemy()
    {
        if (AIEye.ViewEnemy == null) return;
        Vector3 dir = (AIEye.ViewEnemy.transform.position - transform.position).normalized;
        Quaternion rot = Quaternion.LookRotation(dir);
        rot.x = 0;
        rot.z = 0;
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime * 50);
    }
}
