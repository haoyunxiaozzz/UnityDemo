using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyPlayerScore : MonoBehaviour
{
    //�������   score  text   ����
    //ÿ���е�������ʱ���Ը÷�������ı��������޸ģ�Ȼ�󽫽��ͬ��������ScoreUI���

    //score�÷�
    public static int Scores = 0;

    //text�ı�
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
