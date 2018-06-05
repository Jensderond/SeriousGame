using Mapbox.Map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Utils;

public class GetLocations : MonoBehaviour {

    public Mapbox.Unity.Map.AbstractMap map;
    private Rigidbody cube;

    IEnumerator Start()
    {
        cube = GetComponent<Rigidbody>();

        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
        {
            yield break;
        }
        
        Input.location.Start();

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            print("Timed out");
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            yield break;
        }
        else
        {
            while( Input.location.status == LocationServiceStatus.Running )
            {
                transform.rotation = Quaternion.Euler(0, -Input.compass.trueHeading, 0);
                Vector2d newLocation = new Mapbox.Utils.Vector2d(Input.location.lastData.latitude, Input.location.lastData.longitude);
                map.UpdateMap(newLocation, map.Zoom);
                // Access granted and location value could be retrieved
                print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
                yield return new WaitForSeconds(10);
            }
            
        }

        // Stop service if there is no need to query location updates continuously
        Input.location.Stop();
    }
}
