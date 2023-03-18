using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DialoguesAndConversationDatastructures;
using System;

public class HouseScript : MonoBehaviour
{
    // all of the script controllable objects that are part of the game Sequence
    public GameObject NextLevelDoor;

    public GameObject TheMother;
    public GameObject TheFather;
    public GameObject Player;
    public GameObject DoorToRestingQuarters;
    public GameObject TheMotherAnimatedChild;
    public GameObject TheFatherAnimatedChild;
    public Image DialogueBackground;

    public AudioSource ConversationSoundSource;
    public AudioClip[] CharacterConversationClip;

    public AudioSource MotherFootSource;
    public AudioSource FatherFootSource;
    
    public AudioClip BootFootedWoodenFloorWalkingClip;
    
    public AudioSource DoorSoundListner;


    [SerializeField]
    private Sprite[] CharacterImages;
    private Dialogue CharacterDialogues;
    // all of the character Images required for the Scene

    private GameObject ConversationObject;
    public GameObject[] ConversationPrefabs;

    public TextMeshProUGUI DialogueText;
    

    public TextMeshProUGUI ControlsTab;
    public TextMeshProUGUI ObjectivesTab;


    // movement and control variables are here
    public bool isSequenceOn = true;
    float timer = 0f;
    float NpcAnimationSpeed = 2.1f;
    float ClipSpeed = 1.7f;
    public static bool ShouldSkipSequence = false;


    void SetLevelSoundVolumes()
    {
        try
        {
            MotherFootSource.volume = SettingsVariable.GetGeneralSoundsVolume();
            FatherFootSource.volume = SettingsVariable.GetGeneralSoundsVolume();
            DoorSoundListner.volume = SettingsVariable.GetGeneralSoundsVolume();
            ConversationSoundSource.volume = SettingsVariable.GetGeneralSoundsVolume();
        }
        catch (Exception e)
        {
            print("was causing the trouble:- " + e.Message);
        }
    }


    Dialogue[] StartingDialogues = new Dialogue[10] {
        new Dialogue("Father","Careful he has suffered terrible hit from that krystur shot,a shot through his abdomen.",0),
        new Dialogue("Mother","Yes, i am aware of that but have to clean up his wounds otherwise it might poison him.",1),
        new Dialogue("Father","He would be the second Mera who survived this far apart from the \"White Horn\".",0),
        new Dialogue("Mother","Tell me how long we have been trapped here?,while your decietful and scum of a brother is building an empire on our sacrifices and his offsprings enjoying there lives ever merrily.",1),
        new Dialogue("Father","I dont know i am just ashamed to have such brother in our family,i am just concerned about the fates of our childrens and there offsprings.",0),
        new Dialogue("Mother","Ohh,dont worry they will be suffering just for your foolish mistakes,i just cant imagine what had he done to our sons had he enslaved them or left them to rot somewhere.",1),
        new Dialogue("Father","Your anger is reasonable,it was my fault the cost for trusting a scum and millenias of suffering and torment,but i believe in our White Gold princess and she sees through everyones pain and suffering and helps them through there dark times.",0),
        new Dialogue("Mother","Look i love you but sometimes your such foolishness causes me to bear such bitterness for you,i really do believe that the Divine Charmer has really seen through our sufferage and let our generations live in peace ever after or just brought there souls to the Green Mists for them to rest easy.",1),
        new Dialogue("Father","Dont worry i truly believe in her,she would make our generations truly prosper and raise our family's name.",0),
        new Dialogue("Mother","Yes I truly hope so,ohh look he is waking up!!",1),
    };

