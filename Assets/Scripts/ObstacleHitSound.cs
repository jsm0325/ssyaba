using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHitSound : MonoBehaviour
{
    private AudioManager audioManager;
    public string soundName;
    void Start()
    {
        if (audioManager == null)
        {
            audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            audioManager.PlaySFX(soundName);
        }
    }
}
