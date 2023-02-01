using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnScript : MonoBehaviour
{
    public bool endTurn;
    // Start is called before the first frame update
    void Start()
    {
        endTurn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick() 
    {
        endTurn = true;
        Debug.Log("Clicked!");
    }
}
