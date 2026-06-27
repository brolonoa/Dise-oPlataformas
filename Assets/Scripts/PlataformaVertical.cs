using UnityEngine;

public class PlataformaVertical : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float waitTime = 0.5f;

    private int currentPoint;
    private float waitTimer;

    private void Update()
    {
        if (patrolPoints.Length == 0) return;

        Transform target = patrolPoints[currentPoint];

        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.01f)
        {
            waitTimer += Time.deltaTime;

            if (waitTimer >= waitTime)
            {
                waitTimer = 0;
                currentPoint++;

                if (currentPoint >= patrolPoints.Length)
                    currentPoint = 0;
            }
        }
    }



}
