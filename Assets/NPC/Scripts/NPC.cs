using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPC : MonoBehaviour , IHit
{
    GameObject target; //Reference to the target object
    Sight sight; //determine whether the NPC can see the player
    PlayerMovement playerMovement; //chase after the player when in sight
    public float rotationRate = 180f; //Rate at which the NPC rotates towards the target
    public UnityEvent OnTagPlayer = new UnityEvent(); //Invoke an event when an NPC collides with the player

    Animator animator;

    void Awake()
    {
        sight = GetComponentInChildren<Sight>(); //Get the Sight component attached to the NPC
        playerMovement = GetComponent<PlayerMovement>(); //Get the PlayerMovement component attached to the NPC
        target = GameObject.FindWithTag("Player"); //Find the target object with the "Player" tag
        sight.target = target; //Assign the target object to the sight component

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sight.CanSeeTarget()) //If the NPC can see the target
        {
            animator.SetTrigger("Walk");
            Vector3 lookDirection = Vector3.ProjectOnPlane(target.transform.position - transform.position, Vector3.up); //Calculate the direction to look at the target
            Quaternion newRotation = Quaternion.LookRotation(lookDirection); //Create a rotation towards the target
            transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, rotationRate * Time.deltaTime); //Rotate the NPC towards the target
            playerMovement.moveDirection = lookDirection; //Set the movement direction towards the target
        }
        else
        {
            animator.SetTrigger("Idle");
            playerMovement.moveDirection = Vector3.zero; //If the NPC cannot see the target, stop moving
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == target) // If the NPC collides with the target
        {
            Debug.Log("Hit Target!"); // Log a messeage indicating the collision with the target
            animator.SetTrigger("Attack");
            OnTagPlayer.Invoke();

            if (collision.gameObject.TryGetComponent<IHit>(out var hit))
            {
                hit.Hit(gameObject);
            }
        }
    }

    public void Hit(GameObject other)
    {
        Debug.Log($"I {gameObject.name} got hit by {other.name}");
        animator.SetTrigger("Hit");
    }
}
