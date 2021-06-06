using UnityEngine;

public class FeatherParticle : MonoBehaviour
{
    public static ParticleSystem featherGlow;

    public static FeatherParticle Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        featherGlow = GetComponent<ParticleSystem>();
        featherGlow.Stop();
    }
    public void NoGlow()
    {
        featherGlow.Stop(withChildren: true, stopBehavior: ParticleSystemStopBehavior.StopEmittingAndClear);
    }

    public void YesGlow()
    {
        featherGlow.Play();
    }
}
