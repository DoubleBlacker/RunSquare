using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowController : MonoBehaviour {

	public float m_SpeedU = 0.1f;  
	public float m_SpeedV = -0.1f;  

	// Update is called once per frame  
	void Update () {  
		float newOffsetU = Time.time * m_SpeedU;  
		float newOffsetV = Time.time * m_SpeedV;  

		GetComponent<Renderer>().material.mainTextureOffset=new Vector2(newOffsetU, newOffsetV);  
	}  
}
