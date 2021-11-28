using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPrompt : MonoBehaviour
{
    public GameObject waterRefill; //text 
    public WaterGun waterGun; //script - 'type' is name of script 
    public bool PlayerInTrigger = false; 

    // Start is called before the first frame update
    void Start()
    {
        waterRefill.SetActive(false); 
    }

    //initialise variables in WaterGun script 
    private void Awake()
    {
        //in the variable waterGun we set, get the script 
        waterGun = GetComponent<WaterGun>(); 
    }

    void Update() 
    {
        if (PlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            // increase range 
            waterGun.range = 50f; 
        }
    }

        void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInTrigger = true; 
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInTrigger = false; 
        }
    }
}
