using System;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour
{
   public float timeToDestroy;
   public float timeToAppear;
   private bool IsActive;
   private BoxCollider2D boxCollider2D;
   private SpriteRenderer spriteRenderer;

   private void Start()
   {
      gameObject.active = true;
      IsActive = true;
      spriteRenderer = GetComponent<SpriteRenderer>();
      boxCollider2D = GetComponent<BoxCollider2D>();
   }

   private void OnCollisionEnter2D(Collision2D collision)
   {
      if (IsActive)
      {
         StartCoroutine(TimepoEspera());
         IsActive = false;
      }
   }

   private IEnumerator TimepoEspera()
   {
      
      yield return new WaitForSeconds(timeToDestroy);
      Plataform(false);
      yield return new WaitForSeconds(timeToAppear);
      Plataform(true);
      
      
   }

   private void Plataform(bool enable)
   {
      boxCollider2D.enabled = enable;
      spriteRenderer.enabled = enable;
      IsActive = enable;
      
   }
}
