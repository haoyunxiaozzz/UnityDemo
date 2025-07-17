using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEenemyManager : MonoBehaviour
{
    //生成敌人物体
    public GameObject Enemy;

    //（对外）敌方单位生成的位置和角度
    public GameObject CreatEnemyPoint;

    //第一次生成怪物的数量，也就是开局就自动生成一个
    public float firstcreatEnemyTime = 0f;

    //生成怪物的时间
    public float creatEnemyTime = 3;


    


    //希望在游戏刚开始的时候就生成一个
    private void Start()
    {
        //Instantiate(Enemy);

        //循环调用方法函数
        //函数名    间隔时间    循环调用他的时间
        InvokeRepeating("Spawn", firstcreatEnemyTime, creatEnemyTime);

    }

    // Update is called once per frame
    //void Update()
    //{
    //    creatEnemyTime += Time.deltaTime;

    //    if(creatEnemyTime>3f)
    //    Spawn();
    //}

    private void Spawn()
    {
        //creatEnemyTime = 0;
        //生成敌人物体,position位置,rotation角度
        Instantiate(Enemy,CreatEnemyPoint.transform.position,CreatEnemyPoint.transform.rotation);
    }
}
