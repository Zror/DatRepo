using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WingBehavaior : MonoBehaviour {
    public xmlSavingClass save;
    public int index = 0;
    public int selected;
    public ImageData[] images;
    public Button butt;
    public SavedData gold;
    bool notEnough = false;
    public Image render;
    // Use this for initialization
    void Start()
    {
        gold = save.stats;
        gold.boolArraySize("wings", images.Length);
        gold.getBought("wings", images);
        selected = gold.getSelected("wings");
    }

    // Update is called once per frame
    void Update()
    {
        Text t = butt.GetComponentInChildren<Text>();

        render.sprite = images[index].getImage();
        if (!images[index].isOwned())
        {
            t.text = images[index].getCost() + "\n" + images[index].getName();
        }
        else
        {
            t.text = "You own this already\n" + images[index].getName();
            if (index == selected)
            {
                t.text = "You own this already\n" + images[index].getName() + "\nEquipped";
            }
        }

    }
    public void onClick()
    {
        if (canBuy(gold.get(), images[index].getCost()) && !images[index].isOwned())
        {
            images[index].buy();
            gold.lose(images[index].getCost());
            selected = index;
            //Save the states of the variables back to where ever it saves
            gold.updateArray("wings", images);
            gold.selected("wings", selected);
            save.Save();
        }
        else if (images[index].isOwned())
        {
            selected = index;
            gold.selected("wings", selected);
            save.Save();
        }
    }
    private bool canBuy(uint have, uint need)
    {
        return have >= need;
    }
}
