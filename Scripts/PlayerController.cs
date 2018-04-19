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
        
        private bool doubleJump = false, collisionCheck = false, disableJump = false;
        

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
            
          
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("Collided");
            if (collision.gameObject.name == "Hazards")
            {
                ChangeScene.StringManager ("Level1");
               
                
            }
            collisionCheck = true;
        }

        void Update()
        {
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
            else
            {
                playerSpeed -= playerSpeed / 32;
                playerRigidBody.velocity = new Vector2(playerSpeed, jumpHeight);
            }

            if (Input.GetKeyDown(KeyCode.Space) && (collisionCheck == true || doubleJump == true) && disableJump == false)
            {
                jumpHeight = 8;
            }

            if (jumpHeight > -8 && collisionCheck == false)
            {
                if (jumpHeight > -8)
                {
                    jumpHeight -= 0.4f;
                }

            }
            else if (collisionCheck == true && !(Input.GetKey(KeyCode.Space)))
            {
                jumpHeight = 0;
            }
        }
    }
}
