using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Shoot : MonoBehaviour {

	public GameObject bullet;
    //public GameObject muzzleFlash;
    //public ParticleSystem gunShootParticles;
    public new string name;
    public int ammo = 200;
    public static int shotTimer = 7;
    public Text ammoText;

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
        //gunShootParticles.Stop(withChildren: true);
        //gunShootParticles.Clear(withChildren: true);
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

        SetAmmoText();
    }

    void Idle() {
        //gunShootParticles.emissionRate = 0.0f;
        //gunShootParticles.Play(withChildren: true);
        //muzzleFlash.SetActive(false);
    }

	void Fire() {
        //gunShootParticles.emissionRate = 11.42f;
        //muzzleFlash.SetActive(true);
        if (timeBetweenShots == 0) {
            timeBetweenShots = shotTimer;
            ammo--;
            ObjectPooling.Spawn(bullet, this.transform.position, this.transform.rotation);
		}
        if (timeBetweenShots > 0) {
            timeBetweenShots--;
        }
        //if(Physics.Raycast(transform.position, ))
    }

    void Empty() {
        //gunShootParticles.emissionRate = 0.0f;
        //gunShootParticles.Stop(withChildren: true);
        //muzzleFlash.SetActive(false);
    }

    void Reload() {
        ammo += 10;
    }

    public void SetAmmoText() {
        ammoText.text = "Ammo: " + ammo.ToString();
    }
}
