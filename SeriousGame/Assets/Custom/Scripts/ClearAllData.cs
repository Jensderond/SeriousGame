using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearAllData : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ClearData()
    {
        GameController.gameController.WaterLevel = 0;
        GameController.gameController.FoodLevel = 0;
        GameController.gameController.EnergyLevel = 0;
        GameController.gameController.FoodItems = 0;
        GameController.gameController.WaterItems = 0;
        GameController.gameController.FirstTime = true;
        GameController.gameController.Points = 0;
        GameController.gameController.OldDate = DateTime.Now;
        GameController.gameController.CurrentDate = DateTime.Now;
        GameController.gameController.OfflineHours = 0;
        // UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        //GameController.gameController.SaveData();
    }
}
