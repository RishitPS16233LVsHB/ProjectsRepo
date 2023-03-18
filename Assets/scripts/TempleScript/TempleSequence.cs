//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DialoguesAndConversationDatastructures;
using System;

public class TempleSequence : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    public GameObject WhiteGoldPrincess;
    public TextMeshProUGUI TextObject;
    public GameObject PortalAndSummonner;
    public Image TransitionScreen;
    public Image TheEndText;
    public static bool StartTheSequence = false;
    public GameObject ConversationObject;
    private Sprite[] CharacterImages;

    public AudioClip[] CharacterConversationSound;
    public AudioSource ConversationAudioSource;


    float ZoomInTimer = 0f;
    Vector3 PortalBasePosition;
    float Parenttimer = 0f;
    [SerializeField]private float timer = 0;
    bool isFirstSequence;



    Dialogue[] dialogues = new Dialogue[35] {
        new Dialogue("Lady Sunara","Welcome Bravery,i welcome you to the Green Mist,though you might be welcomed by those divine krysturs and wood zymers first[nervously laughs].",0),
        new Dialogue("Meran","My Lady,I am very honored to meet you in person,i ca...can..can't tell how nervous i am to see a god in front of me.",1),
        new Dialogue("Lady Sunara","Oh,please calm yourself dear after what my past action are i think myself of any adventurous aurish girl craving for adventure and also an Unsaric criminal and not of any god.",0),
        new Dialogue("Meran","As i said it is the will of the Unsar and nothing in our hands,you were destined to do such things it is not your fault in any manner,My Lady.",1),
        new Dialogue("Lady Sunara","You are right,the wisdom and understanding in you truly amazes me,as gods we might have all the power and the knowledge in us but we too crave more to better understand the Unsar,will you be willing to mentor me and my love on such kind of knowledge and wisdom?",0),
        new Dialogue("Meran","My lady,i am just a mortal how can i mentor a god on knowledge and wisdom that i barely have grasp upon,but your command is my responsibilty.",1),
        new Dialogue("Lady Sunara","Dear,you are right we gods might just have infinite knowledge on any thing of Unsar but learning to me and ryseth is like an adventure we travel the Unsar to see thriving cultures of every beings and try to implement them in our day to day lifestyles too,we are more like normal beings of Unsar.",0),
        new Dialogue("Lady Sunara","We don't crave attention from the mortals to worship us we both just enjoy what Unsar's finest have to offer and also perform our duties too as our primary responsibility we are its keepers too.",0),
        new Dialogue("Meran","By White Horn,you truly are a god unlike those hypocrites back in Red Sands.",1),
        new Dialogue("Lady Sunara","Hypocrites?,i wouldn't mind calling myself one but i will do anything in my power to set things right,i promise you that.",0),
        new Dialogue("Meran","Please you don't have to,you have done so much for our kind and it was us that chose this path it wasn't your fault,anyways,earlier you were saying that there is a mind element can you tell me what it is,My Lady?",1),
        new Dialogue("Lady Sunara","Good question,bravery,the mind element is part of beings Aura along with the element of consciousness,the mind element is present in all beings and they act as an entity.",0),
        new Dialogue("Lady Sunara","Now the mind element knows everything about the consciousness but the consciousness never knows its presence,think of consciousness as Unsar and us gods as there mind elements all Unsar.",0),
        new Dialogue("Lady Sunara","Whatever happens in the Unsar us keepers get to know about it because we are one with it,in the same way the mind element acts like as it take cares of ones Consciousness and ultimately its Aura.",0),
        new Dialogue("Meran","Wow,thats too much for me,my lady,please dont go further or i might go lose control over my consciousness [nervously laughs].",1),
        new Dialogue("Lady Sunara","[giggles] please do not be embarassed,dear,as i said before we are nothing but adventurers in this wild Unsar and we wish to learn more about the Unsar.",0),
        new Dialogue("Lady Sunara","But shortly said the mind element is a world within you,being traversable world,meaning you can traverse it also,one who reaches the \"Swarna,Noblet,Unrusted,White Horn\",depending which ideology you follow,you tap into your mind element and make your consciousness aquaint with the mind element.",0),
        new Dialogue("Lady Sunara","Once a being reaches at that point he/she can tap into limitless wisdoms and mental abilities basically making him/her a god,same thing happened with me and my love and the White Horn.",0),
        new Dialogue("Lady Sunara","But there always a catch a person reaching the Swarna risk the state of madness as constant control over consciousness can lead one have dissatisfactions in life as all joy dies in that process and one start to live within itself ignoring the ever changing Unsar ultimately driving him/her insane,thus few people can safely reach \"Swarna\".",0),
        new Dialogue("Meran","The concept of swarna must really be a blessing for you,wasn't it?",1),
        new Dialogue("Lady Sunara","Well Dear,the answer would really be mixed.",0),
        new Dialogue("Meran","Mixed,why?",1),
        new Dialogue("Lady Sunara","We are always on the verge on the madness,you see the world i talked about is truly a heaven one could imagine for himself/herself and this time no matter how many time you visit it you never cease to amaze as how the world of the mind element is beautiful each time you venture in it,it always feels new thus making one ever more lustful of the place that makes him/her want to constantly revisit the place.",0),
        new Dialogue("Lady Sunara","After reaching the Swarna one must have a Noble Heart to resist those temptations and really have one compelling reason to live outside of it other wise you will slowly succumb to it and loose all your mind control and become insane.",0),
        new Dialogue("Meran","This must be a very good place then,right?have you met any people in your mind element if you have ventured into it?",1),
        new Dialogue("Lady Sunara","As a matter of fact yes i do have met him the one who controlled,the one who charmed,the one who had pride,the one who was always curious and then the one who was always brave like you[giggles].",0),
        new Dialogue("Meran","I might have completed the ritual but truly i dont consider myself to be brave,My Lady.",1),
        new Dialogue("Lady Sunara","Oh dear,just let yourself be in pride that you are the second Mera who completed this challenge but dont let it get over your head,Unsar needs some one like you all the time.",0),
        new Dialogue("Meran","I wish you spoke more about the mind element it is intriguing and my curiosity is increasing and as a matter of fact i cant just admire your beauty while you speak in that amazement,oh pardon me i shouldn't be doing that it wont happen again my lady.",1),
        new Dialogue("Lady Sunara","[giggle] Apology accepted dear,i wish that i too converse on that topic too but i got to save my love and try to bring balance to the realm and i dont know after talking with you this much you make me feel that you are my Feree i met back in that art convention all those eras ago and i fell in love with.",0),
        new Dialogue("Meran","Oh,i am glad that you feel about me like that but i am just an ordinary mortal and far inferior than Lord Feree.",1),
        new Dialogue("Lady Sunara","I just hope that i some day that i can personally slay my love's corruption with my own hands then watch beautiful sunset later all sitting beside him near a cliff hugging his arm,oh that would be my \"Big Gold\" that i needed.",0),
        new Dialogue("Meran","I too hope so that one day that twisted creature will leave him and unsar will witness a new dawn.",1),
        new Dialogue("Lady Sunara","Now on to your reward for all the way completing the ritual.",0),
        new Dialogue("Meran","Ohh boy,i cant wait for my reward.",1),
};
    Dialogue[] dialogues2 = new Dialogue[10]
    {
        new Dialogue("Ryseth The Second","Wait you changed me.",2),
        new Dialogue("Lady Sunara","[smiles]Yes,Bravery.",0),
        new Dialogue("Lady Sunara","You wanted this since a long time i knew it,i have my eyes on every being and i can see through there pain and joy which also affects me and i heard your prayers too.",0),
        new Dialogue("Ryseth The Second","You made me....a...man?",2),
        new Dialogue("Lady Sunara","[giggles]Ohh....Come on,Bravery,what else did you wanted?these were your deepest desires.",0),
        new Dialogue("Ryseth The Second","but you made into a Mera before our curse a pure Mera,i cant just thank you,my lady about the gift you have given me,My Lady.",2),
        new Dialogue("Lady Sunara","Ohh you are most welcome,Bravery.",0),
        new Dialogue("Lady Sunara","You do originate from my pains but you and white horn make me proud which makes me want to cry more.",0),
        new Dialogue("Ryseth The Second","No,please do not cry or you will give birth to another one of abomination like my kind[Laughs].",2),
        new Dialogue("Lady Sunara","Ohh you silly,[laughs] see i told you,you give me the vibes of my ever more beloved Ryseth that i knew all those eras ago i wish that i can see him again and cherish those moments all over again and ooh....yes dont forget your final reward.",0),
    };

    Dialogue[] dialogues3 = new Dialogue[15]
    {
        new Dialogue("Lady Sunara","Rise Ryseth the Second,and claim the sword that right fully belongs to you and if my Feree was here he would have personally gifted you his sword.",0),
        new Dialogue("Ryseth The Second","I dont know what did i do so special that i got possesions on one of the divine waepon.",2),
        new Dialogue("Lady Sunara","Ohh you did your thing as Unsar intended and you did it so wonderfully that you won our favours.",0),
        new Dialogue("Ryseth The Second","But what about my past life i was very sinful.",2),
        new Dialogue("Lady Sunara","[smiles] Ohh bravery,you never cease to adore me,huh? see after your transformation you are reborn as a completely new and noble man\"Ryseth the second\" and i gave you that name because you remind of my Sweet Iron.",0),
        new Dialogue("Ryseth The Second","[Proud smile]Alright!free at last!",2),
        new Dialogue("Lady Sunara","You might have another adventures planned with you,right?",0),
        new Dialogue("Ryseth The Second","Yes i do, now that i have your blessings i want to end all of the wars on the Red Sands",2),
        new Dialogue("Lady Sunara","[sighs]Ever so brave,yes you must proceed to your homelands and protect your kind,use the sword wisely",0),
        new Dialogue("Ryseth The Second","My Lady can i ask you something?",2),
        new Dialogue("Lady Sunara","Yes Bravery,anything you want....",0),
        new Dialogue("Ryseth The Second","You seemed dissapointed after the last statement i just said,what happened,my lady?is everything alright",2),
        new Dialogue("Lady Sunara","No,it was just I wanted you to come with me and free my Sweet Iron",0),
        new Dialogue("Ryseth The Second","That's it? i can come with you but first my people are calling for my help",2),
        new Dialogue("Lady Sunara","Thank you,bravery i shall assist on your quest of bringing peace on the Red Sands as responsibilty first then love later [smiles] and promise me that you will mentor us both after all that's settled?[Ryseth the second nodes head in approval] alright then off to red sands",0),
    };


    // clearly need another set of dialogues after that ryseth the second assumes the ownership of the sword
    private int dialogueIndex = 0;
    
    void Start()
    {
        
        ConversationObject.SetActive(false);

        if (ConversationObjManager.GetImage() == null)
            ConversationObjManager.SetImages();

        // got all of the image references
        CharacterImages = ConversationObjManager.GetImage();        
        Sprite HetwyImage = CharacterImages[0];
        Sprite MeranImage = CharacterImages[1];
        Sprite RysethTheSecondImage = CharacterImages[3];

        CharacterImages = new Sprite[3] {HetwyImage,MeranImage,RysethTheSecondImage};


        TextObject.text = "\0";
        isFirstSequence = true;
        PortalBasePosition = new Vector3(PortalAndSummonner.transform.position.x,
                                         PortalAndSummonner.transform.position.y,
                                         PortalAndSummonner.transform.position.z);
    }

    public AudioSource[] BodySources;
    public AudioClip GrassWalkingClip;

    void SetAudioVolume()
    {
        BodySources[0].volume = SettingsVariable.GetGeneralSoundsVolume();
        BodySources[1].volume = SettingsVariable.GetGeneralSoundsVolume();
        EffectsSource.volume = SettingsVariable.GetGeneralSoundsVolume();

        AmbienceSource.volume = SettingsVariable.GetEnvironmentalAmbienceVolume();
    }
    private void PlayWalkingSounds(AudioSource BodySource)
    {
        if (!BodySource.isPlaying)
        {
            BodySource.clip = GrassWalkingClip;
            //BodySource.volume = 0.03f;
            BodySource.pitch = 1f;
            BodySource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {

        SetAudioVolume();
        if (StartTheSequence)
        {            
            // just need to  zoom the camera in to the main conversation so to divert the attention of the player to the background to the 
            // current game sequence
            if (Parenttimer >= 0f && Parenttimer <= 1f)
            {
                Player.transform.position = new Vector3(WhiteGoldPrincess.transform.position.x - 5f,Player.transform.position.y,Player.transform.position.z);
                Player.GetComponent<PlayerLevel3Script>().enabled = false;
                CameraZoomin();
            }
            else if (Parenttimer > 1f)
            {
                TempleGameSequence();
            }
            Parenttimer += Time.deltaTime;
        }
        //else
          //  if (TransitionScreen.color.a > 0)
            //    TransitionScreen.color -= new Color32(0, 0, 0, 1);

    }
    void CameraZoomin()
    {
        if (Player.transform.GetChild(0).GetComponent<Camera>().orthographicSize >= 3.2f)
        {
            if (ZoomInTimer >= 0.02f)
            {
                Player.transform.GetChild(0).GetComponent<Camera>().orthographicSize -= 0.1f;
                Player.transform.GetChild(0).GetComponent<Camera>().transform.position -= new Vector3(0, 0.1f, 0);
                ZoomInTimer = 0f;
            }
            else
                ZoomInTimer += Time.deltaTime;
        }
    }


    public AudioClip CorruptConversationSounds;
    public AudioSource EffectsSource;
    public AudioClip FieryTransformation;
    public AudioClip UnsheathingSword;
    public AudioClip SheathingSword;
    public AudioClip PortalAndSummonningEffect;
    public AudioClip LadySunaraCastingSpell;

    public AudioSource AmbienceSource;


    void SourcePlayer(AudioSource Source,AudioClip clip,float volume)
    {
        if (!Source.isPlaying)
        {
            Source.clip = clip;
            //Source.volume = volume;
            Source.Play();
        }
    }
    void TempleGameSequence()
    {
        print(timer);
        if (isFirstSequence)
        {
            // first the white gold princess approaches the champion of the run
            if (timer >= 0f && timer <= 3f)
            {
                PlayWalkingSounds(BodySources[0]);

                Vector3 newPosition = new Vector3(1, 0, 0);
                WhiteGoldPrincess.transform.GetChild(0).GetComponent<Animator>().SetBool("isMoving", true);
                WhiteGoldPrincess.GetComponent<Rigidbody>().MovePosition(WhiteGoldPrincess.transform.position - (newPosition * Time.deltaTime));
            }
            // then she proceeds to conversate with our hero
            else if (timer >= 3.1f && timer <= 248f)
            {
                BodySources[0].Stop();
                BodySources[1].Stop();

                ConversationObject.SetActive(true);
                ConversationFlag = true;
                SingleDialogueFlag = true;
                Conversation(dialogues,7f);
            }
            // then she casts a transformation spell on our player as a reward for all his journey here
            else if (timer >= 248.1f && timer <= 250f)
            {
                if (timer >= 248.1f && timer <= 248.2f)
                {
                    SourcePlayer(BodySources[0], LadySunaraCastingSpell, 0.08f);
                    SourcePlayer(EffectsSource, FieryTransformation, 0.08f);
                }
                DialogueTimer = 0f;
                currentDialoguesIndex = 0;
                WhiteGoldPrincess.transform.GetChild(0).GetComponent<Animator>().SetBool("isMoving", false);
                WhiteGoldPrincess.transform.GetChild(1).GetComponent<Animator>().enabled = true;
                WhiteGoldPrincess.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = true;
                PlayerTransformation(true);
                Player.transform.GetChild(1).GetComponent<Animator>().SetBool("IsTransformed", true);
            }
            else if (timer >= 251f && timer <= 252.8f)
            {
                EffectsSource.Stop();
                Player.transform.GetChild(1).GetComponent<Animator>().SetBool("IsCheckingSelf", true);
            }
            // then they do some chattiing
            else if (timer >= 253f && timer <= 323)
            {
                ConversationObject.SetActive(true);
                ConversationFlag = true;
                SingleDialogueFlag = true;
                Conversation(dialogues2,7f);
            }
            // then the white gold princess summons allmighty Ryseth's Sword for our hero to lay claim on 
            else if (timer >= 324 && timer <= 334f)
            {
                Player.transform.GetChild(1).GetComponent<Animator>().SetBool("IsTransformed", true);
                DialogueTimer = 0f;
                currentDialoguesIndex = 0;
                // the white gold princess moves to some distance to summon Ryseth's sword 
                if (timer >= 324f && timer <= 327f)
                {
                    PlayWalkingSounds(BodySources[0]);
                    WhiteGoldPrincess.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;
                    Vector3 newPosition = new Vector3(1, 0, 0);
                    WhiteGoldPrincess.transform.GetChild(0).GetComponent<Animator>().SetBool("isMoving", true);
                    WhiteGoldPrincess.GetComponent<Rigidbody>().MovePosition(WhiteGoldPrincess.transform.position + (newPosition * Time.deltaTime));
                }
                // summons the sword and the portal object here
                else if (timer >= 328f && timer <= 330f)
                {                    
                    BodySources[1].Stop();

                    if (timer >= 328f && timer <= 328.1f)
                    {
                        SourcePlayer(BodySources[0], LadySunaraCastingSpell, 0.08f);
                        SourcePlayer(EffectsSource, PortalAndSummonningEffect, 0.08f);
                    }
                    WhiteGoldPrincess.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = true;
                    WhiteGoldPrincess.transform.GetChild(1).GetComponent<Animator>().enabled = true;
                    summonSword();
                }
                // hero moves to the sword to claim it
                else if (timer >= 331f && timer <= 334f)
                {
                    float Difference = PortalAndSummonner.transform.position.x - Player.transform.position.x;
                    if (Mathf.Abs(Difference) >= 1f)
                    {
                        PlayWalkingSounds(BodySources[1]);
                        Vector3 newPosition = new Vector3(1.5f, 0, 0);
                        Player.GetComponent<Rigidbody>().MovePosition(Player.transform.position + (newPosition * Time.deltaTime));
                        Player.transform.GetChild(1).GetComponent<Animator>().SetBool("isMoving", true);
                    }
                }
                // actually claims the sword
                else if (timer >= 334.1f && timer <= 335f)
                {
                    EffectsSource.Stop();
                    BodySources[0].Stop();
                    BodySources[1].Stop();

                    PortalAndSummonner.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
                    Player.transform.GetChild(1).GetComponent<Animator>().SetBool("IsWithSword", true);
                    PortalAndSummonner.transform.position = PortalBasePosition;
                }
                else
                {
                    WhiteGoldPrincess.transform.GetChild(0).GetComponent<Animator>().SetBool("isMoving", false);
                    WhiteGoldPrincess.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
                }
            }
            // player checks the sword
            else if (timer >= 335f && timer <= 337f)
            {


                if (timer >= 336.37f && timer <= 336.43f)
                {
                    //BodySources[1].pitch = 0.1f;
                    SourcePlayer(BodySources[1], UnsheathingSword, 0.9f);
                }
                else
                    BodySources[1].pitch = 1f;

                Player.transform.GetChild(1).GetComponent<Animator>().speed = 0.69234f;
                Player.transform.GetChild(1).GetComponent<Animator>().SetBool("IsWithSword", true);
                Player.transform.GetChild(1).GetComponent<Animator>().SetBool("IsCheckingSword", true);
                PortalAndSummonner.transform.position = PortalBasePosition;
                PortalAndSummonner.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
            }
            // then they chat for some time
            else if (timer >= 337f && timer <= 441f)
            {
                if(timer >= 345.1 && timer <= 345.2f)
                    SourcePlayer(BodySources[1],SheathingSword,0.9f);

                Player.transform.GetChild(1).GetComponent<Animator>().SetBool("IsCheckingSword", false);
                ConversationObject.SetActive(true);
                ConversationFlag = true;
                SingleDialogueFlag = true;
                Conversation(dialogues3,7f);
            }
            else if (timer >= 442f && timer <= 444f)
            {
                PlayWalkingSounds(BodySources[1]);
                Vector3 newPosition = new Vector3(1, 0, 0);
                Player.transform.GetChild(1).GetComponent<SpriteRenderer>().flipX = true;
                Player.transform.GetChild(1).GetComponent<Animator>().SetBool("isMoving", true);
                Player.GetComponent<Rigidbody>().MovePosition(Player.transform.position - (newPosition * Time.deltaTime));
            }
            else if (timer >= 444.1f && timer <= 445f)
            {                
                BodySources[1].Stop();

                // to prevent clips to played multiple times
                if (timer >= 444.1f && timer <= 444.2f)
                {
                    SourcePlayer(BodySources[0], LadySunaraCastingSpell, 0.08f);
                    SourcePlayer(EffectsSource, PortalAndSummonningEffect, 0.08f);
                }
                PortalAndSummonner.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
                WhiteGoldPrincess.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = true;
                WhiteGoldPrincess.transform.GetChild(1).GetComponent<Animator>().enabled = true;
                float x = WhiteGoldPrincess.transform.position.x - 3f;
                float y = WhiteGoldPrincess.transform.position.y + 0.5f;
                float z = PortalAndSummonner.transform.position.z;
                PortalAndSummonner.transform.GetChild(0).transform.localScale = new Vector3(5, 5, 1);
                PortalAndSummonner.transform.position = new Vector3(x, y, z);
            }
            else if (timer >= 445.1f && timer <= 447.1f)
            {
                PlayWalkingSounds(BodySources[1]);
                Vector3 newPosition = new Vector3(1, 0, 0);
                Player.transform.GetChild(1).GetComponent<SpriteRenderer>().flipX = false;
                Player.transform.GetChild(1).GetComponent<Animator>().SetBool("isMoving", true);
                Player.GetComponent<Rigidbody>().MovePosition(Player.transform.position + (newPosition * Time.deltaTime));
            }
            else if (timer >= 447.2f && timer <= 453.2f)
            {
                BodySources[0].Stop();
                BodySources[1].Stop();

                TransitionScreen.enabled = true;
                Fadein();

                if (AmbienceSource.volume > 0)
                    AmbienceSource.volume -= 0.1f;
            }
            else if (timer >= 455f && timer <= 460f)
            {

                if (timer >= 455 && timer <= 455.1f)
                    SourcePlayer(ConversationAudioSource,CorruptConversationSounds,0.15f);

                TextObject.text = "Corrupt: Welcome Welcome ";
            }
            else if (timer >= 460.8f && timer <= 462.8f)
            {
                TextObject.text = "\0";
                TheEndText.enabled = true;
                if (TheEndText.color.a < 255)
                    TheEndText.color += new Color32(0, 0, 0, 5);
            }
            else if (timer >= 462.9f && timer <= 464.9f)
            {
                if (TheEndText.color.a >= 0)
                    TheEndText.color -= new Color32(0, 0, 0, 5);
            }
            else if (timer >= 465f && timer <= 466f)
            {
                SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadSceneAsync(0);
            }
            // else we disable necessary things
            else
            {

                EffectsSource.Stop();
                BodySources[0].Stop();
                BodySources[1].Stop();
                ConversationAudioSource.Stop();

                ConversationObject.SetActive(false);
                PlayerTransformation(false);
                Player.transform.GetChild(1).GetComponent<SpriteRenderer>().flipX = false;
                Player.transform.GetChild(1).GetComponent<Animator>().SetBool("isMoving", false);
                Player.transform.GetChild(1).GetComponent<Animator>().SetBool("IsCheckingSword", false);
                WhiteGoldPrincess.transform.GetChild(0).GetComponent<Animator>().SetBool("isMoving", false);
                WhiteGoldPrincess.transform.GetChild(1).GetComponent<Animator>().enabled = false;
                WhiteGoldPrincess.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
                Player.transform.GetChild(1).GetComponent<Animator>().SetBool("IsCheckingSelf", false);
                TextObject.text = "\0";
            }
            timer += Time.deltaTime;
        }
    }
    void summonSword()
    {

        float x = WhiteGoldPrincess.transform.position.x - 2f;
        float y = WhiteGoldPrincess.transform.position.y + 1f;
        float z = WhiteGoldPrincess.transform.position.z;
        PortalAndSummonner.transform.GetChild(0).transform.localScale = new Vector3(4,4,0);
        PortalAndSummonner.transform.position = new Vector3(x,y,z);
    }
    void PlayerTransformation(bool transformationValue)
    {
        //Player.transform.GetChild(2).GetComponent<SpriteRenderer>().enabled = transformationValue;
        //Player.transform.GetChild(2).GetComponent<Animator>().enabled = transformationValue;
        Player.transform.GetChild(3).GetComponent<SpriteRenderer>().enabled = transformationValue;
        Player.transform.GetChild(3).GetComponent<Animator>().enabled = transformationValue;
           
    }

    void Fadein()
    {
        if (TransitionScreen.color.a < 255)
           TransitionScreen.color += new Color32(0,0,0,1);
    
    }

    // dialogue control variables are here
    private bool ConversationFlag = false;
    private bool SingleDialogueFlag = false;
    int currentDialoguesIndex = 0;
    float DialogueTimer = 0f;


    void Conversation(Dialogue[] Dialogues, float TimeLimit = 5f)
    {
        
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
                    if (DialogueTimer <= 0.1f && DialogueTimer >= 0)
                    {
                        // here we have to play some sounds aswell for the respective character if it were for the Ryseth Feree then firstly Majestic Males voice then Twisted Evil Hmms 
                        // if Hetwyie Sunara Then a voice of a divine charmer or beautiful voice of a woman
                        // and if it were our player then some monstrous hmms
                        ConversationAudioSource.clip = CharacterConversationSound[Dialogues[currentDialoguesIndex].SpeakerId];
                        ConversationAudioSource.volume = 0.3f;
                        if (!ConversationAudioSource.isPlaying)
                            ConversationAudioSource.Play();
                    }
                    try
                    { // regardless we load up the Dialogue for the player before the hmms
                        ConversationObject.GetComponent<ConversationObjManager>().ManageConversationObject(Dialogues[currentDialoguesIndex], CharacterImages[Dialogues[currentDialoguesIndex].ImageId]);
                    }
                    catch (Exception e)
                    {
                        print("Some errors lol");
                    }
                }
                DialogueTimer += Time.deltaTime;
            }
        }
    }

}
