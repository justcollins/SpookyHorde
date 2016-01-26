using UnityEngine;
using System.Collections;

public class Action_EmptyClip : Action
{
    public override void Execute(FSMContext context, GameObject obj) {
        obj.GetComponent<Shoot>().EmptyOn();
        if (Input.GetKeyDown("r")) {
            obj.GetComponent<FiniteStateMachine>().Dispatch("Reloading", obj);
        }
    }
}
