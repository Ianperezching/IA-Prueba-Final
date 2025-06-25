using UnityEngine;

public class IACharacterActionsGolem : IACharacterActions
{
    float FrameRate = 0;
    public float Rate=1;
    public int damageGolem;
     private void Awake()
    {
        LoadComponent();
    }
    public override void LoadComponent()
    {
        base.LoadComponent();
        Rate = Random.Range(0.5f, 1f);
        FrameRate = 0;

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
