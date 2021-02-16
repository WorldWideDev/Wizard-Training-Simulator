using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {

    public enum EntitiyChallengeRating
    {
        Easy,
        Medium,
        Hard
    }

    [HideInInspector]
    public int numRating;

    MeshRenderer eRenderer;


    public EntitiyChallengeRating challengeRating;

    void Awake()
    {
        eRenderer = GetComponent<MeshRenderer>();
        switch (challengeRating)
        {
            case EntitiyChallengeRating.Easy:
                eRenderer.material.color = Color.blue;
                numRating = 0;
                break;
            case EntitiyChallengeRating.Medium:
                numRating = 1;
                eRenderer.material.color = Color.yellow;
                break;
            case EntitiyChallengeRating.Hard:
                numRating = 2;
                eRenderer.material.color = Color.red;
                break;
        }
    }
}
