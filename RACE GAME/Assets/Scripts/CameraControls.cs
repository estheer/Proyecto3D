using UnityEngine;
using System.Collections;

public class CameraControls : MonoBehaviour {

    public Transform player;
    public float distance = 8.0f;
    public float distanceLook = 4.0f;
    

    private float verticalPosition;
    private float horizontalPosition;
    private Vector2 circularPos;


    void LateUpdate () {

        transform.position = player.position - player.forward * distance + Vector3.up*distance/2;
        transform.LookAt(player.position + player.forward * distanceLook);

	}
}
