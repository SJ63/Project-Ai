using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Countdown : MonoBehaviour
{
	public float timeStart = 60 ;
	float timeCurrent = 0 ;
	public TextMeshProUGUI textBox;
	public TextMeshProUGUI textBox2;

	public int Max = 5 ;
	int count = 5 ;
    // Start is called before the first frame update

	LevelLoader level_Loader ;
    void Start()
    {
        textBox.text = timeStart.ToString() ;
		timeCurrent = timeStart ;
		count = Max ;
		textBox2.text = count.ToString() ;
    }

    // Update is called once per frame
    void Update()
    {
        timeCurrent -= Time.deltaTime;
		textBox.text = Mathf.Round(timeCurrent).ToString() ;

		if( timeCurrent <= 0)
		{
			Debug.Log("Time = 0") ;
			TimeOut();
		}
    }

	void TimeOut()
	{
		level_Loader = gameObject.GetComponent<LevelLoader>();
		level_Loader.LoadNextLevel();
	}

	void ClearTheBall()
	{
		level_Loader = gameObject.GetComponent<LevelLoader>();
		level_Loader.LoadNextLevel2();
	}

	public void HitTheBall(int hit)
	{
		count -= hit ;
		textBox2.text = count.ToString() ;
		if ( count <= 0)
		{
			Debug.Log("All clear") ;
			ClearTheBall();
		}
	}

	public void refute(float minus)
	{
		timeCurrent = timeCurrent - minus ;
		Debug.Log("Enemy is hitted") ;
	}
}
