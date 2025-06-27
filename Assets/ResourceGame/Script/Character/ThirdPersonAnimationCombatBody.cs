using UnityEngine;
using UnityEngine.AI;
 
 
public class ThirdPersonAnimationCombatBody : ThirdPersonAnimationBase
{

     
    public override void LoadComponent()
    {
        base.LoadComponent();
    }

     
    public void HandleAttack()
    {
        if (CantAttack())
        {
            animator.SetBool("Attack", true);
        }
    }
    public bool CantAttack()
    {
        return !animator.GetBool("Attack") && !animator.GetBool("Hit");
    }


}
