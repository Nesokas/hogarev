using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseManager : MonoBehaviour {

	public static HouseManager instance;
	public List<House> houses;

	public void Awake(){
		if (instance == null)
			instance = this;
	}

	public void addHouse(House house) {
		houses.Add (house);
	}

	public bool applyForHouse(Villager villager) {
		foreach (House house in houses) {
			if (house.isOccupied()) {
				house.buy (villager);
				return true;
			}
		}

		return false;
	}
}
