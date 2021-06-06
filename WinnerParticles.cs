using UnityEngine;

public class WinnerParticles : MonoBehaviour
{
    public static ParticleSystem winnerParticles;

    public static WinnerParticles Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        winnerParticles = GetComponent<ParticleSystem>();
        winnerParticles.Stop();

    }

    public void NoGlow()
    {
        winnerParticles.Stop(withChildren: true, stopBehavior: ParticleSystemStopBehavior.StopEmittingAndClear);
    }

    public void YesGlow()
    {
        winnerParticles.Play();
    }
}
