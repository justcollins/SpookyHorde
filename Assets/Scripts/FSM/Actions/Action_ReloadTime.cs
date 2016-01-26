using UnityEngine;
using System.Collections;

public class Action_ReloadTime : Action
{
    public override void Execute(FSMContext context, GameObject obj) {
        obj.GetComponent<Shoot>().EmptyOff();
    }
}
