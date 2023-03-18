//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DialoguesAndConversationDatastructures;
//using UnityEngine.Audio;
public class IntroSequence : MonoBehaviour
{
    public Image GameTitle;
    public Image WhiteHornEmblem;
    public TextMeshProUGUI DialogueText;
    public GameObject ConversationObject;

    public AudioSource AmbienceSource;
    public AudioSource ConversationSource;

    public AudioClip LadySunaraConversation;
    public AudioClip MeranConversation;

    public AudioClip IntroRollInTheme;
    public AudioClip RedSandsAmbience;
    public AudioClip GreenMistsAmbience;

    public TextMeshProUGUI SkipText;

    float timer = 0f;
    float dialogueTimer = 5f;
    int DialogueIndex = 0;
    Dialogue[] dialogues = new Dialogue[10]
    {
        new Dialogue("Lady Sunara","The Day is Strangely Jolly today here in Green Mists,As The Wars Rage on Red Sands i feel strange relief.",0),
        new Dialogue("Lady Sunara","I should be worried for my Love,but this feels like a strange salvation.",0),
        new Dialogue("Lady Sunara","Salvation from all my pain and suffering,Maybe it is the way of Unsar.",0),
        new Dialogue("Lady Sunara","Usually the air felt heavy to me,but there is this sudden feeling that all my pains will be vanquished today.",0),
        new Dialogue("Lady Sunara","There are far more important matters in Unsar and about my love that i should be really considering right now.",0),
        new Dialogue("Lady Sunara","My inner hope tells me that everything shall be resolved today,it is strange i never had feeling since....since we were back in that camp and he was healing my wound that night",0),
        new Dialogue("Lady Sunara","Aah[weeps and smiles]...That Moment,How can i ever forget it,He was so Desparate and i had this strange feeling of relief,felt like my final moments,but proud and honored of myself of departing as an adventurer and his lover",0),
        new Dialogue("Lady Sunara","He cried and cried so desparately for my safety,I felt my end was near,but poor prince needed me more than anybody else,In his arms i felt joy like never before,until now",0),
        new Dialogue("Lady Sunara","I feel like my inner guilt is eating me up every day for not being an ideal keeper of Unsar and being a betrayer to everyone that believed in me,i think of ending myself right now,but i pledged to live everyday for him.",0),
        new Dialogue("Lady Sunara","For my actions,I should be punished and be condemned for eternity in Darker Unsars,But this strange feeling is compelling me to live another day,i dont know if Unsar wants me to be strong during these times,but i shall never lose hope,and fight for him till my last breath",0)
    };
    Dialogue[] dialogues2 = new Dialogue[10]
    {
        new Dialogue("Meran","Finally free from the imperial prison",0),
        new Dialogue("Meran","I shall never forget what they made me do",0),
        new Dialogue("Meran","She was just as innocent but they made me do unspeakable things to her",0),
        new Dialogue("Meran","I sometimes think this was my fault why didn't i pulled the trigger on myself earlier i joined there rebellion....",0),
        new Dialogue("Meran","That Auran didn't deserve to die like that",0),
        new Dialogue("Meran","I may never be forgiven for my actions but i wish that my soul went clean in the Green Mists and for that i am ready to face any fate Unsar has to offer",0),
        new Dialogue("Meran","I used to Believe in our rebellion but both the side are equally doomed and they can't change there fates now",0),
        new Dialogue("Meran","I don't know if unsar may ever forgive me for my action to that poor Aurish girl",0),
        new Dialogue("Meran","I have heard that successfully performing the \"Ritual of Run\" with purest hearts had changed the fates of many man and there deepest desires were fullfiled",0),
        new Dialogue("Meran","But those who were unsuccessful they were never heard of again,but i don't care my sins overweight me and before entering Green mist i want my soul clean or not enter at all so i will perform the ritual and face the justice of Unsar",0)
    };
    // Start is called before the first frame update
    void Start()
    {
        SkipText.color = new Color32(255, 255, 255, 0);
        timer = -8f;
    }

