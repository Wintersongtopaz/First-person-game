using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IHit
{
    public int healthAmount = 3;

    public void Hit(GameObject other)
    {
        healthAmount -= 1;
        Debug.Log("I've been hit!");
    }
}
