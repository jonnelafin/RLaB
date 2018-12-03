using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour {
	public GameObject nextLVL;
	public float speed;
	public float score = 0F;
	private Rigidbody rigidbody;
	public float isSpr = 1;
	public bool isFlying = false;
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
		if (rigidbody.position.y < -2F)
		{
			print("You died!");
			Application.LoadLevel(Application.loadedLevel);
		}
		
	}
	// Update is called once per frame
	void FixedUpdate(){
		float velH = Input.GetAxis("Horizontal");
		float velV = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(velH, 0.0F, velV);
		rigidbody.AddForce(movement*speed*isSpr);

		if(Input.GetButtonDown("Fire1")){
			if(isFlying == false){
				isFlying = true;
				Vector3 jump = new Vector3(0.0F, 200.0F, 0.0F);

				rigidbody.AddForce(jump);
			}
		}
	}
	void OnTriggerEnter(Collider other)
    {
		if(other.gameObject.CompareTag ("Collectable")){
        	Destroy(other.gameObject);
			score = score + 1F;
		}
		if (score >= 8F){
			print("You won!");
//			Application.LoadLevel(Application.loadedLevel);
			nextLVL.transform.position = nextLVL.transform.position + new Vector3(0F, 10, 0F);
		}
		if(other.gameObject.CompareTag ("Ground")){
        	isFlying = false;
		}
    }
}
