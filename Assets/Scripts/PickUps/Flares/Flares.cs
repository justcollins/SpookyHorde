using UnityEngine;


/*
Author: Justin Collins
Purpose of Script: Controls the pickups and what they do when the player picks them up
    */

public class Flares : MonoBehaviour {

    public int burnTime;
    public float throwForce;

    //private Light flareLight;
    private new Rigidbody rigidbody = null;
    private Transform tr;
    private ForceMode impulse = ForceMode.Impulse;
    private float currentBurnTime;
    private bool flareOn = false;

    void Awake() {
        rigidbody = GetComponent<Rigidbody>();
    }

	void Start () {
        //flareLight = this.gameObject.GetComponentInChildren<Light>();
    }
	
	void Update () {
	    if(flareOn) {
            FlareOn();
        }
        Debug.Log(flareOn);
	}

    public void OnEnable() {
        tr = transform;
        currentBurnTime = 0;
        rigidbody.AddForce(tr.forward * throwForce, impulse);
    }

    public void OnDisable() {
        flareOn = false;
    }

    void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.layer == 8) {
            //tr = transform;
            //transform.position = tr.position;
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
            rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            flareOn = true;
        }
    }

    public void FlareOn() {
        if(currentBurnTime <= burnTime) {
            currentBurnTime += Time.deltaTime;
        } else {
            ObjectPooling.DeSpawn(this.gameObject);
        }
    }
}
