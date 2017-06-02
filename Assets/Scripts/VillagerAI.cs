using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VillagerAI : MonoBehaviour {

	public enum DayState
    {
        IDLE,
        WALK_HOME,
        AT_HOME,
        WALK_WORK,
        AT_WORK,
        GET_SUPPLIES,
        WORKING,
        BUY_SUPPLIES
    }

    public enum JobState
    {
        UNEMPLOYED,
        HAS_JOB
    }

    public enum HomeState
    {
        HOMELESS,
        HAS_HOME
    }

    public DayState dayState;
    public JobState jobState;
    public HomeState homeState;
    public NavMeshAgent agent;
	private Villager villager;

	// Use this for initialization
	void Start () {
        dayState = DayState.IDLE;
        jobState = JobState.UNEMPLOYED;
        homeState = HomeState.HOMELESS;
		villager = GetComponent<Villager> ();
		agent = GetComponent<NavMeshAgent> ();

		StartCoroutine (VDSM ());
        StartCoroutine(VJSM());
        StartCoroutine(VHSM());
    }
	
	IEnumerator VDSM(){
		while(true) {
			switch (dayState) {
                case DayState.IDLE:
                    idle();
                    break;
                case DayState.WALK_WORK:
                    walkWork();
                    break;
                case DayState.AT_WORK:
                    atWork();
                    break;
                case DayState.WORKING:
                    working();
                    break;
                case DayState.WALK_HOME:
                    walkHome();
                    break;
                case DayState.AT_HOME:
                    atHome();
                    break;
			}
			yield return null;
		}
	}

    private void atHome()
    {
        if (homeState != HomeState.HAS_HOME)
        {
            dayState = DayState.IDLE;
        }
        else if (JobsManager.instance.isWorkingTime())
        {
            dayState = DayState.WALK_WORK;
            Vector3 home_entry_position = transform.position;
            home_entry_position.x = villager.getHomePosition().x;
            home_entry_position.z = villager.getHomePosition().z;
            transform.position = home_entry_position;
        }
    }

    private void walkHome()
    {
        if (homeState == HomeState.HAS_HOME)
        {
            agent.enabled = true;
            agent.destination = villager.getHomePosition();
        }
        else
        {
            agent.enabled = false;
            dayState = DayState.IDLE;
        }
    }

    private void atWork()
    {
        if(jobState != JobState.HAS_JOB)
        {
            dayState = DayState.IDLE;
        } else if (!JobsManager.instance.isWorkingTime())
        {
            dayState = DayState.WALK_HOME;
            Vector3 work_entry_position = transform.position;
            work_entry_position.x = villager.getWorkPosition().x;
            work_entry_position.z = villager.getWorkPosition().z;
            transform.position = work_entry_position;
        }
    }

    private void idle()
    {
        if(jobState == JobState.HAS_JOB && JobsManager.instance.isWorkingTime())
        {
            dayState = DayState.WALK_WORK;
        }
    }

    IEnumerator VJSM()
    {
        while (true)
        {
            switch (jobState)
            {
                case JobState.UNEMPLOYED:
                    searchForJob();
                    break;
                case JobState.HAS_JOB:
                    isJobDestroied();
                    break;
            }
            yield return null;
        }
    }

    

    IEnumerator VHSM()
    {
        while (true)
        {
            switch (homeState)
            {
                case HomeState.HOMELESS:
                    searchForHome();
                    break;
                case HomeState.HAS_HOME:
                    isHomeDestroyed();
                    break;
            }
            yield return null;
        }
    }

    private void isHomeDestroyed()
    {
        
    }

    private void searchForHome()
    {
        if (HouseManager.instance.applyForHouse(villager))
        {
            homeState = HomeState.HAS_HOME;
        }
    }

    private void isJobDestroied()
    {
        if (villager.job == null)
            jobState = JobState.UNEMPLOYED;
    }

    private void walkWork() {
        if(jobState == JobState.HAS_JOB)
        {
            agent.enabled = true;
            agent.destination = villager.getWorkPosition();
        } else
        {
            agent.enabled = false;
            dayState = DayState.IDLE;
        }
        
	}

	private void working() {

	}

	private void searchForJob(){
		if (JobsManager.instance.applyForJob (villager)) {
			jobState = JobState.HAS_JOB;
		}
	}

	void OnTriggerEnter(Collider other) {

        Building building = other.gameObject.GetComponentInParent<Building>();

		if (dayState == DayState.WALK_WORK && building == villager.job) {
            dayState = DayState.AT_WORK;
			agent.enabled = false;
			Vector3 work_position = transform.position;
			work_position.x = villager.getAtWorkPosition ().x;
			work_position.z = villager.getAtWorkPosition ().z;
			transform.position = work_position;
		} else if (dayState == DayState.WALK_HOME && building == villager.getHome())
        {
            dayState = DayState.AT_HOME;
            agent.enabled = false;
            Vector3 home_position = transform.position;
            home_position.x = villager.getAtHomePosition().x;
            home_position.z = villager.getAtHomePosition().z;
            transform.position = home_position;
        }
}
}
