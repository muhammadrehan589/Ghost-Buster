using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private LayerMask attackableLayer;
    [SerializeField] private float attackRange=1.5f;
    [SerializeField] private Transform attackTransform;
    [SerializeField] private float damageAmount=1f;
    [SerializeField] private float timeBetweenattack=0.15f;

    private RaycastHit2D[] hits;

    private Animator anim;

    private float attacktimecounter;

    public bool ShouldbeDamaging { get; private set; } = false;

    private List<IDamagable> idamageable = new List<IDamagable>();

    private void Start()
    {
      anim=GetComponent<Animator>();
        attacktimecounter = timeBetweenattack;
    }

 
   private void Update()
   {
    if(UserInput.Instance.controls.Attack.Attack.WasPressedThisFrame() && attacktimecounter>= timeBetweenattack)
    {
            attacktimecounter=0;
           
            anim.SetTrigger("Attack");
    }
        attacktimecounter += Time.deltaTime;
   }
   

    public IEnumerator DamageWhileslashisactive()
    {
        ShouldbeDamaging = true;
        while(ShouldbeDamaging)
        {
            hits = Physics2D.CircleCastAll(attackTransform.position, attackRange, transform.right, 0f, attackableLayer);
            for (int i = 0; i < hits.Length; i++)
            {
                IDamagable idamagable = hits[i].collider.gameObject.GetComponent<IDamagable>();
                if (idamagable != null && !idamagable.Hastakendamage)
                {
                    idamagable.damage(damageAmount,transform.right);
                    idamageable.Add(idamagable);

                }
            }
            yield return null;

        }
        ReturnedAttackabletoDamagable();
    }

    private void ReturnedAttackabletoDamagable()
    {
        foreach (IDamagable thingthatwasdamage in idamageable)
        {
            thingthatwasdamage.Hastakendamage = false;

        }
        idamageable.Clear();
    }
   private void OnDrawGizmos()
   {
    Gizmos.DrawWireSphere(attackTransform.position, attackRange);
   }

    #region Animation Triggers

    public void ShouldBeDamagingToTrue()
    {
        ShouldbeDamaging = true;
    }

    public void ShouldBeDamagingToFalse()
    {
        ShouldbeDamaging = false;
    }


    #endregion
}
