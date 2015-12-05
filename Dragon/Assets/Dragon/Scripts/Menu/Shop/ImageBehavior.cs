using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageBehavior : MonoBehaviour {
    public xmlSavingClass save;
    public int current = 0;
    public int selected = 0;
    public ImageData[] images;
    public Button butt;
    public SavedData gold;
    bool notEnough=false;
    public Image render;
    // Use this for initialization
    void Start () {
        gold = save.stats;
        gold.boolArraySize("skins", images.Length);
        gold.getBought("skins", images);
        selected = gold.getSelected("skins");
    }
	// Update is called once per frame
	void Update () {
        Text t = butt.GetComponentInChildren<Text>();
        render.sprite = images[current].getImage();
        if (!images[current].isOwned())
        {
            t.text = images[current].getCost() + "\n" + images[current].getName();
        }
        else
        {
            t.text = "You own this already\n" + images[current].getName();
            if (current == selected)
            {
                t.text = "You own this already\n" + images[current].getName() + "\nEquipped";
            }
        }

    }
    public void onClick()
    {
        if (canBuy(gold.get(), images[current].getCost()) && !images[current].isOwned())
        {
            images[current].buy();
            gold.lose(images[current].getCost());
            selected = current;
            //Save the states of the variables back to where ever it saves
            gold.updateArray("skins", images);
            gold.selected("skins", selected);
            save.Save();
        }
        else if (images[current].isOwned())
        {
            selected = current;
            gold.selected("skins", selected);
            save.Save();
        }
    }
    private bool canBuy(uint have, uint need)
    {
        return have >= need;
    }

    [System.Xml.Serialization.XmlElement("Integer")]
    public float integer { get; set; }
}
