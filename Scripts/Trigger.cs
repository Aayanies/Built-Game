    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour
{
   public int SceneBulidIndex;
   

   private void OnTriggerEnter2D(Collider2D other)
   
   {
    print("Trigger Entered");
    Invoke("CompleteLevel", 2f);

    //Could use other.GetComponents<Player>() to see if the game object has a player component 
    // Tags/ can also work 

    if(other.tag == "Player")
    //moving the player to the next level 
    {
        
        print("Switching Scene To " + SceneBulidIndex);
        SceneManager.LoadScene(SceneBulidIndex, LoadSceneMode.Single);
    }
   }
}
