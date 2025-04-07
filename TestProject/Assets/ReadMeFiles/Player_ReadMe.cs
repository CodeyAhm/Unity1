using UnityEngine;
using UnityEngine.InputSystem;

public class Player_ReadMe : MonoBehaviour
{
    // Before anything, i made gravity to 3 in rigidBody2D to make the jump feel better.
    public float speed;
    public float jumpStr;
    private bool isFacingRight = true; 
    // I explain this more below in the function Flip() but basically this determines where we are looking. since the player
    // sprite is facing right by default, we set this to true.

    private Vector2 direction; // Made this private since we wont need to edit it.
    public Rigidbody2D playerRb;
    public PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction jumpAction;

    public GroundCheck groundCheck;
    // Whats this? well we need to get the isGrounded bool from the script "GroundCheck". we do this by defining the script first,
    // then getting the bool (or really whatever you need from the script) here. ill show you how if you look in void Update()

    void Awake() 
    // You can see that i replaces void Start() with Awake(). it does the same thing but is a bit faster and can prevent some glitches
    {               
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
    }

    void Update()
    {
        direction = moveAction.ReadValue<Vector2>();
        // Im going to do everything in their independant functions cuz its more clean that way.

        Move(); 

        if (jumpAction.WasPressedThisFrame() && groundCheck.isGrounded)
        // okay so we need to press jump AND (&&) isgrounded to be true. you can do "groundCheck.isGrounded = true" but this way is 
        // more consise. 
        {
            Jump();
        }
    }

    void Move()
    {
        playerRb.linearVelocity = new Vector2(direction.x * speed, playerRb.linearVelocity.y);
        
        // whats down below is probably new to you. but basically, we flip the way the player is looking to make the movement
        // look better. so if we ARE facing right and we press A (direction.x < 0), we flip our character by changing our Z
        // Rotation. and if we are NOT facing right (!isFacingRight) and we press D (direction.x > 0), we also flip. 
        if((isFacingRight && direction.x < 0) || (!isFacingRight && direction.x > 0))
        {
            Flip();
        }
    }

    void Flip()
    {
        transform.Rotate(0, 180, 0);
        // The "transform" here is our player's transform component. this is the one that allows the gameobject to have a position,
        // rotation and scale. you can achive a similar effect by setting the Z scale to -1, but that poses some issues.
        // You can also change the rotation with transform.rotation = , but thats a bit more complicated since unity
        // has a different system for angles.

        isFacingRight = !isFacingRight;
        // when we flip, we change the way we look. which is why im doing this.
    }

    void Jump()
    {
        // playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, jumpStr);
        // Above is one way to handle jumping, but theres a better way thats usually good for jumping/dashing (any sudden movement):

        playerRb.AddForce(new Vector2(0, jumpStr), ForceMode2D.Impulse);
        // Basically, instead of SETTING the force to a variable like before, we are ADDING more force.
        // So we add 0 force to the X axis, but we add some force to the Y axis.
        // Also, ForceMode2D is just describing the nature of the force. there are 2 options: Impulse and Force.
        // Impulse is good for sudden movements obviously and force is good for constant movement.
    }
}
