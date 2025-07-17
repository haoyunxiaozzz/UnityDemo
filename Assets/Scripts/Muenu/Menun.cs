using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menun : MonoBehaviour
{
    //UI界面开始游戏按钮
    public void GameStart()
    {
        SceneManager.LoadScene(1); 
    }


    //UI界面退出游戏按钮
    public void ExitGame()
    {
        Application.Quit();
    }
}
