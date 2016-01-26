using UnityEngine;
using System.Collections.Generic;

/*
Author: Justin Collins
Purpose of Script: To spawn objects at the very beginning of the game so that the game is not constantly creating
and destroying gameobjects.
    */

public class ObjectPooling : MonoBehaviour {
    public static ObjectPooling spawner;
    public ObjectPool[] pools;
    public Dictionary<GameObject, bool> activePoolObjects;

    [System.Serializable]
    public class ObjectPool {
        public GameObject prefab;
        public int poolSize = 10;

        private GameObject[] objects;
        private int poolIndex = 0;

        public void Initialize() {
            objects = new GameObject[poolSize];

            for (int i = 0; i < poolSize; i++) {
                objects[i] = Instantiate(prefab) as GameObject;
                objects[i].SetActive(false);
                objects[i].name = objects[i].name + i;
            }
        }

        public GameObject GetNextObjectInPool() {
            GameObject obj = null;

            for (int i = 0; i < poolSize; i++) {
                obj = objects[poolIndex];
                if (!obj.activeSelf) {
                    break;
                }
                poolIndex = (poolIndex + 1) % poolSize;
            }

            if (obj.activeSelf) {
                ObjectPool.DeSpawn(obj);
            }
            poolIndex = (poolIndex + 1) % poolSize;
            return obj;
        }

        public static GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation) {
            ObjectPool pool = null;

            if (spawner) {
                for (int i = 0; i < spawner.pools.Length; i++) {
                    if (spawner.pools[i].prefab == prefab) {
                        pool = spawner.pools[i];
                    }
                }
            }

            if (pool == null) {
                return Instantiate(prefab, position, rotation) as GameObject;
            }
            GameObject obj = pool.GetNextObjectInPool();
            obj.transform.position = position;
            obj.transform.rotation = rotation;
            obj.SetActive(true);
            spawner.activePoolObjects[obj] = true;

            return obj;
        }

        public static void DeSpawn(GameObject objectToDestroy) {
            if (spawner && spawner.activePoolObjects.ContainsKey(objectToDestroy)) {
                objectToDestroy.SetActive(false);
                spawner.activePoolObjects[objectToDestroy] = false;
            } else {
                objectToDestroy.SetActive(false);
            }
        }
    }

    void Awake() {
        spawner = this;
        int amount = 0;

        for (int i = 0; i < pools.Length; i++) {
            pools[i].Initialize();
            amount += pools[i].poolSize;
        }
        activePoolObjects = new Dictionary<GameObject, bool>();
    }

    public static void DeSpawn(GameObject objectToDestroy) {
        ObjectPool.DeSpawn(objectToDestroy);
    }

    public static void Spawn(GameObject prefab, Vector3 position, Quaternion rotation) {
        ObjectPool.Spawn(prefab, position, rotation);
    }
}
