using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using DialoguesAndConversationDatastructures;


namespace DialoguesAndConversationDatastructures
{
    
    public class Dialogue
    {
        public string CharacterName;
        public string dialogue;
        public int SpeakerId;
        public int ImageId;

        public Dialogue(string Name = null,string Speakerdialogue = null, int Id = 0)
        {
            CharacterName = Name;
            dialogue = Speakerdialogue;
            SpeakerId = Id;
            ImageId = Id;
        }
        public Dialogue(int SId, int IId,string Name = null,string Speakerdialogue = null)
        {
            CharacterName = Name;
            dialogue = Speakerdialogue;
            SpeakerId = SId;
            ImageId = IId;
        }
    }
}

    



// this script controlls the movement of the dinosaur and the game over event 
// the script is simple but yet has so many moving parts so might be complex
public class DinoController : MonoBehaviour
{
    public AudioSource GameOverClip;

    public AudioSource ConversationAudioSource;
    public AudioClip[] CharacterConversationClips;

    public GameObject ConversationsObject;
    private Sprite[] CharacterImages = null;
    // quick list for sorting out what level and what conversation per each level :)
    private int[] endScores = null;
    //private int ConversationIndex = -1;
    private void ManageConversation()
    {
        int EndScore = endScores[BackgroundAndSpriteManager.currentLevelIndex - 1];
        //print("Conversations Index:- " + GameScore / EndScore);
        //print("Convrsations Flag:- " + ConversationFlag);
        //print("Dialogues Flag:- " + SingleDialogueFlag);
        ManageDialogue((int)GameScore/1000);
        TriggerConversation();    
    }
    private void TriggerConversation()
    {
        //print("Triggering score:- " + GameScore % 1000);
        if (!ConversationFlag && !SingleDialogueFlag)
        {
            if (GameScore % 1000 == 0)
            {
                //ConversationIndex++;
                //print("Conversation May Start");
                ConversationFlag = true;
                SingleDialogueFlag = true;
                DialogueIndex = 0;
            }        
        }    
    }
    public static bool SingleDialogueFlag = false; // to convey the start and the end of a dialogue means at the start this flag will be true after some time of waiting this flag will automaticalyy turnoff
    public static bool ConversationFlag = false; // to convey the start of a conversation 
    float dialogueTimer = 0f;
    private int DialogueIndex = 0;

    private void ManageDialogue(int ConversationsIndex)
    {
        //print("Dialogue Index:- " + DialogueIndex);
        if(ConversationFlag)
        {
            if(SingleDialogueFlag)
            {
                if (dialogueTimer >= 5f)
                {

                    if (DialogueIndex == 4)
                    {
                        DialogueIndex = 0;
                        ConversationFlag = false;
                        SingleDialogueFlag = false;
                        ConversationsObject.SetActive(false);
                    }
                    else
                    {
                        print("Dialogue Index:- " + DialogueIndex);
                        DialogueIndex++;
                    }
                    dialogueTimer = 0f;
                }
                else
                {
                    ConversationsObject.SetActive(true);
                    if (dialogueTimer <= 1f && dialogueTimer >= 0)
                    {
                        // here we have to play some sounds aswell for the respective character if it were for the Ryseth Feree then firstly Majestic Males voice then Twisted Evil Hmms 
                        // if Hetwyie Sunara Then a voice of a divine charmer or beautiful voice of a woman
                        // and if it were our player then some monstrous hmms
                        if (!ConversationAudioSource.isPlaying)
                        {
                            if (Dialogues[BackgroundAndSpriteManager.currentLevelIndex - 1, ConversationsIndex, DialogueIndex] != null)
                            {
                                ConversationAudioSource.clip = CharacterConversationClips[Dialogues[BackgroundAndSpriteManager.currentLevelIndex - 1, ConversationsIndex, DialogueIndex].SpeakerId];
                                //print("Conversations Index:- " + ConversationsIndex);
                                //print("Dialogue Index:- " + DialogueIndex);
                                //print("Conversation flag:- " + ConversationFlag);
                                //print("Single Dialogue flag:- " + SingleDialogueFlag);
                                
                                //ConversationAudioSource.clip = clip;

                                //ConversationAudioSource.volume = 0.3f;
                                
                                ConversationAudioSource.Play();
                                // regardless we load up the Dialogue for the player before the hmms
                                ConversationsObject.GetComponent<ConversationObjManager>().ManageConversationObject(
                                    Dialogues[BackgroundAndSpriteManager.currentLevelIndex - 1, ConversationsIndex, DialogueIndex],
                                    CharacterImages[Dialogues[BackgroundAndSpriteManager.currentLevelIndex - 1, ConversationsIndex, DialogueIndex].ImageId]
                                );
                            }
                            if (Dialogues[BackgroundAndSpriteManager.currentLevelIndex - 1, ConversationsIndex, DialogueIndex] == null)
                            {
                                ConversationsObject.SetActive(false);
                                ConversationAudioSource.Stop();
                                ConversationAudioSource.clip = null;
                                DialogueIndex = 0;
                                ConversationFlag = false;
                                SingleDialogueFlag = false;
                            }
                        }                        
                    }
                        ConversationsObject.GetComponent<ConversationObjManager>().ManageConversationObject(
                        Dialogues[BackgroundAndSpriteManager.currentLevelIndex - 1, ConversationsIndex, DialogueIndex],
                        CharacterImages[Dialogues[BackgroundAndSpriteManager.currentLevelIndex - 1, ConversationsIndex, DialogueIndex].ImageId]
                        );
                }  

                //print(Dialogues[BackgroundAndSpriteManager.currentLevelIndex - 1, ConversationsIndex, DialogueIndex].dialogue);
                dialogueTimer += Time.deltaTime;
            }
        }    
    }

    private void ManageConversation(Dialogue[] Dialogues,float DialogueTimeLimit = 7f)
    {
        
        //print("Dialogue Index:- " + DialogueIndex);
        if (ConversationFlag)
        {
            if (SingleDialogueFlag)
            {
                if (dialogueTimer >= DialogueTimeLimit)
                {
                    dialogueTimer = 0f;
                    if (DialogueIndex == 4)
                    {
                        DialogueIndex = 0;
                        ConversationFlag = false;
                        SingleDialogueFlag = false;
                        ConversationsObject.SetActive(false);
                    }
                    else
                    {
                        DialogueIndex++;
                    }
                }
                else
                {
                    ConversationsObject.SetActive(true);
                    if (dialogueTimer <= 1f && dialogueTimer >= 0)
                    {
                        // here we have to play some sounds aswell for the respective character if it were for the Ryseth Feree then firstly Majestic Males voice then Twisted Evil Hmms 
                        // if Hetwyie Sunara Then a voice of a divine charmer or beautiful voice of a woman
                        // and if it were our player then some monstrous hmms
                        if (!ConversationAudioSource.isPlaying)
                        {
                            if (Dialogues[DialogueIndex] != null)
                            {
                                ConversationAudioSource.clip = CharacterConversationClips[Dialogues[DialogueIndex].SpeakerId];
                                //print("Conversations Index:- " + ConversationsIndex);
                                //print("Dialogue Index:- " + DialogueIndex);
                                //print("Conversation flag:- " + ConversationFlag);
                                //print("Single Dialogue flag:- " + SingleDialogueFlag);

                                //ConversationAudioSource.clip = clip;

                                //ConversationAudioSource.volume = 0.3f;

                                ConversationAudioSource.Play();
                                // regardless we load up the Dialogue for the player before the hmms
                                ConversationsObject.GetComponent<ConversationObjManager>().ManageConversationObject(
                                    Dialogues[DialogueIndex],CharacterImages[Dialogues[DialogueIndex].ImageId]
                                );

                            }
                            if (Dialogues[DialogueIndex] == null)
                            {
                                ConversationsObject.SetActive(false);
                                ConversationAudioSource.Stop();
                                ConversationAudioSource.clip = null;
                                DialogueIndex = 0;
                                ConversationFlag = false;
                                SingleDialogueFlag = false;
                            }
                        }
                        //ConversationsObject.GetComponent<ConversationObjManager>().ManageConversationObject(Dialogues[DialogueIndex], CharacterImages[Dialogues[DialogueIndex].ImageId]);

                    }
                    // regardless we load up the Dialogue for the player before the hmms
                }
                dialogueTimer += Time.deltaTime;
            }
        }

    }

    //public void SetConversationFlag(bool flag) {  ConversationFlag = flag; }
    public static bool EarlyConversationflag = false;
    public bool GetConversationFlag() { return ConversationFlag; }

