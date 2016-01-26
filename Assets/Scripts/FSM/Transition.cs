using UnityEngine;
using System;
using System.Collections.Generic;
using System.Text;

public class Transition {

    private State target;
    private Action action;

    public State getTarget() {
        return target;
    }

    public void setTarget(State _target) {
        this.target = _target;
    }

    public Transition(State target, Action action) {
        this.target = target;
        this.action = action;
    }

    public void execute(FSMContext context, GameObject obj) {
        action.Execute(context, obj);
    }
}
