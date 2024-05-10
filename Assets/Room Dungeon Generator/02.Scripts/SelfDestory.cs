using UnityEngine;

public class SelfDestroyOnCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision involves this game object
        if (collision.gameObject == gameObject)
            return;

        // Destroy this game object
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == gameObject) 
            return;

        // Destroy this game object
        Destroy(gameObject);
    }
}
