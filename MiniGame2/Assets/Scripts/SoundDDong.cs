using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDDong : MonoBehaviour
{
    public AudioSource myAudio;
    public bool musicStart = false;

    private void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    /*private void OnTriggerEnter(Collider collider)
    {
        if (!musicStart) // 객체가 들어올 때마다 음악이 재생되면 안 되니까!! 
        {
            if (collider.CompareTag("LEFTD"))
            {
                myAudio.Play();
                musicStart = true;
            }

        }
        
    }*/
}
