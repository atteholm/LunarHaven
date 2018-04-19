﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{

    class Items
    {
        string name;
        int money;
        public Items(string name,int money) {
            this.name = name;
            this.money = money;
        }

        public string Item
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public int Money
        {
            get
            {
                return money;
            }
            set
            {
                money = value;
            }
        }
    }
}