//using System.Collections;
//using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class BooksContent : MonoBehaviour
{
    
    public TextMeshProUGUI BookContent;
    private GameObject PageNumber;
    private GameObject BookTitle;

    public static int CurrentBook = -1;
    public static int CurrentPage = 0;

    [SerializeField]
    private static Sprite[] Symbols;
    private static Sprite DefaultImage;
    public Image SymbolSpace;
    private int[] SymbolImageIndex = new int[12] {1,2,1,3,3,1,2,1,0,2,3,1};
    public static string[,] BookContents = new string[12,5] {
        //0
        { 
            // The Real Hetwyie Sunara part-3
            "Hail Lady Sunara and Lord Feree and all hail Unsar\n" +
            "As they departed for the castle she hugged him telling him she wanted them to forever adventure and never rest , prince smiled and agreed and said \"It would be great but it would be great if we had our own Home in the hills before we went on such adventures..\" , Lady Sunara now finally understanding that he loves her with all his souls and wont let her go off his sights she gave into his love as well , " +
            "hugging him even tighter and blissfully smiling with closed eyes as she rests her head comfortably on his back as they made there way to the castle , at evening they reached The castle and decided to camp but they had limited food so they decided to hunt something for them there was only few hours left for the day light to vanish so they had to gather up there resources fast , so they immediately departed for jungle in front of them." +
            "Ryseth ever so clever in his survival instincts left a clever trail for them to make a return which fascinated Lady Sunara and wanted to know more about that kind of knowledge soon they found a deer roaming around and they hunted it down , on the way to there camp , a bear attacked Lady Sunara but Ryseth Barely Managed to Save her as he casted a fireball on the beast incinerating it alive." +
            "Hetwyie's wounds were grave and she was loosing a lot of blood with each passing second , if left untreated she wont see next dawn or worse would not survive that night , as the dusk fall leaving with no chance they retreated back to there camps Ryseth scouring the camp to find remedy for his love's injury , emptied everything in his and her bags but couldn't found anything that useful but somethings that will help her to prevent blood loss , he saw her pains and can't resist to go find a remedy but a idea came to his mind he decided to use a spell taught by her mother to heal anyone but he hadn't tried it.",

            "He told Lady Sunara about the spell and also told that he never tried that kind of spell ever in his life and fears that it might afflict adverse effects on her but she relieved in his arms saying \"Don't worry , love , if i didn't made it today at least when i go to the mists i would tell my mother that i lived an adventurous life full of thrill , companion ship and true love and you fullfiled my dreams [smiling and tears slowly dripping off her face at the same time]\"." +
            "He screamed while crying for her \"Just shut up i will not let that happen to you , after all this time Unsar gave me such companionship and such love in your form [carefully casts the spells and chants the verses of the spell]\" Lady Sunara said \"[painfully closing her eyes smiling and Weeping for her immediate depature from him but knowing its the wills of Unsar she said] no love , you have fateful future for your kingdom with or without me..\" Ryseth with all his voice told her to shut up and told her to stop thinking like that and tears dripping all over his face." +
            "As he chanted the last verse of the spell , Prince Feree's mother blessed him and he successfully casted that spell and with that she was healed completely , slowly opening her eyes , seeing an exhausted Ryseth laying unconscious , she quick grabbed him and laid him on his bed fearing anything happened to him she checked his vitals and to her fortune he was breathing but just exhausted by all of the casting he had done.",

            "She stayed up all the night protecting him and wont let anything happen to him , the next day Lord Feree finally woke up and saw an asleep Sunara sitting on her chair beside his bed all hugging his arm , he took her in his arms and laid her on her bed and covering her with a blanket while she was being moved she constantly murmered \"n..no....mus...protect...him\"." +
            "he kissed on her forehead and said quietly to have some rest he moved to the cooking pot to cook something for them both , shortly after a while she woke up unable to find his love anywhere distressed but heard a familiar voice \"Ahh you are awake i made some breakfast for us both hope you like it..\" quickly running to him and grabbing him like her priced possesion and long lost love and said \"why can't you stay at your bedroll , you idiot , i worried where you might have been..\" he replied with gentle voice\"you have no right in saying this." +
            "you are as guilty as you claim me to be , that night you said this was your end and you nearly killed me with those words , numbskull\", Knowing nothing but only thing that she has her love in arms she kissed him , not something both were expecting , but prince Feree never felt such companionship and love in his life ever before , he held her tight and let her do her thing after they were finished she said \"Now we are castle ready , lets go!\" to which Prince Feree replied \"I am starving and that deer meat is good till its hot\".",

            "Lady Sunara still crying but happily said yes and added \"you know the gold you have been talking around all this time?\" Ryseth replied with a yes , \"Well I am lucky for my self that i had got some one like you if it weren't for that art convention \" He Replied \"Oh come on please don't say it like that[smiling] , Come on now i am starving[still holding her] , the meat wont taste good if it was stiff cold and i do not have firewood on me\" she weeped but smiled at him gesturing him to have there breakfast." +
            "While eating there meal he said \"I heard your conversation with my father\" she replied with an amazement on her face \" Ohh....\",Ryseths searches something in his bag and says\"....And i brought you this[kneels down on one knee] After you came , My life was filed with the adventure like i felt never before , compassion and love that my Mother had gave me all those years ago , I dont know if it were will of Unsar or not but before this very nature , would you marry me? Are you willing to be with me till the Dusk Crecent of the Unsar?\"." +
            "Lady Sunara excited out of her mind starts crying and excitedly says yes Ryseth replies with \"Well then , my love lets complete our quest and then make our relation official to the Unsar\".",

            "After clearing out the castle on there way to Luhari palace Hetwyie now tightly hugging Ryseth in her arms and gently laying her head on his back asks him \"Will our life as Aadventurer be over after we have married and you would have taken the Ferish Throne? will we be Adventuring ever again?\"." +
            "Prince Feree replies with a yes which dissapoints her but he adds \"Well we arrive at two paths \" Hetwyie lifts her head to look over and replies with \"yes one leads to Luhari kingdom and other leads to a jungle\"." +
            "Prince Feree smiles on her and asks her which way should they pick and told her not to worry at all as he will convince both there father if she picked the other path rather than the one to Luhari palace." +
            "Lady Sunara now fully in her control chooses for jungle and so that path they take as the mighty Adventurers and eventually there path led them to become the very \"Keepers of Unsar\"....The End [continuation of further events in \"The Metal Prince - Start of Journey\"]",
        },
        //1
        {
            // this book is ferish
            // Book name :- Metal Kingdoms  by Eldwane Luva
            "Metal Kingdoms by Eldwane Luva..\n" +
            "Since the dawn crecent of Unsar the one who are most prominent in the field of technology and science are the race of Ferans." +
            "ferans are known for there disciplined lifestyle and work intensive nature they say that a Aurish might worth 100 men,but a job done by a Feran can't be done by those 100 men." +
            "Most ferans reside in the ferish territories ruled by Ferra and Torra,these are governing body of Metal kingdoms regions these government bodies came into existence as the ferish communities were divided between the communities of smiths,Artisans and Mathematicians,Logicians and technocrats." +
            "This divide came out of nowhere as it happened shortly after the Black war took place and was won by the Unsaric Forces against the Foreign Forces trying to invade Unsar",

            "The Ferra are the traditional smiths and artisans who work in the melting hot forges to forge Strong fera weapons and artisans who work all day to make beautiful ferish arts." +
            "The Torra are the beings who believe in advancement of race through the technology they are responsible for many of the greatest inventions Unsar might have seen such as the krystur made out of the Divine Krystal Rock(volatile crystal that can amplify energy or store any kind of any type of energy for long time periods)  which is very hard to engineer." +
            "Common thing about them is that they are very industrious in nature but they too respect ones capacity of work." +
            "Ferra and Torra are now reconsidering about there recent relations ship and are reconsidering to reunite again under one ferish kingdom.",

            "Ferish have interesting case of mind set when it comes to praying someone they do belive in gods but they will not be involved in  there devotions as much as a am agrish or an aurish would be in involved." +
            "From a very young age they are taugh about perfection,determinations and patience while in the work they are taught that perform there duties well when assigned and with perfection or else don't take such task that you can't complete." +
            "This policy might sound shallow and simple but it is often misunderstood and too hard to implement across the Unsar so much so that they are the only masters of this policy.",

            "Lord Ryseth was a ferish before his ascendance toward the \"Unrusted\"(now he pertains his memories as an ferish designer but being a greater unsaric being he cannot be called ferish anymore same foe lady sunara) was done and was very good smith but showed a good aptitude for torrish technologies along with being a ferish forge Master" +
            "Even till date as a god he forges new and exciting things and sharing the knowledge with the Ferans and Torrans.",
            
            ""
        },
        //2
        {
            // this book is aurish 
            // book name :- Lady of Auruswon by delment sunari
            "Lady of Auruswon by Delment Sunari..\n" +
            "Hail Lady Sunara and Hail the All mighty Unsar..\n" +
            "That fateful day that day marked history when two Divines met each other and passionately fell for each other in the bonds of love." +
            "There Meeting would be written down in history as from that point they walked a path to change the fates of unsar and they were on there path to become the Swarnas." +
            "By this point you dear reader can come to know that we will be discussing how Divines Ryseth Feree and Hetwyie Sunara met each other and resolving a long lost conflict between Ferans and Aurans.",

            "Somewhere in the Dawn Crecent of The Unsar,Hetwyie Neev Sunara was born to Sunaran Royalty or put it simply to the king and queen of Auruswon who led the Aurish Sunaran clan in the Aurish provinces." +
            "Young Sunara had a very adoring nature which was loved by all within and outsides of the Auruswon territories,Hetwyie in her younger had least interest towards learning as born in a royal court she was quite comfortable with the Luxuries that she had" +
            "But her this very nature was changed after the loss of her mother in her teen age that made her not to rely on her on the luxuries that the life gave and must be prepared whatever the unsar had in it for her." +
            "Hetwyie was honest in her nature and very honest while talking to anybody but after her mother became one Unsaric being she endured the change and determined herself to change her nature as her mothers dying words were for her to not rely on things that are physical but to trust and rely on the Unsar.",
            
            "Young Sunara worked days and night to change her perspective and her father was quite supportive to her cause as she was there first child meaning potential heir to the throne." +
            "Lady Sunara after her mother's passing had complete change in life it was like from this point she became the Lady Sunara we pray and Adore so much,her mother Kysha Sunara was a Agrish aristocrat's Daughter who teached young sunara about the importance of self-dependence ,love to others and importance of a glorius quests before death." +
            "It was something that her mother wanted for her daughter that she explored Unsar with her beloved one as she did not had that privilege with Neev." +
            "As Lady Sunara was part of Royal family she had to follow many royal customs that she felt were too burdening for her and to her many family as well as societal traditions felt too closed." +
            "The Modern day Aurans owe a great debt to Lady Sunara and her legacy that made Auran race more open and broad minded beings as we know them",

            "In Sunaran culture there is a saying \"A Sunaran might look weak but A Sunaran bear Heart of steel and That makes A Sunaran feel like 100 mens behind him\" Sunarans are taught this princeiple from there early age no matter whatever comes you must prevail." +
            "Again this was the gift of Lady Sunara In her Guidance the Sunaran race ascended to heights that even was not possible for other beings to reach." +
            "Although Lady Sunara never took the leadership of our kind but she always guided every willing Sunaran to reach there true potential,Lady Sunara Our Swarna had not only guided us but guided numerous kinds of mortals through her wisdom." +
            "Lady Sunara was not alone in this journey,Lord Feree of Luhari clan of Ferra helped her in her achievements and became one of the \"Unrusted \" With Lady Sunara",

            "Lady Sunara is passionate lover of art and had a deep cravings to learn something new every day and she has one of the kindest nature in all of Unsar." +
            "despite belonging to a royal family she treated anyone and everyone equally.May her Actions May never be forgotten in this Darkest Dusk crecents of the Unsar" +
            "And May her Ever glowing beauty bring a new morning for the Unsar....."
        },
        //3
        {
            // this book is Unsaric
            // book name:- The Legendary White horn
            "The Legendary White Horn,By ------.\n" +
            "Skies turned red as gods Cursed us for our treachorous actions ,some say it were greater good of the \"Bloom fell\" and her Meras and some say that this inevitable because we were doomed to live like this because what use had we derived of our gifts." +
            "Now the sky has turned red for us and all those blooming life on our lands are now just part of a red desert and we proudly call it \"The Red Sands\" , now that our wonderful planet is set for its gloomy after life , I from the depths of my heart cry for forgiveness to my All Mother." +
            "I feel that my kind may never be redeemed of its unspeakable crimes towards Unsar and towards All Mother we might just originate from her pains but our kind is so shameless that instead of relieving her stress we burdened her forever,tainting her name for creating such a disgraceful race like Meran." +
            "but all hopes are not lost as \"White Horn\" will rescue us from our gloomy fates and relieve our mother's burdens and comfort her like her true son and from that day we will become what our mother intended us to be her relief , her most comforting and adoring sons and daughters.",

            "Dear reader please do not be in the misconception that our \"White Horn\" is a Mythical creature , He was like us a corrupted Mera after Conversion of Bloom fell , Lord Ryseth had" +
            " started the \"Ritual of Run\" for all beings that are in existence and White Horn was the one of the first runner to perform and complete the ritual and earning the favour of the gods and in there infinite wisdom they blessed our hero with immense knowledge and power but has never been spoken of ever since." +
            "Nobody knew after his victory where he went but still in our hearts he lives and such in our hearts the hopes lives and one day we shall make our mother comfort as her true sons and daughters" +
            "And Our lands will become the \"Bloom Fell\" that we loved all those centuries ago",

            "We Merans took our existence as too granted and lived like savages we pillaged , betrayed , ruled , exploited and massacared many beings of Unsar But we did that in the name of our All Mother and that is the reason that we still live like bulls and tainted our beloved mother's name." +
            "The White Horn is purest son of Lady Sunara and even in curse he never stopped in believing her even though being nearly killed by Lord Feree but he thought that he did that so to test him or his kind deserved no mercy so he must suffer for it too but bravery in his breath,he completed the ritual and got our mother's blessing." +
            "He never return to save us from our suffering , Oh Mighty White Horn we await your return , please come make us our mother's true sons and daughter.",

            "White Horn Originally belonged to Myskhoolia The Merish Kingdom of warriors and even ruled the kingdom as her rightful Crown Master Before we were cursed and ever so benevolent in his nature but after the curse something inside him was broken and he became weary of the damn land once he ruled." +
            "White horn might became frustated of his existence but in his curse he believed in our All-Mother and performed the ritual for us and our betterment so that our generations get to live in prosperous new Bloom Fell , but his dissappearance is a waiting , a waiting for his divine arrival." +
            "And by gods this waitings is insufferable , they say that nobody have ever returned from that twisted ritual but we believe in your Might White horn that you shall return and you shall remove all the wrongs and false gods on Bloom fell.",

            "Ohh Mighty Please return For Our All Mother and relieve her pains and make our race right again."
        },


        //4
        {
            //this book is Unsaric
            // book name:- The Ascendence part - 1
            "The Ascendence part - 1, by -------." +
            "Hail all mighty Unsar,." +
            "Let us start the book with a question of What is Aura? The one things that is present in all of us but is very hard to see and understand , What is its nature? How does it operate? How does one affect one's mental abilities?" +
            "These questions might be very hard to answer if we dont know about the Aura , The Aura is Present in All Humans and other Non Human beings which acts like its very soul and its made of two elements." +
            "The Mind and the Source , the concept of Aura cannot be grasped by any mortal just by reading this book and minorly understanding , this concept is purely subjective to one's perspective and way of thinking this concept had driven many insane while some became gods when understood perfectly." +
            "I guess this book can provide the Information required to understand a beings ascendence but it can never provide a subjective view of Aura and Ascendence to each individual being thus reader has to be wise while reading and very thoughtful how they comprehend this concept.",

            "The Aura Has two element the Mind and the Source some may call them as \"The Mind element and The Element of Consciousness\",\"A Unsar within\" and \"The Controller and the Minopia\" as i said the this concept is far more subjective than this book can ever ellaborate." +
            "The Aura with this component is like an Unsar within ones being , The Source element in the Aura acts like a wild Unsar that we experience in our day to day life and we know the nature of unsar that it can get out of control pretty easily thus requiring a good amount of controlling from those who understand it very deeply." +
            "Deep in our minds we do have such beings we just do not know of there presence they are responsible to things more understandable to our consciousness and make our minds more stable , these concepts might not make sense at all but trust me before unsderstanding one must have a deeper connection with ones aura and the mind element",

            "This book might not be subjective in this matter but it tries to provide the general views of all those who have witnessed and seen the realms of mind elements inside them through there strong nerves they remained in there correct state of mind and lived sane enough to share us there stories." +
            "Now you may ask how can the concept of Aura make a person Insane? Well this the Path to Ascendence.......",

            "",

            ""
        },

        //5
        {
            // this book is Aurish
            // Personal Diary of Lady Sunara
            "Dear Diary,\n" +
            "I don't know how ever will be able to free him , that worm or \"Corrupt\" as he calls itself has snatched away him , i know and it dared to do take away my very being from me , " +
            "If i got a chance i will slay him and free my love from him atleast relieving from it's sufferings , he has suffered so much from that leech only if i could trap it , but how? , maybe i can talk to my Sweet Iron through Minopian Underworld if he have some better ideas.." +
            " Seems like that worm had read my diary earlier But i an smart , it was busy setting up defences in the Minopian Underworld but much to his surprise the message must have gone through other source that were not controlled by it....all this years of capturing him and can't fortify much of minopia for itself,shame." +
            "That foul Worm couldn't see the difference it was the Ryseth's Controller that i had given my message and even by now he should know that nobody controls the controller and read its mind.",

            "My sweet iron gave me permission to work on that plan , The plan is simple that foul worm is known to be imapatient just use it to my advantage as The current runner must not voluntarily give up and frustrate him so much that it takes control of the Ryseth's mind forcing Ryseth" +
            "To Kill the current player but here is where that stupid leech lacks intelligence , what i will do is that just banish him to this realm and ending its little scheme must hide this Diary in......never mind i will just keep it with me.." +
            "That Worm never gets out of Green Mist just enjoying the view but i might be underestimating him i must keep it busy with me so that he never leaves the Green Mists",

            ".." +
            "must find improved way to lure that Worm in my hooks,but how?",

            "Alas , another soul will be sacrificed , I see Ryseth is talking like me i guess another one will be sacrificed today.\n\n" +
            "What some one manage to cross his REALM? , after so many years someone managed to cross realm , but i fear he might not be able to cross the Darker depths of Unsar." +
            "\n\nThis must be the Signal of Unsar to Trigger the plan." +
            "That Worm is as cowards as it is weak , it might intimidate someone but needs to learn how to do just basic threatening.........can't threaten a normal being , and it is evil and menacing in nature , shame." +
            "He is Becoming very impatient by the minute , bravo Meran , you are doing pretty good job annoying that worm , all you need to do is keep going a little further.",

            "Thats it , he has became impatient now is my chance.......just need to wait for it to make some idiotic move and then is game over for that worm , i believe in my Sweet iron to annoy it more and more." +
            "\n\n aaha got you now , Nowhere to run , foul worm......\n" +
            "If you are reading this diary , dear Meran , then i apologize for what horrors you have to go through , i Advice you to have trust on your self and not even on me.......\n\n"
        },

        //6
        // book name - Daily Routines
        {
            // this book is Ferish
            "Daily Routine as This Realm is getting me forget even the basic of things that i should remember hope this helps:-" +
            "\n - Clean the Cabin (The damn place is empty anyway even dirt would blush before coming here haha)"+
            "\n - Gather Wood logs from the Dark Forests" +
            "\n - Pray to Unsar,Lady Sunara,Lord Feree For Guidance and strength" +
            "\n - Prepare lunch" +
            "\n - Eat lunch" +
            "\n - Do the Dishes" +
            "\n - Read some books or new books that Lady Sunara brought" +
            "\n - Prepare for Dinner" +
            "\n - eat dinner" +
            "\n - Pray To Unsar Lady Sunara and Lord Feree before resting" +
            "\n - get some rest to suffer another day due to that worm,damn him to void and twilight",
            "",

            "",
            "",
            ""
        },

        //7
        {
            // this book is Aurish
            // book name :- the Real Hetwyie Sunara part 1
            "All hail to our Lady Sunara ,Lord Feree and All hail Unsar.\n"+
            "Somwhere in The Dawn Crecent of Unsar our beloved Lady Sunara is born." +
            "Lady Sunara is daughter of Neev Sunara leader of Sunara clan of Auruswon , Lady Sunara during her age early enjoyed all the luxuries that came with her royal family." +
            "But after passing of her mother , Young Sunara felt broken and she changed her ways of living , young Sunara worked hard to change her self and had great change in her personality so this is where our story begins.",

            "After that Dreadful event Lady Sunara became ever more generous as she is always abiding by her mother's last words to be generous and always be prepared by herselves " +
            "and left all the luxuries that came with royal family and started spending time wandering in her kingdom and looking for what is wrong in her kingdom that is hindering in a great Aurish nation , she noticed that the Aurans of that time were too traditionals compared to the Ferans and the Agrans for them to develop into said \"Great Auran nation\"." +
            "She noticed that her kingdom was classified into higher and lower class and too divided for a \"Great Aurish nation\" but she too knew that Her kingdom including other two clans had diverse culture in themselves simply uniting them into one rule and one culture will make things harsh for any culture so she accpeted the fates and united them as she worked around in uniting all goldcrowns of Auruswon and had Auran culture Coexist with each other." +
            "All this was well and good for young Sunara but she wanted more in her life something not based on being a potential ruler of a kingdom but something more based on going on adventure,you see she didn't wanted power , " +
            "neither wealth , after her mother died she had lost all her real friends except a few but they too were taken away as she had to follow the royal customs of the Sunara clan that made her feeling frustated and spiteful of her father.",

            "She hated the ruling business even more but she knew that one day Unsar will command her and she had to take the command of her." +
            "but who knew at that time Unsar had a Different plan all ready for our noble White Gold Princess but for now she was pressured to rule kingdom alone or leave that life and abandon her people forever to pursue her amibtions,fantasies and adventures . As a skilled artist in the provinces of Auruswon , She let loose all her stress and frustrations in the form of art." +
            "After she reached her divinity , Lady Sunara is a skilled artist as eras upon eras of knowledge had certainly helped her become a better artist of herselves and she gladly shares her knowledge to all beings of Unsar but she still have particular affection for her people." +
            "But before her Ascendance she was and still is a good artist she loves the typical arts of music and Alchemy but she adored the arts of Archery and Magic and yet she loved that so much that , she got invested in learning these arts starting to ignore the other businesses in court which had to be overseen and learnt from her father as she didn't find herselves interested in such matters." +
            "One day every thing had to change when that \"Fateful Summer\" had came , that day fates of the Unsar would be changed forever , the day was like any normal day , Lady Sunara was preparing for the Art Conventions that will be held today she knew that she had Aurish Honor was in line but she sighed in relieve as her father said to just do her best and not to worry about her performance as she is ever more beloved by her people even if she lost her people will take her losses as there honor." +
            "She went to the convention all prepared up and do her best and everyone was there Ferish Engineers and designers , Agrish Nobles and Artists , other Aurish clan's Artist and fighters she turned pale and felt that she was not the only one who was skilled but she did her best and came close to runner up in every competitions she partake in that made her a laughing stock during that time as she was the first Auran who let the aurish fame down and let Agrish and Ferish win the competitions but her father supported her in such hard times.",

            "She was relieved in her arms she felt bad to taste the defeat and was all tensed up in her defeats worrying that what her people might think about her defeat , but after resting for a while she was visited by a Ferish designer named Ryseth Feree congratulating on her achievements saying that she achieved so much in her first try but he was not that full of luck his entire life and this made her felt sorry for the poor fellow , by looking at his idea." +
            "Lady Sunara knew that the boy was extremely passioinate about the designing and building Ferish Machines but he failed as he was not experienced in designing such machines , She got entangled in his eyes as much she looked at him , Her eyes \"Glowed Golden\" for the boy like a match made by Unsar , as the boy kept talking and she felt strange but powerful and comforting connection with boy as he proceeded to motivate young Sunara she felt ever more strong and focused only on her art for his support she decided to help him too , so she teamed up with him in many of the competitions and together , they won it and completed all of the challenges of the competition." +
            "In her archery competition and mage tests she easily managed to ace them after the convention ended she invited boy for dinner to celebrate their victory in the Auruswon palace." +
            "As Ryseth visited the following evening in Auruswon's palace he felt strange attraction for the princess as Unsar demanded them to be together but he kept conversing with the princess about how she managed to have such change in the tide all of the sudden",

            "She replied \"You\" well he was amazed how he could have helped but she later added that it was him that made her realise she might have lost something but others in Unsar aren't very fortunate and they keep on losing forever and that made her rise from her failures which made her give her best and as a token of gratitude she also teamed up with him." +
            "She replied that he was the second person that changed her life after her mother , he asked where her mother was she replied,\"Ohh,She rests in the mists\" which burdened him for a moment but she said that it was alright then she asked about him." +
            "He replied \"Well I am Ferish prince but i dont consider myself as prince as i constantly taint my kingdoms name and her people by constanly failing , but my mother kept me motivated and I always try more and who knows if i succeed\"." +
            "After hearing the line she felt the absence of her mother but then young prince proceeded to thank her adding that it was her that he managed to win first time for his family and kingdom and they were proud of him and she brought him a good luck and she was a great ally," +
            "to which she replied with a adoring smile \"[In her most Adoring tone] If i am your luck , then we should stay together , who knows we might hit a gold for ourselves[smiles at him]......\" Prince blushed out and replied \"ummm.....Alright My Lady , Where should we start from?...\"\n\n\n To be continued..."           
        },
        
        //8
        {
            // this book is agrish
            // Unsar and Time 
            "Hail Unsar,\n" +
            "Unsar is a mystery for us mortals but we from the help of the Keepers of Unsar , Twilight beings and our own mortal efforts managed to uncover many secrets about the all mighty Unsar."+
            "This book tries to cover as much as the concepts of time that Unsar followa and tries not to be eccentric or out of line as sometimes explaining such things related to all mighty Unsar leads to such mishaps."+
            " Unsar and its nature is mysterious too , is it a being? , a place? or omnipresent Force that keeps events occuring in itself? , or is it the time itself? , No one can come to a definite solution but from observations of our Keepers and Twilight beings we came to know that Unsar follows the following life cycle:-" +
            "\n1. Dawn\n" +
            "2. Horizon\n" +
            "3. Dusk\n" +
            "4. Twilight\n" +
            "and this concepts are part of the most races or all races residing in the Unsar , Unsar is represented by its famous representation of \"Arc\" , The Arc is very easy to understand as the tip on the right end with bright color is the Representation of the Dawn or the Dawn Crecent of Unsar.",
            " Middle piece of the Arc is The \"Arckus\" if You Are Ferish or \"Arkus\" if You are Agrish , Merish , Aurish also represents the Horizon Crecent of the Unsar ,The last part of the representation is the final dark tip at the Left most end,represents the Dusk crecent of Unsar, " +
            "One might argue, where does the Twilight Crecent Exists then? , It is debatable but most agree that the time in such era flows in such way that cannot be defined by any mortal or even twilight beings " +
            ", Then do the keepers know what happen in such times? , well answers are yes but we mortals are not ready for there teachings , as the keepers may be gods but they to insist us mortals to not to worship them as they to learn each moment something new and they dont claim themselves to be worthy enough to be worshipped" +
            " as there reasoning being , while being worshipped means distraction from the true knowledge , thus they too keep Studying Unsar And try to uncover as many secrets as they can.",

            "Many argue that Unsaric representation may not represent the time but three different spaces Green Mists,Arckus/Arkus and Darker Unsars all three planes are traversable by any Mortal " +
            "but trying to travel to Darker Unsar From Green Mist is not possible according to the representation any mortal must flow through the Arkus/Arckus Realm To Reach The Green Mists or Darker Unsar" +
            " us mortal live in the plains of Arckus/Arkus and upon our death including man's , Cursed's or the Beast's death will travel to Green mist as we rest easy in the Care of Lady Sunara and few unfortunate will get to visit Darker Unsar if judged guilty for our deed during our time On Arkus/Arckus",
            
            "Thus the question arise how time flows for the one that is Ascended , we are not certain about the Twilight Beings but Keepers in there valuable teachings had told us that upon there ascendance they not just ascend to greater power as gods but they become entirely different person not one from the Arkus/Arckus" +
            " they serve the Unsar till its Dusk And Upon twilight it transforms itself to chaos over Unsaric plane for a New Dawn , they can never die as those rules are applicable only on the beings residing in the Unsaric Plane but keepers who once belonged to but now are not from Unsaric Planes anymore they Experience entirely different flows of time.." +
            " They belong to \"Greater Unsaric Planes\" which are supposed home of twilight beings as such strong proofs Have not been Disclosed about such claims thus making this theory to be fake . Green Mist and Darker Unsar Are the Realms Which Exists in the Unsaric Planes but The Time Experienced in that realm is Entirely Different then we can experience it in the Arckus/Arkus." +
            "The Time flow in both the Realms are ever more mysterious in there ways but certainly fascinate us mortals in there workings.",
            
            "As for the planes of Greater Unsaric Planes has to be remain a mystery as the reality if experienced by normal mortal will likely cause him/her to have a mental death as The Brains Can't Comprehend what is going on and The mortal was never evolved to comprehend such planes will cause the mortal's mental death,only The noblet can understand the nature of The Greater Unsaric Planes." +
            "Upon there Ascendence the Noblet Struggles to Learn His/Her new reality but as time Progresses The noblet acknowledges the new reality as his/her new home , noblet is able to achieve such divine powers as they connect with there inner Unsar and start to live there lives knowing there is an entire universe inside them and thus making them more resistent from the " +
            " Harsh realities of a new Realm they now call home."
        },

        //9
        {
            // this book is ferish
            // The Metal Prince - Start of Journey
            "Hail Unsar and all Hail to our Lord Feree and Lady Sunara\n" +
            "Lord Ryseth Feree the Son of Metal King of Everlasting Luhari clan , Pymsunth Feree and his Metal Queen Mera Feree. Lord Ryseth Feree was Born in The Dawn Crecents of Unsar As Same time as the Lady Sunara was born to Neev and Kysha Sunara." +
            "Lord Feree like true feran had fascination for the technology as he might not be a good smith but he respected the divine art of smithing which is the first art a feran is taught , a feran can work with the metal if he/she knows how the metals are born and bend them to there wills." +
            "As evident in there lifestyle a feran is a person who believes that Unsar is hot metal yet to be shaped to there needs and there hammering will do the task , such great thinking has led our divine race to reach its full glory and made our race much more advanced with the help of our beloved Lord Feree." +
            "Before ascending to be known as an \"Unrusted\",Ryseth was a man of constant failures and suffering but his wills to persist and live another day might not be apparent but it sure became clear when Lady Sunara came in his life making his life more than his failures and in his words he finally found someone equal of lifetime of success." +
            "Lord Feree had been failing nearly in every aspect of his life that made him feel weak for sometimes but the constant affection from his mother made him live another day , till this day even though he might be corrupted his tales are told to the generations as he was the true Feran To ever live , such determination to live in failures breaks a Normal Fera but our Lord were never alone as his Mother Was there with him and so did his love our beloved Unrusted Lady Sunara",

            "Our story starts from much more confident Feree on his way to his kingdom and to metal palace but on there way they chose the lives of being the Adventurers , sure they might have abandon there kinds but that night he did approached the king pymsunth" +
            "telling everything that happened back in the camp as how he was assited by his mother to save Lady Sunara and how he proposed to her to be eternally bonded till dusks and twilight started , seeing happiness and love in his son's eyes that he had never seen , he let Prince live his life with the one he adored." +
            "Something he wanted for his son to happen as he feared that poor boy remained strangely quite and alone after her mother passed away and barely left the Metal Palace and just lost in his Unsaric realm but After Lady Sunara came in his life he had something change in his life which made him feel that he is not alone anymore and when presented with the proposition to live With Lady Sunara away from there palaces but a very Adventurous Life , Pymsunth agreed as it brought him eternal joy" +
            " Some might think Ryseth must have escaped from that palace that night but the very next morning they left there royal lives in front of citizens of Metal Kingdom and citizens of Metal Kingdom had mixed reactions on there departure but they did supported them as it were the wills of Unsar itself and there opinions wont make a difference if they were even heard" +
            "For Pymsunth , seeing his son leave did burden him but his throne was to be taken up by Ryseth's little brother Shuon Feree but happiness in his sons eyes eased his burdens and finally fullfilling the dying request of Mera as her final wish was that Ryseth found someone like Lady Sunara",

            "After there departure from Metal Kingdom , Lord Feree asked Lady Sunara \"See I told you , My Lady , now that we are together where should we go and what should we do now?\", Lady Sunara replied \"Well my love you said we might have a \"Home in the Hills\" , why not just settle in the beautiful peaks of Sonorlands or Auruswon?\" he replied by saying \" That is a good idea but why not just settle somewhere in the provinces of Metal Kingdoms as the \"Ferran Peaks\" were Perfect for there settling." +
            "Lady Sunara sensing a potential dispute tried to dissolve it by saying \"Well your argument is perfectly valid , but i have heard that provinces of Bloomfell have fine hills that you desired , my Love , how about we check all of the provinces along with provinces of Bloomfell to see what fits us best[Smiles]? Lord Feree smilingly replies \"Sure , My Love but with no resources to leave the metal kingdoms we must settle here and try to make a living and every year visit every provinces and see which suits us best,how does that sound?\"" +
            "Lady Sunara replied with a yes as this was dream her adventures start from here along with Lord Feree with her , so they decided to settle down in a nearby settlement in disguise so they can live there normal lives and not been seen as the royals who are living with the villagers of that settlement" +
            "Ryseth felt pressured that how will he be going to see after his family , burdened by this thought he approached Hetwyie saying \"[Sweating]I have been a constant failure in my life , how will i ever handle this family? , how will i ever take care of you? , Did i made mistake taking this decision? , I swore to not let a tear shed from your beautiful eyes , [More Tensed] what if i failed , what if i failed in my duties to protect you , i bearly managed to save you?.....ummmph\"" +
            "Lady Sunara gently putting her finger on his lips calming the man and hugging him said \"[smiles]Ohh My Prince , even i dont know how we will go further from this point on , but i imagined you in my dreams by my side facing Unsar by ourselves , if i am with you , you will be with me , won't you?\"" +
            "to which he repliea yes but still worried about her which reflect on his through his expressions she comforted him and told him \"You were brave enough to face your failures , you are and will be brave even now , do not worry we will face our fates with bravery..\" softly putting her hands on his cheeks she added \"Love , you never took a wrong decision marrying you was my best decision as you brought me true companionship , love and intimacy and life of constant adventure was craved by us both why so tensed when this life throws you minor problems? , besides i will be there for you till the twilight and next dawn " +
            "and its dawn and its dawn and forever for Unsar destined us to meet at that convention but i wish to Unsar that we live together forever.\" Ryseth by holding her hands in his hands and bringing his face closer to hers adding \"Yes , i do wish that your comforting care and love be mine forever[smiling and weeping]\" Lady Sunara feeling pity on her loves emotional states starts to weep as well then she kisses him and says and says \"Let's hit that gold , shall we?[weeps and giggles]\" Lord Feree hugs her tightly and says\"[weeps and proudly says]yes,my love\"",

            "After sometime they find a nice settlement near Metal Kingdoms called \"Forge-fer\" which means the \"Iron Forge\" in the ferish language under disguised identities of Reekus Forg and Haarleen Forg , " +
            "After some days reekus or Lord Feree got a job at local lumber mill , he might not have set foots outside of his palace but knew his way around working at lumber mills and forges and he was master at arts of surviving but felt tensed when he had her love with him fearing to not let her be in misery in any form and so did the Lady Sunara , " +
            "upon hearing the news of his job , Reekus was in joy but seeing him happy made Haarleen happy and joyful , as if it was this she ever wanted joys of adventure , after he was compensated after a month's work he gifted her Aur-Valley flowers and a dinner date night with him in the near by glade that was set up with the help of his friend at work Gallus Swordson" +
            "Gallus never knew who this disguised village residents were but Reekus's managed a likeable personality around the people of Forge-fer that made the couple ever more adoring , Haarleen's personality felt very wise to the village people and they even visited them for there wisdom , knowledge and guidance and they did give them at no cost" +
            " , Prior to that night Reekus had told Haarleen to meet him at 5 pm in evening at Autumn glade as he planned a surprise for her for which she replied positively , after 5pm Haarleen arrived at the place all decorated for a special ocassion.." +
            " When she asked what was the occasion he replied \"Love , i cannot thank you how much you have been with me yet i had not fully appreiciated your love all this time , so me and my friend took some time to prepare this for you , Gallus come out friend she is here , i hope this surprise pleases you\" she replied \"" +
            "Gallus , what a surprise , i cannot thank you for help much\" Gallus replied \"There is no need for you to thank , i was just performing my duties as friend of Reekus who planned of setting up this date , now that lovers are together , please excuse me and enjoy evening , Ma'am\" to which she replied \" Thank you\"" +
            "After A while when Gallus left she said \"Oh my Sweet Iron , You did this but , please don't say that you emptied all your pay on this date it looks expensive to me , love\"",

            " to which he replied \"uhh... i am not sure if you will kill me\" Haarleen Squeezing her eyes and Giving an Adorable smirk saying \"[smiling]Reekus.......\" to which he replies \"Fine , i was joking , how would i ever do that , our dreams for a home in the hills lives on for that i must save whatever resources that are required , my love....[gifting the Aur-Valley flower]\" her reaction was shocked " +
            "saying \"ohh Reekus my adorable love , how did you managed to find them they are very rare and only found in the Aur-Valley in Auruswon they must have costed you a good fortune..\" to which he replied \"not at all love,Gallus gifted me these,[Haarleen knowing reekus endebted them for flowers],now now do not give me that look i have paid him with the royal jewellery that i had , dont worry , my love[hugging her and kissing her] , now the dinner is getting cold and it is already dusk , dear\" , glazing over beautiful scenery viewed from the Autumn glade" +
            "Haarleen mesmerized by the view thought that they have settled just fine in the settlement why look for \"another home in the hills\" and she thought that they are having there best lives should they go on adventures? seeing her in dilemma Reekus asked\"" +
            "Is something bothering you ,love?\" to which she replied saying \"after a month we found and settled in this nice village , love why waste efforts in finding a new home , the Autumn glade made me think that this could be our \"A home in the hills\" [Reekus adoring his wife's decision gives a smirk]\" and adds \"Sure , this place is a beauty in the metal kingdoms and i kind of like this place too , i will work hard to build our new home here.\"" +
            "Haarleen replies \"Come on dear prince you are not the one who is earning we both do our parts by earning and running our home..\" reekus hugs his wife and kisses her and says \"Yes,My sweet\" and they happily spend there nights....To be Continued"
        },

        //10
        {
            // this book is Unsaric
            // book name:- The Ascendence part - 2
            "Hail all mighty Unsar.....\n" +
            "Dear reader, \n if you are reading this book please do not take the theories regarding the Aura as absolute in this book it is not what it is described in book it just provide the general view regarding Aura that can be made some what presentable." +
            " In the last part we discussed about the insanity that comes with the understanding of Aura and the its elements , but how does one feel such adverse effect , what is so wrong regarding this concept and so right that it is the concept of Swarna? " +
            "From my research and countless conversations with the semi ascended mages , I have come to know that the mind element is a whole traversable plane of existence that is present in our consciousness that exists inside the planes of in The element of consciousness." +
            "We never get a feeling that there is an entire plane of existence that lives with us inside of us works for us and helps us understand many day to day life events and show its invisible presence while we are left alone making us feel that we are not alone we have someone with us.",

            "I know what i was saying and what i will be saying will sound gibberish but path to ascendence is not that easy and only select few of Unsar can understand the concept but bear with me." +
            "earlier i said that the mind element is whole plane of existence which can be traversed , Now questions might arise that what is this plane of existence who inhabit these planes , what does it look like , does it appearance be subjective to ones mind?." +
            "Well fascinated reader i may just apologize that i can not perfectly answer those questions but if we let few Ascended to answers the question , they will say that there are different method that they use to enter this space , after i met many people regarding this topic there opinion was that the planes of mind element were close to a Heaven." +
            "and yes they do have met the inhabitants they reportedly said that they met the one who controlled , the one who charmed and gave hope , the one who was always Curios about new things , the one who was always proud of itself and the one who was brave enough to protect them all except for the one who controlled and the one who gave hope." +
            "Note that this entities are part of your mind and if you are lucky and get to meet them they will welcome but for your good and for there plane's better future will ask you to leave after a short while ",
            
            "if we believe some experts who investigated this matter they said that these beings asked you to leave so that you dont become insane about an entire realm inside your head and making things easy for them to manage." +
            " you see there is no physical barrier between the element of consciousness and the element of mind , the element of consciousness and act like Unsaric space for the mind element and in this space our consciousness resides which makes us self-aware regarding our environment" +
            " dear reader i must say the concept of ascendence is rather enigmatic for any who tries to understand it firstly it feel gibberish but as i said only the select few can understand what this concept is all about with that said i shall conclude this book on Ascendence" +
            ".\n\n\n\nThank you dear reader,\n for reading this far.........",
            "",
            ""
        },
        // 11
        {
            // this book is Aurish
            // book name :- The Real Hetwyie Sunara part-2
            "Hail Lady Sunara and Lord Feree and All hail the Unsar.\n" +
            "After that he accepted her proposal , she said with a smile \"Honestly,i dont know where to start from i was hoping that you would suggest where to start from\" knowing that he was as equally clueless as she was , he replied \" i too dont know as well but if we are to stay together then we must get to know each other\" ." +
            "Lady Sunara amazed and little bit excited at his reply knowing that he too was picking her signs up she said by reiterating her true identity in Royal Manner \"most certainly my prince,I am Hetwyie Sunara Daughter of Neev Sunara.\" , after sometimes he replied with his formal reply saying \"I am Ryseth Feree,Prince of Luhari clan\" She replied with strange silence , soon he added that he didn't like ruling , he likes the thrill that Unsar throws at him " +
            "and that his Passion brought to him and he said that his failures uptil now were too much for him to handle thus he never left the castle fearing that everyone will laugh at him for what a failure he was." +
            "Lady Sunara looked at him with curiosity and ever growing affection for him said \"Dont worry your luck is here[giggles],just call me any time and i shall turn your failures to success[smiling],your pains to comforts\" knowing that he might have said something wrong he added \"uuh....i dont know what to say...\" smiling and sensing his nervousness Lady Sunara decided to stop , but still gave a smile to show him some form of affection and said." +
            "\"What ever you want to say[giggles]....\" both of them laughs it off and later that evening Ryseth departed for his home , ever so proud about his return gave the Lady one last smile that made her go crazy for him and that for few nights she didn't slept well or didn't at all which made her dangerously ill , demanding that Prince Feree to come visit her as soon as possible..",

            "After 2 days from same day of recieving the letter Ryseth arrived at Auruswon Palace for Lady Sunara , she explained to him that she hasn't slept entirely for few days , lying and holding his hand and saying in complete distress that she had nightmares and distress calls about her mother in her dreams and she needed him to stay with her just as in the convention to help support her during her illness." +
            "Agreeing with her , he decided to stay with her until she was perfectly fine and one might say she had the greatest joy of him being around ever since it was taken away after the sad demise of her mother , she never felt his company this good some might say what was so special in that one hell of loser of a boy but try telling that to Lady Sunara now and she will give a valid explanation of the connection being a pure love for him." +
            "After that she was fine her \"Sweet Iron\" as she liked to call him all the time insisted that he should proceed for his kingdom and look after his kingdom too as much as he did for Young Sunara , faint distress made across her face hinting him not to leave but his people are his priority to him , her father felt her daughter sadness and was really looking for her to be happy in her life and he had witnessed that happened only when Prince Feree was with her so he told the prince to take her with her so that she would learn something from him about ruling a kingdom." +
            "Prince Feree Agreed with his proposal and took young Sunara with her , some might say that Feras are very hard at outsiders but his presence made her ignore there squabbles , though she wanted adventure with her sweet iron but while he has to rule over his people she can't do anything apart from waiting of when his father comes and resumes his control so that he might have free time but she kept him busy with her by them sneaking out of the Metal Palace and exploring the Luhari kingdom in disguise in the nights" +
            "Unfortunate for Lady Sunara her waiting lasted a year , but she kept on waiting and waiting and better knew the prince and knew all his strengths and weakness and she started to ever more adore him in that time , but that day came , Prince Feree's Father returned , thus Prince Feree was now completely relieved of his responsibilties , but his father had planned to sent him to a conquest to venture into an old ferish fort and recover a Luhari Artifact , he insisted that prince should take Princess Sunara along with him as a personal order from Neev Sunara." +
            "He Agreed on that terms and departed for the fort on the way Lady Sunara spent no time alone and always kept Ryseth Busy talking with her and letting him to talk about himself and let him be open to her." +
            "So they chatted and as Unsar intended there bonds grew ever more deeper and strong , For Hetwyie it was dream come true , her first adventure and also with the one she adored and loved so much...",

            "As they arrived at the ruined fort they started looking for the entrance of the fort And Lady Sunara told that His Archery Skills were very good as she was with him improving his skills all these days , Prince replied with \"Thank you , My lady I appreciate that and now that you are here we might hit some gold for us as you said earlier[winking and smiling at her]\"." +
            "She Blushed and said \"Ohh you,We definitely will hit a large sum of gold for us both\" , as they proceeded into the dungeon it was riddled with ancient ferish locks Prince feree couldn't find the possible combination to open it , Lady Sunara helped him by clever reasoning and thoughtful detailing , amazed by her reasoning and wanting to know more from her regarding logic and reasoning he said\" You have quite the Aptitude For Logic , Lady Sunara , i wish that i had that kind aptitude like that\"." +
            "Hetwyie ever more adoring his man and wanting to stay with him said \"Sure , once we secure a big sum of gold for ourselves i will teach you whatever i can about logic and reasoning [ending with a smile]\" through which Ryseth smiled and Hetwyie followed the gesture soon After,as the Legend say \"Match made Unsar by itself\",they made out of the fort with the artifact but they didn't got any treasure for themselves." +
            "Ryseth On his way back \"Well My Lady , we didn't got any our treasure so you will be upset with me , right?\" as she never was dissapointed with him , her first adventure was complete and she wanted to be with him all her life , wonderfully replied \"Do not worry , My prince , for it was not our fortune to earn that gold may be next time[smiling and hugging him as they were on a Horse] , well when do you want training in the logic and reasoning , My Apprentice[giggling]?\"." +
            "\"Anytime you command me for your teachings i will be there , My Master[Laughing]\" Lady Sunara in total happiness replied \"Well My Apprentice , it would cost you something....\" Ryseth now amazed and said \"Anything for knowledge , what is it you demand my master[smiling]?\" Lady Sunara happily gave a gesture of Nothing or saying no while quickly nodding her head sideways , for her the only price was that he was with her ," +
            " and that was all that she ever wanted , now she started fantasizing about him that they went on epic quests and Adventure so perilous that made there names legendary and she got live with him for eternity.",

            "The very next day Lady Sunara started Ryseth's training in Logic and Reasoning which will make him a better prince to rule the Luhari clans of Ferans but while training poor Prince failed to grasp on her important teachings but young Sunara Ever so patient and strong believer in him , believed that he will learn it and every time he failed she smiled at him and said \"[Adorably smiles] Do not Worry prince the path to knowledge is difficult as it was for me as well but do not let your failure overcome your mind just let them flow with the Unsar and you shall easily grasp the most difficult of the knoledge\"." +
            "Ryseth ever so confident in her he saw her with Curiosity and evergrowing affection for her , believed in her and soon his training was complete that day he asked her , \"Well you truly are master in many thing , My Lady\" to which she replied \"Oh no no , Dear prince , i am just as a learner as you , while going through your training i learned a lot about you like you can be naive sometime , but thats the most adorable thing about you , dear prince[smiling]\"." +
            "Ryseth Smiling and saying \"That might be..,but wait what about your compensation?\" looking at Ryseth with a charming sights she said \"No Prince , your curiosity and determination paid as my compensation and i am very much satisfied with your results\" soon after the palace guard enters and interrupts duos conversation and says \"My Lord , King demands your presence at once[proceeds to leave]\" Prince Feree says \"Come with me My Lady, Looks like Father have another quest for us maybe it is our time to get our big treasure [smiling]\"." +
            "Lady Sunara in her most adoring voice \"Yes , My Prince we should go meet him\" , They met Prince Feree's father who now sent them to clear out a fort which belonged to Ancient Luharis but now is abandoned and lurking with all kind of monsters." +
            "After Assigning the task He Asked Lady Sunara To meet him in person to which she agreed , after everyone left he told her that he had never seen his son so happy in his life after that win in the convention and after that fort they cleared out and he got a word from her father as well to let them go on adventures together as it brought her joy and had firm belief in Prince Feree that he would not let a drop of blood drip off her body and all he wanted for her was that she was happy with his prince and Prince Feree's father begged her to not leave him , poor boy had seen joys of accompany after many years since her Mother too departed for Green Mists.",
            "Lady Sunara ever more loving him started caring for the Poor prince as he faced the same fate as hers and wouldn't let him off her sights for one single moment as she loved him with all her soul she went with him...........\n\n\n\nTo be continued..."
        }

    };

    private GameObject BookSource;
    private AudioClip PageflipClip;
    private AudioClip ChangingBookClip;

    private void Start()
    {
        BookContent.text = null;
        PageNumber = BookContent.transform.parent.transform.GetChild(1).gameObject;
        BookTitle = BookContent.transform.parent.transform.GetChild(4).gameObject;

        if (BookSource == null)
        {
            BookSource = new GameObject();
            BookSource.AddComponent<AudioSource>();
        }
        
        PageflipClip = Resources.Load<AudioClip>("HouseLevelAudio/PageFlipSounds");
        ChangingBookClip = Resources.Load<AudioClip>("HouseLevelAudio/BookOpening");

        DefaultImage = Resources.Load<Sprite>("ButtonSprites/ButtonDefaultSprite");
        // symbols are loaded up here
        Symbols = Resources.LoadAll<Sprite>("Symbols");
        SymbolSpace.sprite = DefaultImage;  
        // individual symbols are also allocated for direct usage
        // i know the implementation of every damn feature in this game is goddamningly static and fucking absolute 
        // for the reader going through this code please forgive for i am also learning these things :)
        //   AgrishSymbol = Symbols[0];
        //   AurishSymbol = Symbols[1];
        //   FerishSymbol = Symbols[2];
        //   UnsarSymbol = Symbols[3];
    }
    private void Update()
    {
        SetAudioVolume();
        if (BookContent.text != null)
            PageNumber.GetComponent<TextMeshProUGUI>().text = " " + (CurrentPage + 1) + " / " + " 5 ";
        else
            PageNumber.GetComponent<TextMeshProUGUI>().text = null;
    }

    void SetAudioVolume()
    {
        BookSource.GetComponent<AudioSource>().volume = SettingsVariable.GetGeneralSoundsVolume();
    }
    void ReadBook()
    {
        if (CurrentBook >= 0)
        {
            print("page number:- " + CurrentPage);
            print("Book Id:- " + CurrentBook);

            if (BookContents[CurrentBook, CurrentPage] != null)
                BookContent.text = BookContents[CurrentBook, CurrentPage];
            else
                BookContent.text = " ";
        }
    }

    public void ReadNewBook()
    {        
        string number = gameObject.transform.name;
        CurrentBook = Int32.Parse(number) - 1;

        string Booktitle = gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
        BookTitle.GetComponent<TextMeshProUGUI>().text = Booktitle;

        DoBookChangeSound();
        // here we got the book id now according to the index we have to load up an image for its respective book 
        SymbolSpace.sprite = Symbols[SymbolImageIndex[CurrentBook]];
        CurrentPage = 0;
        ReadBook();
    }
    public void NextPage()
    {
        if(BookContent.text != null)
            DoPageFlipSound();
        CurrentPage++;
        if (CurrentPage >= 0 && CurrentPage <= 4)
            ReadBook();
        else
        {
            CurrentPage = 4;
            ReadBook();
        }
    }
    public void PreviousPage()
    {
        if (BookContent.text != null)
            DoPageFlipSound();
        CurrentPage--;
        if (CurrentPage >= 0 && CurrentPage <= 4)
            ReadBook();
        else
        {
            CurrentPage = 0;
            ReadBook();
        }
    }

    private void DoPageFlipSound()
    {
        BookSource.GetComponent<AudioSource>().clip = PageflipClip;
        BookSource.GetComponent<AudioSource>().volume = 0.3f;
        //if (!BookSource.GetComponent<AudioSource>().isPlaying)
            BookSource.GetComponent<AudioSource>().Play();
    }

    private void DoBookChangeSound()
    {
        print("Books source" + BookSource);
        print("clip"+ChangingBookClip);
        BookSource.GetComponent<AudioSource>().clip = ChangingBookClip;
        BookSource.GetComponent<AudioSource>().volume = 0.3f;
        //if (!BookSource.GetComponent<AudioSource>().isPlaying)
            BookSource.GetComponent<AudioSource>().Play();
    }
}
