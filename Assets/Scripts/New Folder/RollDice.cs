using UnityEngine;
using UnityEngine.UI;

public class RollDice : MonoBehaviour 
{

	public Text score;
	public Text highScore;

	void Start()
	{
		highScore.text = PlayerPrefs.GetInt("HighScore",0).ToString();
	}	

	public void RollearDice()
	{
		int number = Random.Range(1,7);
		score.text = number.ToString();

		if(number > PlayerPrefs.GetInt("HighScore",0))
		{
			PlayerPrefs.SetInt("HighScore",number);
			print ("felicidades hiciste un nuevo record");
			highScore.text = number.ToString();
		}
	}

	public void Resetear()
	{
		PlayerPrefs.DeleteKey("HighScore");
		highScore.text = "0";
	}
}
