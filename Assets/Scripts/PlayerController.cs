using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D playerRB;

    [SerializeField]
    private LayerMask groundLayer;

    [SerializeField]
    private Animator playerAnimator;

    [SerializeField] public float speed = 4f;
    [SerializeField] public float jumpHeight = 5f;

    private float horizontalInput;
    private bool grounded;
    [SerializeField] private float groundCastDist = 0.5f;

    void Update()
    {
        // Get horizontal input
        horizontalInput = Input.GetAxisRaw("Horizontal");

        // Check if player is grounded
        grounded = Physics2D.Raycast(transform.position, Vector2.down, groundCastDist, groundLayer);

        // Jump
        if (Input.GetButtonDown("Jump") && grounded)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpHeight);
        }
    }

    void FixedUpdate()
    {
        playerRB.velocity = new Vector2(horizontalInput * speed, playerRB.velocity.y);
    }
}
