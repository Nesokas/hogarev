using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : MonoBehaviour {

	enum Gender {
		Male,
		Female
	}

	int age;
	Gender gender;
	Villager spounce;
	List<Villager> children;
	public Building job;
	Building home;

	public void setJob(Building job){
		this.job = job;
	}

	public bool hasJob(){
		return job != null;
	}

	public void quitJob(){
		this.job = null;
	}

	public void moveIn(Building building) {}

	public void moveOut() {}

	public Vector3 getWorkPosition() {
		if (hasJob ()) {
			return job.getEnterPosition ();
		}

		return transform.position;
	}

    internal Vector3 getWorkingPosition()
    {
        if (hasJob())
        {
            return job.transform.position;
        }

        return transform.position;
    }
}
