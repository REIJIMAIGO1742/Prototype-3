using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerContoller : MonoBehaviour
{
    private Rigidbody playerRb;
    public InputAction jumpAction;

    public float jumpForce = 10.0f;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        jumpAction.Enable();

        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpAction.triggered&&isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        { 
            gameOver = true;
            Debug.Log("GameOver!!");
        }
    }
}
