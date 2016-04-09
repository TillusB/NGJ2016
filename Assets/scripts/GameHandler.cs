using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    // TODO: Some routine still runs after Bunny Death?
    //    const float TimeForEveryState = 5;
    static GameHandler ourInstance;

    public Bunny bunny;

    public static GameHandler GetInstance()
    {
        return ourInstance;
    }
    // Controls
    public Button startGameButton;
    public Button restartGameButton;
    public float bleedSpeed = 0.1f;

    // BunnyStates according to it's health:
    // 100...81 -> 5 very good
    //  80...61 -> 4
    //  60...41 -> 3
    //  40...21 -> 2
    //  20...01 -> 1
    //        0 -> 0 dead
    int bunnyState;

    bool gameOver = false;
    bool gameStarted = false;

    float time;

    string[] stateTexts = { "You bleed out :/", "Watch out!!!", "It doesn't get any better!!", "OMG - you're LEAKing!", "Ouch - what's that?!", "What a nice day to jump around :)" };

    public Text stateText;

    public void StartGame()
    {
        ourInstance = this;
        Debug.Log("Start Game!");
        gameStarted = true;
        startGameButton.gameObject.SetActive(false);

        bunnyState = stateTexts.Length - 1;
        StartCoroutine(ShowStateText(stateTexts[bunnyState]));
    }

    public void RestartGame()
    {
        restartGameButton.gameObject.SetActive(false);
        gameOver = false;

        bunny.ResurrectBunny();

        StartGame();
    }

    public void SetGameOver()
    {
        gameOver = true;
        restartGameButton.gameObject.SetActive(true);
        Debug.Log("You're wasted!");
    }

    // Use this for initialization
    void Start()
    {
        // Health: 100...0

        stateText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
            return;

        if (bunny.getHealth() <= 0)
        {
            SetGameOver();
        }

        var currentHealth = (float)bunny.getHealth();
        var currentBunnyState = Mathf.CeilToInt( currentHealth / Bunny.FullHealth * 5f);

        Debug.Log(string.Format("health: {0}, bunnyState: {1}", bunny.getHealth(), currentBunnyState));

        if(currentBunnyState != bunnyState)
        {
            bunnyState = currentBunnyState;

            AdjustBunnyState();
            AdjustWorldState();
        }
    }

    void FixedUpdate()
    {
        Bleed(bleedSpeed);
    }

    private void Bleed(float speed)
    {
        if(bunny.getHealth() > 0)
        {
            bunny.reduceHealth(speed);
        }
    }

    void AdjustBunnyState()
    {
        // TODO: Adjust bunny sprite

        StartCoroutine(ShowStateText(stateTexts[bunnyState]));
    }

    void AdjustWorldState()
    {
        // TODO: Adjust world sprites
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

            stateText.rectTransform.localScale = new Vector2( 2 + animationState * 0.5f, 2 + animationState * 0.5f);

            currentTime -= Time.deltaTime;

            yield return null;
        }

        // Animation is over
        stateText.enabled = false;
    }

    // QUESTIONS
    // How is the level about to change?
}
