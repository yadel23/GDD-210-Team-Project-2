using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
	public CharacterController CC;
	public float MoveSpeed;
	public float Gravity = -9.8f;
	public float JumpSpeed;

	public float verticalSpeed;

	public Transform CamTransform;

	public GameObject Clue1;
	public GameObject Clue2;
	public GameObject Clue3;
	public GameObject Clue4;
	public GameObject Clue5;
	public GameObject Clue6;

	public GameObject person;
	public GameObject hiddenNote;
	public GameObject hiddenLights;

	public GameObject removeWall;

	public GameObject flotingEye;

	public GameObject flashLight;
	public GameObject lightObj;


	private void Update()
	{

		Vector3 movement = Vector3.zero;

		// X/Z movement
		float forwardMovement = Input.GetAxis("Vertical") * MoveSpeed * Time.deltaTime;
		float sideMovement = Input.GetAxis("Horizontal") * MoveSpeed * Time.deltaTime;


		//movement += (transform.player - transform.position) * MoveSpeed * Time.deltaTime;

		movement += (transform.forward * forwardMovement) + (transform.right * sideMovement);

		if (CC.isGrounded)
		{
			verticalSpeed = 0f;
			if (Input.GetKeyDown(KeyCode.Space))
			{
				verticalSpeed = JumpSpeed;
			}
		}

		verticalSpeed += (Gravity * Time.deltaTime);
		movement += (transform.up * verticalSpeed * Time.deltaTime);

		CC.Move(movement);


		RaycastHit hit;
		if (Physics.Raycast(CamTransform.position, CamTransform.forward, out hit))
		{
			Debug.DrawLine(CamTransform.position + new Vector3(0f, -1f, 0f), hit.point, Color.cyan);

			CluesConroller clue = hit.collider.GetComponent<CluesConroller>();
			if (clue != null && hit.distance < 20)
			{
                if (Input.GetMouseButtonDown(0))
                {
					Debug.DrawLine(CamTransform.position + new Vector3(0f, -1f, 0f), hit.point, Color.red);

					string noteName = hit.transform.gameObject.name;
					Debug.Log("noteName: " + noteName);

					if (noteName == "Note1")
                    {
						hideTheClue(Clue1);
					}
					else if(noteName == "Note2")
                    {
						hideTheClue(Clue2);
					}
					else if (noteName == "Note3")
					{
						hideTheClue(Clue3);
					}
					else if (noteName == "Note4")
					{
						hideTheClue(Clue4);
					}
					else if (noteName == "Note5")
					{
						hideTheClue(Clue5);
					}
					else if (noteName == "Note6")
					{
						hideTheClue(Clue6);
					}
					else if(noteName == "flashlight")
                    {
						flashLight.SetActive(false);
						lightObj.SetActive(true);
                    }

					if (noteName == "person")
                    {
						person.SetActive(false);
						hiddenNote.SetActive(true);
						hiddenLights.SetActive(true);
						removeWall.SetActive(false);
					}


					if (noteName == "flotingEye")
                    {
						flotingEye.SetActive(false);
						Cursor.lockState = CursorLockMode.None;
						SceneManager.LoadScene("WinScene");

					}

				}


			}
		}
	}

	private void hideTheClue(GameObject clueName)
    {
		if (clueName.activeInHierarchy == true)
		{
			clueName.SetActive(false);
		}
		else
			clueName.SetActive(true);
	}



}
