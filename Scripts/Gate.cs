using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : Interaction

{

    public GameObject Target;

    public override void Interact()
    {
        SceneController.TransitionPlayer(Target.transform.position);
        
    }
}
