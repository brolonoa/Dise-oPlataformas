using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{ [Header("Movement")]
    [SerializeField] private float moveSpeed = 2f;

    [Header("Detection")]
    [SerializeField] private Transform rayOrigin;
    [SerializeField] private float rayDistance = 0.5f;
    [SerializeField] private LayerMask detectionLayers;

    private Rigidbody2D rb;
    private int direction = 1; // 1 = derecha, -1 = izquierda

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
        CheckFront();
    }

    private void Move()
    {
        rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);
    }

    private void CheckFront()
    {
        Vector2 rayDir = Vector2.right * direction;

        RaycastHit2D hit = Physics2D.Raycast(
            rayOrigin.position,
            rayDir,
            rayDistance,
            detectionLayers);

        if (hit.collider != null)
        {
            direction *= -1;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (rayOrigin == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(
            rayOrigin.position,
            rayOrigin.position + Vector3.right * direction * rayDistance);
    }
   
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IPlayer player = collision.collider.GetComponent<IPlayer>();

        if (player != null)
        {
            Debug.Log(collision.gameObject.name);
            player.TakeDamage();
        }
    }

}