    Dialogue[] Dialogues = new Dialogue[15] {
        new Dialogue("Father","Greetings traveller and welcome to our empty little home,we appreciate your courage and you are like \"White Horn\" as long as you too dont become a myth like him,i dont know what caused our lord to outright kill you,but we surely appreciate your courage and determination to make a difference.",0),
        new Dialogue("Meran","Thank you sir,i dont know but i am nothing like the great White Horn and i also dont know why did he disappered all of the sudden.",2),
        new Dialogue("Mother","Surely you must bear a heart of steel and mind of a genius to see through lies and deception of these ritual and our lord and endured through the depressing nature of this realm.",1),
        new Dialogue("Meran","What do you mean while perfoming this ritual on my home planet,Lady Sunara contacted me herselves and told me of my glorius victory in the Green Mist,are you implying that she was not Lady Sunara?",2),
        new Dialogue("Father","Well unfortunately no,the seducing voice you were hearing were of Ryseth himself not particularly of him but his corruption off,oh damn his corruption!",0),
        new Dialogue("Meran","Yes,i sometimes wish that the Black war never took place and our kind never blighted the Unsar and Lady Sunara was always happy.",2),
        new Dialogue("Father","....Aah,dont be harsh on yourselves trust in Unsar it sets off the events and for new events to occur rather good or bad we should not ever blame such events as they are the will of Unsar.",0),
        new Dialogue("Meran","I suppose you are right sir,but for the deeds of my kind i am very ashamed and for my deeds in the past aswell,i suppose this ritual be my final redemption but i left my fates in the hands of Unsar and i will face them rather bad or good.",2),
        new Dialogue("Mother","I like your courage,dear sir,just like our sons,but trust Lady Sunara and Unsar there will be dawn for you and your kind who still believes in the myth White Horn,i suppose you have courageous heart of him so be there legendary prophet and lead them to glory.",1),
        new Dialogue("Father","Surely,wait someone is trying to reach me.......,Lady Sunara it is an honor to speak with you,how can we be of your service?",0),
        new Dialogue("Lady Sunara","Surely dear,i hate to say but can you leave our traveller and me alone for a while?i want to personally greet the brave soul my self",3),
        new Dialogue("Mother","Oh,most certainly my Divine Charmer,but can you spare us few moments to talk with him for a bit?",1),
        new Dialogue("Lady Sunara","Certainly,please go ahead",3),
        new Dialogue("Mother","Thank you.Lady Sunara i am most thankful of your gratious generosity",1),
        new Dialogue("Mother","Ohh we must apologize to you dear sir for our abrupt end in our little meeting and we are certainly sorry for the not being a good host for our guest but if you intend to stay for some time and feel bored you might read some books out of these shelves",1),
    };

