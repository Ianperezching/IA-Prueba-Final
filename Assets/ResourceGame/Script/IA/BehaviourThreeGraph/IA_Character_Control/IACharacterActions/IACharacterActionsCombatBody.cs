using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IACharacterActionsCombatBody : IACharacterActions
{
    float FrameRate = 0;
    public float Rate = 1;
    public int damage;
    IAEyeAttack _IAEyeAttack;
    ThirdPersonAnimationCombatBody TPAnimationCombatBody;
    public override void LoadComponent()
    {
        base.LoadComponent();
        TPAnimationCombatBody = ((ThirdPersonAnimationCombatBody)_ThirdPersonAnimationBase);
        _IAEyeAttack = ((IAEyeAttack)AIEye);
        FrameRate = 0;
    }
    public void Damage()
    {
        if (_IAEyeAttack != null &&
            _IAEyeAttack.ViewEnemy != null &&
            _IAEyeAttack.AttackDataView.IsInSight(_IAEyeAttack.ViewEnemy.AimOffset))
        {
            _IAEyeAttack.ViewEnemy.Damage(damage, health);
        }

    }
    public void Attack()
    {
        if (_IAEyeAttack != null &&
           _IAEyeAttack.ViewEnemy != null &&
           _IAEyeAttack.AttackDataView.IsInSight(_IAEyeAttack.ViewEnemy.AimOffset))
        {
            LookEnemy();
            if (FrameRate > Rate && TPAnimationCombatBody.CantAttack())
            {
                FrameRate = 0;

                TPAnimationCombatBody.HandleAttack();

            }
            FrameRate += Time.deltaTime;
        }
       



    }
}
