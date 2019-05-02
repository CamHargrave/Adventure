using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithObject : MonoBehaviour

    /// <summary>
    /// Detects when the player presses the INteract button while looking at an IInteractive and then calls that IInteractive's InteractWith method.
    /// </summary>
{

    [SerializeField]
    private RayCast detectInteractive;

    private IInteractive lookedAtInteractive;

    void Update()
    {
        if (Input.GetButtonDown("Interact") && detectInteractive.LookingAtInteractive != null)
        {
            Debug.Log("Player pressed the Interact button");
            detectInteractive.LookingAtInteractive.InteractWith();
        }
    }

    private void OnLookedAtInteractiveChanged(IInteractive newLookedAtInteractive)
    {
        lookedAtInteractive = newLookedAtInteractive;
    }
}
