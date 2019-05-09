using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : InteractiveObject
{
    [Tooltip("The name of the object , as it will apear in the Inventory menu UI.")]
    [SerializeField]
    private string objectName = nameof(InventoryObject);

    [Tooltip("Description of the object.")]
    [TextArea(3,8)]
    [SerializeField]
    private string description;

    [Tooltip("Icon that will display in inventory representing the inventory object.")]
    [SerializeField]
    private Sprite icon;

    private new Renderer renderer;
    private new Collider collider;

    public Sprite Icon => icon;
    public string Description => description;
    public string ObjectName => objectName;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        collider = GetComponent<Collider>();
    }

    public InventoryObject()
    {
        displayText = $"Pickup {objectName}";
    }

        /// <summary>
        /// When player interacts with an inventory object, we needt to do 2 things:
        /// 1. Add the inventory object to the Player Inventory list
        /// 2.Remove the object from the game world / scene.
        /// disable collider and renderer
        /// </summary>
    public override void InteractWith()
    {
        audioSource.Play();
        renderer.enabled = false;
        collider.enabled = false;
        PlayerInventory.InventoryObjects.Add(this);
        InventoryMenu.Instance.AddItemToMenu(this);
    }
}
