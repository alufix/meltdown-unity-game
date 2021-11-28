using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuttyGun : MonoBehaviour
{
    public float range = 10f;
    public float power = 10f;

    public Camera Camera;
    public GameObject PuttyEffect;

    [Header("Sound")]
    public AudioClip PuttyClip;
    public AudioSource Source;

    public int LeakCount;


    public void Start()
    {
        //set it at 30 at start of game 
        LeakCount = 30;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot(); 
        }
    }

    void Shoot()
    {
        RaycastHit hitInfo;

        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hitInfo, range)) 
        {
            //if the point of the raycast is tagged obstacle, fire, or any of the player components... 
            if (hitInfo.transform.CompareTag("Obstacle") || hitInfo.transform.CompareTag("Fire") || 
                hitInfo.transform.CompareTag("MainCamera") || hitInfo.transform.CompareTag("Player") || 
                hitInfo.transform.CompareTag("CinemachineTarget") || hitInfo.transform.CompareTag("FluidFloor")) 
            {
                Source.PlayOneShot(PuttyClip, 1f); // play the sound but don't produce putty 
                return; //then exit the parent function 
            }
            else {
                Instantiate(PuttyEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            }


            // Get rid of the leak effect by running the LeakTarget script 
            LeakTarget target = hitInfo.transform.GetComponent<LeakTarget>(); 
            if (target != null)
            {
                target.RepairLeak(power); 
            }

            // play the sound: 
            Source.PlayOneShot(PuttyClip, 1f);
        }
    }
}
