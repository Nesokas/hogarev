using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobsManager : MonoBehaviour {

	public static JobsManager instance;
	public List<JobBuilding> buildings;

    public bool workingTime;

	public void Awake(){
		if (instance == null)
			instance = this;

        workingTime = true;
	}

	public void addBuilding(JobBuilding building) {
		buildings.Add (building);
	}

	public bool applyForJob(Villager villager) {
		foreach (JobBuilding building in buildings) {
			if (building.hasJobs()) {
				building.hire (villager);
				return true;
			}
		}

		return false;
	}

    internal bool isWorkingTime()
    {
        return workingTime;
    }
}
