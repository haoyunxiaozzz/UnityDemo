using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyPlayerScore : MonoBehaviour
{
    //对外添加   score  text   两个
    //每次有敌人死亡时，对该分数组件的变量进行修改，然后将结果同步给界面ScoreUI组件

    //score得分
    public static int Scores = 0;

    //text文本
    public Text ScoresText;




    //Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()
    {
        ScoresText.text = $"Score: {Scores}";   
    }
}
