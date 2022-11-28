using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class textForCollectibles : MonoBehaviour
{

    [Header("Text")]
    public string textNeedMoreSouls = ("You need more for the Gods");
    public string textSummonGod = ("The Gods have been satisfied");
    public string textCanJump = ("You can now jump!");
    public string textCanClimb = ("You can now climb!");
    public string textCanSprint = ("You can now sprint!");
    public string textCanClimbFast = ("You now have anchors for your undead body");
    public string textKnife = ("I wonder what this knife can be used for?");
    public string textHeart = ("Seems kind of odd for this heart to be unaffected by time, what if its needed for something?");
    public string textRibs = ("The start of your revenge is nigh, now find the rest of your body");
    public Text textElement;

    public int skullPoints;

    Text text;


    // Start is called before the first frame update
    void Start()
    {
       

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Leg 1")
        {
           

            textElement.text = textCanJump;
        }

        if (other.tag == "Leg 2")
        {
            

            textElement.text = textCanSprint;
        }

        if (other.tag == "Arm 1")
        {
            
            textElement.text = textCanClimb;
        }

        if (other.tag == "Joints")
        {
            

            textElement.text = textCanClimbFast;
        }

        if (other.tag == "Heart")
        {
            
            textElement.text = textHeart;
        }

        if (other.tag == "Knife")
        {
          
            textElement.text = textKnife;
        }

        if (other.tag == "Ribcage")
        {
           

            textElement.text = textRibs;
        }

        if (other.tag == "Skull")
        {
            skullPoints = skullPoints + 1;
        }

        if (other.tag == "Egg"
        && skullPoints > 40)
        {
            textElement.text = textSummonGod;
        }
        else if (other.tag == "Egg"
        && skullPoints < 40)
        {
            textElement.text = textNeedMoreSouls;
        }
    }

}
