using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : MonoBehaviour {

	enum Gender {
		Male,
		Female
	}

	public int age;
    public string firstName;
	Gender gender;
	public JobBuilding job;

    public Family family;

    Lexic.NameGenerator namegen;

    void Start()
    {
        namegen = GameObject.FindWithTag("NameGenerator").GetComponent<Lexic.NameGenerator>();
        string familyName = namegen.GetNextRandomName();
        firstName = namegen.GetNextRandomName();
        family = new Family(familyName, this, null);
    }

    internal Family getFamily()
    {
        return family;
    }

    public void setJob(JobBuilding job){
		this.job = job;
	}

	public bool hasJob(){
		return job != null;
	}

	public void quitJob(){
		this.job = null;
	}

	public void moveIn(JobBuilding building) {}

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

    internal void newFamily()
    {
        family = new Family(namegen.GetNextRandomName(), this, null);
    }

    internal Vector3 getHomePosition()
    {
        if(hasHome())
            return family.getHome().getEnterPosition();

        return transform.position;
    }

    private bool hasHome()
    {
        return family.getHome() != null;
    }
}
