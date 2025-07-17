using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MyEnemyMovement : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent nav;
    private MyEnemyHealth myEnemyHealth;

    private MyPlayerHeath myPlayerHeath;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        myEnemyHealth = GetComponent<MyEnemyHealth>();
        myPlayerHeath = player.GetComponent<MyPlayerHeath>();
    }


    // Update is called once per frame
    void Update()
    {
        //以玩家坐标为目的
        //物体是物体，物体的组件是物体的组件
        //nav.SetDestination(player.position);

        //判断当前敌人是否死亡，如果死亡，则每一帧进来，则不能跟踪玩家
        //获取当前敌人是否存活

        // 敌方不死亡 并且  玩家不死亡，那么就跟踪    IsDeath死亡方法
        // 
        if (!myEnemyHealth.IsDeath && !myPlayerHeath.IsPlayerDead)
            nav.SetDestination(player.position);

        //如果有一放死亡，则,nav = GetComponent<NavMeshAgent>(); 导航禁用
        else
            nav.enabled = false;

    }
}
