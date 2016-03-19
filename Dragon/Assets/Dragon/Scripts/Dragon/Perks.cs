using UnityEngine;
using System.Collections;

public class Perks : MonoBehaviour {
    public int[] selectedcombo; //combonation in binary
    bool doubleGold;//1
    bool tripleGold;//2
    bool BarnyardExplosion;//4
    bool doublePrincessWorth;//8
    bool halfDamage;//16
    bool halfBreathCost;//32
    bool resitance;//64
    bool improvedResistance;//128
    bool halfFlightCost;//256
	// Use this for initialization
	void Start () {
        Session_Monitor session = FindObjectOfType<Session_Monitor>();
        int selected = session.getPerks();
        Debug.Log(selected);
        int temp;
        if (selected >= selectedcombo.Length)
        {
            Random.seed = System.DateTime.Now.Millisecond;
           temp = Random.Range(0,511);
        }
        else
        {
            temp = selectedcombo[selected];
        }
        
        if (temp - 256 >= 0)
        {
            halfFlightCost = true;
            temp -= 256;
        }
        else
        {
            halfFlightCost = false;
        }
        if (temp - 128 >= 0)
        {
            improvedResistance = true;
            temp -= 128;
        }
        else
        {
            improvedResistance = false;
        }
        if (temp - 64 >= 0)
        {
            resitance = true;
            temp -= 64;
        }
        else
        {
            resitance = false;
        }
        if (temp - 32 >= 0)
        {
            halfBreathCost = true;
            temp -= 32;
        }
        else
        {
            halfBreathCost = false;
        }
        if (temp - 16 >= 0)
        {
            halfDamage = true;
            temp -= 16;
        }
        else
        {
            halfDamage = false;
        }
        if (temp - 8 >= 0)
        {
            doublePrincessWorth = true;
            temp -= 8;
        }
        else
        {
            doublePrincessWorth = false;
        }
        if (temp - 4 >= 0)
        {
            BarnyardExplosion = true;
            temp -= 4;
        }
        else
        {
            BarnyardExplosion = false;
        }
        if (temp - 2 >= 0)
        {
            tripleGold = true;
            temp -= 2;
        }
        else
        {
            tripleGold = false;
        }
        if (temp - 1 >= 0)
        {
            doubleGold = true;
        }
        else
        {
            doubleGold = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public int goldMult()
    {
        if (tripleGold)
        {
            return 3;
        }
        if (doubleGold)
        {
            return 2;
        }
        return 1;
    }
    public bool BE()
    {
        return BarnyardExplosion;
    }
    public int damageReduction()
    {
        if (improvedResistance)
        {
            return 3;
        }
        if (resitance)
        {
            return 1;
        }
        return 0;
    }
    public double damageMult()
    {
        if (halfDamage)
        {
            return 0.5;
        }
        return 0;
    }
    public int PrincessWorth()
    {
        if (doublePrincessWorth)
        {
            return 2;
        }
        return 1;
    }
    public float breathMult()
    {
        if (halfBreathCost)
        {
            return 0.5f;
        }
        return 0;
    }
    public float flightMult()
    {
        if (halfFlightCost)
        {
            return 0.5f;
        }
        return 0;
    }
    //test
}
