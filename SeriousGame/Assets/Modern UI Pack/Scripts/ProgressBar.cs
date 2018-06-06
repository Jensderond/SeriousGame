using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProgressBar : MonoBehaviour {

	[Header("OBJECTS")]
	public Transform loadingBar;
	public Transform textPercent;

	[Header("VARIABLES (IN-GAME)")]
	public bool isOn;
	public bool restart;
	[Range(0, 100)] public float currentPercent;
	[Range(0, 100)] public int speed;
    [Range(0, 10)] public float decayPerTick;

    [Header("SPECIFIED PERCENT")]
    public bool enableSpecified;
    public bool enableLoop;
    [Range(0, 100)] public float specifiedValue;

    private bool isFilling;

    void Update ()
	{
		if (currentPercent <= 100 && isOn == true && enableSpecified == false) 
		{
			currentPercent += speed * Time.deltaTime;
		}

        if (currentPercent <= 100 && isOn == true && enableSpecified == true)
        {
            if(currentPercent <= specifiedValue)
            {
                currentPercent += speed * Time.deltaTime;
            }

            //when in loop mode simply set current% to 0 else invert default update
            if (enableLoop == true && currentPercent >= specifiedValue)
            {
                currentPercent = 0;
            }else
            if(currentPercent >= specifiedValue)
            {
                currentPercent -= speed * Time.deltaTime;
            }

        }

        // loop
        if (currentPercent == 100 || currentPercent >= 100 && restart == true) 
		{
			currentPercent = 0;
		}

        // when above 1% and not filling up then decay
        if (currentPercent >=1 && specifiedValue >=1 && isOn && isFilling==false)
        {
            specifiedValue -= (float)(decayPerTick/1000);
           // currentPercent -= decayPerTick;
        }

        //TODO: verify that this also works when the bar is emptying
		loadingBar.GetComponent<Image> ().fillAmount = currentPercent / 100;
		textPercent.GetComponent<Text> ().text = ((int)currentPercent).ToString ("F0") + "%";
	}
    public void AddToSpecifiedPercentage(float amountToAdd)
    {
        isFilling = true;
        if(this.specifiedValue+amountToAdd > 100)
        {
            specifiedValue = 100;
        }
        else
        {
            specifiedValue += amountToAdd;
        }
        isFilling = false;
    }
}