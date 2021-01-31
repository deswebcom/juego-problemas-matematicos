using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MathsGame : MonoBehaviour
{
    [SerializeField] Question initialQuestion;
    [SerializeField] Text statementTextField;
    Question currentQuestion;
    int points = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.currentQuestion = this.initialQuestion;
        this.showQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return)) {
            this.currentQuestion = initialQuestion;
            this.showQuestion();
            this.points = 0;
        } else
        {
            this.processAnswer();
        }
    }

    void processAnswer()
    {
        var input = this.detectInput();
        if (this.isNumber(input))
        {
            int answer = Int32.Parse(input);
            if(this.currentQuestion.isPosibleAnswer(answer))
            {
                if (currentQuestion.isCorrectAnswer(answer))
                {
                    this.points += currentQuestion.getPoints();
                    Debug.Log(this.points);
                }
                if(currentQuestion.isLastQuestion())
                {
                    this.statementTextField.text = "El juego ha terminado. Tienes " + this.points + " puntos.\n\nPulsa Enter para comenzar de nuevo el juego";
                } else
                {
                    this.currentQuestion = this.currentQuestion.getNextQuestion(answer);
                    this.showQuestion();
                }
            }
        }
    }

    void showQuestion()
    {
        this.statementTextField.text = this.currentQuestion.getText();
    }

    private string detectInput()
    {
        if (Input.inputString != "")
        {
            return Input.inputString;
        }
        return "";
    }

    private Boolean isNumber(string input)
    {
        int number;
        return Int32.TryParse(input, out number);
    }

}

