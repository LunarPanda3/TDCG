using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject EndTurnButton;
    bool endTurn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EndTurnButton.GetComponent<EndTurnScript>().endTurn == true){
            EndTurn();
        }
    }

    void EndTurn() 
    {
        EndTurnButton.GetComponent<EndTurnScript>().endTurn = false;
        Debug.Log("Turn Ended!");
    }
}
