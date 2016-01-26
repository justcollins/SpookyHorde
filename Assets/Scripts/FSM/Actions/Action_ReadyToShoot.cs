using UnityEngine;
using System.Collections;

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
