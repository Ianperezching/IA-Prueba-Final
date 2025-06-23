using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TypeAgent { A, B, C, D, E }
public enum UnitGame
{
    Zombie,
    Soldier,
    Villager,
    golem,
    None
}
public enum StateAnimator
{
    IdleWalkRun,
    Attack,
    Dead,
    None
}
public class Health : MonoBehaviour
{
    [Header("imageUI")]
    public Image HealthBarLocal;

    [Header("CountHealth")]
    public int health;
    public int healthMax;

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
    protected Animator animator;
    public float TimeDestroy;
    [Header("State Animator")]
    public StateAnimator _StateAnimator;
     
    IEnumerator HurtingMeActive(Health enemy)
    {
        HurtingMe = enemy;
        yield return new WaitForSeconds(3);
        HurtingMe = null;
        StopCoroutine(HurtingMeroutine);
    }
    public virtual void Dead()
    {
        animator.SetBool("Dead", true);
        StartCoroutine(DeadDestroy());
    }
    IEnumerator DeadDestroy()
    {
        yield return new WaitForSecondsRealtime(TimeDestroy);
        Destroy(this.gameObject);
    }
    public virtual void Damage(int damage,Health enemy)
    {
        
        if (Importal) return;
       
        if (!IsDead)
        {
           
            if ((health - damage) > 0)
                health -= damage;
            else
                health = 0;
            UpdateHealthBar();
            if (enemy != null)
                HurtingMeroutine = StartCoroutine(HurtingMeActive(enemy));
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

    public virtual void LoadComponent()
    {
        health = healthMax;
        animator = GetComponent<Animator>();

    }


}
