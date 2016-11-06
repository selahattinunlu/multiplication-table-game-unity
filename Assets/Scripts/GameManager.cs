using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
	public static GameManager Instance;

	public AudioSource correctSound;
	public AudioSource wrongSound;

	private QuestionGenerator qGenerator;
	private Question q;

	void Awake()
	{
		Instance = this;
	}

	void Start () 
	{
		qGenerator = new QuestionGenerator ();
		NextQuestion ();
	}

	public void SendAnswer(int answer)
	{
		if (answer == q.answer) {
			StartCoroutine (CorrectAnswerRoutine ());
		} else {
			StartCoroutine (WrongAnswerRoutine());
		}
	}

	void NextQuestion()
	{
		q = qGenerator.GetQuestion ();

		if (q.firstNumber == null) {
			GameOver ();
			return;
		}

		UIManager.Instance.SetQuestion (q);
		UIManager.Instance.SetAnswer ("?");
	}

	IEnumerator CorrectAnswerRoutine()
	{
		correctSound.Play ();
		UIManager.Instance.SetQuestionPanelVisibility (false);
		UIManager.Instance.SetCorrectAnswerPanelVisibility (true);
		yield return new WaitForSeconds (1f);
		NextQuestion ();
		UIManager.Instance.SetQuestionPanelVisibility (true);
		UIManager.Instance.SetCorrectAnswerPanelVisibility (false);
		yield return null;
	}

	IEnumerator WrongAnswerRoutine()
	{
		wrongSound.Play ();
		UIManager.Instance.SetQuestionPanelVisibility (false);
		UIManager.Instance.SetWrongAnswerPanelVisibility (true);
		yield return new WaitForSeconds (.5f);
		UIManager.Instance.SetAnswer ("?");
		UIManager.Instance.SetQuestionPanelVisibility (true);
		UIManager.Instance.SetWrongAnswerPanelVisibility (false);
		yield return null;
	}

	void GameOver()
	{
		SceneManager.LoadScene ("GameOver");
	}
}
