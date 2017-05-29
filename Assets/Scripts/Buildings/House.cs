using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : Building {

    Family family;

	void Start () {
        HouseManager.instance.addHouse(this);
	}

    internal bool isOccupied()
    {
        return family == null;
    }

    internal void buy(Villager villager)
    {
        family = villager.getFamily();
        family.setHome(this);
    }

    public override Vector3 getEnterPosition()
    {
        if (entry != null)
            return entry.position;

        return transform.position;
    }
}
