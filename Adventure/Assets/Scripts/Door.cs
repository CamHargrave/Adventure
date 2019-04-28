using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : InteractiveObject
{
    private Animator anim;
    private bool isOpen = false;
    /// <summary>
    /// Using constructor to initialize displayText for door
    /// </summary>
    public Door()
    {
        displayText = nameof(Door);
    }

    protected override void Awake()
    {
        base.Awake();
        anim = GetComponent<Animator>();
    }

    public override void InteractWith()
    {
        if (isOpen = false)
        {
            base.InteractWith();
            anim.SetBool("shouldOpen", true);
            displayText = string.Empty;
            isOpen = true;
        }
        
        
    }
}
