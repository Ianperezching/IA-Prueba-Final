using UnityEngine;

public class HealthGolem : Health
{
    public Rigidbody rbShield;
   
    // Start is called before the first frame update
    void Awake()
    {
        base.LoadComponent();
         
    }
     
    public override void Damage(int damage, Health enemy)
    {
        base.Damage(damage, enemy);
        if (Armor == 0 && rbShield.isKinematic)
        {
            rbShield.isKinematic=false;
            rbShield.gameObject.transform.parent = null;
        }
         
    }
}
