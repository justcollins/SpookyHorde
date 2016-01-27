using UnityEngine;
using System.Collections;

public class FlaresThrow : MonoBehaviour {

    public GameObject flare;
    public CharacterInventory inventory;
    public float distance = 10.0f;

    private new Rigidbody rigidbody = null;
    private float distanceStorage;
    private Transform tr;
    private ForceMode impulse = ForceMode.Impulse;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody>();
        distanceStorage = distance;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey("f")) {
            Debug.Log("i threw things");
        }
	    
	}


}
