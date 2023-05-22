using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    Collider rangeCol;
    bool targeting = false;
    public Transform target;
    public List<GameObject> unitList;
    public GameObject rangeTrigger;
    string targetType;

    // Start is called before the first frame update
    void Start()
    {
        rangeCol = GetComponent<Collider>();
        unitList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (targeting == true) {
            transform.LookAt(target, Vector3.left);
        }

        if (Input.GetKeyDown(KeyCode.T)) {
            foreach(GameObject unit in unitList) {
                Debug.Log(unit.name);
            }
        }

        Debug.Log(targetType);
    }

    public void ChangeTargetType(string targetString) {
         targetType = targetString;
    }

    void ChangeTarget() {
        if (targetType == "Furthest"){
            foreach(GameObject unit in unitList) {
                
            }
        }
    }
}