    Dialogue[] EndingDialogues = new Dialogue[21] {
        new Dialogue("Meran","Lady Sunara,it is an honor meeting with you,how may i be of service to you?",2),
        new Dialogue("Lady Sunara","I am truly impressed by your determination to complete this ritual and i really apologize to you about the corrupt's actions towards you,the divines are never allowed to interfere in this ritual like that",3),
        new Dialogue("Meran","No please dont be apologize,it might just be will of Unsar that i got shot and i got to see the Divine Charmer my self,and who gets these kind of luck every now and then,by White Horn you truly are what you are \"Divine Charmer\",\"The Most Beautiful Being in the Unsar\" , ohh,sorry i wasn't supposed to say that",2),
        new Dialogue("Lady Sunara","[giggles]Its alright but i dont deserve such titles for my past actions and decisions as a wisdom god",3),
        new Dialogue("Meran","Wha...What do you mean?,you surely deserve this title you are Divine Charmer and all mother for us mortals",2),
        new Dialogue("Lady Sunara","You maybe correct but deep down i am just burdened by the failures to save my love from that wretched corruption and let those poor souls be trapped in that \"Scheme\" and no mother would let her child fall for that",3),
        new Dialogue("Meran","Don't regret your past actions i and all beings of Unsar still see you as our All Mother and those actions,we really treat them as the will of Unsar,if you say that its all your fault ohh, divine charmer please dont see that as your fault,you did your best to keep Unsar in balance look after us mortal beings,surely that is a really great responsibility on anybody's shoulder to handle and you both have completed them with great care",2),
        new Dialogue("Lady Sunara","No dear there are somethings here that you dont know,i allowed that vile corruption to get all those soul so to keep it from harming my love from it,i feel after all those years corruption got so into him that there is no Old Ryseth in him now just darkness of corruption only,but my poor love had courage and fought back and told me to banish him here so that it might not harm anyone",3),
        new Dialogue("Meran","Lord Feree is here in this realm?..uhh...alright...i dont know what to say about it",2),
        new Dialogue("Lady Sunara","Its alright i am just regretful of my actions and just cant think what should i do next",3),
        new Dialogue("Meran","Well how can i guide a god,but if my love is in danger then i would give my life for her and through out my sinful little existence,i was never so disgusted and ashamed of my self after what they forced me to do that to that Aurish Girl and every moment of my life i regret my existence after that event and i knew i had to right all my wrongs,but i never got another way,so performed this ritual and i am here and i am very grateful to meet you",2),
        new Dialogue("Lady Sunara","Your actions are unforgivable but after sensing your regrets for your actions desparate need for a redemption i think we both are same in comparison",3),
        new Dialogue("Meran","No,All Mother please do not comapare your holy divinity with my petty little character,you are far greater than us,you are called our \"All Mother\" is because you see after your child",2),
        new Dialogue("Meran","You are The Lady Sunara please dont bring yourselves down to my character,if you lose hope who will guide us in these desparate times? and who will save your love if you lose all your hopes?",2),
        new Dialogue("Lady Sunara","I never thought of my unforgivable actions,i wished blindly for his safety and never thought of what my action did...thus now i face its consequences",3),
        new Dialogue("Meran","It was part of one of your lessons if you have to fight for your love then fight till the end do anything to save it",2),
        new Dialogue("Lady Sunara","Dear,it maybe so,but it didn't involved one thing that is doing wrong to achieve something",3),
        new Dialogue("Meran","Dont be devoured by your regrets,your charm comes from your great thinking and wisdom,reasons for your regrets are quite reasonable but think of them as the will of Unsar past cannot be undone only thing can be done is shaping a new future for the beings of Unsar and the Lord Feree and these things are your hands use them and change the fates of Unsar forever",2),
        new Dialogue("Lady Sunara","Seeing your optimism really got my hopes up,you are right the fates of Unsar are in my hands and from now on i will face all my mistakes and try to undo them i have to confront that corruption myself but for the first actions to my redemption i will send the mother and the father back to there family from which they were plucked away from all those thousands years ago now that Ryseth is banished for a while,but i dont know how long can he stay in this realm his corruption is to strong for him i fear that it might end him",3),
        new Dialogue("Meran","Thank you My lady and dont worry i believe in you and your love for him you surely will save him from that corruption and end his pains and be finally united with him",2),
        new Dialogue("Lady Sunara","I surely do believe in my beloved Feree he is strong for that thing to overcome him,i ca..can't possibly thank you for your guidance you must have strong connection with your mind element that keeps you this strong after this much sufferings and i can never pay for your guidance that you have given me,please i beg you to not have faith on me but yourselves you might be alone but in your mind there are millions more to back you,so believe in yourself and complete this damn ritual and earn your glorius reward after.\n farewell,Bravery!",3)
    };
    // Start is called before the first frame update
    void Start()
    {
        SkipText.color = new Color32(255, 255, 255, 0);
        DoorSoundListner.enabled = false;
        ConversationPrefabs[0].SetActive(false);
        ConversationPrefabs[1].SetActive(false);
        ConversationObject = ConversationPrefabs[0];
        // these variables just to store the character images in psuedo Hash table or something like it i dunno yet to learn its implementation XD
        Sprite HetwyConversationImage;
        Sprite MeranConversationImage;
        Sprite FatherConversationImage;
        Sprite MotherConversationImage;
        EarlyLevelTimer = 0;
        
        Reload:
        CharacterImages = ConversationObjManager.GetImage();
        if (CharacterImages == null)
        {
            ConversationObjManager.SetImages();
            goto Reload;
        }

        HetwyConversationImage = CharacterImages[0];
        MeranConversationImage = CharacterImages[1];
        FatherConversationImage = CharacterImages[4];
        MotherConversationImage = CharacterImages[5];
        CharacterImages = new Sprite[4] { FatherConversationImage, MotherConversationImage, MeranConversationImage, HetwyConversationImage };

        isSequenceOn = true;
        ControlsTab.color = new Color32(255, 255, 255, 0);
        ObjectivesTab.color = new Color32(255, 255, 255, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // the house script is really just a game sequence just to have a cutscene type story telling element or whatever that is 
        // long story short just want to tell some story so need a script which can manage these things 
        if (ObjectivesTab.color.a > 0)
            StartCoroutine(WaitTime());
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSecondsRealtime(5f);
        ObjectivesTab.color -= new Color32(0, 0, 0, 1);
        ControlsTab.color -= new Color32(0, 0, 0, 1);
    }

    private bool isLevelStarted = true;
    private float EarlyLevelTimer = 0f;
    public GameObject TransitionScreen;
    public TextMeshProUGUI LevelName;
    private void FixedUpdate()
    {
        SetLevelSoundVolumes();
        if (!isLevelStarted)
            LevelCode();
        else
        {
            if (EarlyLevelTimer >= 0 && EarlyLevelTimer <= 0.2f)
            {
                TransitionScreen.GetComponent<Image>().enabled = true;
                
                    TransitionScreen.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
                LevelName.color = new Color32(255, 255, 255, 0);
                LevelName.enabled = true;
                ConversationObject.SetActive(false);
                //GameStatusBars.SetActive(false);
                ObjectivesTab.enabled = false;

                if (ShouldSkipSequence)
                {
                    ObjectivesTab.enabled = true;
                    ControlsTab.enabled = true;
                    ObjectivesTab.color = new Color32(255,255,255,0);
                    ControlsTab.color = new Color32(255,255,255,0);
                }
            }
            else if (EarlyLevelTimer >= 0.29f && EarlyLevelTimer <= 2f)
            {
                if (LevelName.color.a < 255)
                    LevelName.color += new Color32(0, 0, 0, 10);
                if (ShouldSkipSequence)
                {
                    ObjectivesTab.color += new Color32(0,0,0,10);
                    ControlsTab.color += new Color32(0,0,0,10);
                }
            }
            else if (EarlyLevelTimer >= 4f && EarlyLevelTimer <= 6f)
            {
                if (LevelName.color.a > 0)
                    LevelName.color -= new Color32(0, 0, 0, 10);
                if (ShouldSkipSequence)
                {
                    ObjectivesTab.color -= new Color32(0, 0, 0, 10);
                    ControlsTab.color -= new Color32(0, 0, 0, 10);
                }
            }
            else if (EarlyLevelTimer >= 6)
            {
                EarlyLevelTimer = 0f;
                isLevelStarted = false;
                ObjectivesTab.enabled = true;
                if (ConversationFlag)
                    ConversationObject.SetActive(true);
                //GameStatusBars.SetActive(true);
            }
            EarlyLevelTimer += Time.deltaTime;
        }
    }
    public TextMeshProUGUI SkipText;

    private void LevelCode()
    {
        //print("House Sequence Timer:- " + timer);
        if (!ShouldSkipSequence)
            HouseSequence();
        else
        {
            timer = 339f;
            SkipText.color = new Color32(255, 255, 255, 0);
            ConversationPrefabs[0].SetActive(false);
            ConversationPrefabs[1].SetActive(false);
            ConversationObject.SetActive(false);
            ConversationFlag = false;
            SingleDialogueFlag = false;
            DialogueTimer = 0f;
            currentDialoguesIndex = 0;

            isSequenceOn = false;
            if (!NextLevelDoor.GetComponent<DoorUIScript>().isLevelOver)
                TransitionScreen.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
            Player.GetComponent<PlayerScript>().enabled = true;
            Player.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
            destroyNpc();
        }
    }
    void HouseSequence()
    {
        // moving player based on conditionals is a terrible idea in unity and it is a particular problem if there is a 
        // a funciton call right next to the movement call then the intended movement is not achieved never calling functions 
        // after the movement call XD
        // this is a timer based npc movement well not system but the solution XD , npc moves first then after 10 seconds it talks via
        // terminal pretty god stuff XDDDDDD
        if (timer <= 339f && timer >= -1)
        {
            ShouldSkipSequence = false;
            isSequenceOn = true;
            Player.GetComponent<PlayerScript>().enabled = false;
            Player.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            isSequenceOn = false;
            Player.GetComponent<PlayerScript>().enabled = true;
        }
        timer += Time.deltaTime;

        if (timer <= 70f)
        {
            if (timer >= 8f)
            {
                if (SkipText.color.a < 255)
                    SkipText.color += new Color32(0, 0, 0, 1);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    timer = 339f;
                    SkipText.color = new Color32(255, 255, 255, 0);
                    ConversationPrefabs[0].SetActive(false);
                    ConversationPrefabs[1].SetActive(false);
                    ConversationObject.SetActive(false);
                    ConversationFlag = false;
                    SingleDialogueFlag = false;
                    DialogueTimer = 0f;
                    currentDialoguesIndex = 0;
                    DoorSoundListner.enabled = true;

                    ControlsTab.color = new Color32(255,255,255,255);
                    ControlsTab.enabled = true;

                    ObjectivesTab.color = new Color32(255,255,255,255);
                    ObjectivesTab.enabled = true;

                    isSequenceOn = false;
                    if (!NextLevelDoor.GetComponent<DoorUIScript>().isLevelOver)
                        TransitionScreen.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
                    Player.GetComponent<PlayerScript>().enabled = true;
                    Player.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
                    destroyNpc();
                }
            }
            // may add sound effects for the entry dialogues here
            ConversationFlag = true;
            SingleDialogueFlag = true;
            Conversation(StartingDialogues,7f);
        }
        else if (timer <= 72f && timer > 71f)
        {
            ConversationPrefabs[0].SetActive(false);
            ConversationObject = ConversationPrefabs[1];
            ConversationObject.SetActive(false);
            // the black background screen fades out here
            FadeIn();
        }
        else if (timer <= 82f && timer > 72f)
        {
            // the npc moves towards the player
            MoveNPCtoPlayer();
            currentDialoguesIndex = 0;
            DialogueTimer = 0f;
        }
        else if (timer <= 185f && timer >= 80f)
        {
            ConversationFlag = true;
            SingleDialogueFlag = true;
            ConversationObject.SetActive(true);
            // they have second conversation with the player
            Conversation(Dialogues,7f);
        }
        else if (timer <= 190f && timer >= 187f)
        {
            ConversationObject.SetActive(false);
            // the npc moves towards the door to there resting quarters
            MoveNPCTodoor();
            currentDialoguesIndex = 0;
            DialogueTimer = 0f;
        }
        else if (timer <= 337 && timer >= 190f)
        {
            DoorSoundListner.enabled = true;
            //if (!DoorSoundListner.isPlaying)
                //DoorSoundListner.Play();
            ConversationFlag = true;
            SingleDialogueFlag = true;
            ConversationObject.SetActive(true);
            // ending conversations with the White gold princess
            Conversation(EndingDialogues,7f);
        }
        else if (timer <= 339 && timer >= 338f)
        {
            if (SkipText.color.a > 0)
                SkipText.color -= new Color32(0,0,0,1);

            destroyNpc();
            DialogueText.text = " ";
            DialogueBackground.color = new Color32(0, 0, 0, 32);

            // player is free to roam the shack pop up the controls and objectives
            ControlsTab.color = new Color32(255, 255, 255, 255);
            ObjectivesTab.color = new Color32(255, 255, 255, 255);
            ShouldSkipSequence = true;
        }
        else
        {
            ConversationObject.SetActive(false);
            // each time there conversation ends the current dialogue index is reset to 0
            currentDialoguesIndex = 0;
        }
    }

