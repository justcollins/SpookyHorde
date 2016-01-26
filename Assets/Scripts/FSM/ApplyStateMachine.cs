using UnityEngine;
using System;
using System.Collections.Generic;
using System.Text;

/*
Author: Justin Collins
Purpose of Script: Creates an Instance of the FSM
    */


public static class ApplyStateMachine {
    public static FSMContext createFSMInstance (State currentState, Action init, GameObject obj, string name) {
        return new FSMContext (currentState, init, obj, name);
    }

}
