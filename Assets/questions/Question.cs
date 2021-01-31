using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Question")]
public class Question : ScriptableObject
{
    [TextArea(10, 14)] [SerializeField] string text;
    [SerializeField] Question successNextQuestion;
    [SerializeField] Question errorNextQuestion;
    [SerializeField] string[] answers;
    [SerializeField] int correctAnswerIndex;
    [SerializeField] int points;

    public string getText()
    {
        string answers = this.getAnswers();
        return this.text + "\n" + this.getAnswers();
    }

    public string getAnswers()
    {
        string answerText = "";
        int count = 1;
        foreach(string answer in this.answers)
        {
            answerText += "Respuesta " + count.ToString() + ": " + answer + "\n";
            count++;
        }
        return answerText;
    }

    internal int getPoints()
    {
        return this.points;
    }

    internal Question getNextQuestion(int answer)
    {
        if(this.isCorrectAnswer(answer))
        {
            return this.successNextQuestion;
        }
        return this.errorNextQuestion;
    }

    public bool isPosibleAnswer(int answer)
    {
        return answer > 0 && answer <= answers.Length;
    }

    public bool isCorrectAnswer(int answer)
    {
        return answer - 1 == this.correctAnswerIndex;
    }

    public bool isLastQuestion()
    {
        return this.successNextQuestion == null || this.errorNextQuestion == null;
    }
}
