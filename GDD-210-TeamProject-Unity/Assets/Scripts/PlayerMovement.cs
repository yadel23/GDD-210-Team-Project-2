using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public CharacterController CC;
	public float MoveSpeed;
	public float Gravity = -9.8f;
	public float JumpSpeed;

	public float verticalSpeed;

	public Transform CamTransform;

	public GameObject Clue1;

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
					if (noteName == "Note1")
                    {

						hideTheClue(Clue1);
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
