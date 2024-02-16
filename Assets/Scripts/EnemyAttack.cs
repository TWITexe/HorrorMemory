using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Animator animEnemyAttack;
    private void Start()
    {
        animEnemyAttack = GetComponent<Animator>();
       //enemy = GameObject.Find("Enemy").GetComponent<Enemy>();
    }
    public void ReverseCardAttack(float enemyHP)
    {
        if (enemyHP < 5)
        {
            StartCoroutine(AttackCooldown());
            animEnemyAttack.enabled = true;
            animEnemyAttack.Play("AgroEnemy");
            
        }
    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(2.5f);
        animEnemyAttack.enabled = false;
    }
}
