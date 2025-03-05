using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{

    public bool isDone, multipleSolutions;
    public int numberOfSolutions, completedSolution;

    // Start is called before the first frame update
    void Start()
    {
        isDone = false;
        completedSolution = -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isComplete()
    {
        return isDone;
    }

    public void setSolved(int solution)
    {
        if(!multipleSolutions && solution != 0)
        {
            Debug.LogError("MissMatch puzzle solution type");
        } else if (multipleSolutions && solution > numberOfSolutions)
        {
            Debug.LogError("The solution does not match the number of solutions");
        }
        else
        {
            isDone=true;
            completedSolution = solution;
        }


        
    }


}
