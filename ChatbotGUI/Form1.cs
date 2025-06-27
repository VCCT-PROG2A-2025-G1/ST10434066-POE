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
using System.Windows.Forms;

namespace ChatbotGUI
{
    public partial class Form1 : Form
    {
        private CyberChatBot bot;
        private CyberQuiz quiz;
        private bool quizActive;

        private List<UserTask> tasks = new List<UserTask>();

        public Form1()
        {
            InitializeComponent();
            bot = new CyberChatBot();
            quiz = new CyberQuiz();
            quizActive = false;
        }

        // welcome message
        private void Form1_Load(object sender, EventArgs e)
        {
            chatBox.AppendText("CyberBot: Hello! Welcome to the CyberSecurity Awareness Assistant.\n");
            chatBox.AppendText("CyberBot: Ask me about cybersecurity or type 'start quiz' to begin.\n");
            chatBox.AppendText("CyberBot: Type 'exit' to close the app.\n\n");
        }

        // Handles quiz or chatbot messages
        private void sendButton_Click(object sender, EventArgs e)
        {
            string userInput = inputBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                chatBox.AppendText("CyberBot: You didn't ask anything. Try again.\n\n");
                inputBox.Clear();
                return;
            }

            chatBox.AppendText($"You: {userInput}\n");

            if (userInput.ToLower() == "exit")
            {
                Application.Exit();
                return;
            }

            if (quizActive)
            {
                bool correct = quiz.SubmitAnswer(userInput);
                chatBox.AppendText($"CyberBot: That is {(correct ? "correct" : "incorrect")}\n");

                if (quiz.HasNextQuestion())
                    chatBox.AppendText($"CyberBot: {quiz.GetNextQuestion()}\n\n");
                else
                {
                    chatBox.AppendText($"CyberBot: Quiz complete! Your score: {quiz.GetScore()} of {quiz.TotalQuestions()}.\n");
                    chatBox.AppendText("CyberBot: Ask me any question!\n\n");
                    quizActive = false;
                    quiz.Reset();
                }
            }
            else if (userInput.ToLower() == "start quiz")
            {
                quizActive = true;
                chatBox.AppendText("CyberBot: Let's start the quiz!\n");
                chatBox.AppendText($"CyberBot: {quiz.GetNextQuestion()}\n\n");
            }
            else
            {
                string botReply = bot.ProcessInput(userInput);
                chatBox.AppendText($"CyberBot: {botReply}\n\n");
            }

            inputBox.Clear();
        }

        // Starts the quiz with a button
        private void startQuizButton_Click(object sender, EventArgs e)
        {
            quizActive = true;
            chatBox.AppendText("CyberBot: Starting the cybersecurity quiz!\n");
            chatBox.AppendText($"CyberBot: {quiz.GetNextQuestion()}\n\n");
        }

        // Handles saving tasks from input box
        private void saveTaskButton_Click(object sender, EventArgs e)
        {
            string taskText = taskInputBox.Text.Trim();
            if (!string.IsNullOrWhiteSpace(taskText))
            {
                tasks.Add(new UserTask { Description = taskText, Completed = false });
                chatBox.AppendText($"CyberBot: Task saved - '{taskText}'\n");
                taskInputBox.Clear();
            }
            else
            {
                chatBox.AppendText("CyberBot: Textbox is empty.\n");
            }
        }

        // Displays all saved tasks
        private void displayTasksButton_Click(object sender, EventArgs e)
        {
            chatBox.AppendText("CyberBot: Your tasks:\n");
            if (tasks.Count == 0)
            {
                chatBox.AppendText("CyberBot: No tasks found.\n\n");
                return;
            }

            for (int i = 0; i < tasks.Count; i++)
            {
                string status = tasks[i].Completed ? "[Done]" : "";
                chatBox.AppendText($"  {i + 1}. {tasks[i].Description} {status}\n");
            }
            chatBox.AppendText("\n");
        }

        // Sets reminder based on date selection
        private void setReminderButton_Click(object sender, EventArgs e)
        {
            if (reminders.Value.Date >= DateTime.Now.Date)
                chatBox.AppendText($"CyberBot: Reminder set for {reminders.Value.ToShortDateString()}.\n");
            else
                chatBox.AppendText("CyberBot: Please choose a future date.\n");
        }
    }

    // Model for a task item
    public class UserTask
    {
        public string Description { get; set; }
        public bool Completed { get; set; }
    }
}
