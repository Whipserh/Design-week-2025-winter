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
        solutions = new float[5][];
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
            door.SetActive(false);
        }

        int k = checkValidSolution();
        //did we find a solution?
        //Debug.Log(k);
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
            //Debug.Log(solution.ToString);

            bool solved = true;
            for(int j = 0; j < solution.Length; j++)
            {
                
                //in degrees
                float ringAngle = Mathf.Atan2(rings[j].transform.right.y, rings[j].transform.right.x) * Mathf.Rad2Deg;
                //Debug.Log(rings);
                //if part of the solution does not match then we skip


                //check to see if the angles are too close to the 0/360 line
                int upperAngle = Mathf.Min(mod((int)(int)ringAngle, 360), mod((int)solution[j], 360));
                int lowerAngle = Mathf.Max(mod((int)ringAngle, 360), mod((int)solution[j], 360));
                if(upperAngle < bufferRadius && lowerAngle < bufferRadius)
                    if (upperAngle + 360 - lowerAngle <= bufferRadius) continue;//if we are near the middle then we account for that, if its near the middle and 
                if (Mathf.Abs(mod((int)ringAngle,360) - mod((int)solution[j],360)) > bufferRadius)//else we are not too close to the origin
                {
                    //Debug.Log((ringAngle % 360));
                    //Debug.Log("ring "+i + " " + (ringAngle % 360));
                    //Debug.Log("solution " + i + " " + solution[j]);
                    //Debug.Log("solution " + i + "is false at " +j);
                    solved = false;
                    break;
                }
            }
            if (solved)
            {
                return i;
            }
            i++;
        }

        return -1;
    }//end check


    public int mod (int x, int modulous)
    {
        if(x%modulous<0)
        return (x%modulous) + modulous;
        return x%modulous;
    }


}
