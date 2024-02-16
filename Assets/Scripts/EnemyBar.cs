using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyBar : MonoBehaviour
{
    [SerializeField] private Image HPBar;
    private Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void Update()
    {
        HPBar.fillAmount = enemy.EnemyHP / enemy.MaxHP;
    }
}
