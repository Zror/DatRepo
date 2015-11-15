using UnityEngine;
using System.Collections;

public class ImageData: MonoBehaviour {
    public Sprite imageName;
    public uint cost;
    public string name2;
    public bool owned;
 //   public Image(Sprite i, int c, string n)
 //   {
 //       imageName = i;
 //       cost = c;
 //       name = n;
 //       owned = false;
 //   }
    public void buy()
    {
        owned = true;
    }
    public bool isOwned()
    {
        return owned;
    }
    public Sprite getImage()
    {
        return imageName;
    }
    public uint getCost()
    {
        return cost; 
    }
    public string getName()
    {
        return name2;
    }
}
