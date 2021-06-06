using UnityEngine;

public class TheRain : MonoBehaviour
{
    AudioSource rainPlayer;

    // Start is called before the first frame update
    void Start()
    {
        rainPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            StartStopRain();
        }
    }

    private void StartStopRain()
    {       
        if (TheWereCatGame.raining == true)
        {
            if(!rainPlayer.isPlaying)
            {
                rainPlayer.Play();
            }
        }
        else
        {
            rainPlayer.Stop();
        }
    }
}
