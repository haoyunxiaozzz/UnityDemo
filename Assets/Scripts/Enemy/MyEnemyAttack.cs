using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MyEnemyAttack : MonoBehaviour
{
    private GameObject player;
    private bool playerInRange = false;
    private float timer = 0;
    private MyPlayerHeath myPlayerHeath;
    private Animator enemyAnim;
    public float EnemyAttackDamaged;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        myPlayerHeath = player.GetComponent<MyPlayerHeath>(); 
        enemyAnim =GetComponent<Animator>();
    }

    void Update()
    {
        timer += Time.deltaTime;  
        if (!myPlayerHeath.IsPlayerDead && playerInRange && timer > 1f)
        {
            Attack();
        }

        if (myPlayerHeath.IsPlayerDead)
            enemyAnim.SetTrigger("PlayerDead");
    }

    private void Attack()
    {
        timer = 0;
        myPlayerHeath.TaskDamage(50);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
            playerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }
}
