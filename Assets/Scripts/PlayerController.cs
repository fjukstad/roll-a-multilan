
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PlayerController : MonoBehaviour {

	public float speed = 20.0f;
	public Text countText; 
	public Text winText;

	private Rigidbody rb; 

	private int count; 

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();		
		count = 0; 
		SetCountText();

	}
	
	// Update is called once per frame
	void Update () {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
		rb.AddForce(movement * speed); 
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Pick Up")){
			other.gameObject.SetActive (false);
			count = count+1; 
			print(count); 
			SetCountText() ;
		} 
	}

	void SetCountText(){
		if(count >= 8){
			countText.text = "";
			winText.text = "You win!!!";
		}  else {
			winText.text = "";
		}
		countText.text = "Count: " + count.ToString();  
	}
}
