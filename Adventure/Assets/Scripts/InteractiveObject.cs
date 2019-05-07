using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour, IInteractive
{
    
    [SerializeField]
    protected string displayText = nameof(InteractiveObject);

    public string DisplayText => displayText;
    public AudioSource audioSource;

    protected virtual void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public virtual void InteractWith()
    {
        audioSource.Play();
        Debug.Log($"Player just interacted with {gameObject.name}.");
    }
    
}
