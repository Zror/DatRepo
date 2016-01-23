using System;
using UnityEngine;
using System.Collections;
using System.Linq;

//Creates a floating origin along the X axis.
public class FloatingOrigin : MonoBehaviour
{
    [Range(0, 1000)]
    public float maxOriginPoint;
    [Range(-1000,0)]
    public float clearChildAfter;
    public GameObject trackedObject;

    public event EventHandler<FloatingOriginShiftEventArgs> OnOriginShift;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	    if (trackedObject.transform.position.x - this.transform.position.x > maxOriginPoint)
	    {
	        TransformChildren();
	    }
	}

    private void TransformChildren()
    {
        //Shift objects
        var childTransforms = this.transform.GetComponentsInChildren<Transform>().Where((t) => t.parent == this.transform);
        foreach (var trans in childTransforms)
        {
            trans.position += Vector3.left*maxOriginPoint;

            //Automatically clear objects which are to far away from the playable area
            if (trans.position.x - this.transform.position.x < clearChildAfter)
            {
                Destroy(trans.gameObject);
            }
        }

        //Notify of Shift
        NotifyOriginShift();
    }

    private void NotifyOriginShift()
    {
        if (OnOriginShift != null)
        {
            OnOriginShift.Invoke(this, new FloatingOriginShiftEventArgs() { ShiftAmount = maxOriginPoint });
        }
    }

    private void OnDrawGizmos()
    {
        //Draw the front, back and origin of the floating origin when in the editor.
        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector3(maxOriginPoint + this.transform.position.x, -1000, 0),
            new Vector3(maxOriginPoint + this.transform.position.x, 1000, 0));

        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(clearChildAfter + this.transform.position.x, -1000, 0),
            new Vector3(clearChildAfter + this.transform.position.x, 1000, 0));

        Gizmos.color = Color.grey;
        Gizmos.DrawLine(new Vector3(this.transform.position.x, -1000, 0),
            new Vector3(this.transform.position.x, 1000, 0));
    }
}

public class FloatingOriginShiftEventArgs : EventArgs
{
    public float ShiftAmount { get; set; }
}