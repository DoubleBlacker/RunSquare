using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTime : MonoBehaviour {

	private Text gameTimeText;
	// Use this for initialization
	void Start () {
		gameTimeText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		gameTimeText.text = (Mathf.RoundToInt(GameController.GetInstance ().gameTime) > GameManager.instance.GetBestScore () ?
			"新纪录：" +Mathf.RoundToInt(GameController.GetInstance ().gameTime) + " 秒" :
			"你已经坚持了：" + Mathf.RoundToInt(GameController.GetInstance ().gameTime) + " 秒");
	}
}
