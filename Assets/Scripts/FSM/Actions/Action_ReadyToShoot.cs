using UnityEngine;
using System.Collections;

/*
Author: Justin Collins
Purpose of Script: Action that controls what happens when the player is not shooting and has a full clip
    */

public class Action_ReadyToShoot : Action
{
    public override void Execute(FSMContext context, GameObject obj) {
        obj.GetComponent<Shoot>().IdleOn();
        if (Input.GetMouseButtonDown(0))
        {
        obj.GetComponent<FiniteStateMachine>().Dispatch("Trigger Pulled", obj);
        }
    }
}
