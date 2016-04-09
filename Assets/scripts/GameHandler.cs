using UnityEngine;
using System.Collections;

public class GameHandler : MonoBehaviour
{
    const float TimeForEveryState = 5;

    // 5 = very good
    // 0 = dead
    int bunnyState;

    bool gameOver = false;

    float time;

    string[] stateTexts = { "You bleed out :/", "Watch out!", "Come on!", "Ouch - what's that?!", "What a nice day to jump around :)" };

    // Use this for initialization
    void Start()
    {
        bunnyState = 5;
        time = TimeForEveryState;
    }
	
    // Update is called once per frame
    void Update()
    {
        if (bunnyState == 0)
        {
            gameOver = true;
            Debug.Log("You're wasted!");
        }

        // every 20 seconds the bunnyStatus should decrease
        time -= Time.deltaTime;

        if (time <= 0)
        {
            DecreaseBunnyState();

            // Reset state time
            time = TimeForEveryState;

            Debug.Log(string.Format("Decreased state: {0}", bunnyState));
        }
    }

    void DecreaseBunnyState()
    {
        --bunnyState;
        // TODO: Adjust bunny sprite
    }

    void AdjustWorldState()
    {
        // TODO: Adjust world state
        var interpolation = time / TimeForEveryState; // 0...1


    }

    // QUESTIONS
    // How is the level about to change?
}
