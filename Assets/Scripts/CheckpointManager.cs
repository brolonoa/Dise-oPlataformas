using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance { get; private set; }

    [SerializeField] private Transform initialSpawnPoint;

    public Vector3 CurrentSpawnPosition { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        if (initialSpawnPoint != null)
            CurrentSpawnPosition = initialSpawnPoint.position;
    }

    public void SetCheckpoint(Vector3 newSpawnPosition)
    {
        CurrentSpawnPosition = newSpawnPosition;
    }

    public void Respawn(GameObject player)
    {
        player.transform.position = CurrentSpawnPosition;
    }
}
