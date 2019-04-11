using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    [Tooltip("Starting point f raycast used to detect interatives.")]

    [SerializeField]
    private Transform rayCastOrigin;
    [Tooltip("How far raycast will travel to search for interactive objects.")]
    [SerializeField]
    private float maxDistance;

    public IInteractive LookingatInteractive
    {
        get { return lookingAtInteractive; }
        private set { lookingAtInteractive = value; }
    }

    private IInteractive lookingAtInteractive;

    private void FixedUpdate()
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

        if (interactive != null)
        {
            LookingatInteractive = interactive;
        }
    }

}
