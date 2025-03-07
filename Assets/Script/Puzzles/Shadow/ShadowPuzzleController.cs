using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class ShadowPuzzleController : MonoBehaviour
{
    public List<Transform> constellationPieces;

    public List<bool> flipablePieces;

    public List<Transform> constellationGoals;

    public List<bool> constellationsInPlace;

    public TextMeshProUGUI completeText;

    public float graceRangeSpacing;
    public int graceRangeRotation;

    private Transform lastSelected;

    public void SetLastSelected(GameObject SetLastSelected)
    {
        lastSelected = SetLastSelected.transform;
        Debug.Log("new selected object: " + lastSelected);
    }

    public float turnSpeed = 1;

    // Update is called once per frame
    void Update()
    {
        if(lastSelected != null)
        {
                if (Input.GetMouseButton(1))
            {
                Vector3 transformVector = new Vector3(0, 0, -turnSpeed * Time.deltaTime);
                lastSelected.transform.Rotate(transformVector);
                //Debug.Log("Turning left.");
            }
        }

        for (int i = 0; i < constellationPieces.Count; i++)
        {
            if (!CloseEnough(constellationPieces[i], constellationGoals[i], flipablePieces[i]))
            {
                constellationsInPlace[i] = false;
                return;
            }
            else constellationsInPlace[i] = true;
        }

        if (!completeText.IsActive()) completeText.enabled = true;
    }

    private bool CloseEnough(Transform target, Transform goal, bool isFlipable)
    {
        if (isFlipable && target.position.x < goal.position.x + graceRangeSpacing && target.position.x > goal.position.x - graceRangeSpacing && target.position.y < goal.position.y + graceRangeSpacing && target.position.y > goal.position.y - graceRangeSpacing && (Quaternion.Angle(target.rotation, goal.rotation) < graceRangeRotation || Quaternion.Angle(target.rotation, goal.rotation) > 180 - graceRangeRotation)) return true;
        if (!isFlipable && target.position.x < goal.position.x + graceRangeSpacing && target.position.x > goal.position.x - graceRangeSpacing && target.position.y < goal.position.y + graceRangeSpacing && target.position.y > goal.position.y - graceRangeSpacing && Quaternion.Angle(target.rotation, goal.rotation) < graceRangeRotation) return true;
        return false;
    }
}
