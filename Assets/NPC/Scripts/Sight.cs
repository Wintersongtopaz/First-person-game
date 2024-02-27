using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Sight: Can a given GameObject "see" another GameObject
public class Sight : MonoBehaviour
{
    public GameObject target;
    //maximum angle formed between one object's forward dircetion and the direction to the other object
    public float angle = 60f;
    //maximum distance between both objects
    public float range = 20f;

    public bool CanSeeTarget()
    {
        if (!target) return false;
        Vector3 toTarget = target.transform.position - transform.position;
        if (toTarget.magnitude > range) return false;
        if (Vector3.Angle(transform.forward, toTarget) > angle) return false;
        if (Physics.Raycast(transform.position, toTarget, out var hit))
        {
            if (hit.collider.gameObject == target) return true;
            else return false;
        }
        return true;
    }

    
}
