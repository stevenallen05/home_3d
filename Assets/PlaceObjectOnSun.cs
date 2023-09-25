using UnityEngine;

public class PlaceObjectOnSun : UnityEngine.MonoBehaviour

{
    public UnityEngine.Transform sun; // The object representing the simulated sun
    public float horizonDistance = 5000f; // Distance from the center of the world to the horizon
    public float zenithHeight = 5000f; // Height of the zenith above the center of the world
    public float azimuthDegrees; // Azimuth angle in degrees
    public float altitudeDegrees; // Altitude angle in degrees
    public Vector3 centerOfWorld = Vector3.zero; // Center of the world
 
    private void Start()
    {
        azimuthDegrees = ((WrapAngle(transform.localEulerAngles.y) + 90f)) * -1.0f;
        altitudeDegrees = ((WrapAngle(transform.localEulerAngles.x) - 90f)) * -1.0f;
        calcSunPostion();
    }
 
 
    void calcSunPostion()
    {
        // Convert the Altitude and Azimuth angles to radians
        float altitudeRad = altitudeDegrees * Mathf.Deg2Rad;
        float azimuthRad = azimuthDegrees * Mathf.Deg2Rad;
 
        // Calculate the position of the sun in the sky
        float x = horizonDistance * Mathf.Sin(altitudeRad) * Mathf.Cos(azimuthRad);
        float y = zenithHeight * Mathf.Cos(altitudeRad);
        float z = horizonDistance * Mathf.Sin(altitudeRad) * Mathf.Sin(azimuthRad);
 
        // Place the sun in the sky
        sun.position = centerOfWorld + new Vector3(x, y, z);
    }
 
    private float WrapAngle(float angle)
    {
        angle %= 360;
        if (angle > 180)
            return angle - 360;
 
        return angle;
    }
 
}
 