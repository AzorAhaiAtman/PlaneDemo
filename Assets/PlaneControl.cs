using UnityEngine;
using System.Collections;

public class PlaneControl : MonoBehaviour {
	
	float speed;
	float bias;
	
	// Use this for initialization
	void Start () {
		speed = 90.0f;
		bias = 0.96f;
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 moveCamTo = transform.position + transform.right * 30.0f + Vector3.up * 5.0f;
		
		Camera.main.transform.position = Camera.main.transform.position * bias + moveCamTo * (1 - bias);
		Camera.main.transform.LookAt(transform.position - transform.right * 30.0f);
		
		transform.position -= transform.right * Time.deltaTime * speed;

		transform.Rotate(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
		
		float terrainHeight = Terrain.activeTerrain.SampleHeight(transform.position);		
		if(terrainHeight > transform.position.y)
		{
			transform.position = new Vector3(transform.position.x, terrainHeight, transform.position.y);
		}
	}
}
