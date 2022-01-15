using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "item/PlayerInfo")]
public class CountryScriptable : ScriptableObject
{
	public string city;
	public string country_name;
	public string country_capital;
	public string ip;
}