    private float SkipSequenceTimer = 0;
    // Update is called once per frame
    void Update()
    {
        SkipSequenceTimer += Time.deltaTime;
        if (SkipSequenceTimer >= 17f)
        {
            if (Input.GetKey(KeyCode.Return))
                SkipSequence();
            if (SkipText.color.a < 255)
                SkipText.color += new Color32(0, 0, 0, 5);
        }
        SetAudioVolume();
        IntroGameSequence();
    }
    // do any scene related changes here
    void SkipSequence()
    {
        //SkipSequenceTimer = 0;
        //timer = 147f;
        LoadingScreenLinker.recievingIndex = 5;
        LoadingScreenLinker.DestinationIndex = 2;
        LoadingScreenLinker.subLevelIndex = 1;
        BackgroundAndSpriteManager.GameScore = 0;

        SceneManager.UnloadSceneAsync(5);
        SceneManager.LoadSceneAsync(1);
    }
    void SetAudioVolume()
    {
        AmbienceSource.volume = SettingsVariable.GetEnvironmentalAmbienceVolume();
        ConversationSource.volume = SettingsVariable.GetGeneralSoundsVolume();
    }
    void IntroGameSequence()
    {
        print(timer);
        if (timer >= -8f && timer <= -1f)
        {
            if (!AmbienceSource.isPlaying)
            {
                AmbienceSource.clip = IntroRollInTheme;
                AmbienceSource.Play();
            }
            ConversationObject.SetActive(false);
            if (timer >= -6f && timer <= -5f)
                GameTitle = FadeIn(GameTitle);
            else if (timer >= -2f && timer <= -1f)
                GameTitle = FadeOut(GameTitle);
        }
        else if (timer >= 0f && timer <= 70f)
        {
            if (!AmbienceSource.isPlaying)
            {
                AmbienceSource.clip = GreenMistsAmbience;
                AmbienceSource.Play();            
            }
            Conversation(dialogues,LadySunaraConversation,0.2f);
            
            //else if (timer >= 23f && timer <= 24.1f)
            //  WhiteHornEmblem = FadeIn(WhiteHornEmblem);
            //else if (timer >= 40f && timer <= 42.1f)
            ;//  WhiteHornEmblem = FadeOut(WhiteHornEmblem);
        }
        else if (timer >= 75f && timer <= 145f)
        {
            if (!AmbienceSource.isPlaying)
            {
                AmbienceSource.clip = RedSandsAmbience;
                AmbienceSource.Play();
            }

            Conversation(dialogues2,MeranConversation,0.9f);
            if (SkipText.color.a > 0)
                SkipText.color -= new Color32(0, 0, 0, 1);
        }
        else if (timer >= 147f)
        {
            SceneManager.UnloadSceneAsync(5);
            SceneManager.LoadSceneAsync(2);
            BackgroundAndSpriteManager.currentLevelIndex = 1;
            BackgroundAndSpriteManager.CanChange = true;
        }
        else
        {
            ConversationObject.SetActive(false);
            DialogueIndex = 0;
        }
        timer += Time.deltaTime;
    }
    void Conversation(Dialogue[] dialogues,AudioClip clip,float volume)
    {
        if (DialogueIndex < dialogues.Length)
        {
            if (dialogueTimer >= 7f)
            {
                if (!ConversationSource.isPlaying)
                {
                    ConversationSource.clip = clip;
                    //ConversationSource.volume = volume;
                    ConversationSource.Play();
                    
                }

                ConversationObject.SetActive(true);
                ConversationObject.GetComponent<ConversationObjManager>().ManageConversationObject(dialogues[DialogueIndex]);
                dialogueTimer = 0f;
                DialogueIndex++;

                if (DialogueIndex > dialogues.Length - 1)
                    DialogueIndex = 0;
            }
            else
            {
                dialogueTimer += Time.deltaTime;
            }
        }
        else
        {
            dialogueTimer = 0f;
            DialogueIndex = 0;
        }        
    }
    Image FadeIn(Image target)
    {        
            if (target.color.a < 255)
                target.color += new Color32(0, 0, 0, 5);

        return target;
    }
    Image FadeOut(Image Target)
    {
        if (Target.color.a > 0)
            Target.color -= new Color32(0, 0, 0, 5);
        return Target;
    }
}
