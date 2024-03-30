using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float attackRate = 2f;
    float nextAttack = 0;

    private Animator _anim;
    Rigidbody rb;
    Movement movement;
    [SerializeField] private GameObject AttackButton;


    public Transform attackPoint;
    public float attackDistance;
    public LayerMask enemyLayers;
    public Transform bigAttackPoint;
    public float bigAttackDistance;

    public float damage;
    public float bigDamage;

    WeaponStats weaponStats;


    void Start()
    {
        weaponStats = GetComponent<WeaponStats>();
        movement = GetComponent<Movement>();
        _anim = GetComponent<Animator>();
        AttackButton.SetActive(true);
    
    }

    
    void Update()
    {
        if(Time.time>nextAttack)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                Attack();
                nextAttack = Time.time + 1f / attackRate;
            }
        }

        
    }



    public void Attack()
    {
        float numb = Random.Range(0, 3);
        if (numb==0)
        {

            _anim.SetTrigger("Attack1");

            Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackDistance, enemyLayers);
            foreach (Collider enemy in hitEnemies)
            {

                EnemyStats enemyStats = enemy.GetComponent<EnemyStats>();
                if (enemyStats != null)
                {
                    enemyStats.TakeDamage(weaponStats.DamageInput());
                }
            }
        }
        else if (numb == 1)
        {
            _anim.SetTrigger("Attack2");

            Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackDistance, enemyLayers);
            foreach (Collider enemy in hitEnemies)
            {

                EnemyStats enemyStats = enemy.GetComponent<EnemyStats>();
                if (enemyStats != null)
                {
                    enemyStats.TakeDamage(weaponStats.DamageInput());
                }
            }

        }
        else if (numb == 2)
        {
            _anim.SetTrigger("Attack3");

            Collider[] hitEnemies = Physics.OverlapSphere(bigAttackPoint.position, bigAttackDistance, enemyLayers);
            foreach (Collider enemy in hitEnemies)
            {

                EnemyStats enemyStats = enemy.GetComponent<EnemyStats>();
                if (enemyStats != null)
                {
                    enemyStats.TakeDamage(bigDamage);
                }
            }
        }


        

    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(bigAttackPoint.position, bigAttackDistance);
        Gizmos.DrawWireSphere(attackPoint.position, attackDistance);
    }


}
