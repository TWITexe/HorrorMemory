using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float EnemyHP { get; set; } = 10f;
    public float MaxHP { get; set; } = 10f;
    private int rage = 0;
    [SerializeField] private EnemyAttack _enemyAttack;
    private Animator animEnemy;

    private void Start()
    {
        animEnemy = GetComponent<Animator>();
    }

    public void GetEnemyRage()
    {
        rage++;
        if (rage == 1)
        {
            animEnemy.Play("enemyLVL1");
        }
        else if (rage == 2)
        {
            animEnemy.Play("enemyLVL2");
        }
        else if (rage >= 3)
        {
            animEnemy.Play("enemyLVL3");
        }
    }

    public void EnemyDamage(float damage)
    {
        this.EnemyHP -= damage;
        if ( EnemyHP <= 5)
        {
            _enemyAttack.ReverseCardAttack(EnemyHP);
        }
    }
}
