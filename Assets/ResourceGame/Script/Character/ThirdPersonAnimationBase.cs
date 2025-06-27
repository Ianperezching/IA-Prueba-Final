using UnityEngine;
using UnityEngine.AI;
public enum StateAnimator
{
    IdleWalkRun,
    Attack,
    Dead,
    Combat,
    Hit,
    None
}
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class ThirdPersonAnimationBase : MonoBehaviour
{
    
    protected NavMeshAgent agent;
    protected Animator animator;
    protected Health health;
    [Header("State Animator")]
    public StateAnimator _StateAnimator;
    public float SpeedMax;
    public virtual void LoadComponent()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();
        SpeedMax = agent.speed;
    }
    public bool CantDoDamage()
    {
        return (_StateAnimator == StateAnimator.IdleWalkRun);
    }
    public void HandleHit()
    {
        
        if (_StateAnimator == StateAnimator.IdleWalkRun && !animator.GetBool("Hit"))
        {
            animator.SetBool("Hit", true);
        }
    }
    public void HandleMovement()
    {
        float speedPercent = (agent.velocity.magnitude / (SpeedMax)) ;
        animator.SetFloat("Forward", Mathf.Clamp01(speedPercent));
    }

    
    public void Dead()
    {
        animator.SetBool("Dead", true);
        agent.isStopped = true;
    }
}
