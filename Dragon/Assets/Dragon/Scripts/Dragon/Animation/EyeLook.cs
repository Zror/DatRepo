using UnityEngine;
using System.Collections;

public class EyeLook : MonoBehaviour {

    public Vector2 lookDirection = Vector2.zero;
    public float maximumEyeRange = 0.1f;
    public float eyeSpeed = 10;

    private Vector3 targetPosition = Vector3.zero;

	// Update is called once per frame
	void Update ()
    {
        // Mouse tracking script. Note: Hacky, but hilarious.
        lookDirection.x = Input.mousePosition.x - Screen.width / 2;
        lookDirection.y = Input.mousePosition.y - Screen.height / 2;
        lookDirection.Normalize();

        targetPosition.x = lookDirection.x * maximumEyeRange;
        targetPosition.y = lookDirection.y * maximumEyeRange;

        this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, targetPosition, Time.deltaTime * eyeSpeed);
    }
}
