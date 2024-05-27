using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]  
public abstract class Interaction : MonoBehaviour
{
    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
   public abstract void Interact();


   private void OnTriggerEnter2D(Collider2D collision)
   {
    if(collision.CompareTag("Player"))
        collision.GetComponent<PlayerMovement>().OpenInteractable();
   }

   private void OnTriggerExit2D(Collider2D collision)
   {
     if(collision.CompareTag("Player"))
        collision.GetComponent<PlayerMovement>().CloseIntractable();
   }
}
