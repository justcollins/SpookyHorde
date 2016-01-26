using UnityEngine;
using System.Collections;

/*
Author: Justin Collins
Purpose of Script: The action that is run when the player starts shooting;
    */

public class Action_StartShooting : Action
{
    public override void Execute(FSMContext context, GameObject obj) {
        obj.GetComponent<Shoot>().IdleOff();
    }
}
