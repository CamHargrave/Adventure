using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This UI text displays infor about hte currently interactive being looked at.
/// Tesxt should be hidden if player is not currently looking at an interactive object.
/// </summary>
public class InteractiveDisplayText : MonoBehaviour
{
    private IInteractive lookedAtInteractive;
    private Text displayText;

    private void Awake()
    {
        displayText = GetComponent<Text>();
        UpdateDisplayText();
    }

    private void UpdateDisplayText()
    {
        if (lookedAtInteractive != null)
        {
            displayText.text = lookedAtInteractive.DisplayText;
        }
        else
        {
            displayText.text = string.Empty;
        }
    }
    /// <summary>
    /// Event handler for RayCast.LookedAtInteractiveChanged
    /// </summary>
    /// <param name="newLookedAtInteractive"> Reference to the new IInteractive the player is looking at. </param>
    private void OnLookedAtInteractiveChanged(IInteractive newLookedAtInteractive)
    {
        lookedAtInteractive = newLookedAtInteractive;
        UpdateDisplayText();
    }

    #region Event subscription / unsubscription
    private void OnEnable()
    {
        RayCast.LookedAtInteractiveChanged += OnLookedAtInteractiveChanged;
    }

    private void OnDisable()
    {
        RayCast.LookedAtInteractiveChanged -= OnLookedAtInteractiveChanged;
    }
    #endregion
}
