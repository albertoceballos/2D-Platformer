using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private Transform player;
    [SerializeField]
    private float xMin;
    [SerializeField]
    private float xMax;
    [SerializeField]
    private float yMin;
    [SerializeField]
    private float yMax;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        float x = Mathf.Clamp(player.position.x, xMin, xMax);
        float y = Mathf.Clamp(player.position.y, yMin, yMax);
        transform.position = new Vector3(x, y, transform.position.z);
	}
    
}
