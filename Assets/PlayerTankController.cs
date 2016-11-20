using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerTankController : MonoBehaviour {

	private Transform tankHead;
	private Image powerUI;

	void Start () {
		tankHead = transform.FindChild ("Tower");
		powerUI = GameObject.Find ("Canvas").transform.FindChild ("PowerBack").FindChild ("PowerFront").GetComponent<Image> ();
	}
		
	private float moveSpeed = 10f;
	private float rotateSpeed = 50f;
	void Update () {
		if (Input.GetKey (KeyCode.W)) {
			transform.Translate (transform.right * moveSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.Translate (-transform.right * moveSpeed * Time.deltaTime / 2, Space.World);
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.Rotate (-transform.up * rotateSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.Rotate (transform.up * rotateSpeed * Time.deltaTime, Space.World);
		}

		if (Input.GetKey (KeyCode.UpArrow)) {
			
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
		
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			tankHead.transform.Rotate (-transform.up * rotateSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			tankHead.transform.Rotate (transform.up * rotateSpeed * Time.deltaTime, Space.World);
		}

		if (Input.GetKey (KeyCode.Space)) {
			AddPower (Time.deltaTime);
			if (power > 1f) {
				SetPower (1f);
			}
		}
		if(Input.GetKeyUp (KeyCode.Space)){
			(Instantiate(Resources.Load("bullet",typeof(GameObject)), transform.position + new Vector3(0,3,0), Quaternion.identity) as GameObject).GetComponent<BulletMove>().Shoot(tankHead.transform.up + new Vector3(0f,0.3f,0f), power);
			SetPower (0f);
		}
	}
	private float power = 0f;

	private void SetPower(float power_){
		power = power_;
		powerUI.fillAmount = power;
	}
	private void AddPower(float power_){
		power += power_;
		powerUI.fillAmount = power;
	}
}
