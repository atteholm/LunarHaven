using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    class Health
    {
        int health = 3;
        private Text text;
        //Timer timer = new Timer(3000);
        public Health()
        {

        }
        /// <summary>
        /// Updates health
        /// </summary>
        /// <returns></returns>
        public int UpdateHealth()
        {
            health--;
            return health;
        }
        /// <summary>
        /// Return Health
        /// </summary>
        /// <returns>health</returns>
        public int GetHealth()
        {
            return health;

        }
        /// <summary>
        /// Shows health
        /// </summary>
        public void ShowHealth()
        {
            text.text = "Health: " + health;
        }
        /// <summary>
        /// Resets health
        /// </summary>
        public void ResetHealth()
        {
            health = 3;
        }
        void Start()
        {
            text = GameObject.Find("Health").GetComponent<Text>();
        }


        void Update()
        {
            /*text.text = "Health: " + health;
            if (Input.GetKeyDown(KeyCode.K))
            {
                health++;
            }*/
        }
    }
}

