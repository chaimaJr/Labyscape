using UnityEngine;

public class srcEnemy : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed;
    public Transform leftPoint;
    public Transform rightPoint;
    public float waypointTolerance = 0.1f;

    [Header("References")]
    [SerializeField] private Animator animator;

    private Transform targetPoint;
    private float direction = 1f;

    void Start()
    {
        // Get animator if not assigned
        if (animator == null)
            animator = GetComponent<Animator>();

        // Start by moving right
        targetPoint = rightPoint;
        UpdateAnimator();
    }

    void Update()
    {
        // Move only on X-axis towards target point
        float targetX = targetPoint.position.x;
        float newX = Mathf.MoveTowards(transform.position.x, targetX, moveSpeed * Time.deltaTime);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

        // Check if we reached the target (only check X distance)
        if (Mathf.Abs(transform.position.x - targetX) < waypointTolerance)
        {
            // Switch target
            targetPoint = (targetPoint == rightPoint) ? leftPoint : rightPoint;
            direction = (targetPoint == rightPoint) ? 1f : -1f;
            UpdateAnimator();
        }
    }

    void UpdateAnimator()
    {
        animator.SetFloat("MoveX", direction);
    }

    // Visualize waypoints in editor
    void OnDrawGizmosSelected()
    {
        if (leftPoint != null && rightPoint != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(leftPoint.position, 0.3f);
            Gizmos.DrawWireSphere(rightPoint.position, 0.3f);
            Gizmos.DrawLine(leftPoint.position, rightPoint.position);
        }
    }
}