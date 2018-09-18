using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour {
    public float speed = 10f;

	// Use this for initialization
	
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.up*speed * Time.deltaTime);
        if(transform.position.y >= 6)
        {
            Destroy(this.gameObject);
        }
	}
}
