using UnityEngine;

[CreateAssetMenu(menuName = "State")]

public class State : ScriptableObject
{
    [TextArea(14, 18)] [SerializeField] string storyText;
    [TextArea(6, 5)] [SerializeField] string storyChoices;
    [TextArea(5, 5)] [SerializeField] string triggerWords;
    [SerializeField] AudioClip[] sfx;
    [SerializeField] State[] nextState;


    public string GetStateStory()
    {
        return storyText;
    }

    public string GetStateChoices()
    {
        return storyChoices;
    }

    public string GetTriggerWords()
    {
        return triggerWords;
    }

    public AudioClip[] GetSFX()
    {
        return sfx;
    }

    public State[] UpdateStory()
    {
        return nextState;
    }

}



