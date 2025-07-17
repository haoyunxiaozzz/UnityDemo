using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 摄像头跟随玩家移动
/// </summary>
public class CameraFollow : MonoBehaviour
{
    private GameObject player;
    //距离差
    private Vector3 offset;
    //相机平滑
    public float Smoothing = 5f; 


    private void Awake()
    {

        
        player = GameObject.FindGameObjectWithTag("Player");

        //获取到后，记录一下当前这个物体和当前脚本绑定的这个Main Camera之间的距离差
    }

    private void Start()
    {
        offset = transform.position - player.transform.position;
    }

    //角色移动，相机跟随
    private void FixedUpdate()
    {
        //transform.position =  offset + player.transform.position;角色移动相机移动

        //角色移动，相机计算移动，有略微延迟
        transform.position = Vector3.Lerp(transform.position, offset + player.transform.position, Smoothing * Time.deltaTime);




    }
}
