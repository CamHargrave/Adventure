using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenuItemtoggle : MonoBehaviour
{
    [SerializeField]
    private Image iconImage;
    private InventoryObject associatedInventoryObject;

    public static event Action<InventoryObject> InventoryMenuItemSelected;

    public InventoryObject AssociatedInventoryObject
    {
        get
        {
            return associatedInventoryObject;
        }

        set
        {
            associatedInventoryObject = value;
            iconImage.sprite = associatedInventoryObject.Icon;
        }
    }
    /// <summary>
    /// This will be plugged into the on value changed property in the editor
    /// and will be called when ever toggle is clicked.
    /// </summary>
    public void InventoryMenuItemWasToggled(bool isOn)
    {
        //Only do when toggle is selected.
        if (isOn)
        {
            InventoryMenuItemSelected?.Invoke(AssociatedInventoryObject);
        }
    }

    private void Awake()
    {
        Toggle toggle = GetComponent<Toggle>();
        ToggleGroup toggleGroup = GetComponentInParent<ToggleGroup>();
        toggle.group = toggleGroup;
    }
}
