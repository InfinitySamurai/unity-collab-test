using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereManager : MonoBehaviour
{
    public int maximumSphereCount = 5;
    public int currentSphereCount = 0;
    public int spawnTimerSeconds = 10;

    public GameObject sphereTracker;
    public GameObject spherePrefab;

    private float spawnerCountdown = 0;
    void Start()
    {

    }

    void Update()
    {
        spawnerCountdown -= Time.deltaTime;
        if (spawnerCountdown <= 0)
        {
            spawnerCountdown = spawnTimerSeconds;
            if(sphereTracker.transform.childCount < maximumSphereCount)
            {
                Vector3 spawnPositionRandomness = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
                GameObject newSphere = Instantiate(spherePrefab, this.transform.position + spawnPositionRandomness, Quaternion.identity, sphereTracker.transform);
            }
        }
    }
}
