using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggered : MonoBehaviour
{
    private AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        audioSource.Play();

    }

}