    private Dialogue[,,] Dialogues = new Dialogue[3, 9, 5]
    {
        // this dialogues for level 1
        {
            // score 0
            {
                new Dialogue("Lady Sunara","Welcome,dear Meran to the ritual.",0),
                new Dialogue("Meran","Lady Sunara,It is an honor.",1),
                new Dialogue("Lady Sunara","Likewise,Meran!",0),
                new Dialogue("Lady Sunara","I hope that you complete your ritual fair and square and claim your reward.",0),
                new Dialogue("Meran","With your blessings anything can be done,My lady.",1)
            },
            // score 1000
            {
                new Dialogue("Lady Sunara","Good,your progress is quite noticable,most cowards can't reach uptil this point but you are built different.",0),
                new Dialogue("Lady Sunara","See but you are no different then the rest of the runners,who had cleared this far.",0),
                new Dialogue("Meran","I will do my best,My Lady.",1),
                null,
                null
            },
            // score 2000
            {
                new Dialogue("Lady Sunara","Good One,Meran!",0),
                new Dialogue("Lady Sunara","Most never got this far but you are truly something else.",0),
                new Dialogue("Meran","Thank you,All Mother i will do my best to win your blessings.",1),
                null,
                null
            },
            // score 3000
            {
                new Dialogue("Lady Sunara","Impressive,Meran!",0),
                new Dialogue("Lady Sunara","you are beating most of the competitors but you still don't fall in the category that our most braver competitors come in.",0),
                new Dialogue("Meran","[gasps for air],i.....uhhh...will..do...my...best..my..lady.",1),
                new Dialogue("Lady Meran","Are you getting tired? ohh dear please dont get tired,if you got tired who will do the rest of the runs?",0),
                new Dialogue("Meran","[gasps for air]Yes...my lady.",1)
            },
            // score 4000
            {
                new Dialogue("Lady Sunara","Quite impressive Meran.",0),
                new Dialogue("Lady Sunara","You amaze me very much,your heart must be very strong to bear such hardships that easily.",0),
                new Dialogue("Meran","I am grateful of your views regarding me,My Lady.",1),
                null,
                null
            },
            // score 5000
            {
                new Dialogue("Lady Sunara","Yes....,yes you are doing quite good i will make sure that Ryseth knows of your progress.",0),
                new Dialogue("Lady Sunara","You truly are a strong beast,a strong mera,now complete the run and earn your glorious reward and be relieved off your sins.",0),
                new Dialogue("Meran","Do you think that i am capable of such reward,My Lady?",1),
                new Dialogue("Lady Sunara","Yes....you are truly deserving of that kind of reward.",0),
                null
            },
            // score 6000
            {
                new Dialogue("Lady Sunara","Ohh,you are taking quite some beatings?dont give up for you must transform into a pure mera and help your kind and end all the carnage on your little planet",0),
                new Dialogue("Lady Sunara","But By Unsar,You trully are amazing dont give up,beast",0),
                new Dialogue("Meran","Surely I wont Disappoint you,My Lady",1),
                null,
                null
            },
            // score 7000
            {
                new Dialogue("Lady Sunara","You are very close to your goals dont lose hope my child you are doing great",0),
                new Dialogue("Lady Sunara","Ohh you must have a very brave soul very much fit for us",0),
                new Dialogue("Meran","Huh?What",1),
                new Dialogue("Lady Sunara","A brave soul,fit to be my divine crusader and fit to slay the vile corruption in Lord Feree and your soul is so brave that it can replace my current champion,White Horn",0),
                new Dialogue("Meran","I am grateful for your appreciation but i can never think to replace the legendary White Horn",1)
            },
            // Score 8000
            {
                null, // saves memory space lol XD, I must be idiot to realize this late XDDDD
                null,
                null,
                null,
                null
            }
        },

        // this dialogue for Level 2
        {
            // Score 0
            {
                new Dialogue("Lord Feree","Welcome to the darkness of unsar,Brave Soul.",2),
                new Dialogue("Lord Feree","Lets see how long you last in this realm.",2),
                new Dialogue("Lord Feree","You will find your competitors here but dont you worry they are just as lost as you will be soon.",2),
                new Dialogue("Lord Feree","I can promise you that you can here by the ritual but you wont leave as your soul is mine Meran and you shall roam this planes endlessly as your desires and goals will never be fullfiled.",2),
                new Dialogue("Lord Feree","They proved to be a quite difficult as they never get to leave there realm,they failed before any of that can happen but you and white horn made that so much easy for us and your souls are worth thounsands of these useless hissing and dragging souls that roam this plane,Enjoy travels.",2)
            },
            // Score 1000
            {
                new Dialogue("Lord Feree","Quite Impressive,mortal but i dont think the darkness of this realm will let you achieve your dreams.",2),
                new Dialogue("Lord Feree","See these are planes are ruled by me.",2),
                new Dialogue("Lord Feree","So,stop your worthless rebellion to win against me in my own realm.",2),
                new Dialogue("Meran","My fates are in the hands of Unsar,My Lord,the same deity that you and i worship.",1),
                new Dialogue("Lord Feree","Fine,you may survive but Unsar also knows that you wont survive for long.",2)
            },
            // Score 2000
            {
                new Dialogue("Lord Feree","Are you still alive?",2),
                new Dialogue("Meran","Yes,My Lord.",1),
                new Dialogue("Lord Feree","Well you wont be for long,Dear Child.",2),
                new Dialogue("Lord Feree","Your kind is already a blight for the Unsar,even i dont know how long it will favour you.",2),
                new Dialogue("Lord Feree","But by Unsar,it wont be long.",2)
            },
            // Score 3000
            {
                new Dialogue("Lord Feree","Ahh bravery,why do you think going any further will change anything?",2),
                new Dialogue("Meran","I am dead soul anyway,my sins are outweight me,if unsar gave me slightest hope for redemption then i must do its bidding.",1),
                new Dialogue("Lord Feree","Fine you may keep going but every moment in this realm,your hope will dimmen.",2),
                null,
                null
            },
            // Score 4000
            {
                new Dialogue("Lord Feree","Is that hope gone,my child?",2),
                new Dialogue("Lord Feree","Nothing lasts in this darkness,thus no hope can ever prevail ,should yours be an exception?",2),
                new Dialogue("Meran","Why Do you want my worthless soul anyway it wont benefit you in any manner?",1),
                new Dialogue("Lord Feree","See it wont matter to me but your soul can be my fine collection that serves me for eternity.",2),
                new Dialogue("Lord Feree","If you ask me,that would be fine redemption for you,if you wish for such.",2)
            },
            // Score 5000
            {
                new Dialogue("Lord Feree","You are getting on my nerves and making me crazy while you seem very fine than me,what is truly that you want from this ritual?",2),
                new Dialogue("Meran","Even if i told you ,you will betray me anyway,so why waste the effort?",1),
                new Dialogue("Lord Feree","Ohh come on,you do know that there is no way out for you out of this realm that i rule it,so i decide who gets out.",2),
                new Dialogue("Meran","If you rule this realm why don't you just kill me.",1),
                new Dialogue("Corrupt","Because this fool wont let me,see Feree had entrapped me but i controlled him just as you if i were free i would taken your soul right when you started this ritual.",3)
            },
            // Score 6000
            {
                new Dialogue("Corrupt","Meran!,give up your lord is weak and i will be free shortly so just surrender your soul to me otherwise my methods are very cruel.",3),
                new Dialogue("Meran","No.",1),
                new Dialogue("Corrupt","Meran,give up now,your efforts are in vain do you really think your \"lady sunara\" will ever help you,no she was always rejected your kind and your kind has done nothing but disgrace and betrayal to her.",3),
                new Dialogue("Corrupt","so even if you won and somehow escape me she wont help you instead,she might curse so you are doomed either way.",3),
                new Dialogue("Meran","I believe in my All Mother,she is the most loving and cares about for anybody no matter how evil they are.",1)
            },
            // Score 7000
            {
                new Dialogue("Corrupt","Give up and i will ease your fate just like i did with the White Horn.",3),
                new Dialogue("Meran","What have you done to him?",1),
                new Dialogue("Corrupt","Ohh to see what i have done you have to willingly give up and your fate will not be like the rest of the useless bones who drag themselves over here.",3),
                new Dialogue("Meran","So you mean it will be even worse,by my All Mother,i would die fighting and my All Mother will see my after afterlife not you.",1),
                new Dialogue("Corrupt","Ohh foolish mortal,your All....Mother is as helpless as poor ryseth,soon i shall gather my forces and Dusk Crecent of the Unsar shall begin.",3)
            },
            // Score 8000
            {
                new Dialogue("Corrupt","I just had enough of you,ritual may permit you to leave,but i wont.",3),
                new Dialogue("Meran","i would certainly want to see you try.",1),
                new Dialogue("Corrupt","Dont tempt me if it were my way.....",3),
                new Dialogue("Corrupt","You shall be dead by now.....",3),
                new Dialogue("Meran","Go on if this were my fates i shall face it,try all you want,my struggles are seen by my All Mother you wont get my soul even if you kill me,you twisted creature!",1)
            }
        },
        // these dialogues for level 3
        {
            // Score 0
            {
                new Dialogue("Lady Sunara","I really do apologize everything that is happening with you,Bravery.",0),
                new Dialogue("Meran","Please do not be sorry,my lady,it was not your fault.",1),
                new Dialogue("Lady Sunara","Adoring innocence,but Bravery,i let that dark creature harvest soul from the Unsar for its dark deeds.",0),
                new Dialogue("Meran","It is reasonable my lady,but you are hopes for a better future if you lose all your hopes what will be our fates?",1),
                new Dialogue("Lady Sunara","I guess you are right i must be strong,my Love also would want me to be strong,thank you,Bravery.",0)
            },
            // Score 1000
            {
                new Dialogue("Lady Sunara","Ahh yes you are closer, please dont lose your hopes and focus from your tracks.",0),
                new Dialogue("Meran","My lady,may i ask you something?.",1),
                new Dialogue("Lady Sunara","Yes,Anything...",0),
                new Dialogue("Meran","All mother,i thought while communicating telepathically you might sound more divine and angellic but you still sound like a normal being,why is that so?",1),
                new Dialogue("Lady Sunara","I am surprised that no one in the Red Sands told you that,but i do not think to highly of my self,thus i do not project myselves as a divine or an angel,you use these words for us,but for me and my Sweet Iron,being worshipped is just distraction so i and he too just prefer our original form that we had all those years ago,now enough with the talk,please you must focus on the ritual.",0)
            },
            // Score 2000
            {
                new Dialogue("Lady Sunara","I have already started spreading message across Arckus to forbade this ritual so you will be the last performer please do not lose your focus.",0),
                new Dialogue("Lady Sunara","Hmm....this ritual is hard to overcome.",0),
                new Dialogue("Meran","So it would seem,may be Unsar wants me to complete it legitimately,so i should do that.",1),
                new Dialogue("Lady Sunara","You may have a point and this might be the will of Unsar,but don't worry i will do my best to remove you from this curse.",0),
                new Dialogue("Meran","Surely All Mother,And thank you for your help.",1)
            },
            // Score 3000
            {
                new Dialogue("Lady Sunara","Oh Good Unsar,why you have to be so cruel sometimes?",0),
                new Dialogue("Meran","Seems like my journey is yet to be concluded,ain't it,My lady?",1),
                new Dialogue("Lady Sunara","No please dont say that,surely your soul wont be trapped but Unsar needs your help,bravery,i need your help bravery.",0),
                new Dialogue("Meran","For that i will keep on the path dont you worry,All Mother.",1),
                new Dialogue("Lady Sunara","Yes,please do not give up hopes i will still go for some form of manipulation of the curse and will make you free,you have suffered enough and you need peace not free your soul kind but mental peace[nervous laughter].",0)
            },
            // Score 4000
            {
                new Dialogue("Lady Sunara","This curse is very hard for me,Bravery,i cant find how can i get that out of you.",0),
                new Dialogue("Meran","All Mother be calm look for any clues that Lord Feree has left for you regarding this curse.",1),
                new Dialogue("Meran","I can run near infinite distance as your tears and your pains run through my veins,do not worry about me all mother.",1),
                new Dialogue("Lady Sunara","That is a good idea i will immediately search for clues that love left for me,i really apologize that you have to still keep your neck at line.",0),
                new Dialogue("Meran","I believe in you,All Mother.",1)
            },
            // Score 5000
            {
                new Dialogue("Lady Sunara","Bravery i just wanted to ask you how are you so calm,after your soul was on tha way to be forfieted by a demon and still it is on line this entire time.",0),
                new Dialogue("Lady Sunara","How did you do it,you are like my Ryseth he is calm,are you an incarnation of him?",0),
                new Dialogue("Meran","No My All Mother,i can never match Lord Feree and you,i remained calm was that i believed in you,your love for any mortal and your actions to save them",1),
                new Dialogue("Lady Sunara","That might be true bravery,but from this point i cannot do anything to help you,yet still you manage to be so calm and never any signs of distress,why is it so,bravery?",0),
                new Dialogue("Meran","You to know that i lived a very sinful life,i might not get any kind of redemption but i will face any punishment mighty Unsar has for me",1)
            },
            // Score 6000
            {
                new Dialogue("Lady Sunara","I got it bravery,explaining the terms is little hard,but try to keep yourselves on your legs for a while then this curse will automatically be lifted from you.",0),
                new Dialogue("Lady Sunara","Then i can save you and you can finally get some peace,Unsar had to redeem you or not but your efforts has pleased me enough.",0),
                new Dialogue("Lady Sunara","And after you have completed the damn ritual i may relieve you of your sins,i promise you that.",0),
                new Dialogue("Meran","Thank you,Lady Sunara.",1),
                new Dialogue("Meran","No matter how gratious i can be i can never repay this debt.",1)
            },
            // Score 7000
            {
                new Dialogue("Lady Sunara","It seems that the curse is nearly over.",0),
                new Dialogue("Meran","Yes,i hope so.",1),
                new Dialogue("Lady Sunara","Yes Bravery,hopes are strong now,corrupt planned to use Ryseth and infect the greater Unsars and bring dusk crecents of Unsar.",0),
                new Dialogue("Lady Sunara","This event is inevitable but when i last saw the life cycle of Unsar,corrupt was way too early so we might be able to banish him but we can banish it and we might just get few thousand million or so years from that point on.",0),
                new Dialogue("Meran","Yes,My Lady,in these times Unsar will become ever more beautiful and powerful.",1)
            },
            // Score 8000
            {
                null,
                null,
                null,
                null,
                null
            }
        }
    };

