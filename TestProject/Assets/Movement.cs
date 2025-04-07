using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public PlayerInput playerController;
    private InputAction moveAction; 
    private InputAction jumpAction;
    public Vector2 direction;
     public int speed;
     public int jumpStr;
    public Rigidbody2D playerRb;
    void Start()
    {
        moveAction = playerController.actions["Move"];
        jumpAction = playerController.actions["Jump"];
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = moveAction.ReadValue<Vector2>();
        playerRb.linearVelocity = new Vector2(direction.x * speed, playerRb.linearVelocity.y);

        if (jumpAction.WasPressedThisFrame())
        {
            jump();
        }


    }

    void jump()
    {
        playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, jumpStr);
    }
}
