using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavTilesScript : MonoBehaviour
{
   Renderer rend;
    public Vector3 nodePoint;

    bool navDone;
    // Start is called before the first frame update
    void Start()
    {
        /*rend = GetComponent<Renderer>();
        rend.enabled = false;*/

        nodePoint = transform.position;
        navDone = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*int layerMask = 1 << 8;
        layerMask = ~layerMask;

        if (navDone == false) {
            RaycastHit hit;
            if (Physics.Raycast(rayPoint.transform.position, rayPoint.transform.TransformDirection(Vector3.down), out hit, 100, layerMask))
            {
                Debug.DrawRay(rayPoint.transform.position, rayPoint.transform.TransformDirection(Vector3.down) * 100, Color.green, 100);
                nodePoint = hit.point;
                navDone = true;
            } else 
            {
                Debug.Log("Did Not Hit");
                navDone = true;
            }
        }*/ 
    }
}
