using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawn : MonoBehaviour
{
    public GameObject PlanetPrefab;
    public Transform Player;
    public static List<GameObject> PlanetsList = new List<GameObject>();
    public GameObject background;

    private void Start()
    {
        PlanetsList.Add(GameObject.Find("Planet"));
        SpawnPlanet(PlanetPrefab, Player, background);
    }

    private static Vector3 CreateSpawnPosition(Transform player)
    {
        float x = UnityEngine.Random.Range(-2 + player.position.x, 2 + player.position.x);
        float y = UnityEngine.Random.Range(6.5f + player.transform.position.y, 7 + player.transform.position.y);
        return new Vector3(x , y , 0);
    }

    public static void SpawnPlanet(GameObject planet, Transform player, GameObject background)
    {
        PlanetsList.Add(planet);
        Vector3 spawnPos = CreateSpawnPosition(player);
        Instantiate(planet, spawnPos, Quaternion.identity);
        Instantiate(background, spawnPos + new Vector3(0,7,0), Quaternion.identity);
    }

    //public static void RestartPlanets()
    //{
    //    for (int i = PlanetsList.Count; i < 1; i--)
    //    {
    //        Destroy(PlanetsList[i]);
    //        PlanetsList.RemoveAt(i);
    //    }
    //}
}
