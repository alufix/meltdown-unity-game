using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluidTrigger : MonoBehaviour
{
    public bool PlayerInTrigger = false;
    public bool PlayerLeakDamage = false;

    public PlayerHealth playerHealth; //access the script 'PlayerHealth'

    void OnTriggerEnter(Collider player)
    {
        if (PlayerInTrigger == false)
        {
            if (PlayerLeakDamage == false)
            { 
                if (player.gameObject.tag == "Player")
                {
                    PlayerInTrigger = true;
                    PlayerLeakDamage = true;

                    //call PlayerHealth's function InFluid() 
                    FindObjectOfType<PlayerHealth>().InFluid();
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        PlayerInTrigger = false;
        PlayerLeakDamage = false; 
    }

}
