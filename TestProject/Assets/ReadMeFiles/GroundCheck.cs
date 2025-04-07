using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded;

    void OnTriggerEnter2D(Collider2D other)
    // OnTriggerEnter2D means that if the collider that is on the gameobject is triggered, the code is triggered.
    {
        if (other.CompareTag("Ground"))
        // Okay so. "other" is the thing that is inside of the trigger. this could be anything, including the player. which we 
        // obviously dont want. so, we make sure that ONLY ground can trigger it by comparing the "tag" (explained later) of the
        // object inside the trigger with a string. the string in this case is "Ground"
        // If it is ground thats inside of the trigger, we set isGrounded to true, and vise versa.

        // Now what's a "tag"? well all gameobjects in unity have a tag. basically this is a nickname for the gameobject that makes it
        // unique. this can be used in many ways, this being one of them. we can set our "Floor" gameobject to have the tag "Ground"
        // if we go to Floor -> and at the top of the right window (the inspector window), we see tag and a dropdown. right now it 
        // is set to ground. you can change it if you want, but obviously this will make jumping impossible.
        {
            isGrounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    // dont need to explain what OnTriggerExit2D does...
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
