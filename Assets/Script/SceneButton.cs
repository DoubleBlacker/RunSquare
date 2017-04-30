using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneButton : MonoBehaviour {

	public string sceneName="home";

	void Start () {
		GetComponent<Button> ().onClick.AddListener (() => GameManager.instance.LoadScene (sceneName));
	}

}
