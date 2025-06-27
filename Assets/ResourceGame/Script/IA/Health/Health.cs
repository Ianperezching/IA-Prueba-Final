using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TypeAgent { A, B, C, D, E }
public enum UnitGame
{
    Zombie,
    Villager,
    golem,
    None
}

public class Health : MonoBehaviour
{
    [Header("imageUI")]
    public Image HealthBarLocal;

    [Header("CountHealth")]
    public int health;
    public int healthMax;
    public int Armor;
    public int ArmorMax;
    public bool IsDead { get => (health <= 0); }

    [Header("AimOffSet")]
    public Transform AimOffset;
    public Health HurtingMe;

    [Header("Type Agent")]
    public TypeAgent typeAgent;
    [Header("Type List Agent Allies")]
    public List<TypeAgent> typeAgentAllies = new List<TypeAgent>();
    Coroutine HurtingMeroutine;

    public bool Importal = false;
    public UnitGame _UnitGame;
    public bool IsCantView=true;
    public float TimeDestroy;
    public bool activeDead = false;
    ThirdPersonAnimationBase thirdPersonAnimationBase;
    public virtual void LoadComponent()
    {
        health = healthMax;
        Armor = ArmorMax;
        thirdPersonAnimationBase = GetComponent<ThirdPersonAnimationBase>();
        activeDead = false;
        UpdateHealthBar();
    }
     
    IEnumerator HurtingMeActive(Health enemy)
    {
        HurtingMe = enemy;
        yield return new WaitForSeconds(3);
        HurtingMe = null;
        StopCoroutine(HurtingMeroutine);
    }
    public virtual void Dead()
    {
        activeDead = true;
        thirdPersonAnimationBase.Dead();
        StartCoroutine(DeadDestroy());
    }
    IEnumerator DeadDestroy()
    {
        yield return new WaitForSecondsRealtime(TimeDestroy);
        Destroy(this.gameObject);
    }
    public virtual void Damage(int damage,Health enemy)
    {
        if (activeDead) return;
        if (Importal) return;
        Armor = Mathf.Clamp(Armor - damage, 0, ArmorMax);
        if (Armor == 0)
            health = Mathf.Clamp(health - damage, 0, healthMax);

        thirdPersonAnimationBase.HandleHit();

        UpdateHealthBar();
        if (enemy != null)
            HurtingMeroutine = StartCoroutine(HurtingMeActive(enemy));

        if (IsDead)
        {
            Dead();

        }
         
    }

    
    public void UpdateHealthBar()
    {
        if (HealthBarLocal != null)
        {
            float h = ((float)((float)health / (float)healthMax));
            HealthBarLocal.fillAmount = h;
        }
    }

    

}
