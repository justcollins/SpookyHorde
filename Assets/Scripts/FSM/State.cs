﻿using UnityEngine;
using System;
using System.Collections.Generic;
using System.Text;

/*
Author: Justin Collins
Purpose of Script: Creates a state for the FSM
    */

public class State {

    private Action entryAction;
    private Action updateAction;
    private Action exitAction;
#pragma warning disable 414
    private string name;
#pragma warning restore 414
    private Dictionary<string, Transition> transitions = new Dictionary<string, Transition>();

    public State(Action entryAction, Action updateAction, Action exitAction, string name) {
        this.entryAction = entryAction;
        this.updateAction = updateAction;
        this.exitAction = exitAction;
        this.name = name;
    }

    public void Dispatch(FSMContext context, string eventName, GameObject obj) {
        if( transitions.ContainsKey(eventName)) {
            Transition t = (transitions[eventName] as Transition);
            context.currentState.exitAction.Execute(context, obj);
            t.execute(context, obj);
            context.currentState = t.getTarget();
            context.currentState.entryAction.Execute(context, obj);
        }
    }

    public void AddTransition(Transition t, string eventName) {
        transitions.Add(eventName, t );
    }

    public void UpdateState(FSMContext context, GameObject obj) {
        updateAction.Execute(context, obj);
    }
}
