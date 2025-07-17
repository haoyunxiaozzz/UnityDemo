using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    //再次进入游戏
    public void GameAgain()
    {
        SceneManager.LoadScene(1);
    }

    //UI界面退出游戏按钮
    public void ExitGame()
    {
        Application.Quit();
    }
}
