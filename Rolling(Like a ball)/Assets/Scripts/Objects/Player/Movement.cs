using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour {
	public float speed;
	public float score = 0F;
	private Rigidbody rigidbody;
	public float isSpr = 1;
	void Start(){
		rigidbody = GetComponent<Rigidbody>();
	}
	void Update(){
		if (Input.GetKeyDown("space"))
        {
            isSpr = 5;
        }
		if (Input.GetKeyUp("space"))
        {
            isSpr = 1;
        }
		if (rigidbody.position.y < -10F)
		{
			print("You died!");
			Application.LoadLevel(Application.loadedLevel);
		}
		if (score >= 8F){
			print("You won!");
			Application.LoadLevel(Application.loadedLevel);
		}
	}
	// Update is called once per frame
	void FixedUpdate(){
		float velH = Input.GetAxis("Horizontal");
		float velV = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(velH, 0.0F, velV);
		rigidbody.AddForce(movement*speed*isSpr);
	}
	void OnTriggerEnter(Collider other)
    {
		if(other.gameObject.CompareTag ("Collectable")){
        	Destroy(other.gameObject);
			score = score + 1F;
		}
    }
}
