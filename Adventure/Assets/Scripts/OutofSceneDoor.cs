using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutofSceneDoor : InteractiveObject
{ 

    [SerializeField]
    private string gameSceneName;

    public OutofSceneDoor()
    {
        displayText = nameof(Door);
    }

    protected override void Awake()
    {
        audioSource = GetComponent<AudioSource>();

    }

    public override void InteractWith()
    {
        audioSource.Play();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(gameSceneName);

    }
}
