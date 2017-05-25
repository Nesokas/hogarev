using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobsManager : MonoBehaviour {

	public static JobsManager instance;
	public List<Building> buildings;

	public void Awake(){
		if (instance == null)
			instance = this;
	}

	public void addBuilding(Building building) {
		buildings.Add (building);
	}

	public bool applyForJob(Villager villager) {
		foreach (Building building in buildings) {
			if (building.hasJobs()) {
				building.hire (villager);
				return true;
			}
		}

		return false;
	}

    internal bool isWorkingTime()
    {
        return true;
    }
}
