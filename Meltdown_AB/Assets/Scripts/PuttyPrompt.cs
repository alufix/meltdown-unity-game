using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuttyPrompt : MonoBehaviour
{
    public GameObject puttyGunObject; //object 
    public PuttyGun puttyGun; //script - 'type' is name of script 
    public GameObject puttyRefill; //text 
    public bool PlayerInTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        puttyRefill.SetActive(false);
    }

    //initialise variables in PuttyGun script 
    private void Awake()
    {
        //in the variable puttyGun we set, get the script 
        puttyGun = GetComponent<PuttyGun>(); 
        
    }

    void Update()
    {
        if (PlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            // increase range 
            puttyGun.range = 50f;
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
