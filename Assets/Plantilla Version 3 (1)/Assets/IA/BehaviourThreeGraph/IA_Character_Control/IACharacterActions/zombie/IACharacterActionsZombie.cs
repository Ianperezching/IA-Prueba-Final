using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IACharacterActionsZombie : IACharacterActions
{

    float FrameRate = 0;
    public float Rate=1;
    public int damageZombie;
    ThirdPersonNavMeshController _ThirdPersonNavMeshController;
    IAEyeZombieAttack _IAEyeZombieAttack;
    private void Awake()
    {
        LoadComponent();
    }
    public override void LoadComponent()
    {
        base.LoadComponent();
        _ThirdPersonNavMeshController=GetComponent<ThirdPersonNavMeshController>();
        _IAEyeZombieAttack = ((IAEyeZombieAttack)AIEye);
        Rate = Random.Range(2.17f, 3f);
        FrameRate = 0;
    }
    public void Damage()
    {
        if (_IAEyeZombieAttack != null &&
                _IAEyeZombieAttack.ViewEnemy != null)
        {
            _IAEyeZombieAttack.ViewEnemy.Damage(damageZombie, health);
        }
        
    }
    public void Attack()
    {
        
        if(FrameRate>Rate && _ThirdPersonNavMeshController.CantAttack())
        {
            FrameRate = 0;
           

            if (_IAEyeZombieAttack != null &&
                _IAEyeZombieAttack.ViewEnemy != null)
            {
                 
                _ThirdPersonNavMeshController.HandleAttack();
                
            }
            
        }
        FrameRate += Time.deltaTime;


    }
}
