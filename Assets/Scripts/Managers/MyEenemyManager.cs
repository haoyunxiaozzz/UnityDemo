using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEenemyManager : MonoBehaviour
{
    //���ɵ�������
    public GameObject Enemy;

    //�����⣩�з���λ���ɵ�λ�úͽǶ�
    public GameObject CreatEnemyPoint;

    //��һ�����ɹ����������Ҳ���ǿ��־��Զ�����һ��
    public float firstcreatEnemyTime = 0f;

    //���ɹ����ʱ��
    public float creatEnemyTime = 3;


    


    //ϣ������Ϸ�տ�ʼ��ʱ�������һ��
    private void Start()
    {
        //Instantiate(Enemy);

        //ѭ�����÷�������
        //������    ���ʱ��    ѭ����������ʱ��
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
        //���ɵ�������,positionλ��,rotation�Ƕ�
        Instantiate(Enemy,CreatEnemyPoint.transform.position,CreatEnemyPoint.transform.rotation);
    }
}
