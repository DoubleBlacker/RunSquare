using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeController : MonoBehaviour {

	public InputField inputField;

	void Start()
	{
		inputField.transform.Find ("Placeholder").GetComponent<Text> ().text = GameManager.instance.GetPlayerName ();
	}

	public void OnChangeName()
	{
		GameManager.instance.SetPlayerName (inputField.text);
	}

	public void OnOpenBestScorePanel()
	{
		Panel.Open ("BestScorePanel");
	}
}
