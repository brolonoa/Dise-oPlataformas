using UnityEngine;

public class Spikes : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other)
   {
      
      if (other.GetComponent<IPlayer>() != null)
      {
         Debug.Log(other.gameObject.name);
         IPlayer player = other.GetComponent<IPlayer>();
         player.TakeDamage();
      }
   }
}
