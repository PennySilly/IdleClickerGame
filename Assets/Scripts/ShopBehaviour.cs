using UnityEngine;

public class ShopBehaviour : MonoBehaviour
{
    public PlayerScore playerScore;

    public void BuyClickerUpgrade()
    {
        //if the player score is above 10
        if (playerScore.GetPlayerScoreValue() >= 10)
        {
            //remove the amount of score for the upgrade
            playerScore.RemoveScore(10);
            //increase their multiplier by one
            playerScore.IncreaseMultiplier();
        }
    }

    public void BuyAutoUpgrade()
    {
        //if the player score is above 25
        if (playerScore.GetPlayerScoreValue() >= 25)
        {
            //check if the auto clicker is activated
            if (!playerScore.isAutoClickerActivated)
            {
                playerScore.isAutoClickerActivated = true;
                playerScore.RemoveScore(25);
                //and now we exit the method so the other code does not run
                return;
            }
            
            playerScore.RemoveScore(25);
            playerScore.autoClickerInterval /= 2;
        }
    }
}
