using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithObject : MonoBehaviour

    /// <summary>
    /// Detects when the player presses the INteract button while looking at an IInteractive and then calls that IInteractive's InteractWith method.
    /// </summary>
{   // Update is called once per frame

    [SerializeField]
    private RayCast detectInteractive;

    void Update()
    {
        if (Input.GetButtonDown("Interact") && detectInteractive.LookingatInteractive != null)
        {
            Debug.Log("Player pressed the Interact button");
            detectInteractive.LookingatInteractive.InteractWith();
        }
    }
}
