using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class ThirdPersonNavMeshController : MonoBehaviour
{
    
    private NavMeshAgent agent;
    private Animator animator;
    public Health health;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();
    }

    void Update()
    {
        if (health.IsDead) return;

        HandleMovement();
        HandleAttack();
    }

    void HandleMovement()
    {
        // Animar la velocidad normalizada
        float speedPercent = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("Forward", Mathf.Clamp01(speedPercent));
    }

    public void HandleAttack()
    {
        if (!animator.GetBool("Attack"))
        {
            
            animator.SetBool("Attack", true);
        }
           
          
    }
    public bool CantAttack()
    {
        return !animator.GetBool("Attack");
    }

    public void Die()
    {
        animator.SetBool("Dead", true);
    }
}