    void MoveNPCtoPlayer()
    {
        // i am a fucking fool i was trying to have a movecounter based npc movement but it wont work in regularly updating frame cycles
        // the solution was to check if she had reached certain distance near to the player then stop dont move anymore
        if (TheMother.transform.position.x < Player.transform.position.x - 5f)
        {
            TheMother.transform.position = Vector3.Lerp(TheMother.transform.position, Player.transform.position, 0.004f);
            TheMotherAnimatedChild.GetComponent<Animator>().SetBool("isMoving", true);
            TheMotherAnimatedChild.GetComponent<Animator>().speed = NpcAnimationSpeed;
            if (!MotherFootSource.isPlaying)
            {
                MotherFootSource.clip = BootFootedWoodenFloorWalkingClip;
                //MotherFootSource.volume = 0.5f;
                MotherFootSource.pitch = ClipSpeed;
                MotherFootSource.Play();
            }
        }
        else
        { 
            TheMotherAnimatedChild.GetComponent<Animator>().SetBool("isMoving", false);
            if (MotherFootSource.isPlaying)
                MotherFootSource.Stop();
        }

        if (TheFather.transform.position.x < Player.transform.position.x - 8f)
        {
            TheFather.transform.position = Vector3.Lerp(TheFather.transform.position, Player.transform.position, 0.003f);
            TheFatherAnimatedChild.GetComponent<Animator>().SetBool("isMoving", true);
            TheFatherAnimatedChild.GetComponent<Animator>().speed = NpcAnimationSpeed;
            if (!FatherFootSource.isPlaying)
            {
                FatherFootSource.clip = BootFootedWoodenFloorWalkingClip;
                //FatherFootSource.volume = 0.5f;
                FatherFootSource.pitch = ClipSpeed;
                FatherFootSource.Play();
            }
        }
        else
        {
            TheFatherAnimatedChild.GetComponent<Animator>().SetBool("isMoving", false);
            if (FatherFootSource.isPlaying)
                FatherFootSource.Stop();
        }
    }


