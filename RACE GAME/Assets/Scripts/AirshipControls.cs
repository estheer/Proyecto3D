using UnityEngine;
using System.Collections;

public class AirshipControls : MonoBehaviour
{

    public float maxSpeed = 40.0f;
    public float acceleration = 20.0f;
    public float rotSpeed = 60.0f;
    public float tiltSpeed = 80.0f;
    public float maxTilt = 30.0f;
    public float levitationAmp = 1.0f;
    public float levSpeed = 4.0f;


    private float currentSpeed;
    private float tiltAngle;
    private float yaw;
    private float currentLevSpeed;
    private float time;

    void Update()
    {

        float dt = Time.deltaTime;

        //Get Inputs
        float forward = Input.GetKey(KeyCode.Space) ? 1.0f : 0.0f;
        float tilt = -Input.GetAxisRaw("Horizontal");
        yaw -= tilt*rotSpeed*dt;

        //Tilting
        float tiltTarget = tilt * maxTilt;
        float tiltOffset = tiltTarget - tiltAngle;
        tiltOffset = Mathf.Clamp( tiltOffset, -tiltSpeed * dt, tiltSpeed * dt);
        tiltAngle += tiltOffset;

        //Forward movement
        float targetSpeed = forward * maxSpeed;
        float offsetSpeed = targetSpeed - currentSpeed;
        offsetSpeed = Mathf.Clamp( offsetSpeed, -acceleration * dt, acceleration * dt);
        currentSpeed += offsetSpeed;

        //Levitation effect
        currentLevSpeed = levitationAmp * Mathf.Sin(levSpeed * time);
        time += dt;
        time %= 2 * Mathf.PI / levSpeed;

        //Update position
        transform.position += currentSpeed * transform.forward * dt + transform.up*currentLevSpeed*dt ;

        //Update tilting(roll) and rotation
        transform.eulerAngles = Vector3.forward * tiltAngle + Vector3.up*yaw;

    }
}
