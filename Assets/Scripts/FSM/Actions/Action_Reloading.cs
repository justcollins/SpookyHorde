using UnityEngine;
using System.Collections;

public class Action_Reloading : Action
{
    public override void Execute(FSMContext context, GameObject obj) {
        obj.GetComponent<Shoot>().ReloadingOn();
        if(obj.GetComponent<Shoot>().ammo == 200) {
        obj.GetComponent<FiniteStateMachine>().Dispatch("Reloaded", obj);
        }
    }
}