    private Dialogue Level1EndingDialogue = new Dialogue("Lady Sunara","Finally,You will be easy for us,Dear Meran.",0);
    private Dialogue[] Level2EndingDialogue = new Dialogue[6] {
        new Dialogue("Corrupt","I just had enough with you,your soul is mine and even if i had to kill you i will do that.",3),
        new Dialogue("Corrupt","No...No,what is happening....you let me go,i have slained you in past i will do so now,just let me go lady and i promise you,i will make this quick.",3),
        new Dialogue("Lady Sunara","Ohh even if i tried i couldn't,see you broke your own terms,you interfered in the ritual and that is why you are so powerless,you twisted worm.",0),
        new Dialogue("Corrupt","No...no this wont end well for you and your precious love.",3),
        new Dialogue("Lady Sunara","You swore your words,then you broke it,now you have no power on me and as for my love he far too strong for you,he just needed you to give into your impatience and so you trapped yourself,hope you get along with that tough soul well.",0),
        new Dialogue("Corrupt","Nooooo.......",3)
    };
    private Dialogue Level3EndingDIalogue = new Dialogue("Lady Sunara","After so many years,down with this scheme.",0);


    // all of the HUD stuff is here
    public GameObject GameStatusBars;
    public Image InjuredImage;

    // this is the Object where all the animations will be played on never disturbing the actual logical player
    public GameObject AnimatedChild;
    public GameObject EffectsChild;

    public GameObject Teleporter;
    public GameObject Camera;

    public AudioSource AmbienceSource;
    public AudioSource MusicSource;

    public AudioSource BodySource;
    public AudioSource VoiceSource;
    public AudioSource MagicSource;

    //public AudioClip GrassRunning;
    public AudioClip PainSounds;
    public AudioClip DoubleJump;
    public AudioClip SuperJump;
    public AudioClip SuperSprintWarpIn;
    public AudioClip SuperSprint;
    public AudioClip SuperSprintWarpOut;
    public AudioClip Blessings;

    public GameObject GameOverScreen;
    public GameObject LoadFiles;
    public GameObject SavedFile;

    public TextMeshProUGUI LevelName;

    // here are the transition effect objects 
    public Image TransitionScreen;
    float TransitionScreenTimer = 0f;

    // For Knocking Down Player Scene
    public ContinuosObjectSpawner Spawner;
    private float SceneTimer = -3f;
    private bool Level2SceneTrigger = false;
    public GameObject Projectile;
    GameObject ProjectileObject;
    bool isKnockedOut = false;



    // ui text based Objects for Debug and game Checks
    public GameObject ScoreText;
    public GameObject IsGameOverText;
    public GameObject IsAffectedWithBlessingsText;
    public GameObject TotalBlessingsAvailableText;
    public GameObject IsDoubleJumpAvailableText;
    public GameObject PlayerCurrentHealthText;
    public GameObject IsinArmourEffectText;
    public GameObject SuperSprintStatus;
    public GameObject SuperJumpStatus;
    public GameObject ConfirmationsTab;

    public TextMeshProUGUI ObjectivesTab;
    public TextMeshProUGUI ControlsTab;

    public static bool isPauseMenuActive = false;
    public GameObject PauseMenu;
    public GameObject CloseButton;

    // here is the gameOver Timer
    float GameOverTimer = 0f;

    private const int Level1RequirementScore = 7269;
    private const int Level2RequirementScore = 8486;
    private const int Level3RequirementScore = 7300;



    // here are all of the scene management variables
    int GameScore = 0;
    public int SubLevelIndex = 1;


    // all of the input/ game control variables are here
    private bool isGrounded = true;
    private bool isGameOver = false;
    private bool ShouldTeleport = false;


    private bool startDoubleJumpTimer = true;
    public static bool startSuperSprint = false;
    public static bool HealthPickedUp = false;
    public static bool ArmourPickedUp = false;
    public static bool HasGameRestarted = false;

    private float ArmourEffectTimer = 0f;
    //private bool startSuperSprintTimer = false;

    private bool DoJump = true;
    private bool DoDoubleJump = false;
    public static bool ShouldCreateAnewCourse = false;
    public static bool StopMovingObstacles = false;
    public static bool MakeNormalJump = false;

    // these are the speed variables
    private float DinoSpeed = 17f;
    private float Displacement = 1f;

    // these are the gameObject and Vectors
    private Rigidbody DinoBody;
    private Rigidbody CameraBody;
    private Vector3 Position;

    // timers are here
    private bool CanDoASuperJump = false;
    private float SuperJumpTimer = 0f;
    private bool startHealthtimer = false;
    private float SuperSprintTimer = 0f;
    private bool normalJump = false;
    private bool MakeEnableTheSuperJump = true;
    private float SuperJumpActivationTimer = 0f;
    public static float SuperSprintWaitingTimerSharable = 0f;

    // private float SuperSprintWaitTimer = 0f;
    private float lastPressTime = 0f;
    private float DoubleJumpTimer = 0f;
    private float SpeedTimer = 0f;
    private float HealthTimer = 0f;
    private float Health = 500;
    private float ScoreTimer = 0f;
    private float SuperSprintWaitingTimer = 181f;
    private float SuperJumptimer = 0f;

    // blessingsEffects
    private bool IsAffectedByBlessingsOfHetwy = false;
    private bool IsBlessingsOfHetwyAvailable = true;
    private static int NumberOfBlessingsOfHetwy = 4;
    private float dealDamage = 1f;


    // blessings timer
    private float HetwysTimer = -1f;
    public static void SetBlessingOnLoadingFile(int Amount) { NumberOfBlessingsOfHetwy = Amount; }
    public static int GetNumberofBlessingsLeft() { return NumberOfBlessingsOfHetwy; }

   

