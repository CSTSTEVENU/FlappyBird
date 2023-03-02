using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Created game object and setting values of the pipes max and min height, spawn rate

    // Prefab is a script created for the pipe objects 
    public GameObject prefab;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;

    // when game starts it spawns the green pipes repeadtly 
    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    // when game stops On Disable is called to clear the repeating green pipes
    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    // Spawn randomizes the values min/max height of the green pipes and changes the position with Quaternion.identity and transform.position
    private void Spawn()
    {
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
