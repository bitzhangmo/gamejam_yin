using UnityEngine;
using System.Collections;

public class particleSettings
{
    public float Aangle { get; set; }
    public float Radius { get; set; }
    public float Speed { get; set; }
    public particleSettings(float r)
    {
        this.Radius = r;
        this.Aangle = Random.value * 2 * Mathf.PI;
        this.Speed = Random.value * Mathf.Sqrt(Radius);
    }
    public Vector3 GetPosition()
    {
        return Radius * new Vector3(Mathf.Cos(Aangle), 0, Mathf.Sin(Aangle));
    }
    public void rotate()
    {
        this.Aangle += Time.deltaTime * Speed / 10;
        if (this.Aangle > 2 * Mathf.PI)
            this.Aangle -= 2 * Mathf.PI;
        this.Radius += Random.value * 0.2f - 0.1f;
        if (this.Radius > ParticleRotate.MaxRadius)
            this.Radius = ParticleRotate.MaxRadius;
        if (this.Radius < ParticleRotate.MinRadius)
            this.Radius = ParticleRotate.MinRadius;
    }
}

public class ParticleRotate : MonoBehaviour
{

    public ParticleSystem particleSystem;
    private ParticleSystem.Particle[] particlesArray;
    private particleSettings[] psetting;
    public int seaResolution = 5;
    public static float MaxRadius = 1f;
    public static float MinRadius = 0.5f;
    public float radius = 0.1f;
    public Gradient colorGradient;

    private void Start()
    {
        particlesArray = new ParticleSystem.Particle[seaResolution * seaResolution];
        psetting = new particleSettings[seaResolution * seaResolution];
        particleSystem.maxParticles = seaResolution * seaResolution;
        particleSystem.Emit(seaResolution * seaResolution);
        particleSystem.GetParticles(particlesArray);
        SetInitialPosition();

    }
    private void Update()
    {
        RotateParticles();
        particleSystem.SetParticles(particlesArray, particlesArray.Length);
    }

    private void SetInitialPosition()
    {
        for (int i = 0; i < seaResolution; i++)
        {
            for (int j = 0; j < seaResolution; j++)
            {
                psetting[i * seaResolution + j] = new particleSettings(radius);
                particlesArray[i * seaResolution + j].position = psetting[i * seaResolution + j].GetPosition();
            }
        }
        particleSystem.SetParticles(particlesArray, particlesArray.Length);
    }

    private void RotateParticles()
    {
        for (int i = 0; i < seaResolution; i++)
        {
            for (int j = 0; j < seaResolution; j++)
            {
                psetting[i * seaResolution + j].rotate();
                particlesArray[i * seaResolution + j].position = psetting[i * seaResolution + j].GetPosition();
            }
        }
    }
}