using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerShooting : MonoBehaviour
{
    private AudioSource gunAudio;
    public float timeBetweenBullets = 0.1f;       
    float time = 0f;
    private float effctsDisplayerTime = 0.1f;
    private Light gunLight;
    private LineRenderer gunLine;
    private ParticleSystem gunParticle;
    private Ray shootRay;
    private RaycastHit shootHit;       
    private int shootMask;

    private void Awake()
    {
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
        gunLine = GetComponent<LineRenderer>();
        gunParticle = GetComponent<ParticleSystem>();
        shootMask = LayerMask.GetMask("shootable");
    }

    void Update()
    {     
        time = time + Time.deltaTime;
        if (Input.GetButton("Fire1") && time>= timeBetweenBullets)
        {           
            Shoot();
        }

        if (time >= timeBetweenBullets * effctsDisplayerTime)
        {
            
            gunLight.enabled = false;
            gunLine.enabled = false;
        }
    }


    void Shoot()
    {
        time = 0;
        gunLight.enabled = true;              
        gunLine.SetPosition(0, transform.position);           
        gunLine.enabled = true;
        gunParticle.Play();
        gunAudio.Play();
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward; 


        if (Physics.Raycast(shootRay,out shootHit,100,shootMask))
        {
            gunLine.SetPosition(1, shootHit.point); 
            MyEnemyHealth enemyHealth = shootHit.collider.GetComponent<MyEnemyHealth>();
            enemyHealth.TaskDamage(50, shootHit.point);
        }
        else
        {
            
            gunLine.SetPosition(1, transform.position + transform.forward * 100); 
        }
    }
}
