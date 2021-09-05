using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{

	public CharacterController2D controller;
	public Animator animator;
	int difficulty;
	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

	private GameObject[] players;

    void Start()
    {
		DontDestroyOnLoad(gameObject);
    }

    void Update()
	{

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetBool("IsJumping", true);
		}

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		}
		else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}

	}

	public void OnLanding()
	{
		animator.SetBool("IsJumping", false);
	}

	public void OnCrouching(bool isCrouching)
	{
		animator.SetBool("IsCrouching", isCrouching);
	}

	void FixedUpdate()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}

    private void OnLevelWasLoaded(int level)
    {
		difficulty = gameObject.GetComponent<difficulty>().diff;
		FindStartPos(difficulty);

		players = GameObject.FindGameObjectsWithTag("Player");
		if(players.Length > 1)
        {
			Destroy(players[1]);
        }
    }

	void FindStartPos(int difficulty)
    {
		string name = "Start position (" + difficulty + ")";


		transform.position = GameObject.Find(name).transform.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.gameObject.tag == "Platform")
        {
			this.transform.parent = collision.transform;
        }
	}

    private void OnCollisionExit2D(Collision2D collision)
    {
		if (collision.gameObject.tag == "Platform")
		{
			this.transform.parent = null;
		}
	}
}