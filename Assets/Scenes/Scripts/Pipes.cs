using UnityEngine;

// creating Pipes parent class which effects child class MonoBehaviour Unity IDE menu
public class Pipes : MonoBehaviour
{
    // the speed effects how fast the green pipes move across the screen
    public float speed = 5f;

    // leftEdge is a variable that is intialized when the green pipes hit left edge of screen
    private float leftEdge;

    // leftEdge is a variable that is intialized when the start function is hit
    private void Start()
    {
        // left edge = follows green pipes across screen until it hits leftEdge of screen

        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x -1f;
    }

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        // left edge = when green pipes hit left edge of screen it deletes the green pipe
        if(transform.position.x < leftEdge) {
            Destroy(gameObject);
        }
    }
    
}
