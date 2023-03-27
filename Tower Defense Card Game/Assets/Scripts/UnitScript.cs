using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent navMeshAgent;
    public GameObject pathNode;
    public List<GameObject> pathNodeList;
    public Transform PathingNodesHolder;
    GameObject nextNode;
    int nextNodeNum;
    bool followUpdated;

    void Awake() 
    {
        followUpdated = false;
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        nextNodeNum = 0;
        nextNode = PathingNodesHolder.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(PathingNodesHolder.GetChild(nextNodeNum).gameObject.transform.position, transform.position) < 20f)
        {
            nextNodeNum++;
            nextNode = PathingNodesHolder.GetChild(nextNodeNum).gameObject;
            Debug.Log("Next Point");
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
