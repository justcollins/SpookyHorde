using UnityEngine;
using System.Collections;

/*
Author: Justin Collins
Purpose of Script: Action that controls what happens when the players clip turns to empty
    */

public class Action_ReloadTime : Action
{
    public override void Execute(FSMContext context, GameObject obj) {
        obj.GetComponent<Shoot>().EmptyOff();
    }
}
