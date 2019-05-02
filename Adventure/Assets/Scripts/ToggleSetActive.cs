using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSetActive : InteractiveObject
{
    [Tooltip("Toggles and object on and off.")]
    [SerializeField]
    private GameObject ObjectToToggle;

    private AudioSource lightSwitch;
    

    /// <summary>
    /// Tollges the activeSelf value for the objectToToggle when the player interacts with this object
    /// </summary>
    public override void InteractWith()
    {
        ObjectToToggle.SetActive(!ObjectToToggle.activeSelf);
        lightSwitch.Play();
    }
}
