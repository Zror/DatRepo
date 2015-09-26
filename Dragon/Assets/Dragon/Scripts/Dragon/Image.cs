using UnityEngine;
using System.Collections;

public class Image {
    private string imageName;
    private int cost;
    private string name;
    private bool owned;
    public Image(string i, int c, string n)
    {
        imageName = i;
        cost = c;
        name = n;
        owned = false;
    }
    public void buy()
    {
        owned = true;
    }
    public bool isOwned()
    {
        return owned;
    }
    public string getImage()
    {
        return imageName;
    }
    public int getCost()
    {
        return cost; 
    }
    public string getName()
    {
        return name;
    }
}
