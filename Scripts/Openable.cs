using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
public class Openable : Interaction
{
      public Sprite open;
      public Sprite close;
    private SpriteRenderer sr;
    private bool isOpen;

    public override void Interact()
    {
       if(isOpen)
        sr.sprite = close;
        else
            sr.sprite = open;

            isOpen = !isOpen;
    }

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = close; 
    }

}
