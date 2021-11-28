using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelPrompt : MonoBehaviour
{
    public GameObject wheelText;
    public GameObject Door; 
    public bool PlayerInTrigger = false;

    [Header("Sound")]
    public AudioClip MetalHatchClip; 
    public AudioSource Source;

    void Start()
    {
        wheelText.SetActive(false); 
    }

    void Update()
    {
        if (PlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            Door.gameObject.SetActive(false);
            Source.PlayOneShot(MetalHatchClip, 1f); 
        }
    }

    void OnTriggerEnter(Collider player)
    {
        PlayerInTrigger = true;

        if (player.gameObject.tag == "Player")
        {
            wheelText.SetActive(true);
            StartCoroutine("Wait3Sec"); 
        }
    }

    IEnumerator Wait3Sec()
    {
        yield return new WaitForSeconds(3);
        wheelText.SetActive(false); 
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerInTrigger = false; 
    }

}
