using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class GameController : MonoBehaviour {

    public static GameController gameController;

    [Range(0, 100)] public float EnergyLevel;// { get; set; }
    [Range(0, 100)] public float FoodLevel;// { get; set; }
    [Range(0, 100)] public float WaterLevel;// { get; set; }
    public int OfflineHours;// { get; set; }
    public DateTime OldDate;// { get; set; }
    public DateTime CurrentDate;


    private void Awake()
    {
        if( gameController == null )
        {
            DontDestroyOnLoad( gameObject );
            gameController = this;
        }
        else if( gameController != this )
        {
            Destroy( gameObject );
        }
    }

    private void OnEnable()
    {
        if ( File.Exists( Application.persistentDataPath + "playerInfo.data" ) )
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = File.Open( Application.persistentDataPath + "playerInfo.data", FileMode.Open );
            PlayerData playerData = (PlayerData) binaryFormatter.Deserialize( fileStream );

            EnergyLevel = playerData.EnergyLevel;
            FoodLevel = playerData.FoodLevel;
            WaterLevel = playerData.WaterLevel;
            OldDate = playerData.OldDate;
            CurrentDate = System.DateTime.Now;
            TimeSpan difference = CurrentDate.Subtract(OldDate);
            OfflineHours = difference.Hours;
        }
    }

    private void OnDisable()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = File.Create( Application.persistentDataPath + "playerInfo.data" );
        PlayerData playerData = new PlayerData
        {
            EnergyLevel = EnergyLevel,
            FoodLevel = FoodLevel,
            WaterLevel = WaterLevel,
            OldDate = System.DateTime.Now

    };

        binaryFormatter.Serialize( fileStream, playerData );
        fileStream.Close();
    }


    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

[Serializable]
class PlayerData
{
    public float EnergyLevel { get; set; }
    public float FoodLevel { get; set; }
    public float WaterLevel { get; set; }
    public DateTime OldDate { get; set; }
}
