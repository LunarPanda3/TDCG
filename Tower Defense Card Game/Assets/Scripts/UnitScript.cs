using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent navMeshAgent;
    public GameObject pathNode;
    public List<GameObject> pathNodeList;
    public Transform PathingNodesHolder;
    public Transform SplitPathHolder1;
    public Transform SplitPathHolder2;
    GameObject nextNode;
    int nextNodeNum;
    int nextSplitPathNodeNum;
    bool followUpdated;
    bool atEnd = false;
    bool onSplitPath = false;
    int pathNum = 0;

    void Awake() 
    {
        followUpdated = false;
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        nextNodeNum = 0;
        nextSplitPathNodeNum = 0;
        nextNode = PathingNodesHolder.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(PathingNodesHolder.GetChild(nextNodeNum).gameObject.transform.position, transform.position) < 20f && atEnd == false)
        {
            if (PathingNodesHolder.GetChild(nextNodeNum).gameObject.name == "SplitPath1" || PathingNodesHolder.GetChild(nextNodeNum).gameObject.name == "SplitPath2")
            {
                onSplitPath = true;
                pathNum = Random.Range(0,2);
            }
            if (onSplitPath == false) 
            {
                nextNodeNum++;
                if (nextNode != null)
                {
                    nextNode = PathingNodesHolder.GetChild(nextNodeNum).gameObject;  
                } else 
                {
                    Debug.Log("At the end");
                    atEnd = true;
                    Destroy(this);
                }
            } else 
            {
                nextSplitPathNodeNum++;
                if (nextNode != null)
                {
                    if (pathNum == 1)
                    {
                        nextNode = SplitPathHolder1.GetChild(nextSplitPathNodeNum).gameObject;  
                    } else {
                        nextNode = SplitPathHolder2.GetChild(nextSplitPathNodeNum).gameObject;  
                    }
                } else 
                {
                    Debug.Log("At the end");
                    onSplitPath = false;
                }
               
            }
            //Debug.Log("Next Point");
        }
        /*if (Vector3.Distance(PathingNodesHolder.GetChild(nextNodeNum).gameObject.transform.position, transform.position) < 20f)
        {
            nextNodeNum++;
            nextNode = PathingNodesHolder.GetChild(nextNodeNum).gameObject;
            Debug.Log("Next Point");
        }*/

        navMeshAgent.SetDestination(nextNode.transform.position);
    }

    public void CreatePathingNode() {
        pathNodeList.Add((GameObject)Instantiate(pathNode, transform.position, Quaternion.identity, PathingNodesHolder));  
    }

    public void DeletePathingNode() {
        GameObject.DestroyImmediate(pathNodeList[pathNodeList.Count-1]);
        pathNodeList.RemoveAt(pathNodeList.Count-1);
    }
}
