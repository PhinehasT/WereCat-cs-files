using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TheWereCatGame : MonoBehaviour
{
    [SerializeField] Text textStory;
    [SerializeField] Text textChoices;
    [SerializeField] Text triggerWords;
    [SerializeField] State startingState;

    State state;

    AudioSource player;
    AudioClip[] sfxClips;
    

    private readonly string rootsFound = "yes roots";
    private readonly string cloverFound = "yes clover";
    private readonly string cloverLost = "clover lost";
    private readonly string featherFound = "yes feather";
    private readonly string featherLost = "feather lost";
    private readonly string resetAllThree = "start over reset";
    private readonly string startRain = "start rain";
    private readonly string youWin = "you win!";

    public static bool raining;

    void Start()
    {
        player = GetComponent<AudioSource>();
        state = startingState;
        textStory.text = state.GetStateStory();
        textChoices.text = state.GetStateChoices();
        triggerWords.text = state.GetTriggerWords();

        raining = false;
    }

    void Update()
    {
        StoryUpdate();
        UpdateTriggers();
        TheRain();
    }

    private void StoryUpdate()
    {
        var updateStory = state.UpdateStory();
        for (int index = 0; index < updateStory.Length; index++)
        {
            if(Input.GetKeyDown(KeyCode.Alpha1 + index) || Input.GetKeyDown(KeyCode.Keypad1 + index))
            {
                state = updateStory[index];
                PlayTheSFX();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        textStory.text = state.GetStateStory();
        textChoices.text = state.GetStateChoices();
        triggerWords.text = state.GetTriggerWords();
    }

    // This plays the sound effects for each scene. The first 'if' is in case there is a long sound effect from
    // the previous state still playing. The only downside is I've found if you are just blowing through the game
    // really fast sometimes it stops a sound effect that isn't intended. But as long as your taking a few seconds
    // to read before making a choice - aka playing the game as intended, so far it has worked very well.

    private void PlayTheSFX()
    {
        if(player.isPlaying)
        {
            player.Stop();
        }

        sfxClips = state.GetSFX();
        
        if(sfxClips.Length == 0)
        {
            //do nothing
        }
        else if(sfxClips.Length == 1)
        {
            player.clip = sfxClips[0];
            player.Play();
        }
        else if(sfxClips.Length > 1)
        {
            StartCoroutine(PlayMultiple());         
        }
    }

    private IEnumerator PlayMultiple()
    {
        foreach(AudioClip x in sfxClips)
        {
            player.clip = x;
            player.Play();
            yield return new WaitForSeconds(x.length);
        }

    }

    // This returns true or false. If the keyword is "flower" and in the keyword section of the state file that 
    // word can be found it will return true. It could be an entire sentece like "smell a flower" or just the
    // keyword itself. It will check that it "contains" the keyword somewhere in the keyword section.

    private bool TriggerByKeyword(string keyWord)
    {
        triggerWords.text = state.GetTriggerWords();
        string toCompare = triggerWords.text.ToString();

        if(toCompare.Contains(keyWord))
        {
            return true;
        }
        else
        {
            return false;
        }
    }   
    // See TheRain.cs - this is a seperate audio player attatched to a different game object since the rain SFX
    // plays in the backround while other mini SFX can still play at the same time.
    private void TheRain()
    {
        if(TriggerByKeyword(startRain) == true)
        {
            raining = true;
        }
    }

    // This contains all the triggers for particle effects starting and stoping. It utilizes the bool method
    // above TiggerByKeyword.
    private void UpdateTriggers()
    {

        if (TriggerByKeyword(rootsFound) == true)
        {
            RootsParticle.Instance.YesGlow();
        }
        else if (TriggerByKeyword(cloverFound) == true)
        {
            ThornsParticle.Instance.YesGlow();
        }
        else if (TriggerByKeyword(cloverLost) == true)
        {
            ThornsParticle.Instance.NoGlow();
        }
        else if (TriggerByKeyword(featherFound) == true)
        {
            FeatherParticle.Instance.YesGlow();
            if (TriggerByKeyword(youWin) == true)
            {
                WinnerParticles.Instance.YesGlow();
                raining = false;
            }
        }
        else if(TriggerByKeyword(featherLost) == true)
        {
            FeatherParticle.Instance.NoGlow();
        }
        else if (TriggerByKeyword(resetAllThree) == true)
        {
            RootsParticle.Instance.NoGlow();
            ThornsParticle.Instance.NoGlow();
            FeatherParticle.Instance.NoGlow();
            WinnerParticles.Instance.NoGlow();
            raining = false;
        }
    }
}
