using UnityEngine;
using System.Collections;
using System.Text;

public class FiniteStateMachine : MonoBehaviour {

    private FSMContext stateMachine;
    private State idle;
    private State firing;
    private State outOfAmmo;
    private State reload;
    private State jam;

    public new string name = "gun";

    void Start () {
        idle = new State(new Action_NoAction(), new Action_ReadyToShoot(), new Action_StartShooting(), "Idle");
        firing = new State(new Action_NoAction(), new Action_Shooting(), new Action_StopShooting(), "Firing");
        outOfAmmo = new State(new Action_NoAction(), new Action_EmptyClip(), new Action_ReloadTime(), "Out Of Ammo");
        reload = new State(new Action_NoAction(), new Action_Reloading(), new Action_FullClip(), "Reload");

        idle.AddTransition(new Transition(firing, new Action_NoAction()), "Trigger Pulled");
        firing.AddTransition(new Transition(idle, new Action_NoAction()), "Trigger Released");
        firing.AddTransition(new Transition(outOfAmmo, new Action_NoAction()), "Empty Clip");
        outOfAmmo.AddTransition(new Transition(reload, new Action_NoAction()), "Reloading");
        reload.AddTransition(new Transition(idle, new Action_NoAction()), "Reloaded");

        stateMachine = ApplyStateMachine.createFSMInstance(idle, new Action_NoAction(), this.gameObject, name);
	}
	
	void Update () {
        stateMachine.UpdateContext(this.gameObject);
	}

    public void Dispatch (string finiteStateMachineEvent, GameObject obj) {
        stateMachine.dispatch(finiteStateMachineEvent, obj);
    }
}