    // brings up only the normal health icon
    private void SetGameBarIcon(int Index)
    {
        //print("this method is called in update somewhere");
        if (Index == 7)
        {
            GameStatusBars.transform.GetChild(7).GetComponent<Image>().enabled = true;
            GameStatusBars.transform.GetChild(8).GetComponent<Image>().enabled = false;
            GameStatusBars.transform.GetChild(9).GetComponent<Image>().enabled = false;
            GameStatusBars.transform.GetChild(10).GetComponent<Image>().enabled = false;
        }
        else if (Index == 8)
        {
            GameStatusBars.transform.GetChild(7).GetComponent<Image>().enabled = false;
            GameStatusBars.transform.GetChild(8).GetComponent<Image>().enabled = true;
            GameStatusBars.transform.GetChild(9).GetComponent<Image>().enabled = false;
            GameStatusBars.transform.GetChild(10).GetComponent<Image>().enabled = false;
        }
        else if (Index == 9)
        {
            GameStatusBars.transform.GetChild(7).GetComponent<Image>().enabled = false;
            GameStatusBars.transform.GetChild(8).GetComponent<Image>().enabled = false;
            GameStatusBars.transform.GetChild(9).GetComponent<Image>().enabled = true;
            GameStatusBars.transform.GetChild(10).GetComponent<Image>().enabled = false;
        }
        else if (Index == 10)
        {
            GameStatusBars.transform.GetChild(7).GetComponent<Image>().enabled = false;
            GameStatusBars.transform.GetChild(8).GetComponent<Image>().enabled = false;
            GameStatusBars.transform.GetChild(9).GetComponent<Image>().enabled = false;
            GameStatusBars.transform.GetChild(10).GetComponent<Image>().enabled = true;
        }

    }

    
    // Start is called before the first frame update
    void Start()
    {
        
        //BodySource.pitch = 1.5f;
        BodySource.volume = 0;

        GameOverTimer = 0f;
        GameOverClip.enabled = false;

        // here loaded all of the images
        CharacterImages = ConversationObjManager.GetImage();
        Sprite HetwyImage, MeranImage, RysethImage;
        HetwyImage = CharacterImages[0];
        MeranImage = CharacterImages[1];
        RysethImage = CharacterImages[2];

        SceneTimer = 0f;
        CharacterImages = new Sprite[4] { HetwyImage, MeranImage, RysethImage,RysethImage};


        ConversationsObject.SetActive(false);
        
        CloseButton.GetComponent<Image>().color = new Color32(255,255,255,0);
        CloseButton.GetComponent<Button>().enabled = false;
        transform.position = new Vector3(15, 2, transform.position.z);
        Camera.transform.position = new Vector3((Teleporter.transform.position.x + 10), Camera.transform.position.y, Camera.transform.position.z); // teleports the camera to the teleporter source

        // level progress bar is set here
        endScores = new int[3] { Level1RequirementScore,Level2RequirementScore,Level3RequirementScore};
        GameStatusBars.transform.GetChild(4).GetComponent<Slider>().maxValue = endScores[BackgroundAndSpriteManager.currentLevelIndex - 1];

        SuperSprintWaitingTimer = SuperSprintWaitingTimerSharable;
        InjuredImage.color = new Color32(255,0,0,0);        
        
        IsAffectedByBlessingsOfHetwy = false;
        StopMovingObstacles = false;
        startSuperSprint = false;
        CanDoASuperJump = false;
        MakeEnableTheSuperJump = false;
        DoDoubleJump = false;
        IsSuperJumping = false;

        SuperJumpActivationTimer = 10f;
        GameStatusBars.transform.GetChild(3).GetComponent<Slider>().value = GameStatusBars.transform.GetChild(3).GetComponent<Slider>().maxValue;

        // usually sets the normal health icon
        SetGameBarIcon(7);
        // here player can refresh his/her controls knowledge
        ControlsTab.color = new Color32(255, 255, 255, 255);
        // here clear object for the player is displayed on the screen
        if (BackgroundAndSpriteManager.currentLevelIndex == 1)
        {
            BackgroundAndSpriteManager.LevelQuestName = "Fall of an Evil";
            BackgroundAndSpriteManager.LevelLocationName = "Red Sands";
            ObjectivesTab.text = "Objective:- \n Score 7269 or more Points to Cross The Level\n";
            PauseMenu.transform.GetChild(9).GetComponent<TextMeshProUGUI>().text = "\"Fall of an Evil\",Red Sands\n" + ObjectivesTab.text + "\n";
            LevelName.text = "\"" + BackgroundAndSpriteManager.LevelQuestName + "\"" + ",\n" + BackgroundAndSpriteManager.LevelLocationName;
        }
        else if (BackgroundAndSpriteManager.currentLevelIndex == 2)
        {
            BackgroundAndSpriteManager.LevelQuestName = "Into A Dark Trap";
            BackgroundAndSpriteManager.LevelLocationName = "Darker Unsar";
            ObjectivesTab.text = "Objective:- \n Score 8486 or more Points to Cross The Level\n";
            PauseMenu.transform.GetChild(9).GetComponent<TextMeshProUGUI>().text = "\"Into a Dark Trap\",Darker Unsar\n" + ObjectivesTab.text + "\n";
            LevelName.text = "\"" + BackgroundAndSpriteManager.LevelQuestName + "\"" + ",\n" + BackgroundAndSpriteManager.LevelLocationName;
        }
        else
        {
            BackgroundAndSpriteManager.LevelQuestName = "The After life realm";
            BackgroundAndSpriteManager.LevelLocationName = "Green Mists";
            ObjectivesTab.text = "Objective:- \n Score 7300 or more Points to Cross The Level\n";
            PauseMenu.transform.GetChild(9).GetComponent<TextMeshProUGUI>().text = "\"Off With The Scheme\",Green Mists\n" + ObjectivesTab.text + "\n";
            LevelName.text = "\"" + BackgroundAndSpriteManager.LevelQuestName + "\"" + ",\n" + BackgroundAndSpriteManager.LevelLocationName;
        }

        ObjectivesTab.color = new Color32(255, 255, 255, 255);

        LoadFiles.SetActive(false);
        SavedFile.SetActive(false);


        DinoBody = GetComponent<Rigidbody>(); // we first get the rigid body of the current dinosaur object and then do the appropriate logic on its movement 
        CameraBody = Camera.GetComponent<Rigidbody>();
        // by default sets the level sprites but can change the sprites to be displayed
        gameObject.GetComponent<BackgroundAndSpriteManager>().ChangeTheBackgroundSprites();
        PauseMenu.SetActive(false);
        //BodySource.clip = GrassRunning;
        VoiceSource.clip = PainSounds;
        GameOverScreen.SetActive(false);

        // is displayed in the pause menu what Quest and what location is player in 

        LevelName.color = new Color32(255, 255, 255, 255);
        ObjectivesTab.color = new Color32(255,255,255,0);
        
    }

    IEnumerator WaitTime()
    {
        //print("waiting");
        yield return new WaitForSecondsRealtime(2f);
        LevelName.color -= new Color32(0, 0, 0, 1);
        //print("reducing");
    }

    IEnumerator WaitTimeForObjectivesAndControls()
    {
        yield return new WaitForSecondsRealtime(10f);
        ObjectivesTab.color -= new Color32(0,0,0,1);
        ControlsTab.color -= new Color32(0, 0, 0, 1);
    }
    public void Retry()
    {
        GameOverClip.enabled = false;
        GameOverTimer = 0f;
        if (ConversationFlag)
            ConversationsObject.SetActive(true);
            

        print("this function is called");
        InjuredImage.color = new Color32(255, 0, 0, 0);
        ScoreText.GetComponent<Text>().enabled = true;
        SetGameBarIcon(7);
        PauseMenu.SetActive(false);
        SuperSprintTimerValue = 180f;
        GameStatusBars.transform.GetChild(0).GetComponent<Slider>().value = 0;
        GameStatusBars.transform.GetChild(1).GetComponent<Slider>().value = GameStatusBars.transform.GetChild(1).GetComponent<Slider>().maxValue;
        GameStatusBars.transform.GetChild(2).GetComponent<Slider>().value = GameStatusBars.transform.GetChild(2).GetComponent<Slider>().maxValue;
        GameStatusBars.transform.GetChild(3).GetComponent<Slider>().value = GameStatusBars.transform.GetChild(3).GetComponent<Slider>().maxValue;


        // Conversation control variables;
        //ConversationIndex = -1;
        ConversationFlag = false;
        SingleDialogueFlag = false;
        DialogueIndex = 0;
        dialogueTimer = 0f;


        GameStatusBars.SetActive(true);
        Time.timeScale = 1;
        isGameOver = false;
        SceneTimer = 0f;
        Level2SceneTrigger = false;
        isKnockedOut = false;
        IsSuperJumping = false;


        SuperJumpActivationTimer = 10f;
        GameScore = 0;
        Displacement = 1f;
        DinoSpeed = 17;
        transform.position = new Vector3(15,2,transform.position.z);
        Camera.transform.position = new Vector3((Teleporter.transform.position.x + 10), Camera.transform.position.y, Camera.transform.position.z); // teleports the camera to the teleporter source

        // here are the dialogue control variables
        DialogueIndex = 0;
        dialogueTimer = 0f;
        SingleDialogueFlag = false;
        ConversationFlag = false;


        //NumberOfBlessingsOfHetwy = 4;
        Health = 500f;
        IsAffectedByBlessingsOfHetwy = false;
        StopMovingObstacles = false;
        HetwysTimer = 0f;
        //IsBlessingsOfHetwyAvailable = true;
        EffectsChild.GetComponent<Animator>().SetBool("IsBlessed", false);

        AnimatedChild.GetComponent<Animator>().SetBool("IsDead", false);
        AnimatedChild.transform.localPosition = new Vector3(0.13f, 0.23f, -13f);
        SuperSprintWaitingTimer = 181f;
        SuperJumpTimer = 4f;
        //transform.position = new Vector3((Teleporter.transform.position.x + 8), 2, 0); // teleports to the teleporter source
        ShouldTeleport = false; // after teleportation we will not teleport anymore
        ShouldCreateAnewCourse = true; // will set of an alarm for the continuos spawner to make a         
        HasGameRestarted = true;
    }
    void ManageMusicAndAmbience(bool isGameOver)
    {
        if (isGameOver)
        {
            if (AmbienceSource.volume >= 0)
                AmbienceSource.volume -= 0.1f;
            if (MusicSource.volume >= 0)
                MusicSource.volume -= 0.1f;
        }/*
        else
        {              
            if (AmbienceSource.volume < 0.7f)
                AmbienceSource.volume += 0.1f;
            if (MusicSource.volume < 0.7)
                MusicSource.volume += 0.1f;
        }*/
    }

