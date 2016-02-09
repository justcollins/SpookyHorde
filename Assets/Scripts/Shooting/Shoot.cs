using UnityEngine;
using System.Collections;

/*
Author: Justin Collins
Purpose of Script: Controls what the gun does in each state, the ammo of the gun and shot timer.
    */

public class Shoot : MonoBehaviour {

	public GameObject bullet;
    public new string name;
    public int ammo = 200;
    public static int shotTimer = 7;

    public void IdleOn() { idle = true; }
    public void IdleOff() { idle = false; }
    public void ShootingOn() { shooting = true; }
    public void ShootingOff() { shooting = false; }
    public void ReloadingOn() { reloading = true; }
    public void ReloadingOff() { reloading = false; }
    public void EmptyOn() { empty = true; }
    public void EmptyOff() { empty = false; }

    private bool idle = false;
    private bool shooting = false;
    private bool reloading = false;
    private bool empty = false;
    private int timeBetweenShots = shotTimer;

    void Awake() {
    }

	void Update () {
        if(idle) {
            Idle();
        } else if (shooting) {
            Fire();
        } else if(empty) {
            Empty();
        } else if(reloading) {
            Reload();
        }
    }

    void Idle() {
    }

	void Fire() {
        if (timeBetweenShots == 0) {
            timeBetweenShots = shotTimer;
            ammo--;
            ObjectPooling.Spawn(bullet, this.transform.position, this.transform.rotation);
		}
        if (timeBetweenShots > 0) {
            timeBetweenShots--;
        }
    }

    void Empty() {
    }

    void Reload() {
        ammo += 10;
    }
}
