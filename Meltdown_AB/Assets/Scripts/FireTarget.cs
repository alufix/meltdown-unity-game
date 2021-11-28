using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class FireTarget : MonoBehaviour
{
    public float fireStrength = 30f;

    public WaterGun waterGun;
    public int RemainingFires; //to be set later 

    [Header("Sound")] 
    public AudioSource Source;

    [Header("UIText")]
    public Text fireCountX; 


    public void DouseFire(float amount) 
    {
        fireStrength -= amount;
        if (fireStrength <= 0f)
        {
            Doused();
        }
    }

    void Doused()
    {
        //display number of remaining fires - minus one from FireCount, then log in console 
        (waterGun.GetComponent<WaterGun>().FireCount) -= 1;
        RemainingFires = waterGun.GetComponent<WaterGun>().FireCount;

        //Debug.Log(RemainingFires + " / 18");

        //set new string value as the integer variable converted to a string 
        string RemainingFiresString = RemainingFires.ToString();

        //update the text object with this string 
        fireCountX.text = RemainingFiresString; 

        Destroy(gameObject); 
    }
}
