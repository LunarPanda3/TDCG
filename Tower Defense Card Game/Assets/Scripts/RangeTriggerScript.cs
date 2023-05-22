using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeTriggerScript : MonoBehaviour
{
    Collider rangeCol;
    bool targeting = false;
    public Transform target;
    GameObject parentTower;

    // Start is called before the first frame update
    void Start()
    {
        rangeCol = GetComponent<Collider>();
        //parentTower = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (targeting == true) {
            transform.LookAt(target, Vector3.left);
        }

        //Debug.Log(targetType);
    }

    void OnTriggerEnter(Collider col) {
        if (col.tag == "Unit") {
            // add unit to list
            GetComponentInParent<TowerScript>().unitList.Add(col.gameObject);
        }
    }

    void OnTriggerExit(Collider col) {
        if (col.tag == "Unit") {
            // add unit to list
            GetComponentInParent<TowerScript>().unitList.Remove(col.gameObject);
        }
    }
}
