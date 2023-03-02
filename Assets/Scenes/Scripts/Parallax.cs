using UnityEngine;

public class Parallax : MonoBehaviour
{   
    // handles repeating background image with MeshRenderer
    private MeshRenderer meshRenderer;

    // the speed at which the background animation repeats
    public float animationSpeed = 1f;

    // Awake function intializes the background
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update function which handles the speed of the background when games running
    private void Update()
    {
        // this handles the speed on the repeating background and goes at the same pace of the Frames per second of screen
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
    }
}
