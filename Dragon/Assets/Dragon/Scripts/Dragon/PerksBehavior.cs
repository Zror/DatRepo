using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PerksBehavior : MonoBehaviour {
    public int index = 0;
    public int selected = 0;
    private Image[] images = new Image[10];
    public Button butt;
    public GoldBehavior gold;
    bool notEnough = false;
    // Use this for initialization
    void Start()
    {
        //Will actually call the saved data from wherever saved
        for (int i = 0; i < 10; i++)
        {
            images[i] = new Image("Image " + i, 20 * (i + 1), "Perk " + i);
        }
        images[0].buy();

    }

    // Update is called once per frame
    void Update()
    {
        Text t = butt.GetComponentInChildren<Text>();
        //        if (notEnough)
        //        {
        //            //t.color = new UnityEngine.Color(251,0,0);
        //            t.text = ((string)images[index].getImage()) + "\nYou don't have enough Gold\n" + images[index].getName();
        //            System.Threading.Thread.Sleep(2000);
        // t.color = new UnityEngine.Color(0, 0, 0);
        //            notEnough = false;
        //      }

        if (!images[index].isOwned())
        {
            t.text = ((string)images[index].getImage()) + "\n" + images[index].getCost() + "\n" + images[index].getName();
        }
        else
        {
            t.text = ((string)images[index].getImage()) + "\nYou own this already\n" + images[index].getName();
            if (index == selected)
            {
                t.text = ((string)images[index].getImage()) + "\nYou own this already\n" + images[index].getName() + "\nEquipped";
            }
        }

    }
    public void onClick()
    {
        if (canBuy(gold.get(), images[index].getCost()) && !images[index].isOwned())
        {
            images[index].buy();
            gold.change(-images[index].getCost());
            selected = index;
            //Save the states of the variables back to where ever it saves
        }
        else if (images[index].isOwned())
        {
            selected = index;
        }
    }
    private bool canBuy(int have, int need)
    {
        return have >= need;
    }
}
