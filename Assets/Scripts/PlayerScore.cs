using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    //we are making the score private as we want to only interact with it through methods
    private int _playerScore = 0;
    //this is how powerful the players clicks are
    private int _scoreMultiplier = 1;

    //this is a float to see if enough time has passed to click for the player
    private float _autoClickerTimer = 0f;
    //this bool is switched on if the player has purchased an auto clicker
    public bool isAutoClickerActivated = false;
    //how long to wait before the auto clicker activates
    public float autoClickerInterval = 2.5f;
    
    //these are references to our text in the scene
    public Text multiplierText;
    public Text scoreText;

    //we can set the initial score of the player here
    private void Start()
    {
        UpdateText();
    }

    //Fixed update is like a regular update, but is more consistent since it runs at a fixed time step, it is normally used for physics calculations
    private void FixedUpdate()
    {
        //this only runs if the bool is true
        if (isAutoClickerActivated)
        {
            //we can add time to the timer
            _autoClickerTimer += Time.deltaTime;

            //if the timer is above they interval
            if (_autoClickerTimer > autoClickerInterval)
            {
                AddScore();
                //reset the time
                _autoClickerTimer = 0;
            }
        }
    }

    //the parameter takes an int to remove from the players score
    public void AddScore()
    {
        _playerScore += 1 * _scoreMultiplier;
        UpdateText();
    }

    //the parameter takes an int to remove from the players score
    public void RemoveScore(int scoreToRemove)
    {
        _playerScore -= scoreToRemove;
    }

    //this increases the player multiplier
    public void IncreaseMultiplier()
    {
        _scoreMultiplier++;
        UpdateText();
    }

    //this is for the shop to able to see how much score the player has without directly accessing the variable
    public int GetPlayerScoreValue()
    {
        return _playerScore;
    }

    //since we update the text a lot, we created a separate method we can call from multiple places
    private void UpdateText()
    {
        scoreText.text = "Player Score = " + _playerScore;
        multiplierText.text = "Player Multiplier = " + _scoreMultiplier;
    }
}
