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
            CurrentDate = DateTime.Now;
            FoodLevel = playerData.FoodLevel;
            TimeSpan difference = CurrentDate.Subtract(OldDate);
            OfflineHours = difference.Hours;
            OldDate = playerData.OldDate;
            Points = playerData.Points;
            WaterLevel = playerData.WaterLevel;
        }
    }

    private void OnDisable()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = File.Create(Application.persistentDataPath + "playerInfo.data");
        PlayerData playerData = new PlayerData
        {
            EnergyLevel = EnergyLevel,
            FirstTime = FirstTime,
            FoodLevel = FoodLevel,
            OldDate = DateTime.Now,
            Points = Points,
            WaterLevel = WaterLevel
        };

        binaryFormatter.Serialize(fileStream, playerData);
        fileStream.Close();
    }

}

[Serializable]
class PlayerData
{
    public float EnergyLevel { get; set; }
    public bool FirstTime { get; set; }
    public float FoodLevel { get; set; }
    public DateTime OldDate { get; set; }
    public int Points { get; set; }
    public float WaterLevel { get; set; }
}
