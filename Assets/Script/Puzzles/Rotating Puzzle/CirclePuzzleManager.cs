using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclePuzzleManager : MonoBehaviour
{
    public GameObject [] rings;
    public float bufferRadius = 15;
    public GameObject [] doors;
    public float []solution1,solution2, solution3, solution4, solution5;
    private float[][] solutions;


    // Start is called before the first frame update
    void Start()
    {
        solutions[0] = solution1;
        solutions[1] = solution2;
        solutions[2] = solution3;
        solutions[3] = solution4;
        solutions[4] = solution5;
        if (solutions.Length != doors.Length)
        {
            Debug.LogError("the number of possible solutions does not match the number of doors");
        }
        if(solutions.Length == 0)
        {
            Debug.LogError("the number of solutions for this puzzzle is set to 0");
        }else if (solutions[0].Length != rings.Length)
        {
            Debug.LogError("One of the solutions does not match the number of rings");
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        //set all the doors to false
        foreach(GameObject door in doors)
        {
            door.active = false;
        }

        int k = checkValidSolution();
        //did we find a solution?
        if (k!=-1)//yes
        {
            doors[k].SetActive(true);//set the index to be true
        }

    }

    //returns -1 if no solution is found
    public int checkValidSolution()
    {
        int i = 0;
        foreach (float[] solution in solutions)
        {
            bool solved = true;
            for(int j = 0; j < solution.Length; j++)
            {
                //in degrees
                float ringAngle = Mathf.Atan2(rings[j].transform.right.y, rings[j].transform.forward.x) * Mathf.Rad2Deg;

                //if part of the solution does not match then we skip
                if (Mathf.Abs(ringAngle - solution[j]) > bufferRadius)
                {
                    solved = false;
                    break;
                }
            }
            if (solved)
            {
                return i;
            }
        }

        return -1;
    }
}
