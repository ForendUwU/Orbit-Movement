using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawn : MonoBehaviour
{
    public GameObject PlanetPrefab;
    public Transform Player;
    public static List<GameObject> PlanetsList = new List<GameObject>();

    private void Start()
    {
        PlanetsList.Add(GameObject.Find("Planet"));
        SpawnPlanet(PlanetPrefab, Player);
    }

    private static Vector3 CreateSpawnPosition(Transform player)
    {
        float x = UnityEngine.Random.Range(-2 + player.position.x, 2 + player.position.x);
        float y = UnityEngine.Random.Range(6.5f + player.transform.position.y, 7 + player.transform.position.y);
        return new Vector3(x , y , 0);
    }

    public static void SpawnPlanet(GameObject planet, Transform player)
    {
        PlanetsList.Add(planet);
        Instantiate(planet, CreateSpawnPosition(player), Quaternion.identity);
    }

    //public static void DestroyPlanet()
    //{
    //    Destroy(PlanetsList[0]);
    //    PlanetsList.RemoveAt(0);
    //}
}
