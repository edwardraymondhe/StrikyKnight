using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public PlayerStat playerStat;

    public GameObject graphic;
    public WeaponHolder weaponHolder;
    public WeaponInfo weaponInfo;

    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyMask;

    public Animator animator;
    private Animator weaponAnimator;

    private bool isAttacked = false;

    private Rigidbody2D rb;

    private void Start()
    {
        attackRange = 0.8f;
        playerStat = GetComponentInParent<PlayerStat>();
        graphic = transform.gameObject;
        weaponHolder = graphic.GetComponentInChildren<WeaponHolder>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        weaponInfo = weaponHolder.getWeapon().GetComponent<WeaponInfo>();
        if (weaponInfo.weaponType == 0)
        {
            animator.ResetTrigger("Ranged");
            animator.SetTrigger("Melee");
        }
        if (weaponInfo.weaponType == 1)
        {
            animator.ResetTrigger("Melee");
            animator.SetTrigger("Ranged");
        }
        Debug.Log(weaponInfo.weaponType);
        /*
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            animator.SetTrigger("Attack");
        }
        */
}

public void attack()
    {
        int weaponType = weaponInfo.weaponType;

        switch (weaponType)
        {
            case 0:
                meleeAttack();
                break;

            case 1:
                rangedAttack();
                break;

            default:
                Debug.Log("NO SUCH WEAPON TYPE");
                return;
        }

        Debug.Log("Just attacked !");
    }

    void meleeAttack()
    {
        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyMask);

        if (hitEnemy != null)
        {
            foreach (Collider2D enemy in hitEnemy)
            {
                enemy.GetComponent<EnemyStat>().takeDamage(playerStat.currMeleeDmg + weaponInfo.weaponDmg / 2);
            }
        }
    }

    void rangedAttack()
    {

    }


    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreLayerCollision(10, 11, true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreLayerCollision(10, 11, false);
        }
    }
}
