using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class GameController : MonoBehaviour {

    public static GameController gameController;

    public float EnergyLevel;// { get; set; }
    public float FoodLevel;// { get; set; }
    public float WaterLevel;// { get; set; }


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
            WaterLevel = WaterLevel
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
}
