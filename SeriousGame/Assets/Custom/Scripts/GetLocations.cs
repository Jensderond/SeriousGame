﻿using Mapbox.Utils;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GetLocations : MonoBehaviour
{

    public Mapbox.Unity.Map.AbstractMap map;
    public Text distanceText;
    public Text pointText;
    public int amountMeters;
    private double totalDistance;
    private int points;
    IEnumerator Start()
    {
        var anim = GetComponent<Animator>();
        int walkHash = Animator.StringToHash("Walk");

        totalDistance = 0;
        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
        {
            yield
            break;
        }

        Input.location.Start();

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield
            return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            print("Timed out");
            yield
            break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            yield
            break;
        }
        else
        {
            float[] oldgps = new float[] {
    Input.location.lastData.latitude, Input.location.lastData.longitude
   };
            Vector2d oldLocation = new Vector2d(oldgps[0], oldgps[1]);

            while (Input.location.status == LocationServiceStatus.Running)
            {
                Vector2d newLocation = new Vector2d(Input.location.lastData.latitude, Input.location.lastData.longitude);
                if (newLocation.x == oldLocation.x && newLocation.y == oldLocation.y)
                {
                    anim.ResetTrigger(walkHash);
                }
                else
                {
                    anim.SetTrigger(walkHash);
                }
                map.UpdateMap(newLocation, map.Zoom);
                Calcdistance(oldgps[0], oldgps[1], Input.location.lastData.latitude, Input.location.lastData.longitude);
                distanceText.text = ("Distance: " + Math.Round(totalDistance, 2) + " km").Replace('.', ',');
                pointText.text = "Points: " + setPoints(totalDistance, amountMeters);


                oldLocation = newLocation;
                oldgps[0] = Input.location.lastData.latitude;
                oldgps[1] = Input.location.lastData.longitude;
                yield
                return new WaitForSeconds(3);
            }

        }
        // Stop service if there is no need to query location updates continuously
        Input.location.Stop();
    }

    public void Calcdistance(float lat1, float lon1, float lat2, float lon2)
    {
        double distance = 0;
        var R = 6378.137; // Radius of earth in KM
        var dLat = lat2 * Mathf.PI / 180 - lat1 * Mathf.PI / 180;
        var dLon = lon2 * Mathf.PI / 180 - lon1 * Mathf.PI / 180;
        float a = Mathf.Sin(dLat / 2) * Mathf.Sin(dLat / 2) +
         Mathf.Cos(lat1 * Mathf.PI / 180) * Mathf.Cos(lat2 * Mathf.PI / 180) *
         Mathf.Sin(dLon / 2) * Mathf.Sin(dLon / 2);
        var c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
        distance = R * c;
        //  distance = distance * 1000f; // meters

        totalDistance = totalDistance + distance;
    }


    public int setPoints(double distance, int amountMeters)
    {
        var distanceMeters = distance * 1000;
        var newPoints = (int)Math.Round(distanceMeters / amountMeters);
        int totalpoints = newPoints + getPoints();
        points = totalpoints;
        return points;
    }
    private int getPoints()
    {
        try
        {
            return GameController.gameController.Points;
        }
        catch (Exception)
        {

            return 0;
        }
    }

    public void Save()
    {
        print("saved");
        GameController.gameController.Points = points;
    }

    void OnApplicationPause(bool isPaused)
    {
        if (isPaused)
        {
            totalDistance = 0;
            GameController.gameController.Points = points;
        }
    }
    void OnApplicationQuit()
    {
        GameController.gameController.Points = points;
    }
    public void Cheat()
    {
        totalDistance = totalDistance + 0.05;
        pointText.text = "Points: " + setPoints(totalDistance, amountMeters);
        distanceText.text = ("Distance: " + Math.Round(totalDistance, 2) + " km").Replace('.', ',');
    }
}