    void GeneralSoundVolumeSetter()
    {
        BodySource.volume = SettingsVariable.GetGeneralSoundsVolume();
        MagicSource.volume = SettingsVariable.GetGeneralSoundsVolume();
        GameOverClip.volume = SettingsVariable.GetGeneralSoundsVolume();

        ConversationAudioSource.volume = SettingsVariable.GetGeneralSoundsVolume();
        VoiceSource.volume = SettingsVariable.GetGeneralSoundsVolume();

        AmbienceSource.volume = SettingsVariable.GetEnvironmentalAmbienceVolume();
        MusicSource.volume = SettingsVariable.GetMusicVolume();
    }

    public void ResumeGame()
    {
        GameOverClip.enabled = false;
        if (ConversationFlag)
            ConversationsObject.SetActive(true);
        CloseButton.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
        CloseButton.GetComponent<Button>().enabled = false;
        GameStatusBars.SetActive(true);
        isPauseMenuActive = false;
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
        ConfirmationsTab.SetActive(false);
        LoadFiles.SetActive(false);
        SavedFile.SetActive(false);
    }
    

    private bool isLevelStarted = true;
    private float EarlyLevelTimer = 0f;
    // Update is called once per frame
    void Update()
    {        
        //print(Application.persistentDataPath);

        if (!isLevelStarted)
            LevelCode();
        else
        {
            if (EarlyLevelTimer >= 3f && EarlyLevelTimer <= 5f)
            {
                ObjectivesTab.enabled = true;
                if (ObjectivesTab.color.a < 255)
                    ObjectivesTab.color += new Color32(0,0,0,5); 
            }
            

            if (EarlyLevelTimer >= 0 && EarlyLevelTimer <= 0.2f)
            {
                TransitionScreen.enabled = true;
                TransitionScreen.color = new Color32(0, 0, 0, 255);
                LevelName.color = new Color32(255, 255, 255, 0);
                LevelName.enabled = true;
                ConversationsObject.SetActive(false);
                GameStatusBars.SetActive(false);
                ObjectivesTab.enabled = false;
            }
            else if (EarlyLevelTimer >= 0.29f && EarlyLevelTimer <= 2f)
            {   
                if (LevelName.color.a < 255)
                    LevelName.color += new Color32(0, 0, 0, 5);
            }
            

            else if (EarlyLevelTimer >= 8f && EarlyLevelTimer <= 10f)
            {
                if (LevelName.color.a > 0)
                    LevelName.color -= new Color32(0, 0, 0, 5);
                if (ObjectivesTab.color.a > 0)
                    ObjectivesTab.color -= new Color32(0,0,0,5);
            }
            else if (EarlyLevelTimer >= 10)
            {
                EarlyLevelTimer = 0f;
                isLevelStarted = false;
                ObjectivesTab.enabled = true;
                if(ConversationFlag)
                    ConversationsObject.SetActive(true);
                GameStatusBars.SetActive(true);
            }
            EarlyLevelTimer += Time.deltaTime;
        }

    }
    // update ends here
    void LevelCode()
    {
        //print("difficulty level:- " + SettingsVariable.GetDifficultyLevel());

        GameStatusBars.transform.GetChild(4).GetComponent<Slider>().value = GameScore;
        GameStatusBars.transform.GetChild(5).GetComponent<Slider>().value = NumberOfBlessingsOfHetwy;


        BodySource.GetComponent<AudioSource>().loop = false;
        MagicSource.GetComponent<AudioSource>().loop = false;
        VoiceSource.GetComponent<AudioSource>().loop = false;

        // we first check if the game is running or not if its not then all animations and the movement stops ad game is over 
        // by now

        ManageMusicAndAmbience(isGameOver);
        if (InjuredImage.color.a > 0)
            InjuredImage.color -= new Color32(0, 0, 0, 1);

        if (Health <= 0)
        {
            AnimatedChild.GetComponent<Animator>().SetBool("IsDead", true);
            isGameOver = true;
        }
        if (!isGameOver)
        {
            GeneralSoundVolumeSetter();
            GameOverScreen.SetActive(false);
            if(!BodySource.isPlaying)
                BodySource.Play();

            // calling the pause menu section
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!isPauseMenuActive)
                {
                    Time.timeScale = 0f;
                    PauseMenu.SetActive(true);
                    isPauseMenuActive = true;
                    GameStatusBars.SetActive(false);
                    ControlsTab.color = new Color32(255, 255, 255, 0);
                    ObjectivesTab.color = new Color32(255, 255, 255, 0);
                    CloseButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                    CloseButton.GetComponent<Button>().enabled = true;
                }
                else
                {
                    ResumeGame();
                }
            }




            if (!isKnockedOut)
                AnimatedChild.GetComponent<Animator>().SetBool("IsDead", false);
            else
                AnimatedChild.GetComponent<Animator>().SetBool("IsDead", true);
            // default player animation state

            // the is grounded variable is used to check if the player is colliding with ground of any type
            Position = new Vector3(Displacement, 0, 0);

            // the teleport is a way to not to make big ass maps and do not have to manage big coordinates
            // we teleport during that process what we do is we teleport the player to the start of the map and then create a new obstacle course            
            if (ShouldTeleport)
            {
                transform.position = new Vector3((Teleporter.transform.position.x + 8), transform.position.y, transform.position.z); // teleports to the teleporter source
                Camera.transform.position = new Vector3((Teleporter.transform.position.x + 8), Camera.transform.position.y, Camera.transform.position.z); // teleports the camera to the teleporter source
                ShouldTeleport = false; // after teleportation we will not teleport anymore
                ShouldCreateAnewCourse = true; // will set of an alarm for the continuos spawner to make a new course 
            }

            if (MakeEnableTheSuperJump == false)
            {

                SuperJumpActivationTimer += Time.deltaTime;
                GameStatusBars.transform.GetChild(3).GetComponent<Slider>().value = SuperJumpActivationTimer;
                if (SuperJumpActivationTimer >= 10f)
                {
                    SuperJumpActivationTimer = 0f;
                    MakeEnableTheSuperJump = true;
                }
            }



            if (!Level2SceneTrigger)
            {
                ManageConversation();

                if (TransitionScreen.color.a > 0)
                    TransitionScreen.color -= new Color32(0, 0, 0, 1);

                if (Input.GetKeyDown(KeyCode.LeftControl) && DoJump && MakeEnableTheSuperJump)
                {
                    SetGameBarIcon(10);
                    MagicSource.Stop();
                    MagicSource.clip = SuperJump;
                    if (!MagicSource.isPlaying)
                        MagicSource.Play();
                    ConversationsObject.SetActive(false);
                    BodySource.Stop();

                    AnimatedChild.GetComponent<Animator>().SetBool("IsSuperJumping", true);
                    AnimatedChild.GetComponent<Animator>().SetBool("IsNormalJumping", false);
                    isGrounded = false;
                    CanDoASuperJump = true;
                    DoJump = false;
                    //print("double space prepare for failed super jump");
                    DoSuperJump();
                    MakeEnableTheSuperJump = false;
                }

                // if pressed the space then the dinosaur must jump but checks if the dinosaur is on the ground or not 
                // by checking is the dinosaur is colliding with the ground of any type that will be checked in the onCollisionEnter method which is right below
                // float Difference = transform.position.y - Spawner.transform.position.y;                
                // print("Player to Spawning ground difference:- " + Difference + " SpawnGround y location:- " + Spawner.transform.position.y + " Player y Location:- " + transform.position.y);
                // if (Difference >= 3f && Difference <= 5f)
                // isGrounded = true;

                if(SettingsVariable.GetDifficultyLevel() == 3)
                    if (!isGrounded)
                        DinoBody.AddForce(1.95f * Vector3.down,ForceMode.Impulse);
                
                if (Input.GetKeyDown(KeyCode.Space) && (DoJump || DoDoubleJump))
                {
                    BodySource.Stop();
                    DoJump = false;
                    normalJump = true;
                    MakeNormalJump = true;
                    float Magnitude = 150f;
                    if (SettingsVariable.GetDifficultyLevel() == 3)
                        Magnitude = 200f;
                    if (isGrounded)
                    {
                        // if the dinosaur is perfectly grounded then appropriate force will be applied on the up side of the dinosaur body(RigidBody) to make 
                        // a jump and the speed is decreased appropriately
                        DinoBody.AddForce(Vector3.up * Magnitude, ForceMode.Impulse);
                        isGrounded = false; // and yes the dinosaur will be in the air and not touching the ground so the isGround variable is set to false 
                                            // so the double jumping glitch wont happen
                    }

                    // if not grounded then player must be in the mid air then we check if the player is fully double jump recharged or not if he is recharged then
                    // we will make a mid air or double jump
                    else if (!isGrounded && DoDoubleJump == true)
                    {
                        MagicSource.Stop();
                        MagicSource.clip = DoubleJump; // sets the clip for double jump here

                        AnimatedChild.GetComponent<Animator>().SetBool("IsSuperJumping", false);
                        DinoBody.AddForce(Vector3.up * 100f, ForceMode.Impulse);

                        if (!MagicSource.isPlaying) // plays the clip here
                            MagicSource.Play();


                        isGrounded = false;
                        DoDoubleJump = false; // the double jump is performed so it cant be performed again to make a triple jump so it is set to false
                        startDoubleJumpTimer = true;
                    }
                    MakeNormalJump = false;
                }

                // checks for the double click event using the double click Left Shift Event
                if (DoublePressedLeftShift())
                    if (SuperSprintWaitingTimer >= 180f)
                        startSuperSprint = true;



                if (Input.GetKeyDown(KeyCode.H))
                {
                    print(" called hetwy for help");
                    if (IsBlessingsOfHetwyAvailable)
                    {
                        print("had enough blessings");
                        if (!IsAffectedByBlessingsOfHetwy)
                        {
                            MagicSource.Stop(); // stop any magic music playing 
                            MagicSource.clip = Blessings; // play the blessings sound effect
                            MagicSource.Play(); // will actually play here

                            print("was not currently getting any help");
                            Health = 500;
                            dealDamage = 0.25f;
                            IsAffectedByBlessingsOfHetwy = true;

                            //if(HetwysTimer >= 59.9f)
                             NumberOfBlessingsOfHetwy--;
                        }
                    }
                }
            }

