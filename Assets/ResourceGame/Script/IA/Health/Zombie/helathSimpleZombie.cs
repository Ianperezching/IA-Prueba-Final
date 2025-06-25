using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helathSimpleZombie : healthZombie
{

    bool activeDead=false;
    // Start is called before the first frame update
    void Awake()
    {
        base.LoadComponent();
        activeDead = false;
    }
    public override void Dead()
    {
        base.Dead();
        activeDead=true;
    }

    public override void Damage(int damage, Health enemy)
    {

        if (activeDead) return;
        base.Damage(damage, enemy);
        if (IsDead)
        {
            Dead();
        }
         
    }

}
