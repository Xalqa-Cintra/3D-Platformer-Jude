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
    public GameObject textBox;

    public int skullPoints;

    Text textElement;

    float textTimer;
    


    // Start is called before the first frame update
    void Start()
    {
        textBox.SetActive(false);
        textElement = textBox.GetComponent<Text>();

    }

    void Update()
    {
        textTimer = textTimer - 0.1f;
        
        if (textTimer < 0f)
        {
            textBox.SetActive(false);
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Leg 1")
        {

            textBox.SetActive(true);
            textElement.text = textCanJump;
            textTimer = 20f;
        }

        if (other.tag == "Leg 2")
        {

            textBox.SetActive(true);
            textElement.text = textCanSprint;
            textTimer = 20f;
        }

        if (other.tag == "Arm 1")
        {
            textBox.SetActive(true);
            textElement.text = textCanClimb;
            textTimer = 20f;
        }

        if (other.tag == "Joints")
        {

            textBox.SetActive(true);
            textElement.text = textCanClimbFast;
            textTimer = 200f;
        }

        if (other.tag == "Heart")
        {
            textBox.SetActive(true);
            textElement.text = textHeart;
            textTimer = 200f;
        }

        if (other.tag == "Knife")
        {
            textBox.SetActive(true);
            textElement.text = textKnife;
            textTimer = 200f;
        }

        if (other.tag == "Ribcage")
        {

            textBox.SetActive(true);
            textElement.text = textRibs;
            textTimer = 200f;
        }

        if (other.tag == "Skull")
        {
            skullPoints = skullPoints + 1;
        }

        if (other.tag == "Egg"&&skullPoints >= 40)
        {
            textBox.SetActive(true);
            textElement.text = textSummonGod;
            textTimer = 100f;
        } 
        if (other.tag == "Egg"&&skullPoints < 40)
        {
            textBox.SetActive(true);
            textElement.text = textNeedMoreSouls;
            textTimer = 100f;
        }




    }

        
}