    // dialogue control variables are here
    float DialogueTimer = 0f;
    private bool ConversationFlag = false;
    private bool SingleDialogueFlag = false;
    int currentDialoguesIndex = 0;


    void Conversation(Dialogue[] Dialogues, float TimeLimit = 5f)
    {
        //print("Dialogue Index:- " + DialogueIndex);
        if (ConversationFlag)
        {
            if (SingleDialogueFlag)
            {
                if (DialogueTimer >= TimeLimit)
                {
                    if (currentDialoguesIndex == Dialogues.Length - 1)
                    {
                        currentDialoguesIndex = 0;
                        ConversationFlag = false;
                        SingleDialogueFlag = false;
                    }
                    else
                        currentDialoguesIndex++;
                    DialogueTimer = 0f;
                }
                else
                {
                    if (DialogueTimer <= 0.5f && DialogueTimer >= 0)
                    {
                        // here we have to play some sounds aswell for the respective character if it were for the Ryseth Feree then firstly Majestic Males voice then Twisted Evil Hmms 
                        // if Lady Sunaraie Sunara Then a voice of a divine charmer or beautiful voice of a woman
                        // and if it were our player then some monstrous hmms
                        if (!ConversationSoundSource.isPlaying)
                        {
                            ConversationSoundSource.clip = CharacterConversationClip[Dialogues[currentDialoguesIndex].SpeakerId];
                            //ConversationSoundSource.volume = 0.05f;
                            ConversationSoundSource.Play();
                        }
                    }
                    // regardless we load up the Dialogue for the player before the hmms
                    try
                    {
                        ConversationObject.GetComponent<ConversationObjManager>().ManageConversationObject(Dialogues[currentDialoguesIndex], CharacterImages[Dialogues[currentDialoguesIndex].ImageId]);
                        //print(Dialogues[currentDialoguesIndex].ImageId);
                    }
                    catch (Exception e)
                    {
                        print(" was causing the trouble :- " + e.Message);
                    }
                }
                DialogueTimer += Time.deltaTime;
            }
        }
    }

