using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerControl : MonoBehaviour
{
    public float AngularVelocity;
    public float Radius;
    public float MovementVelocity;
    public Transform Planet;
    public GameObject PlanetPrefab;
    public RectTransform panelWithScore;

    private GameObject newPlanet;
    private bool isTouched;
    private bool isOnOrbit;

    private void Start()
    {
        isTouched = false;
        newPlanet = Planet.gameObject;
    }

    private void Update()
    {
        if (!isTouched)
        {
            float x = Mathf.Sin((Time.time * AngularVelocity / 360f % 1f * 360f) * Mathf.Deg2Rad) * Radius + Planet.position.x;
            float y = Mathf.Cos((Time.time * AngularVelocity / 360f % 1f * 360f) * Mathf.Deg2Rad) * Radius + Planet.position.y;
            transform.position = new Vector3(x, y, 0f);

            Vector3 relativePosition = transform.position - Planet.position;

            float rotationVelocity = Mathf.Atan2(relativePosition.x, relativePosition.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(-rotationVelocity, Vector3.forward);
        }

        Vector3 trueDir = transform.rotation * Vector3.up;
        Debug.DrawRay(transform.position, trueDir, Color.blue);

        if (Input.touchCount > 0 || Input.GetKeyDown(KeyCode.Space))
        {
            isTouched = true;
        }

        if (isTouched)
        {
            transform.position += transform.up * (MovementVelocity * Time.deltaTime);
        }

        if (isOnOrbit)
        {
            Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, new Vector3(newPlanet.transform.position.x, newPlanet.transform.position.y + 4, -10), 10 * Time.deltaTime);
            if (Camera.main.transform.position == new Vector3(newPlanet.transform.position.x, newPlanet.transform.position.y + 4, -10))
            {
                isOnOrbit = false;
            }
        }

        if (transform.position.x > Camera.main.transform.position.x + Camera.main.orthographicSize / 2f
            || transform.position.x < Camera.main.transform.position.x - Camera.main.orthographicSize / 2f
            || transform.position.y > Camera.main.transform.position.y + Camera.main.orthographicSize
            || transform.position.y < Camera.main.transform.position.y - Camera.main.orthographicSize)
        {
            Debug.Log("game over");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        ScoreScript.ChangeScore(panelWithScore);
        newPlanet = col.gameObject;
        Planet = newPlanet.transform;
        isTouched = false;
        PlanetSpawn.SpawnPlanet(PlanetPrefab, transform);
        isOnOrbit = true;
    }
}