using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerMovement))]
public class ParticleController : MonoBehaviour
{

    public ParticleSystem particleSystem;

    public PlayerMovement playerMovement;

    float baseEmit = 1.5f;

    private void Start()
    {
        particleSystem = GetComponentInChildren<ParticleSystem>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        var main = particleSystem.main;
        main.startLifetime = (playerMovement.ZAxisMovement + baseEmit);
    }
}
