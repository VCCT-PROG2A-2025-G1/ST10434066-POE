/* Fay-yaad Ahmed Parker
 * ST10434066
 * Group 1
 * References:
 * OpenAI (2025). OpenAI. [online] OpenAI. Available at: https://openai.com/.
 * GeeksforGeeks. (2018). C# Programming Language - GeeksforGeeks. [online] Available at: https://www.geeksforgeeks.org/csharp-programming-language/.
 * GeeksforGeeks (2018). Introduction to C# Windows Forms Applications. [online] GeeksforGeeks. Available at: https://www.geeksforgeeks.org/c-sharp/introduction-to-c-sharp-windows-forms-applications/.
 * -----------------------------------------------------------------------------------------------------------
 */

using System;
using System.Collections.Generic;

namespace ChatbotGUI
{
    public class CyberQuiz
    {
        private List<(string Question, string Answer)> questions;
        private int currentQuestionIndex;
        private int score;

        public CyberQuiz()
        {
            questions = new List<(string, string)>
            {
              // True/False
                ("True or False: You should never share your password with anyone.", "False"),
                ("True or False: Public Wi-Fi is always secure.", "False"),

                // Word answers
                ("What does HTTPS stand for?", "Hypertext Transfer Protocol Secure"),
                ("What is phishing?", "a Scam"),
                ("What electronic communication does phishing use", "E-mail"),

                // Multiple Choice
                ("Which of the following is a strong password?\nA.123\nB. Yeehaw24\nC. CowBOy234!", "C"),
                ("What is a sign of a phishing?\nA. greeting\nB. Personalized name\nC.unkown links", "C"),
                ("What is a firewall used for?\nA. Cooking\nB. Preventing cyber attacks\nC. Construction sites", "B"),
                ("Which of these is safest to use?\nA. Public Wi-Fi\nB. VPN on public Wi-Fi\nC.Unsecure sites", "B"),
                ("How often to update your passwords?\nA. Every hour \nB. Never\nC. As often as Possible", "C")
            };
            currentQuestionIndex = 0;
            score = 0;
        }

        public bool HasNextQuestion()
        {
            return currentQuestionIndex < questions.Count;
        }

        public string GetNextQuestion()
        {
            if (!HasNextQuestion()) return null;
            return questions[currentQuestionIndex].Question;
        }

        public bool SubmitAnswer(string userAnswer)
        {
            string correctAnswer = questions[currentQuestionIndex].Answer;
            bool isCorrect = userAnswer.Trim().Equals(correctAnswer, StringComparison.OrdinalIgnoreCase);

            if (isCorrect)
                score++;

            currentQuestionIndex++;
            return isCorrect;
        }

        public int GetScore()
        {
            return score;
        }

        public int TotalQuestions()
        {
            return questions.Count;
        }

        public void Reset()
        {
            currentQuestionIndex = 0;
            score = 0;
        }
    }
}