using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Detects interactive elements the player is looking at.
/// </summary>

public class RayCast : MonoBehaviour
{
    [Tooltip("Starting point of raycast used to detect interactives.")]

    [SerializeField]
    private Transform rayCastOrigin;
    [Tooltip("How far raycast will travel to search for interactive objects.")]
    [SerializeField]
    private float maxDistance;

    /// <summary>
    /// Event raised when the player looks at a different IInteractive.
    /// </summary>
    public static event Action<IInteractive> LookedAtInteractiveChanged;

    public IInteractive LookingatInteractive
    {
        get { return lookingAtInteractive; }
        private set {
            bool isInteractiveChanged = value != lookingAtInteractive;
            if (isInteractiveChanged)
            {
                lookingAtInteractive = value;
                LookedAtInteractiveChanged?.Invoke(lookingAtInteractive);
            }
        }
    }

    private IInteractive lookingAtInteractive;

    private void FixedUpdate()
    {
       LookingatInteractive = GetLookedAtInteractive();
    }

    /// <summary>
    /// Raycasts forward from camera to look at IIneractives
    /// </summary>
    /// <returns> the first IInteractive detected, or null if none are found.</returns>

    private IInteractive GetLookedAtInteractive()
    {
        Debug.DrawRay(rayCastOrigin.position, rayCastOrigin.forward * maxDistance, Color.red);
        RaycastHit hitInfo;
        bool objectwasDetected = Physics.Raycast(rayCastOrigin.position, rayCastOrigin.forward, out hitInfo , maxDistance);

        IInteractive interactive = null;

        LookingatInteractive = interactive;

        if (objectwasDetected)
        {
            //Debug.Log($"Player is looking at {hitInfo.collider.gameObject.name} ");
            interactive = hitInfo.collider.gameObject.GetComponent<IInteractive>();
        }

        return interactive;
    }

}
