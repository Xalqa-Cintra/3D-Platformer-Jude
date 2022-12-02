using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class textForCollectibles : MonoBehaviour
{

    [Header("Text")]
    public string textGiveMePower = "Wise witch Doctor, collect more skulls in order to enact your revenge on those outlanders.";
    public string textGettingThere = "Collect more doctor. Revenge is within your grasp.";
    public string textHalfwayThere = "Only a little more my dear follower, everything will be set right soon.";
    public string textGoToEgg = "You've done well Lich, now go and awaken the egg.";
    public string textRetry = "Poor Witch Doctor, You can Resummon yourself to your coffin if you hold R.";
    public string textNeedMoreSouls = ("You need more for the Gods.");
    public string textSummonGod = ("The Gods have been satisfied.");
    public string textCanJump = ("You can now jump!");
    public string textCanClimb = ("You can now climb!");
    public string textCanSprint = ("You can now sprint!");
    public string textJoints = ("You now have anchors for your undead body.");
    public string textKnife = ("I wonder what this knife can be used for?");
    public string textHeart = ("Seems kind of odd for this heart to be unaffected by time, what if its needed for something?");
    public string textRibs = "The start of your revenge is nigh, now find the rest of your body.";
    public string textSkulls = "Skulls: ";
    public GameObject textBox;
    public GameObject textScoreBox;

    [Header("Bools")]
    public bool skull_1 = false;
    public bool skull_10 = false;
    public bool skull_20 = false;
    public bool skull_40 = false;

    [Header("Sound")]
    public AudioClip music;
    public AudioClip roar;
    public AudioSource musicPlayer;
    public AudioSource roarPlayer;

    public int skullPoints;

    Text textElement;
    Text textElement2;
    public GameObject god;

    float textTimer;
    


    // Start is called before the first frame update
    void Start()
    {
        skull_1 = false;
        skull_10 = false;
        skull_20 = false;
        skull_40 = false;

        god.SetActive(false);
        textBox.SetActive(false);
        textElement = textBox.GetComponent<Text>();
        textElement2 = textScoreBox.GetComponent<Text>();

        musicPlayer.clip = music;
        musicPlayer.loop = true;
        musicPlayer.Play();


    }

    void Update()
    {
        textTimer = textTimer - 0.1f;

        if (textTimer < 0f)
        {
            textBox.SetActive(false);

        }
        textElement2.text = textSkulls + skullPoints;

        if (skull_1 == false) 
        {
            if (skullPoints == 1)
            {
                textBox.SetActive(true);
                textElement.text = textGiveMePower;
                skull_1 = true;
            }
        }

        if (skull_10 == false)
        {
            if (skullPoints == 10)
            {
                textBox.SetActive(true);
                textElement.text = textGettingThere;
                skull_10 = true;
            }
        }

        if (skull_20 == false)
        {
            if (skullPoints == 20)
            {
                textBox.SetActive(true);
                textElement.text = textHalfwayThere;
                skull_20 = true;
            }
        }

        if (skull_40 == false)
        {
            if (skullPoints == 40)
            {
                textBox.SetActive(true);
                textElement.text = textGoToEgg;
                skull_40 = true;
            }
        }
        Debug.Log(textTimer);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "retry")
        {
            textBox.SetActive(true);
            textElement.text = textRetry;
            textTimer = 500f;
        }

        if (other.tag == "Leg 1")
        {

            textBox.SetActive(true);
            textElement.text = textCanJump;
            textTimer = 500f;
        }

        if (other.tag == "Leg 2")
        {

            textBox.SetActive(true);
            textElement.text = textCanSprint;
            textTimer = 500f;
        }

        if (other.tag == "Arm 1")
        {
            textBox.SetActive(true);
            textElement.text = textCanClimb;
            textTimer = 500f;
        }

        if (other.tag == "Joints")
        {

            textBox.SetActive(true);
            textElement.text = textJoints;
            textTimer = 500f;
        }

        if (other.tag == "Heart")
        {
            textBox.SetActive(true);
            textElement.text = textHeart;
            textTimer = 500f;
        }

        if (other.tag == "Knife")
        {
            textBox.SetActive(true);
            textElement.text = textKnife;
            textTimer = 500f;
        }

        if (other.tag == "Ribcage")
        {

            textBox.SetActive(true);
            textElement.text = textRibs;
            textTimer = 500f;
        }

        if (other.tag == "Skull")
        {
            
            skullPoints = skullPoints + 1;
            textTimer = 500f;
            
        }

        if (other.tag == "Egg"&&skullPoints >= 40)
        {
            textBox.SetActive(true);
            textElement.text = textSummonGod;
            textTimer = 500f;
            god.SetActive(true);
        } 
        if (other.tag == "Egg"&&skullPoints < 40)
        {
            textBox.SetActive(true);
            textElement.text = textNeedMoreSouls;
            textTimer = 500f;
            roarPlayer.PlayOneShot(roar);
        }

        


    }

        
}
