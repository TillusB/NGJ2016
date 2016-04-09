using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    const float TimeForEveryState = 5;

    // 5 = very good
    // 0 = dead
    int bunnyState;
    // Bunny

    bool gameOver = false;

    float time;

    string[] stateTexts = { "You bleed out :/", "Watch out!", "Come on!", "Ouch - what's that?!", "What a nice day to jump around :)" };

    public Text stateText;

    // Use this for initialization
    void Start()
    {
        bunnyState = 5;
        time = TimeForEveryState;

        // Health: 1...0

        stateText.enabled = false;
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

        StartCoroutine(ShowStateText(stateTexts[bunnyState]));
    }

    void AdjustWorldState()
    {
        // TODO: Adjust world state
        var interpolation = 1 - time / TimeForEveryState; // 0...1
        Debug.Log(interpolation);
    }

    IEnumerator ShowStateText(string message)
    {
        var animationTime = 1f; // How long is the animation in seconds
        var currentTime = animationTime;

        stateText.enabled = true;
        stateText.text = message;

        while (currentTime > 0)
        {
            // 0...1
            var animationState = 1 - currentTime / animationTime;

            // TODO: fade in / out

            stateText.rectTransform.localScale = new Vector2( 2 + animationState, 2 + animationState);

            currentTime -= Time.deltaTime;

            yield return null;
        }
        // Animation is over
        stateText.enabled = false;
    }

    // QUESTIONS
    // How is the level about to change?
}
