using UnityEngine;

public class Player : MonoBehaviour
{
    
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
    private Vector3 direction;

    public float gravity = -9.8f;

    public float strength = 5f;

    // Awake function to intialize the game
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Starting the game using the start function
    private void Start()
    {
        // Invoke reapting is a function that continously calls upon a function
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    // Game is running with onEnable and when called allows manipulation of player object
    private void OnEnable()
    {
        // Vector3 is a direction variable built in unity
        // Creating the position of the player object and positioning it on the interface
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        // Vector3.zero places the player object back to its starting position
        direction = Vector3.zero;
    }

    // Update function for USER INPUT
    private void Update()
    {
        // User input for player object to jump up by either pression space bar or left mouse button
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            direction = Vector3.up * strength;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began) {
                direction = Vector3.up * strength;
            }
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    // creates a repeating number of sprites on the user interface
    private void AnimateSprite()
    {
        spriteIndex++;

        if(spriteIndex >= sprites.Length) {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }

    // When player object collides with other objects it triggers an event handler
    private void OnTriggerEnter2D(Collider2D other)
    {
        // if player object hits obstacle then game ends
        if (other.gameObject.tag == "Obstacle") {
            FindObjectOfType<GameManager>().GameOver();
        // if player object doesn't hit obstacle then a score is kept
        } else if (other.gameObject.tag == "Scoring") {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }
}


