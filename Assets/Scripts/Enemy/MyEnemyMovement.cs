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
        //���������ΪĿ��
        //���������壬������������������
        //nav.SetDestination(player.position);

        //�жϵ�ǰ�����Ƿ������������������ÿһ֡���������ܸ������
        //��ȡ��ǰ�����Ƿ���

        // �з������� ����  ��Ҳ���������ô�͸���    IsDeath��������
        // 
        if (!myEnemyHealth.IsDeath && !myPlayerHeath.IsPlayerDead)
            nav.SetDestination(player.position);

        //�����һ����������,nav = GetComponent<NavMeshAgent>(); ��������
        else
            nav.enabled = false;

    }
}
