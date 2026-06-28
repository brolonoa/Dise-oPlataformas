using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private bool activated;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (activated)
            return;

        if (other.TryGetComponent<IPlayer>(out _))
        {
            CheckpointManager.Instance.SetCheckpoint(transform.position);
            activated = true;
        }
    }
}
