using UnityEngine;
using System.Collections;
using UnityEngine;
public class JumpPad : MonoBehaviour
{
    [SerializeField] private float bounceSpeed = 20f;
    [SerializeField] private float bounceTime = 0.05f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.rigidbody;

        if (rb != null)
        {
            StartCoroutine(Bounce(rb));
        }
    }

    private IEnumerator Bounce(Rigidbody2D rb)
    {
        float timer = 0;

        while (timer < bounceTime)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, bounceSpeed);

            timer += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
    }
}
