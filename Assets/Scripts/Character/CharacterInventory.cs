using UnityEngine;
using System.Collections;

/*
Author: Justin Collins
Purpose of Script: Manages the amount of Flares that the player is currently holding and can hold
To Do: Make inventory also manage amount of ammo the player can hold
    */

public class CharacterInventory : MonoBehaviour {

    public int maxFlares = 5;
    public int startingFlares = 2;

    private int currentFlares;

    public void subtractFlares(int subFlares) {
        currentFlares -= subFlares;
    }

    public void addFlares(int addFlares) {
        currentFlares += addFlares;
    }

    public int getCurrentFlares() {
        return currentFlares;
    }

    public void Start() {
        currentFlares = startingFlares;
    }

    public void Update() {
    }
}
