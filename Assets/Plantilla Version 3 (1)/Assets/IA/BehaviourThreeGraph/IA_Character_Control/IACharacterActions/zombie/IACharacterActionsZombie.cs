using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IACharacterActionsZombie : IACharacterActions
{

    float FrameRate = 0;
    public float Rate=1;
    public int damageZombie;
    private void Start()
    {
        LoadComponent();
    }
    public override void LoadComponent()
    {
        base.LoadComponent();

    }
    public void Attack()
    {
         
        if(FrameRate>Rate)
        {
            FrameRate = 0;
            IAEyeZombieAttack _IAEyeZombieAttack = ((IAEyeZombieAttack)AIEye);
            
            if (_IAEyeZombieAttack != null &&
                _IAEyeZombieAttack.ViewEnemy != null)
            {
                _IAEyeZombieAttack.ViewEnemy.Damage(damageZombie, health);
                Debug.Log("Attack a IAN: " + _IAEyeZombieAttack.ViewEnemy.health);
            }
            
        }
        FrameRate += Time.deltaTime;


    }
}
