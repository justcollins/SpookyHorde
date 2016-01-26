using UnityEngine;
using System.Collections;

public class Action_Shooting : Action
{
    public override void Execute(FSMContext context, GameObject obj) {
        obj.GetComponent<Shoot>().ShootingOn();
        if(Input.GetMouseButtonUp(0)) {
        obj.GetComponent<FiniteStateMachine>().Dispatch("Trigger Released", obj);
        }
        if(obj.GetComponent<Shoot>().ammo == 0) {
        obj.GetComponent<FiniteStateMachine>().Dispatch("Empty Clip", obj);
        }
    }
}
