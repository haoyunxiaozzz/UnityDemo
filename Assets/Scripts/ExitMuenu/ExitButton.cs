using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    //�ٴν�����Ϸ
    public void GameAgain()
    {
        SceneManager.LoadScene(1);
    }

    //UI�����˳���Ϸ��ť
    public void ExitGame()
    {
        Application.Quit();
    }
}
