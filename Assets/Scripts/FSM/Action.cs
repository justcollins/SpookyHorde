using UnityEngine;
using System;
using System.Collections.Generic;
using System.Text;

/*
Author: Justin Collins
Purpose of Script: Contains what any Action defined in any of the FSM scripts needs to have
    */

public abstract class Action {
    public abstract void Execute(FSMContext context, GameObject obj);
}
