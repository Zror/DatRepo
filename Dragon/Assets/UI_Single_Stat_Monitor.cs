using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections;

public class UI_Single_Stat_Monitor : MonoBehaviour {

    public HealthMonitor source = null;
    public RectTransform Trans = null;
    public Image img = null;
    public int Use_Stat_Number = 0;
    /*
    How to use:
            0 = HP
            1 = Stamina
            2 = Flame
            3 (DEBUG! for use with SIN or COS)
    */
    public float atx = 0;
    private int max = 100;
    private float len_x = 121f; // Do not rewrite after INIT!
    private float left_x = 32.5f; // Do not rewrite after INIT!
    private float cur_x = -1;

    private bool hasStatMonitor = false;

	// Use this for initialization
	void Start ()
    {

	}

    void Awake()
    {
        GetStatMonitor();
        if (Use_Stat_Number > 3 || Use_Stat_Number < 0)
        {
            Use_Stat_Number = Mathf.Clamp(Use_Stat_Number, 0, 3);
        }
        if (Trans == null)
        {
            // Thats bad!!!
            Debug.LogError("[!] UI Stat Monitor must be tied to a RectTransform on INIT!! It can't work without it!");
        }
        else
        {
            // Calculate origins for later use
            len_x = Trans.sizeDelta.x; // Total Length

            left_x = len_x / 2;
            cur_x = len_x;
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
        // Trans.S
        // Mess with the width
        cur_x = CalcTrans();
        // Debug.Log("[@] x: " + xx + " , y:" + yy+" (xorg: "+this.len_x+", )");
        Trans.sizeDelta = new Vector2(cur_x, Trans.sizeDelta.y);

        // Mess with the position
        // (len_x/2) - (cur_x/2) = offset
        float offset = (this.len_x / 2) - (this.cur_x / 2);
        float xxx = 2*(Trans.position.x - offset) ;
        atx = xxx;

        Trans.position.Set(Mathf.Max( Mathf.Min(xxx , len_x/2) , left_x), Trans.position.y, Trans.position.z);

        Debug.Log("[@" + Use_Stat_Number + "] x: " + xxx);
    }

    float CalcTrans()
    {
        GetStatMonitor();
        if (source == null)
        {
            //Debug.Log("[!] Can't find Stat Monitor! ");
            return len_x;
        }
        float zz = Mathf.Max(Mathf.Max(source.GetStatAtIndex(Use_Stat_Number),0f) / this.max , 0.01f);
        //Debug.Log("[@@] zz:" + zz + " HP:" + source.HP);
        return len_x * zz;
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

            if (Use_Stat_Number == 3)
            {
                // Use a debug mode which used SIN()
                max = 1;
            }
            else
            {
                max = source.GetLimitAtIndex(Use_Stat_Number);
            }
            
        }
        else
        {

            hasStatMonitor = true;
        }
    }
    //
}
