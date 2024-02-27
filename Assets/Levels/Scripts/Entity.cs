using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Entity : MonoBehaviour
{
    public bool active = false; // Indicates whether the entity is currently active or not
    public UnityEvent onActivate = new UnityEvent(); // Event triggered when the entity is activated
    public UnityEvent onDeactivate = new UnityEvent(); //Event triggered when the entity is deativated

    public void ToggleActive()
    {
        if (active) Deactivate(); //If the entity is currently active, deactivate it
        else Activate(); //If the entity is currently inactive, activate it
    }

    public void Activate()
    {
        active = true; //Set the entity as active
        onActivate.Invoke(); //Trigger the onActivate event
    }

    public void Deactivate()
    {
        active = false; //Set the entity as inactive
        onDeactivate.Invoke(); //Trigger the onDeactivate event
    }
}
