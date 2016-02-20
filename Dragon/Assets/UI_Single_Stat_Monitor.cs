using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections;

public class UI_Single_Stat_Monitor : MonoBehaviour {

    public HealthMonitor source = null;
    public int Use_Stat_Number = 0;
    public RectTransform Trans = null;

    private int max = 100;
    private float orig_x = 121;
    private bool hasStatMonitor = false;

	// Use this for initialization
	void Start ()
    {
        GetStatMonitor();
        if (Use_Stat_Number > 2 || Use_Stat_Number < 0)
        {
            Use_Stat_Number = Mathf.Clamp(Use_Stat_Number, 0, 2);
        }
        if (Trans == null)
        {
            // Thats bad!!!
            Debug.LogError("[!] UI Stat Monitor must be tied to a a RectTransform on INIT!! It can't work without it!");
        }
        else
        {
            orig_x = Trans.sizeDelta.x;
           
        }

	}
	
    void Update()
    {
        // Make sure this doesnt move
        /*
        Vector2 zz = gameObject.transform.position;
        Vector2 vpP = Camera.main.WorldToViewportPoint(zz);

        Trans.anchorMin = vpP;
        Trans.anchorMax = vpP;
        */
    }

	// Update is called once per frame
	void FixedUpdate ()
    {
        //Trans.S
        float xx = CalcTrans();
        float yy = Trans.sizeDelta.y;
        //Debug.Log("[@] x: " + xx + " , y:" + yy+" (xorg: "+this.orig_x+", )");
        Trans.sizeDelta = new Vector2(xx,yy);
        
	}

    float CalcTrans()
    {
        GetStatMonitor();
        if (source == null)
        {
            //Debug.Log("[!] Can't find Stat Monitor! ");
            return orig_x;
        }
        float zz = Mathf.Max(Mathf.Max(source.GetStatAtIndex(Use_Stat_Number),0f) / this.max , 0.01f);
        //Debug.Log("[@@] zz:" + zz + " HP:" + source.HP);
        return orig_x * zz;
    }

    void GetStatMonitor()
    {
        if (hasStatMonitor == true) { return; }
        if (source == null)
        {
            // Get a source

            source = FindObjectsOfType<HealthMonitor>().First(t => t.tag == Globals.TAGS.Player);
            if (source == null)
            {
                // Thats bad!
                return;
            }

            max = source.GetLimitAtIndex(Use_Stat_Number);
        }
        else
        {

            hasStatMonitor = true;
        }
    }
    //
}
