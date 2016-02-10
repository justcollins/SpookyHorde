using UnityEngine;
using System.Collections;

/*
Author: Justin Collins
Purpose of Script: Action that controls what is happening when the player is currently reloading;
    */

public class Action_Reloading : Action
{
    public override void Execute(FSMContext context, GameObject obj) {
        obj.GetComponent<Shoot>().ReloadingOn();
        if(obj.GetComponent<Shoot>().ammo == 200) {
        obj.GetComponent<FiniteStateMachine>().Dispatch("Reloaded", obj);
        }
    }
}
