using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Adjust this value to set the player's movement speed
    private Rigidbody2D rb;
    private bool canMove = true; // Add a flag to control whether the player can move

    void Start()
    {
        // Get the Rigidbody2D component attached to the player GameObject
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (canMove)
        {
            // Get input values for horizontal and vertical movement
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            // Calculate movement vector
            Vector2 movement = new Vector2(horizontal, vertical);

            // Normalize the movement vector to prevent faster diagonal movement
            movement.Normalize();

            // Update the Rigidbody2D velocity based on input and speed
            rb.velocity = movement * speed;
        }
    }

    // Add a method to enable or disable player movement
    public void SetCanMove(bool move)
    {
        canMove = move;
    }
}
