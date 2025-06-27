using UnityEngine;
using UnityEngine.AI;
 
 
public class ThirdPersonAnimationPaldin : ThirdPersonAnimationCombatBody
{

    private void Awake()
    {
        this.LoadComponent();
    }
    public override void LoadComponent()
    {
        base.LoadComponent();
    }

    void Update()
    {
        if (health.IsDead) return;

        HandleMovement();
     
    }

     
}
