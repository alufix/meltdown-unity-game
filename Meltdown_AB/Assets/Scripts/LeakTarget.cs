using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class LeakTarget : MonoBehaviour
{
    public float leakStrength = 30f;

    public PuttyGun puttyGun;
    public int RemainingLeaks; //to be set later 

    [Header("Sound")]
    public AudioSource Source;

    [Header("UIText")]
    public Text leakCountX; //the text object to update 


    public void RepairLeak(float amount) 
    {
        leakStrength -= amount; 
        if (leakStrength <= 0f)
        {
            Fixed();
        }
    }

    void Fixed ()
    {
        //display number of remaining leaks - minus one from LeakCount, then log in console 
        (puttyGun.GetComponent<PuttyGun>().LeakCount) -= 1;
        RemainingLeaks = puttyGun.GetComponent<PuttyGun>().LeakCount; 

        //set new string value as the integer variable converted to a string 
        string RemainingLeaksString = RemainingLeaks.ToString();

        //update the text object with this string 
        leakCountX.text = RemainingLeaksString; 

        Destroy(gameObject); 
    }
}