            if (isGrounded)
            {
                AnimatedChild.GetComponent<Animator>().SetBool("IsNormalJumping", false);
                AnimatedChild.GetComponent<Animator>().SetBool("IsDoubleJumping", false);
                AnimatedChild.GetComponent<Animator>().SetBool("IsGrounded", true);
            }
            else
            {
                if (!startDoubleJumpTimer)
                    AnimatedChild.GetComponent<Animator>().SetBool("IsNormalJumping", true);
                else
                {
                    AnimatedChild.GetComponent<Animator>().SetBool("IsDoubleJumping", true);
                }
                AnimatedChild.GetComponent<Animator>().SetBool("IsGrounded", false);
            }

            // so in order to use the animator controller without changing the actual logical body of the player we must attach a child animator
            // object then add a animator controller to it not by manually adding the component but by generating new animations so unity will automatically 
            // generate the controller for you 
            // in order to change the state we must use the boolean signals to change the states for eg to simulate if the player is jumping we must check if he is 
            // in the air or not so we might play the jumping animation at that time other wise normal idle or running animations will be played


            if (DoJump == false && normalJump == false)
            {
                SuperJumptimer += Time.deltaTime;
                AnimatedChild.GetComponent<Animator>().SetBool("IsNormalJumping", false);
                if (SuperJumptimer >= 3f)
                {
                    // reset the game state here
                    SetGameBarIcon(7);
                    SuperJumptimer = 0f;
                    DoJump = true;
                    AnimatedChild.GetComponent<Animator>().SetBool("IsSuperJumping", false);
                }
            }





            // here is the speed increment code 
            // we check if the SpeedTimer Variable is greater than 10 seconds then increase the DinoSpeed by 2 units
            // then keep incrementing the speed and then check if the timer is greater than or equal to 20 seconds then reset the timer
            // and increase the displacement by 0.2 units

            // this is a speed timer
            // the speed timer will increase every 10 seconds
            // they will be increased if they are below there upper limits
            // other wise they remain constant through out the game 
            if (Displacement <= 3.0f && DinoSpeed <= 30)
            {
                if (SpeedTimer >= 20f)
                {
                    Displacement += 0.1f;
                    DinoSpeed += 1;
                    SpeedTimer = 0f;
                }
                else
                {
                    SpeedTimer += Time.deltaTime;
                }
            }

            // checks the completion Of Quest
            CheckQuestCompletion();
            ManagerHealthBar();
            ManageSuperJumpBar();
            ManageSuperSprintBar();


