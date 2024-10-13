using UnityEngine;

public class DestroyUponCollision : MonoBehaviour
{
    // This function is called when another object enters the trigger collider attached to the plastic
    void OnTriggerEnter(Collider other)
{
    Debug.Log("Collided with: " + other.gameObject.name); // This will print out the object you collided with

    if (other.gameObject.CompareTag("Player"))
    {
        Destroy(gameObject);
        Debug.Log("Plastic collected and destroyed.");
    }
}

    
}
