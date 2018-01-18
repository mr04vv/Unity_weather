using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeatherEntity{
	public Wether[] weather;
	public Wind wind;

}

[System.Serializable]
public class Wether{
	public string main;
	public int id;
}

[System.Serializable]
public class Wind{
	public float deg;
	public float speed;

}