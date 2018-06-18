using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour {

    private int points;

    public int setPoints(double distance,int amountMeters)
    {
        var distanceMeters = distance * 1000;
        var newPoints = (int)Math.Round(distanceMeters / amountMeters);
        int totalpoints = newPoints + getPoints();
        points = totalpoints;
        return totalpoints;
        
    }
    public int getPoints()
    {
        // return GameController.gameController.Points;
        return 0;
    }

    void OnApplicationQuit()
    {
        // GameController.gameController.Points = Points;
    }
    void OnApplicationPause(bool isPaused)
    {
        if (isPaused)
        {
            // GameController.gameController.Points = Points;
        }
    }
}
