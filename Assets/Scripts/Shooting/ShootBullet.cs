using UnityEngine;

/*
Author: Justin Collins
Purpose of Script: Controls the bullets that shoot out of the gun and how they interact when they hit an enemy or environment
    */

public class ShootBullet : MonoBehaviour {
    public float speed = 10;
    public float lifeTime = 0.5f;
    public float distance = 10;
    public int damage = 5;

    private float spawnTime = 0.0f;
    private Transform tr;
    private float distanceStorage;
    private new Rigidbody rigidbody = null;
    private ForceMode impulse = ForceMode.Impulse;

    void Awake() {
        distanceStorage = distance;
        rigidbody = GetComponent<Rigidbody>();
    }

    public void OnEnable() {
        distance = distanceStorage;
        tr = transform;
        spawnTime = Time.time;
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
    }

    public void Update() {
        CheckBulletDespawn();
    }

    public void FixedUpdate() {
        UpdateBulletPosition();
    }

    public void UpdateBulletPosition() {
        rigidbody.AddForce(-tr.up * speed, impulse);
    }

    public void CheckBulletDespawn() {
        distance -= speed * Time.deltaTime;
        if (Time.time > spawnTime + lifeTime || distance < 0) {
            ObjectPooling.DeSpawn(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.layer == 10) {
            collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
            ObjectPooling.DeSpawn(this.gameObject);
    }
}
