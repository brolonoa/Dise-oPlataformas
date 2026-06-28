using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour, IPlayer
{
    public void TakeDamage()
    {
        Death();
    }

    private void Death()
    {
        CheckpointManager.Instance.Respawn(gameObject);
    }
}
