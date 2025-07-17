using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MyEnemyHealth : MonoBehaviour
{
    //�з���ʼѪ��
    public int StartingHealth = 100;
    //�����ܻ���Ч
    private AudioSource enemyAudioSource;
    //�����ܻ���Ч
    private ParticleSystem enemyParticles;
    //�������������Ч
    public AudioClip DeathClip;

    private Animator enemyAniamtor;

    //��������ʹ�ô�����
    private CapsuleCollider enemyCapsuleCollider;

    public bool IsDeath = false;

    private bool IsSiking = false;


    //����з���λ��ͬ�ĵ÷�
    //private int pigStartingHealth;
    //private int bearStartingHealth;
    //private int hellphtStartingHealth;



    private void Awake()
    {
        //��ȡ��ǰ���壬��ʹ��GetComponent����
        enemyAudioSource = GetComponent<AudioSource>();
        enemyParticles = GetComponentInChildren<ParticleSystem>();      //�����µ������壬ʹ��GetComponentInChildren
        enemyAniamtor = GetComponent<Animator>();
        enemyCapsuleCollider  = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        //�ƶ�����
        if (IsSiking) 
        {
            transform.Translate(-transform.up *0.3f* Time.deltaTime);
        }

    }

    public void TaskDamage(int amout, Vector3 HitPoint)
    {
        //�жϵ����Ƿ����������������ֱ��return
        if (IsDeath == true)
            return;

        //��ͨ�����յ��˺�ʱ��Ҳ����StartingHealth����ʱ�������ܻ�������
        enemyAudioSource.Play();

        //�յ��˺�ʱ������������Ч�Ĳ���
        enemyParticles.transform.position = HitPoint;
        enemyParticles.Play();

        StartingHealth -= amout;
        if(StartingHealth <= 0)
       
            //�����ɫ����
         Death();
        
        //Debug.Log(StartingHealth);
    }

    void Death()
    {
        //��ʾ�з���λ�Ѿ������ˡ�
        IsDeath = true;

        //���ŵ�����������
        enemyAniamtor.SetTrigger("Death");

        //�ط���λ�����󣬲����е���������ã�Ȼ����ø����
        //����NavMeshAgent����
        GetComponent<NavMeshAgent>().enabled = false;
        //���ܵ���Χ����Ӱ����
        GetComponent<Rigidbody>().isKinematic = true;   //������ٿ���

        //���ŵ���������Ч
        enemyAudioSource.clip = DeathClip;
        enemyAudioSource.Play();

        //�з���λ�����󣬲����赲�ӵ�
        enemyCapsuleCollider.enabled = false;

        //����ҼƷ���������ľ�̬����  ���ӷ���
        MyPlayerScore.Scores += 10;
    }

    //�������Ŷ���������
    public void StartSinking()
    {
        IsSiking = true;

        //�з���λ����ʱ��
        Destroy(gameObject, 2f);
    }
}
