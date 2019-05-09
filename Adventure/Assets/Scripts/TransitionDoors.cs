using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionDoors : InteractiveObject
{
    [SerializeField]
    private string gameSceneName;

    public TransitionDoors()
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
        SceneManager.LoadScene(gameSceneName);

    }

}
