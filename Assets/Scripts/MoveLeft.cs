using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    public float speed = 20.0f;
    private PlayerContoller playerContollerScript;

    private float leftBound = -15;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerContollerScript = GameObject.Find("Player").GetComponent<PlayerContoller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerContollerScript.gameOver == false)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    
    }
}
