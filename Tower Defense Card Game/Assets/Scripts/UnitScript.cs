using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent navMeshAgent;
    public GameObject pathNode;
    public List<GameObject> pathNodeList;
    public Transform PathingNodesHolder;
    public Transform SplitPathHolder;
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
        if (onSplitPath == true) {
            if (SplitPathHolder.gameObject.transform.childCount > nextSplitPathNodeNum) {
                if (Vector3.Distance(SplitPathHolder.GetChild(nextSplitPathNodeNum).gameObject.transform.position, transform.position) < 20f && atEnd == false)
                {
                    if (nextNode != null) {
                        nextSplitPathNodeNum++;
                        if (SplitPathHolder.gameObject.transform.childCount > nextSplitPathNodeNum) {
                            nextNode = SplitPathHolder.GetChild(nextSplitPathNodeNum).gameObject;
                        }
                    }
                }
            } else {
                onSplitPath = false;
                nextSplitPathNodeNum = 0;
            }
        } else {
            if (PathingNodesHolder.gameObject.transform.childCount > nextNodeNum) {
                if (Vector3.Distance(PathingNodesHolder.GetChild(nextNodeNum).gameObject.transform.position, transform.position) < 20f && atEnd == false)
                {
                    if (PathingNodesHolder.GetChild(nextNodeNum).gameObject.tag == "SplitPath")
                    {
                        onSplitPath = true;
                        pathNum = Random.Range(0,2);
                        if (pathNum == 1){
                            SplitPathHolder = PathingNodesHolder.GetChild(nextNodeNum).gameObject.transform;
                        } else {
                            SplitPathHolder = PathingNodesHolder.GetChild(nextNodeNum + 1).gameObject.transform;
                        }
                        nextNodeNum++;
                        nextNodeNum++;
                    }
                    if (onSplitPath == false) 
                    {
                        nextNodeNum++;
                        if (nextNode != null && PathingNodesHolder.gameObject.transform.childCount > nextNodeNum)
                        {
                            nextNode = PathingNodesHolder.GetChild(nextNodeNum).gameObject;  
                        }
                    } 
                }
            } else {
                atEnd = true;
            }
            
        }
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
