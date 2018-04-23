/// <summary>
/// Player controller.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts
{
    public class PlayerController : MonoBehaviour
    {

        // Fields
        private float playerSpeed = 0, jumpHeight = 0, maxSpeed = 7;
        Rigidbody2D playerRigidBody;
        Health hp;
        
        private bool doubleJump = PowerUps.doubleJump, collisionCheck = false, disableJump = false, run = PowerUps.run;
        AudioSource jumpSound;
        

        // Check collision and run actions depending on 
       
        void OnCollisionExit2D(Collision2D collision)
        {
            Debug.Log("Collision exit");
            disableJump = false;
            collisionCheck = false;
        }

        // Use this for initialization
        void Start()
        {
            playerRigidBody = GetComponent<Rigidbody2D>();
            hp = GameObject.Find("Player").AddComponent<Health>();
			jumpSound = GameObject.Find ("JumpSound").GetComponent<AudioSource> ();
          
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("Collided");
            // Death when collided with hazards
            if (collision.gameObject.name == "Hazards")
            {
                hp.UpdateHealth();
				collisionCheck = true;
            }
            
            // Collect points and items
			else if (collision.transform.parent.name == "Items") {
				if (collision.transform.name == "FuelCan") {
					ChangeScene.StringManager ("HubMap");
				}

				Score.score += 100;
				Destroy (collision.gameObject);

			}else {
				collisionCheck = true;
			}
        }

        // Constantly running
        void Update()
        {
            // Check any x-axis movement. If not detected, let player speed slow down.
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    if (playerSpeed > -maxSpeed)
                    {
                        playerRigidBody.velocity = new Vector2(playerSpeed, jumpHeight);
                        playerSpeed -= 0.4f;
                    }
                    else
                    {
                        playerRigidBody.velocity = new Vector2(playerSpeed, jumpHeight);
                    }
                }
                else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    if (playerSpeed < maxSpeed)
                    {
                        playerRigidBody.velocity = new Vector2(playerSpeed, jumpHeight);
                        playerSpeed += 0.4f;
                    }
                    else
                    {
                        playerRigidBody.velocity = new Vector2(playerSpeed, jumpHeight);
                    }
                }
            }
            
            // Slows the player down by constantly decreasing the current speed.
            else
            {
                playerSpeed -= playerSpeed / 32;
                playerRigidBody.velocity = new Vector2(playerSpeed, jumpHeight);
            }
            
            // The jump script.
            if (Input.GetKeyDown(KeyCode.Space) && (collisionCheck == true || doubleJump == true) && disableJump == false)
            {
                jumpHeight = 8;
                jumpSound.Play();

            }
				

            // "Gravity" makes the player fall until a collision is detected.
            if (jumpHeight > -14 && collisionCheck == false)
            {
                if (jumpHeight > -14)
                {
                    jumpHeight -= 0.4f;
                }

            }
			// Prevents autojumping by resetting the jumpheight after space is not pressed anymore.
            else if (collisionCheck == true && !(Input.GetKey(KeyCode.Space)))
            {
                jumpHeight = 0;
            }

			// Run
			if (Input.GetKey (KeyCode.LeftShift) && run == true) {
				maxSpeed = 12;
			} else {
				maxSpeed = 7;
			}

			// Manual restart
			if (Input.GetKeyDown (KeyCode.R)){
				ChangeScene.Restart ();
			}

			// Cheats
			if (Input.GetKey (KeyCode.Tab) && Input.GetKey (KeyCode.P))
			{
				Debug.Log ("Cheats activated! and bonushealt = " + PowerUps.bonusHealth);
				PowerUps.ActivatePowerUp ("run");
				PowerUps.ActivatePowerUp ("doubleJump");
				PowerUps.ActivatePowerUp ("bonusHealth");
			}

			// Restart level when player falls off map.
			if (transform.position.y < -6) {
				ChangeScene.Restart ();
			}
        }
    }
}
