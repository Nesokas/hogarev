using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constructor : Building {

	public Constructor() : base(2, Job.Builder, false) { }

	public override Vector3 getEnterPosition(){
		if (entry != null)
			return entry.position;
		
		return transform.position;
	}
}
