using UnityEngine;

public class RootsParticle : MonoBehaviour
{
    public static ParticleSystem rootsGlow;

    public static RootsParticle Instance;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        rootsGlow = GetComponent<ParticleSystem>();
        rootsGlow.Stop();
    }

    public void NoGlow()
    {
        
        rootsGlow.Stop(withChildren: true, stopBehavior: ParticleSystemStopBehavior.StopEmittingAndClear);
    }

    public void YesGlow()
    {
        rootsGlow.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
