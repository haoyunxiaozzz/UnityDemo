using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ����ͷ��������ƶ�
/// </summary>
public class CameraFollow : MonoBehaviour
{
    private GameObject player;
    //�����
    private Vector3 offset;
    //���ƽ��
    public float Smoothing = 5f; 


    private void Awake()
    {

        
        player = GameObject.FindGameObjectWithTag("Player");

        //��ȡ���󣬼�¼һ�µ�ǰ�������͵�ǰ�ű��󶨵����Main Camera֮��ľ����
    }

    private void Start()
    {
        offset = transform.position - player.transform.position;
    }

    //��ɫ�ƶ����������
    private void FixedUpdate()
    {
        //transform.position =  offset + player.transform.position;��ɫ�ƶ�����ƶ�

        //��ɫ�ƶ�����������ƶ�������΢�ӳ�
        transform.position = Vector3.Lerp(transform.position, offset + player.transform.position, Smoothing * Time.deltaTime);




    }
}
