using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menun : MonoBehaviour
{
    //UI���濪ʼ��Ϸ��ť
    public void GameStart()
    {
        SceneManager.LoadScene(1); 
    }


    //UI�����˳���Ϸ��ť
    public void ExitGame()
    {
        Application.Quit();
    }
}
