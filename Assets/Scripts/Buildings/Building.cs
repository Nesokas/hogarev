using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour {

	int maxNumberWorkers;
	int working;
	Job job;
	bool isHouse;

	public Transform entry;

	protected Building(int maxNumberWorkers, Job job, bool isHouse) {
		this.maxNumberWorkers = maxNumberWorkers;
		this.job = job;
		this.isHouse = isHouse;
        working = 0;
	}

	public void Start(){
		JobsManager.instance.addBuilding (this);
	}

	public bool hire(Villager villager) {
		if (working >= maxNumberWorkers)
			return false;

		working++;
		villager.setJob (this);
		if(isHouse)
			villager.moveIn(this);
		return true;
	}

	public bool quitJob(Villager villager) {
		working--;
		villager.quitJob ();
		if(isHouse)
			villager.moveOut();
		return true;
	}

	public bool hasJobs(){
		return working < maxNumberWorkers;
	}

	public abstract Vector3 getEnterPosition ();
}
