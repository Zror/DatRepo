using UnityEngine;
using System.Collections;

public class DeleteSave : MonoBehaviour {
    public void onClick()
    {
        PlayerPrefs.DeleteAll();
        Application.LoadLevel(0);
    }
}
