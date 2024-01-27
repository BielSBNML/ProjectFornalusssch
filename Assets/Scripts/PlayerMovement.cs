using UnityEngine;

public class Mover : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float lerpTime = 1.0f;
    private Rigidbody2D rb;
    private Vector2 targetVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetVelocity = Vector2.zero;
    }

    void FixedUpdate()
    {
        Vector2 movement = Vector2.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            movement += Vector2.up;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            movement += Vector2.down;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movement += Vector2.left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            movement += Vector2.right;
        }

        targetVelocity = movement * moveSpeed;
        rb.velocity = Vector2.Lerp(rb.velocity, targetVelocity, lerpTime * Time.fixedDeltaTime);
    }
}
