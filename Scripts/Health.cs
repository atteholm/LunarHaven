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
        private static int startHealth = 3;
        private int currentHealth;
        public Text hptext;
        
        
        void Start()
        {
           
            hptext = GameObject.Find("Health").GetComponent<Text>();
            ResetHealth();
            
        }
        /// <summary>
        /// Updates health
        /// </summary>
        /// <returns></returns>
        public void UpdateHealth()
        {
            if (currentHealth > 0) { 
                currentHealth = currentHealth - 1;
                GetHealth();
            }
        }
       
        
        public void ResetHealth()
        {
            currentHealth = startHealth;
        }
        public void GetHealth()
        {
            hptext.text = "Heath: " + currentHealth;
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

