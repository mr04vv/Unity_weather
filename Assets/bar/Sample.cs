using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.UI;
public class Sample : MonoBehaviour {

	public int TimeOutSeconds = 10;
	
	public IEnumerator Load(){
		string[] id = {"1864518","2111149","5128581","2128295"};
		// var id ="2111149"; //sendai
		// var id = '2128295'; //sapporo
		// var id = '5128581'; //new york
		var appid = "b6fa337cd031a676c7949c63525dd096";
		var url = "http://api.openweathermap.org/data/2.5/weather?id=" + id[0] + "&appid="+ appid;
		var request = UnityWebRequest.Get(url);
		var progress = request.SendWebRequest();

		int waitSeconds = 0;
        while (!progress.isDone) {
            yield return new WaitForSeconds(1.0f);
            waitSeconds++;
            if (waitSeconds >= TimeOutSeconds)
            {
                Debug.Log("timeout:" + url);
                yield break;
            }
		
        }
		if(request.responseCode==200){
			string jsonText = request.downloadHandler.text;
			Debug.Log(jsonText);
			WeatherEntity we = JsonUtility.FromJson<WeatherEntity>(jsonText);
			ShowWeather(we);
			yield break;
		}
	}


	public Rigidbody bar;
	public Text text;
	// Use this for initialization
	void Start () {
		bar = GetComponent<Rigidbody>();
		text = GetComponent<Text>();
	}



	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Return)){
			StartCoroutine(Load());
		}
	}


	void ShowWeather(WeatherEntity we){
		text.text = we.weather[0].main;
	}

	void OnTriggerStay(Collider other)
	{
		
	 	if(Input.GetKeyDown(KeyCode.Space)){
			 bar.AddForce(0f,10f,0f);
		}
	}
}
