using UnityEngine;

public class cameracontroller : MonoBehaviour
{   //Room camera
    [SerializeField]private float speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;

    //Follows the player 
    [SerializeField] private Transform player;
    [SerializeField] private float aHeadDistance;
    [SerializeField] private float camSpeed;
    private float lookAhead;


    private void Update()
    {      
        
        //Follows the player
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead, (aHeadDistance * transform.localScale.x), Time.deltaTime * camSpeed);


        //Room Camera 
        // transform.position = Vector3.SmoothDamp(transform.position,
        //  new Vector3(currentPosX, transform.position.y, transform.position.z), ref velocity, speed);
    }

    public void newRoom(Transform _newRoom)
    {
        currentPosX = _newRoom.position.x;
    }

}


