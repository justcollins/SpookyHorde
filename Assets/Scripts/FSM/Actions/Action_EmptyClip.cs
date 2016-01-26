using UnityEngine;
using System.Collections;

/*
Author: Justin Collins
Purpose of Script: Action that controls what happens when the player has an empty clip and is idle
    */

public class Action_EmptyClip : Action
{
    public override void Execute(FSMContext context, GameObject obj) {
        obj.GetComponent<Shoot>().EmptyOn();
        if (Input.GetKeyDown("r")) {
            obj.GetComponent<FiniteStateMachine>().Dispatch("Reloading", obj);
        }
    }
}
