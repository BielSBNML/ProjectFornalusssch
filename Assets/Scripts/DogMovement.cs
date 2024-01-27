using UnityEngine;

public class DogMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float detectionDistance = 2.0f;
    private Vector2 direction = Vector2.right;

    void Update()
    {
        // Check for obstacles
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, detectionDistance);

        if (hit.collider != null && hit.collider.CompareTag("Obstacle"))
        {
            Debug.Log("Dodge");
            AvoidObstacle(hit);
        }
        
    }

void AvoidObstacle(RaycastHit2D hit)
{
    // Calculate the vector pointing from the dog to the obstacle
    Vector2 obstacleDirection = hit.point - (Vector2)transform.position;

    // Calculate a new direction to move in. Here, we simply take the perpendicular vector
    // to the obstacleDirection which will steer the dog either left or right of the obstacle
    direction = new Vector2(-obstacleDirection.y, obstacleDirection.x).normalized;

    // Optionally, you can add some randomness to the avoidance to make it less predictable
    if (Random.value > 0.5f)
    {
        direction = -direction;
    }

    transform.Translate(direction * speed * Time.deltaTime);
}

    void OnDrawGizmos()
    {
        // Draw the raycast in the editor for debugging
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)(direction * detectionDistance));
    }
}
