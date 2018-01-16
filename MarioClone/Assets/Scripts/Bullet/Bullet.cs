using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    [SerializeField]
    public float speed;
    
	// Update is called once per frame
    //moves the bullet forward
	void Update () {
        Vector3 pos = transform.position;
        Vector3 vel = new Vector3(speed * Time.deltaTime,0, 0);
        pos += transform.rotation * vel;
        transform.position = pos;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Wall" || collision.tag=="Enemy" || collision.tag == "Destroyer")
        {
            Destroy(gameObject);
        }
    }
}
