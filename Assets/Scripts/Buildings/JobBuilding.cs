using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class JobBuilding : Building {

	int maxNumberWorkers;
	int working;
	Job job;

	protected JobBuilding(int maxNumberWorkers, Job job) {
		this.maxNumberWorkers = maxNumberWorkers;
		this.job = job;
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
		return true;
	}

	public bool quitJob(Villager villager) {
		working--;
		villager.quitJob ();
		return true;
	}

	public bool hasJobs(){
		return working < maxNumberWorkers;
	}
}
