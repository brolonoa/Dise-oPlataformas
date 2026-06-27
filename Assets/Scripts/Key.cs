using UnityEngine;

public class Key : MonoBehaviour
{
  [SerializeField] private GameObject puerta;
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.GetComponent<IPlayer>() != null)
    {
      Destroy(puerta);
      Destroy(gameObject);
    }
  }
}
