using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour {
    public Transform entry;
    public abstract Vector3 getEnterPosition();
}
