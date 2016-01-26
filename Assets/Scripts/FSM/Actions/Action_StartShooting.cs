using UnityEngine;
using System.Collections;

public class Action_StartShooting : Action
{
    public override void Execute(FSMContext context, GameObject obj) {
        obj.GetComponent<Shoot>().IdleOff();
    }
}
