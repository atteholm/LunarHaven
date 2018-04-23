using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    class Health:MonoBehaviour
    {
        
        private int currentHealth;
        public Text hptext;
        private bool = hasBeenHit = false;
        
        
        void Start()
        {
           
            hptext = GameObject.Find("Health").GetComponent<Text>();
            ResetHealth();
            
        }
        
        /*Checks if health is 1 == dead and if not then reduce hp with 
        1 if character has not been hit
        */
        public void UpdateHealth()
        {
            if( currentHealth == 1){
                ChangeScene.Restart();
            }
            else if (currentHealth > 0 && hasBeenHit == false) { 
                currentHealth = currentHealth - 1;
                GetHealth();
            }
        }
       
        //Resets health
        public void ResetHealth()
        {
            currentHealth = 3 + PowerUps.bonusHealth;
        }
        public void GetHealth()
        {
            hptext.text = "Heath: " + currentHealth;
        }
        public void GracePeriod()
        {
            hasBeenHit = true;
            Invoke("NotInvunerable", 3);
        }
        private void NotInvunerable()
        {
            hasBeenHit = false;
        }


        void Update()
        {
            hptext.text = "Health: " + currentHealth;
            if (Input.GetKeyDown(KeyCode.L))
            {
                ResetHealth();
            }
        }
    }
}

