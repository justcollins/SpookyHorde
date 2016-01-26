using UnityEngine;
using System;
using System.Collections.Generic;
using System.Text;

public abstract class Action {
    public abstract void Execute(FSMContext context, GameObject obj);
}
