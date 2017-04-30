using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetConis : MonoBehaviour {

	private Text coinsText;
	// Use this for initialization
	void Start () {
		coinsText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		coinsText.text = GameManager.instance.Coin.ToString();
	}
}
