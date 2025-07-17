using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MyEnemyHealth : MonoBehaviour
{
    //敌方初始血量
    public int StartingHealth = 100;
    //敌人受击音效
    private AudioSource enemyAudioSource;
    //敌人受击特效
    private ParticleSystem enemyParticles;
    //保存敌人死亡音效
    public AudioClip DeathClip;

    private Animator enemyAniamtor;

    //敌人死亡使用触发器
    private CapsuleCollider enemyCapsuleCollider;

    public bool IsDeath = false;

    private bool IsSiking = false;


    //计算敌方单位不同的得分
    //private int pigStartingHealth;
    //private int bearStartingHealth;
    //private int hellphtStartingHealth;



    private void Awake()
    {
        //获取当前物体，就使用GetComponent即可
        enemyAudioSource = GetComponent<AudioSource>();
        enemyParticles = GetComponentInChildren<ParticleSystem>();      //物体下的子物体，使用GetComponentInChildren
        enemyAniamtor = GetComponent<Animator>();
        enemyCapsuleCollider  = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        //移动物体
        if (IsSiking) 
        {
            transform.Translate(-transform.up *0.3f* Time.deltaTime);
        }

    }

    public void TaskDamage(int amout, Vector3 HitPoint)
    {
        //判断敌人是否死亡，如果死亡，直接return
        if (IsDeath == true)
            return;

        //普通敌人收到伤害时，也就是StartingHealth减少时，发出受击的声音
        enemyAudioSource.Play();

        //收到伤害时，进行粒子特效的播放
        enemyParticles.transform.position = HitPoint;
        enemyParticles.Play();

        StartingHealth -= amout;
        if(StartingHealth <= 0)
       
            //定义角色死亡
         Death();
        
        //Debug.Log(StartingHealth);
    }

    void Death()
    {
        //表示敌方单位已经死亡了。
        IsDeath = true;

        //播放敌人死亡动画
        enemyAniamtor.SetTrigger("Death");

        //地方单位死亡后，不进行导航点的设置，然后禁用该组件
        //禁用NavMeshAgent导航
        GetComponent<NavMeshAgent>().enabled = false;
        //不受到周围物理影响了
        GetComponent<Rigidbody>().isKinematic = true;   //变相减少开销

        //播放敌人死亡音效
        enemyAudioSource.clip = DeathClip;
        enemyAudioSource.Play();

        //敌方单位死亡后，不可阻挡子弹
        enemyCapsuleCollider.enabled = false;

        //让玩家计分类型下面的静态变量  增加分数
        MyPlayerScore.Scores += 10;
    }

    //死亡播放动画到空中
    public void StartSinking()
    {
        IsSiking = true;

        //敌方单位销毁时间
        Destroy(gameObject, 2f);
    }
}
