using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public struct Question
{
	public int firstNumber;
	public int secondNumber;
	public int answer;
}

public class QuestionGenerator 
{
	private List<int> tablesOrigin = new List<int> (){2,3,4,5,6,7,8,9};
	private List<int> secondNumbersOrigin = new List<int> (){1,2,3,4,5,6,7,8,9};

	// memory
	private List<int> tables;
	private List<int> secondNumbers;
	private int currentTable;

	public QuestionGenerator()
	{
		Init ();
	}

	public Question GetQuestion()
	{
		if (tables.Count == 0) {
			return new Question();
		}

		if (secondNumbers.Count == 0) {
			currentTable = tables [0];
			tables.RemoveAt (0);
			secondNumbers = new List<int> (secondNumbersOrigin);
			return GetQuestion ();
		}

		int secondNumberIndex = Random.Range (0, secondNumbers.Count - 1);
		Question q = new Question ();
		q.firstNumber = currentTable;
		q.secondNumber = secondNumbers [secondNumberIndex];
		secondNumbers.RemoveAt (secondNumberIndex);
		q.answer = q.firstNumber * q.secondNumber;

		return q;
	}

	public void Init()
	{
		tables = new List<int> (tablesOrigin);
		secondNumbers = new List<int> (secondNumbersOrigin);
		currentTable = tables [0];
		tables.RemoveAt (0);
	}
}
