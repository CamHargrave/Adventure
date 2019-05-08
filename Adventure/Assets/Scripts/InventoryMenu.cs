using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class InventoryMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryMenuItemTogglePrefab;
    private static InventoryMenu instance;
    private RigidbodyFirstPersonController rigidbodyFirstPersonController;

    [Tooltip("Content fo the scrollview for the list of inventory items.")]
    [SerializeField]
    private Transform inventoryListContentArea;

    private CanvasGroup canvasGroup;
    private AudioSource audioSource;
    private bool IsVisible => canvasGroup.alpha > 0;

    [Tooltip("Place in the UI for displaying the name of the selected inventory item.")]
    [SerializeField]
    private Text itemLabelText;

    [Tooltip("Place in the UI for displaying info about the selected inventory item.")]
    [SerializeField]
    private Text descriptionAreaText;


    public void ExitMenuButtonClicked()
    {
        HideMenu();
    }

    public static InventoryMenu Instance
    {
        get
        {
            return instance;
        }
        private set { instance = value; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            throw new System.Exception("There is already an instance of Inventory Menu and there can oly be one.");

        canvasGroup = GetComponent<CanvasGroup>();
        rigidbodyFirstPersonController = FindObjectOfType<RigidbodyFirstPersonController>();
        audioSource = GetComponent<AudioSource>();
        
    }

    private void Start()
    {
        HideMenu();
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            if (IsVisible)
            {
                HideMenu();
            }
            if (!IsVisible)
            {
                ShowMenu();
            }
        }
    }

    private void ShowMenu()
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        rigidbodyFirstPersonController.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        audioSource.Play();
    }

    private void HideMenu()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rigidbodyFirstPersonController.enabled = true;

    }

    /// <summary>
    /// Instatiates a new InventoryMenuItemToggle prefab and adds it to the menu.
    /// </summary>
    /// <param name="inventoryObjectToAdd"></param>
    public void AddItemToMenu(InventoryObject inventoryObjectToAdd)
    {
        GameObject clone = Instantiate(inventoryMenuItemTogglePrefab, inventoryListContentArea);
        InventoryMenuItemtoggle toggle = clone.GetComponent<InventoryMenuItemtoggle>();
        toggle.AssociatedInventoryObject = inventoryObjectToAdd;
    }

    /// <summary>
    /// This is the event handler for the InventoryMenuItemSelected.
    /// </summary>
    /// <param name="inventoryObjectThatWasSelected"></param>
    private void OnInventoryMenuItemSelected(InventoryObject inventoryObjectThatWasSelected)
    {
        itemLabelText.text = inventoryObjectThatWasSelected.ObjectName;
        descriptionAreaText.text = inventoryObjectThatWasSelected.Description;
    }

    private void OnEnable()
    {
        InventoryMenuItemtoggle.InventoryMenuItemSelected += OnInventoryMenuItemSelected;
    }

    private void OnDisable()
    {
        InventoryMenuItemtoggle.InventoryMenuItemSelected -= OnInventoryMenuItemSelected;
    }
}
