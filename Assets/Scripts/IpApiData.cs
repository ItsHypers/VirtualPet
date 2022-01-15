using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.Net;
using System.Linq;

public class IpApiData : MonoBehaviour
{
	public string IP;
	public CountryScriptable CS;
	private void Start()
    {
		if (string.IsNullOrWhiteSpace(CS.city))
		{
			StartCoroutine("GetIP");
			StartCoroutine("DetectCountry");
		}
    }
	IEnumerator DetectCountry()
	{
		UnityWebRequest request = UnityWebRequest.Get("https://api.ipgeolocation.io/ipgeo?apiKey=6d49dfdd37844ec7b5c3f508e7e568f2&ip=" + IP);
		yield return request.SendWebRequest();

		if (request.result == UnityWebRequest.Result.ConnectionError) 
		{
			Debug.Log("error");
		}
		else
		{
			if (request.isDone)
			{
				Country res = JsonUtility.FromJson<Country>(request.downloadHandler.text);
				CS.country_name = res.country_name;
				CS.country_capital = res.country_capital;
				CS.city = res.city;
				Debug.Log("ran");
			}
		}
	}
	IEnumerator GetIP()
    {
		UnityWebRequest ip = UnityWebRequest.Get("https://api.ipgeolocation.io/getip");
		yield return ip.SendWebRequest();
		if (ip.result == UnityWebRequest.Result.ConnectionError)
		{
			Debug.Log("error");
		}
		else
		{
			if (ip.isDone)
			{
				IP = ip.downloadHandler.text;
				CS.ip = IP;
			}
		}
	}

}