using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerContoller : MonoBehaviour
{
    private Rigidbody playerRb;
    public InputAction jumpAction;
    private Animator playerAnim;

    public float jumpForce = 10.0f;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;

    public ParticleSystem explotionPaticle;
    public ParticleSystem dirtPaticle;

    private AudioSource playAudio;
    public AudioClip jumpSound;
    public AudioClip clashSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playAudio = GetComponent<AudioSource>();
        jumpAction.Enable();

        Physics.gravity *= gravityModifier;

    }

    // Update is called once per frame
    void Update()
    {
        if (jumpAction.triggered&&isOnGround&&!gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            dirtPaticle.Stop();

            playAudio.PlayOneShot(jumpSound,1.0f);

            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtPaticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        { 
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explotionPaticle.Play();
            dirtPaticle.Stop();

            playAudio.PlayOneShot(clashSound,1.0f);

            Debug.Log("GameOver!!");
        }
    }
}
