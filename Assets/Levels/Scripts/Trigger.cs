using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Triggers: level entities which respond to events / interactions, and may trigger other entities.
[RequireComponent(typeof(Entity))]
public class Trigger : MonoBehaviour
{
    Entity entity;

    void Awake() => entity = GetComponent<Entity>(); //Get the Entity component attached to the same GameObject

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) entity.ToggleActive(); //If a collider with the tag "Player" enters the trigger, toggle the Entity's active state
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) entity.ToggleActive(); //If a collider with the tag "Player" exits the trigger, toggle the Entity's active state  
    }
}
