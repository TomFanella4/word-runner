using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;

    void OnCollisionEnter(Collision collisionInfo) {
        if (collisionInfo.collider.tag == "Obstical") {
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame(); // Only 1 object can exist
        }
    }
}
