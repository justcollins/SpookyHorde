using UnityEngine;
using System.Collections;

/*
Author: Justin Collins
Purpose of Script: Action that controls what happens when the player gets a full clip after reloading
    */

public class Action_FullClip : Action
{
    public override void Execute(FSMContext context, GameObject obj) {
        obj.GetComponent<Shoot>().ReloadingOff();
    }
}
