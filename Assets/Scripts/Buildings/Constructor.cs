using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constructor : JobBuilding {

	public Constructor() : base(2, Job.Builder) { }

	public override Vector3 getEnterPosition(){
		if (entry != null)
			return entry.position;
		
		return transform.position;
	}
}
