using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour 
{
	public static UIManager Instance;

	public Text answerText;
	public Text questionText;
	public Image questionPanel;
	public Image correctAnswerPanel;
	public Image wrongAnswerPanel;

	void Awake()
	{
		Instance = this;
	}

	public void OnClickRestartButton()
	{
		SceneManager.LoadScene ("Game");
	}

	public void OnClickGoMainButton()
	{
		SceneManager.LoadScene ("Main");
	}

	public void OnClickMainPlayButton()
	{
		SceneManager.LoadScene ("Menu");
	}

	public void OnClickModeButton(string modename)
	{
		SceneManager.LoadScene ("Game");
	}

	public void OnClickNumberButton(int number)
	{
		if (answerText.text == "?") {
			answerText.text = "";
		}

		answerText.text += number.ToString ();
	}

	public void OnClickBackspaceButton()
	{
		if (answerText.text == "?") {
			return;
		}

		if (answerText.text.Length == 1) {
			answerText.text = "?";
			return;
		}

		answerText.text = answerText.text.Substring (0, answerText.text.Length - 1);
	}

	public void OnClickSendAnswerButton()
	{
		GameManager.Instance.SendAnswer (Int32.Parse(answerText.text));
	}

	public void SetQuestion(Question q)
	{
		questionText.text = q.firstNumber.ToString () + " x " + q.secondNumber.ToString () + " =";
	}

	public void SetAnswer(string a)
	{
		string _answer = a;

		if (a == null || a == "") {
			_answer = "?";
		}

		answerText.text = _answer;
	}

	public void SetQuestionPanelVisibility(bool s)
	{
		questionPanel.gameObject.SetActive (s);
	}

	public void SetCorrectAnswerPanelVisibility(bool s)
	{
		correctAnswerPanel.gameObject.SetActive (s);
	}

	public void SetWrongAnswerPanelVisibility(bool s)
	{
		wrongAnswerPanel.gameObject.SetActive (s);
	}
}