            RegenrateHealth(); // regenerates the player health over the time
            DoubleJumpMaker(); // allows to make a double jump
            DoSuperSprint(); // allows to do a super sprint
            ManageBlessings(); // manages the blessings of Hetwy
            resetter(); // resets the position of player if he gets offcourse 
            //EffectsManager(); // manages the effects of armour and the health
            CalculateScore(); // calculates scores on the basis of timer of 0.7 seconds


        }
        // here if nothings true and game is over then the time is brought to a stand still
        else
        {

            ScoreText.GetComponent<Text>().enabled = false;

            BodySource.Stop(); // the player is dead no need to play the running sound effect 
            MagicSource.Stop();// while being dead the dead body cant cast spells so we stop the sounds right away
            VoiceSource.Stop(); // While being dead one cant be hurt so good idea will be to shut our heros mouth so that in his death he shall not roar

            if (GameOverTimer >= 2f)
            {
                GameOverTimer = 0f;                
                GameOverScreen.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                GameOverClip.volume = SettingsVariable.GetMusicVolume();
                ConversationsObject.SetActive(false);
                ControlsTab.color = new Color32(255, 255, 255, 0);
                ObjectivesTab.color = new Color32(255, 255, 255, 0);
                PauseMenu.SetActive(false);
                GameStatusBars.SetActive(false);

                if (TransitionScreen.color.a <= 1)
                    TransitionScreen.color += new Color32(0, 0, 0, 5);

                Displacement = 0f;
                DinoSpeed = 0f;
                AnimatedChild.transform.localPosition = new Vector3(0.13f, 1.37f, -15f);
                if (GameOverTimer >= 0 && GameOverTimer <= 0.1f)
                {                    
                    GameOverClip.enabled = true;
                    if(!GameOverClip.isPlaying)
                        GameOverClip.Play();
                }

                GameOverTimer += Time.deltaTime;                
            }
            if (Input.GetKeyDown(KeyCode.Return) && isGameOver)
                Retry();
        }


        ManageTextBasedOutputs(); // manages the text outputs for user convinience
    }

    private bool IsSuperJumping = false;
   
    
    void ManageSuperJumpBar()
    {

        if (IsSuperJumping)
        {
            if (GameStatusBars.transform.GetChild(3).GetComponent<Slider>().value > 0)
                GameStatusBars.transform.GetChild(3).GetComponent<Slider>().value--;
            else
                IsSuperJumping = false;
        }

    }

    Image FadeIn(Image img,byte intesity)
    {
        if (img.color.a < 255)
            img.color += new Color32(0,0,0,intesity);
        return img;
    }
    Image FadeOut(Image img,byte intensity)
    {
        if (img.color.a > 0)
            img.color -= new Color32(0, 0, 0, intensity);
        return img;
    }
    private void CheckQuestCompletion()
    {
        // changes the scene once the score reaches the 100 points;
        if (GameScore >= Level1RequirementScore && SubLevelIndex == 1)
        {            
            GameScore = 7269;
            GameStatusBars.SetActive(false);
            ObjectivesTab.enabled = true;
            ObjectivesTab.color = new Color32(255, 255, 255, 255);
            ObjectivesTab.text = "Objective Accomplished: Quest Complete";
            PauseMenu.transform.GetChild(9).GetComponent<TextMeshProUGUI>().text = "\"" + BackgroundAndSpriteManager.LevelQuestName + "\"" + ",\n" + BackgroundAndSpriteManager.LevelLocationName + "\n" + ObjectivesTab.text;
            if (TransitionScreenTimer >= 5f)
            {
                startSuperSprint = false;
                TransitionScreenTimer = 0f;
                Displacement = 1f;
                DinoSpeed = 17;
                SuperSprintTimer = 0f;
                // naturally load the sequence
                TempleSequence.StartTheSequence = false;
                HouseScript.ShouldSkipSequence = false;
                ConversationsObject.SetActive(false);
                AnimatedChild.GetComponent<Animator>().SetBool("IsSuperSprinting", false);
                LoadingScreenLinker.recievingIndex = 2;
                LoadingScreenLinker.DestinationIndex = 2;
                LoadingScreenLinker.subLevelIndex = 2;
                BackgroundAndSpriteManager.GameScore = 0;
                gameObject.GetComponent<SaveGameScript>().SaveFile();
                SceneManager.UnloadSceneAsync(2);
                SceneManager.LoadSceneAsync(1);
            }
            else
            {
                if (TransitionScreen.color.a < 255)
                    TransitionScreen.color += new Color32(0, 0, 0, 10);
                Spawner.DestroyCurrentObstacleCourse();
                ConversationsObject.SetActive(true);
                ConversationsObject.GetComponent<ConversationObjManager>().ManageConversationObject(Level1EndingDialogue,CharacterImages[Level1EndingDialogue.ImageId]);
                TransitionScreen = FadeIn(TransitionScreen, 1);
                TransitionScreenTimer += Time.deltaTime;
            }
        }
        else if (GameScore >= Level2RequirementScore && SubLevelIndex == 2)
        {
            print("Scenetimer:- " + SceneTimer);
            GameScore = 8486;
            ObjectivesTab.enabled = true;
            ObjectivesTab.color = new Color32(255, 255, 255, 255);
            ObjectivesTab.text = "Objective Accomplished: Quest Complete";
            PauseMenu.transform.GetChild(9).GetComponent<TextMeshProUGUI>().text = "\"" + BackgroundAndSpriteManager.LevelQuestName + "\"" + ",\n" + BackgroundAndSpriteManager.LevelLocationName + "\n" + ObjectivesTab.text;

            if (SceneTimer >= 4f && SceneTimer <= 39f)
                ManageConversation(Level2EndingDialogue, 7f);

            // the idea is that when ever the player has reached the 2nd level maximum score a cut scene must trigger
            if (SceneTimer >= 42f)
            {
                GameStatusBars.SetActive(false);
                if (TransitionScreenTimer >= 2f)
                {
                    Level2SceneTrigger = false; // by default end the scene
                    SceneTimer = 0f;
                    AnimatedChild.GetComponent<Animator>().SetBool("IsSuperSprinting", false);
                    startSuperSprint = false;
                    TransitionScreenTimer = 0f;
                    Displacement = 1f;
                    DinoSpeed = 17;
                    SuperSprintTimer = 0f;

                    // naturally load the sequence
                    TempleSequence.StartTheSequence = false;
                    HouseScript.ShouldSkipSequence = false;


                    LoadingScreenLinker.recievingIndex = 2;
                    LoadingScreenLinker.DestinationIndex = 3;
                    LoadingScreenLinker.subLevelIndex = 0;
                    BackgroundAndSpriteManager.GameScore = 0;
                    gameObject.GetComponent<SaveGameScript>().SaveFile();
                    SceneManager.UnloadSceneAsync(2);
                    SceneManager.LoadSceneAsync(1);
                }
                else
                {
                    TransitionScreen = FadeIn(TransitionScreen, 1);
                    TransitionScreenTimer += Time.deltaTime;
                }
            }
            // first fade the screen
            else if (SceneTimer >= 0f && SceneTimer <= 2f)
            {
                ConversationFlag = true;
                SingleDialogueFlag = true;

                dialogueTimer = 0f;
                DialogueIndex = 0;


                if (TransitionScreen.color.a < 255)
                    TransitionScreen.color += new Color32(0, 0, 0, 20);
                
                IsAffectedByBlessingsOfHetwy = false;
                StopMovingObstacles = false;
                HetwysTimer = 0f;
                EffectsChild.GetComponent<Animator>().SetBool("IsBlessed", false);
                Spawner.DestroyCurrentObstacleCourse(); // cleared the course by now 
            }
            else if (SceneTimer >= 2f && SceneTimer <= 4f)
            {
                Level2SceneTrigger = true; // disables the Player controls over the Character
                if (TransitionScreen.color.a > 0)
                {
                    ObjectivesTab.color -= new Color32(0, 0, 0, 20);
                    TransitionScreen.color -= new Color32(0, 0, 0, 20);
                }
            }

            else if (SceneTimer >= 9f && SceneTimer <= 10f)
            {
                if (ProjectileObject == null)
                    ProjectileObject = Instantiate<GameObject>(Projectile, new Vector3(transform.position.x - 60f, transform.position.y, transform.position.z), new Quaternion(0, 0, 0, 0));
                ProjectileObject.GetComponent<Rigidbody>().freezeRotation = true;
                ProjectileObject.GetComponent<ProjectileController>().SetXSpeed(9f);
                ProjectileObject.transform.name = "SceneProjectile";
            }

            else if (SceneTimer >= 34f && SceneTimer <= 36f)
            {
                if (TransitionScreen.color.a < 255)
                    TransitionScreen.color += new Color32(0, 0, 0, 10);
            }
            else;// you are very powerless, you cant threaten the might computer in doing anything else then this,you foolish little mortal XD XD



            SceneTimer += Time.deltaTime;
        }


        else if (GameScore >= Level3RequirementScore && SubLevelIndex == 3)
        {
            GameScore = 7300; 
            ObjectivesTab.enabled = true;
            ObjectivesTab.color = new Color32(255, 255, 255, 255);
            ObjectivesTab.text = "Objective Accomplished: Quest Complete";
            PauseMenu.transform.GetChild(9).GetComponent<TextMeshProUGUI>().text = "\"" + BackgroundAndSpriteManager.LevelQuestName + "\"" + ",\n" + BackgroundAndSpriteManager.LevelLocationName + "\n" + ObjectivesTab.text;
 
            if (TransitionScreenTimer >= 5f)
            {
                GameStatusBars.SetActive(false);
                AnimatedChild.GetComponent<Animator>().SetBool("IsSuperSprinting", false);
                startSuperSprint = false;
                TransitionScreenTimer = 0f;
                Displacement = 1f;
                DinoSpeed = 17;
                SuperSprintTimer = 0f;
                // naturally load the sequence
                TempleSequence.StartTheSequence = false;
                HouseScript.ShouldSkipSequence = false;
                ConversationsObject.SetActive(false);
                LoadingScreenLinker.recievingIndex = 2;
                LoadingScreenLinker.DestinationIndex = 4;
                LoadingScreenLinker.subLevelIndex = 0;
                BackgroundAndSpriteManager.GameScore = 0;
                gameObject.GetComponent<SaveGameScript>().SaveFile();
                SceneManager.UnloadSceneAsync(2);
                SceneManager.LoadSceneAsync(1);
            }
            else
            {
                if (TransitionScreen.color.a < 255)
                    TransitionScreen.color += new Color32(0, 0, 0, 10);
                Spawner.DestroyCurrentObstacleCourse();
                ConversationsObject.SetActive(true);
                ConversationsObject.GetComponent<ConversationObjManager>().ManageConversationObject(Level3EndingDIalogue,CharacterImages[Level3EndingDIalogue.ImageId]);
                TransitionScreen = FadeIn(TransitionScreen, 1);
                TransitionScreenTimer += Time.deltaTime;
            }
        }
    }
    public void SetGameScore(int score) {GameScore = score;}
    public int GetScore() { return GameScore; }
    public bool GetGameOverFlag() { return isGameOver; }


    int[] DamagePerDifficulty = new int[3] {50, 100, 150};
    private void OnCollisionEnter(Collision collision) 
    {
        // if the Player is touching the ground of any type
        if (collision.transform.name == "Spawnableground" || collision.transform.name == "ReSpawnLocation") 
        {            
            // if player is touching the ground then the player is ready to jump and can jump
            isGrounded = true;
            DoJump = true;
            normalJump = false;
        }
        // or if the Player is touching any Obstacle 
        if ((collision.transform.name.Contains("Obstacle") || 
            collision.transform.name.Contains("MobileEnemy") ||
            collision.transform.name.Contains("ArmedEnemy"))&& startSuperSprint == false)
        {
            // if player is touching any obstacle then the game is over
                isGameOver = true;
                AnimatedChild.GetComponent<Animator>().SetBool("IsDead", true);
        }
        if ((collision.transform.name == "TopSection" ||
            collision.transform.name.Contains("projectile")) && startSuperSprint == false)
        {
            
            ReduceHealthBar = true;
            if (!VoiceSource.isPlaying)
                VoiceSource.Play();
            // the player is injured not dead so his speed is reduced to the original speed and will keep increasing over the time
            Health -= DamagePerDifficulty[SettingsVariable.GetDifficultyLevel() - 1] * dealDamage;
            GameStatusBars.transform.GetChild(1).GetComponent<Slider>().value -= DamagePerDifficulty[SettingsVariable.GetDifficultyLevel() - 1] * dealDamage;
            InjuredImage.color = new Color32(255,0,0,100);
            startHealthtimer = true;            
        }

        if (collision.transform.name == "TeleporterDestination")
        {
            // will start the event to recreate the obstacle course as to continuosly spawn objects and travelling and teleporting seamlessly
            ShouldTeleport = true;
        }

        if (collision.transform.name == "SceneProjectile")
        {
            // halt down the player
            DinoSpeed = 0f;
            Displacement = 0f;
            isKnockedOut = true;
            // play the Death Animation 
            AnimatedChild.GetComponent<Animator>().SetBool("IsDead", true);
            AnimatedChild.transform.localPosition = new Vector3(0.13f, 1.37f, -15f);
            BodySource.Stop(); // the player is dead no need to play the running sound effect 
            MagicSource.Stop();// while being dead the dead body cant cast spells so we stop the sounds right away
            VoiceSource.Stop(); // While being dead one cant be hurt so good idea will be to shut our heros mouth so that in his death he shall not roar
        }
    }


    private void FixedUpdate()
    {
        // this code to highlight the level and the questname
        if (LevelName.color.a > 0)
            StartCoroutine(WaitTime());
        else
            StopCoroutine(WaitTime());

        // this code to highlight the controls and the objectives to the Player
        if (ObjectivesTab.color.a > 0 && 
            ((Level2RequirementScore >= GameScore && BackgroundAndSpriteManager.currentLevelIndex == 2) ||
             (Level1RequirementScore >= GameScore && BackgroundAndSpriteManager.currentLevelIndex == 1) ||
             (Level3RequirementScore >= GameScore && BackgroundAndSpriteManager.currentLevelIndex == 3)
            )
           )
            StartCoroutine(WaitTimeForObjectivesAndControls());
        else
        {
            ControlsTab.enabled = false;
            ObjectivesTab.enabled = false;
        }
        MoveCode(Position);        // moves the dinosaur's rigid body in the fixd update time so that the calculated collisions are correct
    }

    // for rigidBody movement we will use the RigidBody.MovePosition() method 
    // we have been updating the position Vector in the Update Function 
    // in the Fixed Update method we call our MoveCode in which we give the Updating Vector of the Dinosaur and the in the MoveCode
    // the Updating Vector is multiplied with Speed and delta time and then added to the Current position of the Dinosaur
    private void MoveCode(Vector3 Directions)
    {
        // here a good thing is that the camera and the dinosaur 's speed is managed by the Displacement which is the distance to be travelled by the object 
        // and DinoSpeed which multiplies the movement speed along with the delta time here neat thing is that changes to the camera and the object is done only using the 
        // displacement and dinospeed variables so just have to modulate them whenever needed
        DinoBody.MovePosition(transform.position + (Directions * DinoSpeed * Time.deltaTime));
        CameraBody.MovePosition(Camera.transform.position + (Directions * DinoSpeed * Time.deltaTime));
    }

    private bool ReduceHealthBar = false;
    private bool IncreaseHealthBar = false;

    void ManagerHealthBar()
    {
        float HealthBarValue = GameStatusBars.transform.GetChild(1).GetComponent<Slider>().value;
        if (ReduceHealthBar)
        {
            if (HealthBarValue > Health)
                GameStatusBars.transform.GetChild(1).GetComponent<Slider>().value--;
            else
                ReduceHealthBar = false;
        }
        if (IncreaseHealthBar)
        {
            if (HealthBarValue < Health )
                GameStatusBars.transform.GetChild(1).GetComponent<Slider>().value++;
            else
                IncreaseHealthBar = false;
        }

    }

    float[] IncreaseHealthTimerPerDifficulty = new float[3] {2f,3f,4f};
    float[] IncreaseHealthPerDifficulty = new float[3] {105f,90f,75f};
    // with the hard difficulty player really need to use the saving exploit that runs well with how the spawning behaviour in this game actually work
    // and i really hope that my dear players find this thing soon while they play the game on such difficulty :)
    void RegenrateHealth()
    {
        if (!IsAffectedByBlessingsOfHetwy)
        {
            if (Health < 500)
            { 
                if (HealthTimer >= IncreaseHealthTimerPerDifficulty[SettingsVariable.GetDifficultyLevel() - 1])
                {
                    IncreaseHealthBar = true;
                    Health += IncreaseHealthPerDifficulty[SettingsVariable.GetDifficultyLevel() - 1];
                    HealthTimer = 0f;
                }
                else
                    HealthTimer += Time.deltaTime;
            }
        }
    }

    float[] DoubleJumpRefreshTimerPerDifficulty = new float[3] {1.2f,0.8f,0.4f};
    void DoubleJumpMaker()
    {
        // this method follows the same implementation as the method above which is healthRegenrator
        // this is a double jump timer 
        // the double jump module will activate like every 5 seconds if it was previously performed 
        // and the timer will be reset if it were true then will be set to true only
        if (startDoubleJumpTimer)
        {
            DoubleJumpTimer += Time.deltaTime;
            if(DoubleJumpTimer >= 0.1f)
                AnimatedChild.GetComponent<Animator>().SetBool("IsDoubleJumping", false);
            if (DoubleJumpTimer >= DoubleJumpRefreshTimerPerDifficulty[SettingsVariable.GetDifficultyLevel() - 1])
            {
                // after this time the double jump is available
                DoDoubleJump = true;
                DoubleJumpTimer = 0f;
                startDoubleJumpTimer = false;
            }
        }
    }



    // this method will check if the shift is pressed double times or not it will first take the input of the left shift key
    // then it will store the last press time and store the difference of the current time and the last pressed time in to the difference variable
    // which is time since last press then it will check if the user re inputs the same key and the time window is .3 seconds if the user inputs 
    // the left shift within the .3 second window then return true or in all case return false
    private bool DoublePressedLeftShift()
    {
        bool isDoublePressed = false;
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            float timeSinceLastPress = Time.time - lastPressTime;
            lastPressTime = Time.time;
            print("shift was pressed once");
            if (timeSinceLastPress <= 0.3f)
            {
                print("shift was pressed twice");
                isDoublePressed = true;
            }
        }
        return isDoublePressed;
    }


    // this method will make the dino do a super sprint for 10 seconds and have a 5 second go through phase in which the dinosaur can go
    // through any obstacle but not the ground and the teleporters in the first 10 seconds the speed is maxed out and the sprint time is calculated
    // then it is checked if 10 seconds are passed since the sprint activation or not if it has passed then reset the speed to original starting speed
    // and during the super sprint jump command is not registered it is instead in the 5 seconds cool down phase and after 15 seconds the 
    // super sprint is brought to a complete halt

    float SuperSprintTimerValue = 180f;
    private float ReducingTimer = 1f;
    void ManageSuperSprintBar()
    {
        if(startSuperSprint)
        {
            SuperSprintWaitingTimerSharable = 0;
            if (ReducingTimer > 0.5f)
            {
                SuperSprintTimerValue = GameStatusBars.transform.GetChild(2).GetComponent<Slider>().value;
                SuperSprintTimerValue -= (180/24);
                ReducingTimer = 0f;    
            }
            else
            {
                ReducingTimer += Time.deltaTime;
                if (GameStatusBars.transform.GetChild(2).GetComponent<Slider>().value > SuperSprintTimerValue)
                    GameStatusBars.transform.GetChild(2).GetComponent<Slider>().value--;
            }
        }

        else
        {            
            SuperSprintWaitingTimer += Time.deltaTime;
            SuperSprintWaitingTimerSharable = SuperSprintWaitingTimer;
            GameStatusBars.transform.GetChild(2).GetComponent<Slider>().value = SuperSprintWaitingTimer;
        }
    }

    private void DoSuperSprint()
    {
        if (startSuperSprint)
        {
            MagicSource.volume = 1f;
            SetGameBarIcon(9);
            if (SuperSprintTimer <= 5f)
            {
                BodySource.Stop();// dont want some mishaps with the sounds but keep the running sound down when super sprinting
                AnimatedChild.GetComponent<Animator>().SetBool("IsSuperSprinting", true);
                if (SuperSprintTimer >= 0 && SuperSprintTimer <= 1f)
                {
                    MagicSource.clip = SuperSprintWarpIn; // first play the Warp in 
                    MagicSource.loop = false;
                    if (!MagicSource.isPlaying)
                        MagicSource.Play();
                }
                else if (SuperSprintTimer >= 1f && SuperSprintTimer <= 4f)
                {
                    MagicSource.loop = true;
                    MagicSource.clip = SuperSprint; // then play the Super sprint effect
                    if (!MagicSource.isPlaying)
                        MagicSource.Play();
                }
                else
                {
                    MagicSource.loop = false;
                    MagicSource.clip = SuperSprintWarpOut; // then play the warp out effect
                    if (!MagicSource.isPlaying)
                        MagicSource.Play();
                }
            }
            Displacement = 3.0f;
            DinoSpeed = 30;
            SuperSprintTimer += Time.deltaTime;
            SuperSprintWaitingTimer = 0f;
            // super sprint phase
            DoJump = false;
            CanDoASuperJump = false;
            isGrounded = false;
            DoDoubleJump = false;
            if (SuperSprintTimer >= 4.2f)
                AnimatedChild.GetComponent<Animator>().SetBool("IsSuperSprinting", false);

            if (SuperSprintTimer >= 5f)
            {
                MagicSource.Stop();
                BodySource.Play();
                // slow down phase
                Displacement = 1f;
                DinoSpeed = 17;
                //AnimatedChild.GetComponent<Animator>().SetBool("IsSuperSprinting",false);                
                if (SuperSprintTimer >= 9f)
                {
                    DoJump = true;
                    CanDoASuperJump = true;
                    isGrounded = true;
                    DoDoubleJump = true;
                    if (SuperSprintTimer >= 12f)
                    {
                        SetGameBarIcon(7);
                        startSuperSprint = false;
                        SuperSprintTimer = 0f;
                        ReducingTimer = 0f;
                    }
                }
                // complete halt down
            }
        }


    }

    private void DoSuperJump()
    {
        float Magnitude = 200f;
        if (SettingsVariable.GetDifficultyLevel() == 3)
            Magnitude = 400f;


        DinoBody.AddForce(Vector3.up * Magnitude, ForceMode.Impulse);
        isGrounded = false;
        CanDoASuperJump = false;
    }

    // sometimes the dinosaur gets off track and needs to be relocated to the track so this method will check if the 
    // the dinosaur goes to much in the right or the left then it will reset the dino position 
    private void resetter()
    {
        if (transform.position.z > 1 || transform.position.z < -1)
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }



    private float BlessingBarReducingTimer = 0f;
    void ManageBlessings()
    {
        // simple Quantity Check nothing too complicated
        if (NumberOfBlessingsOfHetwy <= 0)
            IsBlessingsOfHetwyAvailable = false;

        // checks if the player is blessed by the her Divinity or not
        if (IsAffectedByBlessingsOfHetwy)
        {
            print("Hetwy's timer:- " + HetwysTimer);
            if (HetwysTimer < 0)
                GameStatusBars.transform.GetChild(0).GetComponent<Slider>().value = 60;


            if (HetwysTimer >= 0 && HetwysTimer <= 60f)
            {
                EffectsChild.GetComponent<Animator>().SetBool("IsBlessed", true);
                SetGameBarIcon(8);
                if (BlessingBarReducingTimer > 1f)
                {
                    GameStatusBars.transform.GetChild(0).GetComponent<Slider>().value--;
                    BlessingBarReducingTimer = 0;
                }
                else
                    BlessingBarReducingTimer += Time.deltaTime;
            }
            else
            {
                SetGameBarIcon(7);
            }
            HetwysTimer += Time.deltaTime;

            
            if (HetwysTimer >= 0.1f && HetwysTimer <= 60f)
            {
                StopMovingObstacles = true;
                if (Health < 500)
                    Health = 500;
            }
            // after like 30 seconds the effect wears off
            if (HetwysTimer >= 60f)
            {
                IsAffectedByBlessingsOfHetwy = false;
                HetwysTimer = 0f;
                EffectsChild.GetComponent<Animator>().SetBool("IsBlessed",false);
            }            
        }

    }
  
    void CalculateScore()
    {
        float scoreUpdateTimer;


        if (startSuperSprint)
            scoreUpdateTimer = 0.02f;
        else if (IsAffectedByBlessingsOfHetwy)
            scoreUpdateTimer = 0.06f;
        else
            scoreUpdateTimer = 0.07f;
        // increments the score like every 0.1 seconds
        if (ScoreTimer >= scoreUpdateTimer)
        {
            GameScore++;
            ScoreTimer = 0f;
        }
        else
            ScoreTimer += Time.deltaTime;
    }
    void ManageTextBasedOutputs()
    {
        // outputs and updates the values in the variable of different variables which are essential for the game
        ScoreText.GetComponent<Text>().text = "" + GameScore;
        IsAffectedWithBlessingsText.GetComponent<Text>().text = "Blessings of Hetwy:- " + IsAffectedByBlessingsOfHetwy;        
        IsinArmourEffectText.GetComponent<Text>().text = "the armour status:- " + ArmourPickedUp;
        PlayerCurrentHealthText.GetComponent<Text>().text = " Health:- " + Health;
        IsDoubleJumpAvailableText.GetComponent<Text>().text = " is double Jump :- " + DoDoubleJump;
        TotalBlessingsAvailableText.GetComponent<Text>().text = "number of blessings available:- " + NumberOfBlessingsOfHetwy;
        SuperSprintStatus.GetComponent<Text>().text = "Is in Super sprint:- " + startSuperSprint;
        IsGameOverText.GetComponent<Text>().text = "the game is Over :- " + isGameOver;
        SuperJumpStatus.GetComponent<Text>().text = " Super Jump is Available:- " + MakeEnableTheSuperJump;

        
    }
}
