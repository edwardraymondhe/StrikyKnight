using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject objectFollowing;
    private Vector3 position;

    // Update is called once per frame
    void Update()
    {
        position = new Vector3(objectFollowing.transform.position.x, objectFollowing.transform.position.y, transform.position.z);
        transform.position = position;
    }
}
