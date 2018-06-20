using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class GameController : MonoBehaviour
{

    public static GameController gameController;

    [Range(0, 100)] public float EnergyLevel;// { get; set; }
    [Range(0, 100)] public float FoodLevel;// { get; set; }
    [Range(0, 100)] public float WaterLevel;// { get; set; }
    public int OfflineHours;// { get; set; }
    public DateTime OldDate;// { get; set; }
    public DateTime CurrentDate;
    public int Points;
    public bool FirstTime;

    public int WaterItems;
    public int FoodItems;
    public int EnergyItems;


    private void Awake()
    {
        if (gameController == null)
        {
            DontDestroyOnLoad(gameObject);
            gameController = this;
        }
        else if (gameController != this)
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        if (File.Exists(Application.persistentDataPath + "playerInfo.data"))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = File.Open(Application.persistentDataPath + "playerInfo.data", FileMode.Open);
            PlayerData playerData = (PlayerData)binaryFormatter.Deserialize(fileStream);

            EnergyLevel = playerData.EnergyLevel;
            WaterLevel = playerData.WaterLevel;
            FoodLevel = playerData.FoodLevel;
            CurrentDate = DateTime.Now;
            TimeSpan difference = CurrentDate.Subtract(playerData.OldDate);
            OfflineHours = difference.Hours;
            WaterItems = playerData.WaterItems;
            FoodItems = playerData.FoodItems;
            EnergyItems = playerData.EnergyItems;
            OldDate = playerData.OldDate;
            Points = playerData.Points;
        }
        else
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = File.Create(Application.persistentDataPath + "playerInfo.data");
            PlayerData playerData = new PlayerData
            {
                FirstTime = true,
                EnergyLevel = 86,
                FoodLevel = 86,
                WaterLevel = 86,
                OldDate = System.DateTime.Now,
                Points = 50,
                WaterItems = 5,
                FoodItems = 5,
                EnergyItems = 5

            };

            binaryFormatter.Serialize(fileStream, playerData);
            fileStream.Close();
        }
    }

    private void OnDisable()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = File.Create(Application.persistentDataPath + "playerInfo.data");
    PlayerData playerData = new PlayerData
    {
        FirstTime = FirstTime,
        EnergyLevel = EnergyLevel,
        FoodLevel = FoodLevel,
        WaterLevel = WaterLevel,
        OldDate = System.DateTime.Now,
        Points = Points,
        WaterItems = WaterItems,
        FoodItems = FoodItems,
        EnergyItems = EnergyItems

        };

        binaryFormatter.Serialize(fileStream, playerData);
        fileStream.Close();
    }

    private void OnApplicationQuit()
    {
        OnDisable();
    }

    public void SaveData()
    {
        OnDisable();
    }
}

[Serializable]
class PlayerData
{
    public bool FirstTime { get; set; }
    public float EnergyLevel { get; set; }
    public float FoodLevel { get; set; }
    public float WaterLevel { get; set; }
    public DateTime OldDate { get; set; }
    public int Points { get; set; }
    public int WaterItems { get; set; }
    public int FoodItems { get; set; }
    public int EnergyItems { get; set; }

}
