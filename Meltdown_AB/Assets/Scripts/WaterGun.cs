using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGun : MonoBehaviour
{
    public Transform SpawningPoint;
    public GameObject WaterBeam; 
    public Camera Camera;

    public float range = 10f;
    public float power = 20f;

    [Header("Timer")]
    [Range(0, 2)]
    public float DouseTime = 1f;
    private float DouseTimer = 0;

    [Header("Sound")]
    public AudioSource Source;

    public int FireCount;

    public void Start()
    {
        FireCount = 18; 
    }

    void Update()
    {
        //timer: (every second, this decreases by 1) 
        DouseTimer -= Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            // PLAY THE SOUND 
            Source.UnPause();

            // if timer is not yet 0, exit this function 
            if (DouseTimer > 0)
            {
                return;
            }

            // --------------------------- SHOOTING --------------------------
            // SHOOT AND DOUSE FIRE 
            RaycastHit hitInfo;

            if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hitInfo))
            {
                //set WaterBeam cylinder active: 
                WaterBeam.SetActive(true);

                // Get rid of the fire effect by running the FireTarget script 
                FireTarget target = hitInfo.transform.GetComponent<FireTarget>();
                if (target != null)
                {
                    target.DouseFire(power);
                }
            } 

            // Set timer: 
            DouseTimer = DouseTime;

        }
        else
        {
            // Graphics
            WaterBeam.SetActive(false);

            // Sound 
            Source.Pause(); 
        }
    }
}