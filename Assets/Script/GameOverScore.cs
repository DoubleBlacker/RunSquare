using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScore : MonoBehaviour {

	private GameObject newScore;

	void Awake()
	{
		newScore = transform.Find ("Text").gameObject;
		if (newScore.activeSelf) {
			newScore.SetActive (false);
		}
	}

	void Start () {
		GetComponent<Text> ().text = "当前得分： "+Mathf.RoundToInt(GameController.GetInstance ().gameTime)+" 秒";
		if (GameManager.instance.isNewScore) {
			if (!newScore.activeSelf) {
				newScore.SetActive (true);
			}
		}
	}

}
