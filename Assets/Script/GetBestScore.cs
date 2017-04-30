using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetBestScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Text> ().text = GameManager.instance.GetPlayerName () + " \n 你目前的最高分是："
		+ GameManager.instance.GetBestScore () + "秒";
	}

}
