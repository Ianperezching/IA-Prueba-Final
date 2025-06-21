using UnityEngine;

public class IACharacterActionsGolem : IACharacterActions
{
    float FrameRate = 0;
    public float Rate=1;
    public int damageGolem;
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
            IAEyeGolem IAEyeGolem = ((IAEyeGolem)AIEye);
            
            if (IAEyeGolem != null &&
                IAEyeGolem.ViewEnemy != null)
            {
                IAEyeGolem.ViewEnemy.Damage(damageGolem, health);
                Debug.Log("Attack a IAN: " + IAEyeGolem.ViewEnemy.health);
            }
            
        }
        FrameRate += Time.deltaTime;


    }
}
