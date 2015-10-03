using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BreathBehavior : MonoBehaviour {
    public int index = 0;
    public int selected = 0;
    public ImageData[] images;
    public Button butt;
    public GoldBehavior gold;
    bool notEnough = false;
    public Image render;
    // Use this for initialization
    void Start()
    {

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
        }
        else if (images[index].isOwned())
        {
            selected = index;
        }
    }
    private bool canBuy(uint have, uint need)
    {
        return have >= need;
    }
}
