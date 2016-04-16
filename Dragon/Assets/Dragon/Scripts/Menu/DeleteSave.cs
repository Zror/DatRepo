using UnityEngine;
using System.Collections;

public class DeleteSave : MonoBehaviour {
    public void onClick()
    {
        PlayerPrefs.DeleteAll();
    }
}
