using UnityEngine;

public class ThornsParticle : MonoBehaviour
{
    public static ParticleSystem thornsGlow;

    public static ThornsParticle Instance;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        thornsGlow = GetComponent<ParticleSystem>();
        thornsGlow.Stop();
    }
    public void NoGlow()
    {
        thornsGlow.Stop(withChildren: true, stopBehavior: ParticleSystemStopBehavior.StopEmittingAndClear);
    }

    public void YesGlow()
    {
        thornsGlow.Play();
    }
}
