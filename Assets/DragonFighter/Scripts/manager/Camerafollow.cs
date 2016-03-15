// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden

using UnityEngine;
using System.Collections;

public class Camerafollow : MonoBehaviour
{
    public GameObject playerObject;
    public float cameraOffset = 5.0F;
    public float height=60;

    void Update()
    {

        Vector3 cameraPosition = new Vector3(playerObject.transform.position.x, height, +cameraOffset);
        GetComponent<Camera>().transform.position = cameraPosition;
    }
}