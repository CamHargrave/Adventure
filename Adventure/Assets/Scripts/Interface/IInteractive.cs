using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractive
{
    void InteractWith();
    string DisplayText { get; }
}
