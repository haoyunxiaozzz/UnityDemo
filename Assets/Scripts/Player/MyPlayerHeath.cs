using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MyPlayerHeath : MonoBehaviour
{
    //Player Heath
    private int PlayerStartingHeath = 100;
    public bool IsPlayerDead = false;
    private AudioSource playerAudio;
    public AudioClip PlayerDeathCilp;
    private Animator playerAnim;
    private PlayerMovement playerMovement;
    private MyPlayerShooting myPlayerShooting;
    private bool damaged = false;
    public Text PlayerHealthUI;
    public Image DamageImage;
    public Color FlashColor = new Color(1f,0f,0f,0.1f);

    private void Awake()
    {
        playerAudio = GetComponent<AudioSource>();
        playerAnim= GetComponent<Animator>(); 
        playerMovement = GetComponent<PlayerMovement>();
        myPlayerShooting = GetComponentInChildren<MyPlayerShooting>();
        
    }

    void Update()
    {
        if (damaged)
            DamageImage.color = FlashColor;
        else                             
            DamageImage.color = Color.Lerp(DamageImage.color, Color.clear,1f * Time.deltaTime);  

        damaged = false;
    }

    public void TaskDamage(int amout)
    {
        if(IsPlayerDead)
            return;

        damaged = true;
        playerAudio.Play();
        PlayerStartingHeath -= amout;
        PlayerHealthUI.text = PlayerStartingHeath.ToString();

        if (PlayerStartingHeath <= 0)
            Death();
        
    }

    void Death()
    {
        IsPlayerDead = true;  
        playerAudio.clip = PlayerDeathCilp;
        playerAudio.Play();
        playerAnim.SetTrigger("Die");
        playerMovement.enabled = false;
        myPlayerShooting.enabled = false;
        MyPlayerScore.Scores = 0;
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(2);
    }
}