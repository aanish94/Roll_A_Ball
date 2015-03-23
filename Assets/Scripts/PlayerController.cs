using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float speed;
	private int count;

	public GUIText countText;
	public GUIText winText;
	public GUIText aaText;
	void Start()
	{
		count = 0;
		setCountText ();
		winText.text = "";
		aaText.text = "Created by Aanish PS";
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		if (movement != Vector3.zero) 
		{
			GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "PickUp") 
		{
			other.gameObject.SetActive(false);
			count = count + 1;
			setCountText();
		}
	}

	void setCountText()
	{
		aaText.text = "Created by Aanish PS";
		countText.text = "Count: " + count.ToString();
		if (count >= 12) 
		{
			winText.text = "YOU WIN!!!";
		}
	}
}
