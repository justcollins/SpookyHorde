using UnityEngine;
using System.Collections;

public class CharacterInventory : MonoBehaviour {

    public int maxFlares = 5;
    public int startingFlares = 2;
    //public int startingAmmo = 200;

    private int currentFlares;
    //private int currentAmmo;

    public void subtractFlares(int subFlares) {
        currentFlares -= subFlares;
    }

    public void addFlares(int addFlares) {
        currentFlares += addFlares;
    }

    public int getCurrentFlares() {
        return currentFlares;
    }
    /*
    public void subtractAmmo(int subAmmo) {
        currentAmmo -= subAmmo;
    }

    public void addAmmo(int addAmmo) {
        currentAmmo += addAmmo;
    }

    public int getAmmo() {
        return currentAmmo;
    }
    */
    public void Start() {
        currentFlares = startingFlares;
        //currentAmmo = startingAmmo;
    }

    public void Update() {
    }
}
