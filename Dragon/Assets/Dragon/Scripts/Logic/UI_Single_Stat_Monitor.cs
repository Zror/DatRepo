﻿using UnityEngine;
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

    private Vector3 loss_scale;

    private bool hasStatMonitor = false;

	// Use this for initialization
	void Start ()
    {
        if (Use_Stat_Number == 2)
        {
            max = 8;
        }
        loss_scale = Trans.lossyScale;

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
        AdjustBar();
        
    }

    void AdjustBar()
    {
        // Collapses to middle
        float xx = CalcTrans();
        float yy = Trans.sizeDelta.y;
        //

        Trans.anchoredPosition.Set(Trans.anchoredPosition.x - (len_x * (xx / len_x)), Trans.anchoredPosition.y);

        Trans.sizeDelta = new Vector2(xx,yy);
        //Trans.position.Set(Trans.position.x -(len_x *(xx/len_x)), Trans.position.y, Trans.position.z);
    }

    void AdjustBar2()
    {
        // Trans.S
        // Mess with the width
        cur_x = CalcTrans();
        //Debug.Log("[@] x: " + xx + " , y:" + yy+" (xorg: "+this.len_x+", )");
        //Trans.sizeDelta = new Vector2(cur_x, Trans.sizeDelta.y);
        //C:\Users\bakriz\Source\Repos\DatRepo\Dragon\Assets\UI_Single_Stat_Monitor.cs
        // Mess with the position
        // (len_x/2) - (cur_x/2) = offset
        float num = (this.len_x / 2);
        float denom = (this.cur_x / 2);
        float offset = num - denom;

        float xxx = 2 * Mathf.Abs(Trans.position.x - offset);
        atx = xxx;
        float derb = Mathf.Abs(Mathf.Max(Mathf.Min(Mathf.Abs(xxx), num), left_x));
        //this.loss_scale.x * //Mathf.Abs(cur_x)

        Trans.localScale = new Vector3(xxx, this.loss_scale.y);
        Trans.position.Set(derb, Trans.position.y, Trans.position.z);

        Debug.Log("[@" + Use_Stat_Number + "] x: " + derb + " xls: " + xxx + " <> offset: " + offset + " <- " + num + " - " + denom + " ((lenx: " + len_x + ", cur_x: " + cur_x + ", left_x: " + left_x + "))");

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
