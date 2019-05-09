using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSetActive : InteractiveObject
{
    [Tooltip("Toggles and object on and off.")]
    [SerializeField]
    private GameObject ObjectToToggle;


    /// <summary>
    /// Tollges the activeSelf value for the objectToToggle when the player interacts with this object
    /// </summary>
    protected override void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        
    }
    public override void InteractWith()
    {
        ObjectToToggle.SetActive(!ObjectToToggle.activeSelf);
        audioSource.Play();
    }
}
