﻿using UnityEngine;
using System;
using System.Collections.Generic;
using System.Text;

public class FSMContext {

    public State currentState;
    public string name;

    public FSMContext(State _currentState, Action init, GameObject obj, string name) {
        currentState = _currentState;
        init.Execute(this, obj);
    }

    public void UpdateContext (GameObject updateObj) {
        currentState.UpdateState(this, updateObj);
    }

    public void dispatch (string fsmEvent, GameObject obj) {
        currentState.Dispatch(this, fsmEvent, obj);
    }
}
