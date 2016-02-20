using UnityEngine;

using System.Collections.Generic;
using System.Collections;

public class SavedData  {
    public List<bool> wings= new List<bool>();
    public List<bool> perks = new List<bool>();
    public List<bool> breath = new List<bool>();
    public List<bool> skins = new List<bool>();
    public int wingSelected;
    public int perkSelected;
    public int breathSelected;
    public int skinSelected;
    public uint gold = 100;
    public int first = 0;
    public int princess_captured;
	// Use this for initialization
	
	// Update is called once per frame
    public uint get()
    {
        return gold;
    }
    public void change(uint c)
    {
        gold += c;
    }
    public void lose(uint c)
    {
        gold -= c;
    }
    public void boolArraySize(string name, int size)
    {
        if (first<4)
        {
            if (name.Equals("wings"))
            {
                wings.Add(true);
                for (int i = 1; i < size; i++)
                {
                    wings.Add(false);
                }
                wingSelected = 0;
            }
            if (name.Equals("perks"))
            {
                perks.Add(true);
                for (int i = 1; i < size; i++)
                {
                    perks.Add(false);
                }
                perkSelected = 0;
            }
            if (name.Equals("breath"))
            {
                breath.Add(true);
                for (int i = 1; i < size; i++)
                {
                    breath.Add(false);
                }
                breathSelected = 0;
            }
            if (name.Equals("skins"))
            {
                skins.Add(true);
                for (int i = 1; i < size; i++)
                {
                    skins.Add(false);
                }
                skinSelected = 0;
            }
            first++;
        }
    }
    public void updateArray(string name, ImageData[] images)
    {
        if (name.Equals("wings"))
        {
            for (int i = 0; i < wings.Count; i++)
            {
                wings[i] = images[i].isOwned();
            }
        }
        if (name.Equals("perks"))
        {
            for (int i = 0; i < perks.Count; i++)
            {
                perks[i] = images[i].isOwned();
            }
        }
        if (name.Equals("breath"))
        {
            for (int i = 0; i < breath.Count; i++)
            {
                breath[i] = images[i].isOwned();
            }
        }
        if (name.Equals("skins"))
        {
            for (int i = 0; i < skins.Count; i++)
            {
                skins[i] = images[i].isOwned();
            }
        }
    }
    public void getBought(string name, ImageData[] images)
    {
        if (name.Equals("wings"))
        {
            for (int i = 0; i < wings.Count; i++)
            {
                if ((bool)wings[i])
                    images[i].buy();
            }
        }
        if (name.Equals("perks"))
        {
            for (int i = 0; i < perks.Count; i++)
            {
                if((bool)perks[i])
                    images[i].buy();
            }
        }
        if (name.Equals("breath"))
        {
            for (int i = 0; i < breath.Count; i++)
            {
               if((bool)breath[i])
                    images[i].buy();
            }
        }
        if (name.Equals("skins"))
        {
            for (int i = 0; i < skins.Count ; i++)
            {
                if((bool)skins[i]) images[i].buy();
            }
        }
    }
    public void selected(string name, int select)
    {
        if (name.Equals("wings"))
        {
            wingSelected = select;
        }
        if (name.Equals("perks"))
        {
            perkSelected = select;
        }
        if (name.Equals("breath"))
        {
            breathSelected = select;
        }
        if (name.Equals("skins"))
        {
            skinSelected = select;
        }
    }
    public int getSelected(string name)
    {
        if (name.Equals("wings"))
        {
            return wingSelected;
        }
        if (name.Equals("perks"))
        {
            return perkSelected;
        }
        if (name.Equals("breath"))
        {
            return breathSelected;
        }
        if (name.Equals("skins"))
        {
            return skinSelected;
        }
        return -1;
    }
}