    void MoveNPCTodoor()
    {
        if (TheMother.transform.position.x > DoorToRestingQuarters.transform.position.x - 10f)
        {
            TheMother.transform.position = Vector3.Lerp(TheMother.transform.position, DoorToRestingQuarters.transform.position, 0.004f);
            TheMotherAnimatedChild.GetComponent<SpriteRenderer>().flipX = true;
            TheMotherAnimatedChild.GetComponent<Animator>().SetBool("isMoving", true);
            TheMotherAnimatedChild.GetComponent<Animator>().speed = NpcAnimationSpeed;
            if (!MotherFootSource.isPlaying)
            {
                MotherFootSource.clip = BootFootedWoodenFloorWalkingClip;
                //MotherFootSource.volume = 0.5f;
                MotherFootSource.pitch = ClipSpeed;
                MotherFootSource.Play();
            }
        }
        else
        {
            TheMotherAnimatedChild.GetComponent<Animator>().SetBool("isMoving", false);
            if (MotherFootSource.isPlaying)
                MotherFootSource.Stop();
        }

        if (TheFather.transform.position.x > DoorToRestingQuarters.transform.position.x - 5f)
        {
            TheFather.transform.position = Vector3.Lerp(TheFather.transform.position, DoorToRestingQuarters.transform.position, 0.005f);
            TheFatherAnimatedChild.GetComponent<SpriteRenderer>().flipX = true;
            TheFatherAnimatedChild.GetComponent<Animator>().SetBool("isMoving", true);
            TheFatherAnimatedChild.GetComponent<Animator>().speed = NpcAnimationSpeed;
            if (!FatherFootSource.isPlaying)
            {
                FatherFootSource.clip = BootFootedWoodenFloorWalkingClip;
                //FatherFootSource.volume = 0.5f;
                FatherFootSource.pitch = ClipSpeed;
                FatherFootSource.Play();
            }
        }
        else
        {
            TheFatherAnimatedChild.GetComponent<Animator>().SetBool("isMoving", false);
            if (FatherFootSource.isPlaying)
                FatherFootSource.Stop();
        }
    }
    void destroyNpc()
    {

        // after the npc had done there job they show that they entered there private quarters and will probably never comeback 
        // which means that they were destroyed well didnt died in the story but there physical character models were just destroyed
        if(TheMother != null)
            Destroy(TheMother);
        if(TheFather != null)
            Destroy(TheFather);
    }
    void FadeIn()
    {
        // decreasing the alpha means that the transparency of the image is increased by what ever unit you select 
        // here then i am deducting 10 units from the alpha value of the transition screen until it is equal to 0
        if (TransitionScreen.GetComponent<Image>().color.a >= 0)
            TransitionScreen.GetComponent<Image>().color -= new Color32(0,0,0,10);
    }
}
