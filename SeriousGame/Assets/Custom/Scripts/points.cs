using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class points : MonoBehaviour {

    private int Points;
    //TODO save newpoints


    public int setPoints(double distance,int amountMeters)
    {
        var distanceMeters = distance * 1000;
        var newPoints = (int)Math.Round(distanceMeters / amountMeters);
        int totalpoints = newPoints + getPoints();

        return totalpoints;
        
    }
    public int getPoints()
    {
        var i = 0;
        return i;
    }
}
