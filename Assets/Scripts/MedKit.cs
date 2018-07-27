using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKit : Item
{
    private int healing_power = 10;

    public int HealingPower
    {
        get { return healing_power; }
        //set { healing_power = value; }
    }
}