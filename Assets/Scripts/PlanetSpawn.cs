using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlanetSpawn : MonoBehaviour
{
    public GameObject Planet;
    void Start()
    {
        Instantiate(Planet, CreateSpawnPosition(), Quaternion.identity);
    }

    void Update()
    {
        
    }

    private Vector3 CreateSpawnPosition()
    {
        float x = UnityEngine.Random.Range(-3, 3);
        float y = UnityEngine.Random.Range(2, 6);
        return new Vector3(x, y, 0);
    }
}
