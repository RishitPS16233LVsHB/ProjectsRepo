//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LoadScreenScript : MonoBehaviour
{
    public Image[] LoadingScreenImageList;
    public Image Logo;
    public Image GameTitle;
    public TextMeshProUGUI LoadingScreentips;
    public static GameObject Linker;
    public AudioSource BackgroundBreeze;
    int Index=0;
    float Timer = -1f;
    
    string[] Tips = new string[120]
    {   
        " The Merans had originated from the tears of the Lady Sunara.",
        " The Merish were cursed to live a sinful life.",
        " Although the Merish people lived a sinful lives,they do believe in \"The Great White Horn\" \n who will change there fates forever.",
        " Zymer may look like a pretty unintelligent species of beings but some of there race played a vital role in the growth Merish civilization.",
        " Many races of \"RAUN\" consider the race of Meran to be a disgrace to Lady Sunara.",
        " Recent civil war on the Merish home planet of \"Red Sands\" had left most of the populus devasted,\n signalling the Ferans to launch an invasion on Red Sands.",
        " The cause of the Merish race were tears of White Gold Princess's grief over Ryseth's Black War Corruption.",
        " Merish kind has a special ability towards atheletics making them run and jump near endless times.",
        " The Merish invasion done by the Metal Kingdoms is led by Rissel Calisbaan.",
        " Over the period of time the Merish kind has done henious acts through out the Arkus/Arckus,\n thus they earned there disgraceful titles.",

        " Really who or more specifically what is Unsar?\nIs it a place or a being?\nWhy is it so powerful that both wisdom gods worship it for its favor upon them?",
        " Lady Sunara And Lord Feree were not always the gods they are thought of now,they earned there god hood by great divine quest which are conducted by the Unsar itself.",
        " It is predicted by the wisdom gods that Unsar will always turn chaotic after certain millenia,\n after that all of the Unsar will be plunged into dark times wars , civil wars , debauchery , collapse of law and order and many more,\n after that whats left is nothing but voidful Unsar,not even the gods can survive the fall.",
        " Ryseth Feree is the god of wisdom , courage , order and companionship.",
        " Ryseth was corrupted thoudsands of years ago in the Black War against some unknown forces which had brought great imbalance to the Unsar.",
        " Lady Sunara And Ryseth Feree are considered to be most deeply connected lovers and will not leave each others side no matter what situation comes.",
        " Lady Sunara was deeply scared by the corruption of Lord Feree's as if she just lost a part of her being or even more was lost.",
        " Till this date Lady Sunara is trying to cure Lord Feree's corruption,but she fail each time.",
        " The Lord Feree's challenge of 3 realm run is just soul harvesting scheme for him to cure his corruption.",
        " The Corruption has gotten to the wisdom god so much that he has lost much of his former character and had made him a jealous,short-sighted and angry man and a pure evil has found its way into his mind.",

        " Lady Sunara is the goddess of wisdom,love,life and beauty.",
        " Lady Sunara and Lord Feree are called the \"Keepers of the Unsar\".",
        " Before being a divine goddess,Lady Sunara lived a life of royal luxury,while on the other hand Lord Feree lived his life of constant failures yet lived with hope of success one day.",
        " Lady Sunara is considered to be the true companion of the mighty Unsar and Lord Feree through these dark times.",
        " Although Lady Sunara is the goddess of the love and non-violence in the needing time she too picks up the sword to support the right side.",
        " \"The scars of corruptions were never healed , yet i hope to witness a final dawn together with my sweet iron before its dark\"\n-Lady Sunara.",
        " Clan Sunara of Auruswon Province has dominated the Aurish Province since the dawn crecent of Unsar.",
        " Once in battle on situation , Lady Sunara generated an energy burst so violent that it nearly wiped out entire planet which still scares his dear husband till this date.",
        " As the wisdom gods Lady Sunara And Lord Feree can know future events through complicated rituals.",
        " The wisdom divines possess the ability to manipulate time itself if they want to but at very small scale for large scale its impossible for them.",

        " Double press Left Shift to achieve that sweet super sprint.",
        " Press Left Control to dodge twice the amount of enemies.",
        " In this 3 realm run challenge the runner is not entirely helpless divines will help the player if need or called by the player.",
        " Many beings reside Arckus/Arkus which consists of Merans,Ferans,Aurans,Agrans and Zymers much of the Arckus/Arkus is left unexplored by these beings maybe they may explore something new in future.",
        " Player may get chance to read some books,\n he or she may or may not read them but it might help them uncovering the Unsar.",
        " The Darker Unsar is a dark realm and is close to a lock up to trap all of the foreign powers and corrupted spirits up there.",
        " The wisdom divines reside in Green Mists,in which they live life like normal beings.",
        " All those fallen travellers in the Darker Unsar now aimlessly and lifelessly drag themselves as they failed to complete there run and there souls were forfeited by Lord Feree.",
        " The player must travel a certain amount of distance to cross a realm.",
        " The 3 realm run challenge has very simple rules do not hurt any living beings,just dodge them in any manner possible,if you had purest of intentions for this ritual then you are permitted to perform it , otherwise you are just wasting your time and be careful your treacherous action of decieving the divnes in any form during this run , you will be noted and from that point your run is considered irrelevant thus you will be wasting your time.",
        
        " Be very careful while quick saving the game you will be overwriting your previously quick saved game....",
        " If you want to replay some moments in the game but the game auto saves you can always manually backup your prefered saved game file and load it instead of the current save game.",
        " While you save the game in a game sequence you will be storing the level information not the information about how much the sequence was completed,upon loading the sequence will load from start only if saved after then you will have successfully skipped the sequence.",
        " Be very careful on using your blessings from start of the new game you only get 4 of them and every time you replay or restart the number never resets to 4.",
        " Lady Sunara knows much about the Unsar and her blessings can help you very much by halting every moving enemy on the place and making them jitter for 60 seconds all you have to do is still avoid them or else you might still lose.",
        " While being blessed you are mostly immune from health damage done by the krysturs and landing on top any non moving objects but you are still vulnerable to be knocked down by these objects.",
        " Blessings last for 60 seconds but your ability to score run points and to win the favour of the gods remains mostly the same.",
        " Double jumping is very essential and very common mechanic use it often in the life or death situations so you might evade certain death.",
        " Super jumping makes you jump a huge height but its recharge is often 10 - 20 seconds long so use them very cautiously.",
        " Wounds are not eternal,your damaged health can be restored overtime,all you have to do is to complete the run and win the favour of the gods.",
        
        " Myskhoolians are a group of Merish engineers and rebel group who are currently rebelling against the \"Crown masters of Red Sands\" to demolish there control over the Red Sands.",
        " Zymers have three species one found on the planet of Red Sands,One found in the Green Mists realm and one is thought to be found on Zymer home planet which are thought to be extinct.",
        " Aurans and Agrans are most prominent in Economics,Business,Diplomacy and Worship of the gods.",
        " Aurans And Agrans are constantly in Competition with one another and to win the favour of the gods for themselves and advance there own civilization.",
        " The Ferans are masters in the art of warfare and technology,although being very scientific they do value of art of any form and do believe in the Unsar and its keepers but they are not particularly involved themselves to fanatically praise them like Aurans and Agrans.",
        " The Black War is an ancient legend that had been fought between the gods with there followers against some mysterious beings of existence.",
        " During The Black War,Ryseth got corrupted while trying to save his armies and Lady Sunara,nobody knows how but till today it is known that in the process of saving his men and his wife,he was covered by dense fog at some point of time and what emerged of it was faint and now corrupted Ryseth.",
        " \"The Ritual of Run\" that any being performs to win the favour of gods,was completed by many beings in the past and gods granted them special status of being not there follower but applying there code and bringing balance to Unsar.",
        " Gods are very powerful as just there tears can give birth to entirely new beings.",
        " Mother and Father are of Ferish Origin who were Trapped in The Darker Unsar some time after the Black War.",

        "Aurans are natives of Auran Nation by the name of Auruswon.",
        "Aurans have a rich history of divine worshipping and very good ties with Trading,Business,Commerce and Economics.",
        "An Aurish man/woman may be alone but so determined that it would be foolishness to consider him/her all alone.",
        "Aurans used to feel egoistic about themselves and sought themselves as the greatest race in the Unsar,but everything changed when Lady Sunara ascended and taught them to never underestimate the wills of Unsar.",
        "A great reasons why Aurish folks are so prepared is that they were taught to never trust what is in front of them and follow the wills of Unsar and be ready to face whatever Unsar throws at them.",
        "The concept of Dawn,Horizon,Dusk,Twilight crecent of Unsar or time was first researched by Aurish and Agrish scholars who worked very hard on there theories and worked very hard to prove them right.",
        "According to Aurish,The Dawn crecent is that period of time similiar to morning where time reset and what rises is a new lifeful Unsar.",
        "Every being believes that,Unsar flows through the cycle of Dawn,Horizon,Dusk and then Twilight and no mortal can escape this cycle.",
        "Unsar is believed to be a dominant force,but such dominant force is like beast,ready to pounce on any one and likely cause chaos,but according to Aurish The Swarna is the one who controls and tames this beast.",
        "As Dusk Crecent arrives,Beast(Unsar) becomes restless want itself to be freed from the clutches of the Swarna and becomes more and more powerful,after then the it is freed,so the Chaos Dawns upon Unsar and with such begins the Twilight Crecent.",
                
        "Ferans are the natives of Metal Kingdoms now Called The United Provinces of Ferra and Torra.",
        "Ferish People are known for there Technological advancements in divine smithing and technological innovations.",
        "Ferish People Are divided into sub-cultures of Ferrish Ferra Known for there Legendary Smithing and Crafting achievements and Ferrish Torra known for there Technological and Philosophical Achievements.",
        "A Feran child is taught from there childhood that Unsar is a hot metal yet to be shaped,hammer it enough to shape it to your needs.",
        "Ferra might be Smiths but they are Powerful in logic and reasoning too as Ferraun Engineers had performed such feats in engineering that made Torraun Engineer shame themselves at that time.",
        "Ferish people belives that a Ferrish man is lucky to work at forge and engineer greatness,but he/she is Lucky to eternally work at forge once he/she achieves the \"Unrusted\".",
        "When any race looks upon the Ferish folks,they see them always working and never resting,but that is not the case,Ferish are the creator,not there own creations that work day and night restlessly.",
        "Ferish do enjoy there lives but they are rarely seen doing enjoying activities such as festival celebrations and feasts,but when they do they can put Agrish and Aurish to Utter amazements.",
        "Ferrish celebrate there new years hoping to earn the knowledge most knowledge they can from the Unsar.",
        "Ferrish do believe in unsar and its keepers but they prefer working rather than begging like others do and in that way Unsar smiles on them and rewards them handsomely for there struggle",

        "Agrish are the natives Sonor Lands or the \"Great Agrish Nation\".",
        "Agrans are known to be the rivals of Aurans in most aspects of Aurish lifestyle and business.",
        "Agrish were originally Aurans who decided to leave there home lands to explore new places and settled in the present day Sonor Lands.",
        "Agrish still persists the classic class systems and generally have egoistic attitude.",
        "An Agrish believes that universe must flow in its intended purpose,but they believe that there is another universe inside of us.",
        "Symbols of Aurish And Agrish is quite engimatic but they were not created by them but they are thought to be the teachings of long forgotten twilight beings Unsar.",
        "In Agrish culture if Lady Sunara,White Horn and Lord Feree are praised in the name of \"Noblet\".",
        "Agrish Sonor Lands is Home for many Snowy Tundra planets.",
        "An Agran from there childhood are told that the Unsar is like there home planet,frigid in nature and colder beyond there comprehension,but there ambition and determination to survive in such cold will keep them warm in this endless blizzard.",
        "Agrish Sonor Lands Might look cold dead,but it is not all cold and snow some of its planet are warm and filled with beautiful woods that give Aurish \"Swarna Woods\" some good beatings.",

        "Many identify Unsar by its an almost close arc with both its tips colored in dark and light tones.",
        "The Arc representation of Unsar can be interpretted in many ways,some says it represents all three realms :- \"Green Mists,Mortal Space or Arkus/Arckus\" and Darker Unsar.",
        "Some represent Unsaric symbol in different way in a more \"Time based\" manner defining it as in the form of Dawn Crecent,Dusk Crecent,Horizon and the Twilight Crecents.",
        "Aurish Representation or Auric Symbol was gifted to them by the twilight beings of Unsar in Early Dawn Crecents of Unsar.",
        "Agrish believe that there is another Unsar like ours inside all of us.",
        "One interpretation of the Auric symbol is that Unsar held by support of two beings who are not a part Unsar for them reality exists outside of it,thus normal rules of time does not apply on them.",
        "Agrish are the firm believers of a reality within there reality,the only concept that proves there theory is the theory of \"The Ascended\" or the \"Swarna,Unrusted,Noblet or White Horn\" depending which ideology you follow.",
        "White Horn is an Legend of the times when Merans were first cursed to live like bulls hundered or thousands of years ago who had managed to attain the Ascendence but was never heard of again.",
        "Nobody knows what will happen when dusk falls?,Could there be endless war and blood shed?,Could moralality of the mortal fall?,Could the great shiner eat us and bring forth the eternal darkness we fear today? Anything can happen at that time.",
        "The Wisdom Gods met twilight beings or the \"Beings of old time\",who face there end.",

        "Ryseth Feree A Ferrish,was born in Luhari Clan which dominates the provinces of Metal Kingdoms and Hetwyie Sunara an Aurish,Was Born in Sunara clan which dominates the Auruswon provinces.",
        "He barely managed to save her from that ferocious beast,She felt that this was her end,she was in Agonizing pain yet she smiled and told him that even if she died that night she was happy that atleast she died in his arms and as an adventurer.",
        "Lord Feree barely saved her from her wound,thanks to the healing spell his mother had taught him all those years ago.",
        "The spell costed too much for young Feree that he was unconscious after chanting the last verse.",
        "Lady Sunara still remenbers that night,Hugging his arm while he rested and knowing that he will be with her forever and ever,remaining awake all night guarding his unconscious body and periodically checking him and treating his injuries from that bear attack.",
        "Lady Sunara had attraction for the prince but it changed to pure gilded love when she came to know that he suffered too in the past,but enjoyed her company and was living his life for the first time,she knew that anything happened and she will stay by his side forever.",
        "\"The Eternal Bonds\" was no ordinary marriage it is here when Lord Feree asked Lady Sunara to be one in front of Unsar and in front of the very wilderness where he saved her life to be forever be bounded with each other and never leave each other no matter ehat Unsar throws at them.",
        "Lord Feree and Lady Sunara loved to adventure and learn new thing,politics of great kingdoms were dust for them and wealth worthed them nothing so when given a choice they chose there holy path to adventure and to there ascendence they chose the path for adventure.",
        "The decision of Lord Feree and Lady Sunara became inspiration for next generation of Aurans,Agrans,Meran and Ferans for given choice between Unlimited power,wealth and path of adventure and knowledge one must pick the choose the later option,as one might not ascend but for greater unsar every civilization needs thinkers not politicians.",
        "Leaders lead there people,Thinkers Think for there people and in that saying both are required to guide the races of mortals to a greater Unsar before Dusk falls and void settles.",

        "In Heads Up Display,The Purple Bar progress slowly and it signifies the progress of each level that you are currently playing.",
        "In Heads Up Display,The Lime colored bar shows the number of blessings that you have left now,use them very wisely as you get only 4 of them through out the game.",
        "In Heads Up Display,Numerical score is also shown if the player prefers it that way along with the score bar.",
        "In Heads Up Display,Blue bar shows the charge required to make a super jump,after employing a super jump this bar will gradually fill up,super jump can only be employed once that bar is fully filled up.",
        "In Heads Up Display,The Green Bar shows the charge required to perform super sprint,after employing a super sprint this bar will gradually fill up,super sprint can only be employed once that bar is fully filled up.",
        "In Heads Up Display,The Golden or Yellow colored bar represents the time remaining for blessing of lady sunara,try not to die as Lady Sunara helps you relieve your burdens and just dodge the obstacles.",
        "In Heads Up Display,The obvious red bar represents health of the player,do not let it fall down too much,else you die.",
        "In Heads Up Display,if player is in a magical effect like super jump,super sprint or in blessed it will be displayed in the center circular space.",
        "Objectives and controls for the current level will be made clear to player each time you reload the level or enter the level newly,and they are accessible anytime in the pausemenu.",
        "Make sure while you call for blessings,you use it completely as saving the game while being affect with blessings will only reduce your blessings count but next to you reload the same game you might not be blessed."
    };

    void SetAudioVolume() {
        BackgroundBreeze.volume = SettingsVariable.GetEnvironmentalAmbienceVolume();
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadingScreentips.text = " ";
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        SetAudioVolume();
        //print(Timer);
        if (Timer >= -1f && Timer <= -0.1f)
            ResetSprites();

            LoadingSequence();
        Timer += Time.deltaTime;
    }
    void ResetSprites()
    {
        foreach (Image img in LoadingScreenImageList)
            img.color = new Color32(255,255,255, 0);
        GameTitle.color = new Color32(255, 255, 255, 0);
        Logo.color = new Color32(255, 255, 255, 0);
        LoadingScreentips.color = new Color32(255, 255, 255, 0);
        Timer = 0f;
    }
    void LoadingSequence()
    {
        if (Timer >= 0f && Timer <= 10f)
        {
            if (Timer >= 0f && Timer <= 0.101f)
            {
                Index = Random.Range(0, Tips.Length-1);
            }
            else if (Timer >= 1f && Timer <= 3f)
            {
                GameTitle = FadeIn(GameTitle);
                Logo = FadeIn(Logo);
                LoadingScreentips.text = Tips[Index];
                LoadingScreentips = FadeIn(LoadingScreentips);

                int ImageIndex = Index / 10;
                LoadingScreenImageList[ImageIndex] = FadeIn(LoadingScreenImageList[ImageIndex]);
                /*
                if (Index >= 0 && Index <= 9)
                    LoadingScreenImageList[0] = FadeIn(LoadingScreenImageList[0]);
                if (Index >= 10 && Index <= 19)
                    LoadingScreenImageList[1] = FadeIn(LoadingScreenImageList[1]);
                if (Index >= 20 && Index <= 29)
                    LoadingScreenImageList[2] = FadeIn(LoadingScreenImageList[2]);
                if (Index >= 30 && Index <= 39)
                    LoadingScreenImageList[3] = FadeIn(LoadingScreenImageList[3]);
                if (Index >= 40 && Index <= 49)
                    LoadingScreenImageList[4] = FadeIn(LoadingScreenImageList[4]);
                if (Index >= 50 && Index <= 59)
                    LoadingScreenImageList[5] = FadeIn(LoadingScreenImageList[5]);
                if (Index >= 60 && Index <= 69)
                    LoadingScreenImageList[6] = FadeIn(LoadingScreenImageList[6]);
                if (Index >= 70 && Index <= 79)
                    LoadingScreenImageList[7] = FadeIn(LoadingScreenImageList[7]);
                if (Index >= 80 && Index <= 89)
                    LoadingScreenImageList[8] = FadeIn(LoadingScreenImageList[8]);
                if (Index >= 90 && Index <= 99)
                    LoadingScreenImageList[9] = FadeIn(LoadingScreenImageList[9]);
                if (Index >= 100 && Index <= 109)
                    LoadingScreenImageList[10] = FadeIn(LoadingScreenImageList[10]);
                */
            }
            else if (Timer >= 13 && Timer <= 15f)
            {
                GameTitle = FadeOut(GameTitle);
                Logo = FadeOut(Logo);
                LoadingScreentips.text = Tips[Index];
                LoadingScreentips = FadeOut(LoadingScreentips);

                int ImageIndex = Index / 10;
                LoadingScreenImageList[ImageIndex] = FadeIn(LoadingScreenImageList[ImageIndex]);

                /*
                if (Index >= 0 && Index <= 9)
                    LoadingScreenImageList[0] = FadeOut(LoadingScreenImageList[0]);
                if (Index >= 10 && Index <= 19)
                    LoadingScreenImageList[1] = FadeOut(LoadingScreenImageList[1]);
                if (Index >= 20 && Index <= 29)
                    LoadingScreenImageList[2] = FadeOut(LoadingScreenImageList[2]);
                if (Index >= 30 && Index <= 39)
                    LoadingScreenImageList[3] = FadeOut(LoadingScreenImageList[3]);
                if (Index >= 40 && Index <= 49)
                    LoadingScreenImageList[4] = FadeOut(LoadingScreenImageList[4]);
                if (Index >= 50 && Index <= 59)
                    LoadingScreenImageList[5] = FadeOut(LoadingScreenImageList[5]);
                */
            }
        }
        else
        {
            Timer = 0f;
            ResetSprites();
            gameObject.GetComponent<LoadingScreenLinker>().ChangeTheScene();
        }
    }

    Image FadeIn(Image img)
    {
        if (img.color.a < 255)
            img.color += new Color32(0, 0, 0, 10);

        return img;
    }
    Image FadeOut(Image img)
    {
        if (img.color.a > 0)
            img.color -= new Color32(0,0,0,10);
        return img;
    }
    TextMeshProUGUI FadeIn(TextMeshProUGUI text)
    {
        if (text.color.a < 255)
            text.color += new Color32(0, 0, 0, 10);
        return text;
    }
    TextMeshProUGUI FadeOut(TextMeshProUGUI text)
    {
        if (text.color.a > 0)
            text.color -= new Color32(0, 0, 0, 10);
        return text;
    }

}
