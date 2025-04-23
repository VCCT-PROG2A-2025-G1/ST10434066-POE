/*
 *
 *
 *
 */


using System;
using System.IO;
using System.Media;

namespace ChatBot
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            WelcomeMessage();
        }

        
        // WELCOME MESSAGES AND LOGO PRINTING METHODS.
        private static void WelcomeMessage()
        {
            string welcome = "Voice1.wav";
            if (File.Exists(welcome))
            {
                var player = new SoundPlayer(welcome);
                player.PlaySync();
            }
            else
            {
                Console.WriteLine("Audio file could not be found.");
            }
        }

        private static void Ascii()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            var asciiArt = @"
 
                               _______
                             /         \
                            /   _____   \
                           |   |     |  |
                           |   |     |  |
                           |   |_____|  |
                           |     ___    |
                           |    |___|  |
                            \         /
                             \_______/
                             /       \
                            |  CYBER  |
                            | CHATBOT |
                             \_______/
                                        
            ";
            Console.WriteLine(asciiArt);
            Console.ResetColor();
        }

        // INPUT AND OUTPUT HANDLING.

        public static string GetUserName()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Enter Username:");
            var username = Console.ReadLine();
            Console.WriteLine($"\n Hello {username}, Welcome to CyberSecurity Awareness Assistant " +
                              "\n I am here to help you stay safe online.");
            Console.ResetColor();
            return username;
        }
        //CHATBOT SETTINGS
        public static void BotMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("CyberBot:"+ message);
            Console.ResetColor();
        }

        public static string UserInput()
        {
            //sets the user colour, name and avoids null errors and type case errors.
            Console.ForegroundColor = ConsoleColor.Blue;
            string user = GetUserName();
            Console.Write(user);
            string input = Console.ReadLine()?.Trim().ToLower();
            Console.ResetColor();
            return input;
        }
        // CHAT LOOP BETWEEN USER AND CHATBOT
        static void ChatLoop()
        {
            BotMessage("\n You can ask me questions about Cyber Security." +
                              "\n Type 'exit' to end the conversation.");
            //while loop to keep the chat running 
            while (true)
            {
              string input = UserInput();
                
                // input handling.
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("CyberBot: You didn't ask me questions. Ask me again.");
                    Console.ResetColor();
                    continue;
                }

                //exit prompt handling
                    if (input.Equals("exit"))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("CyberBot: Goodbye! Stay safe online. 👋 ");
                        Console.ResetColor();
                        Environment.Exit(0);
                        
                    }
                    
                    //Logic for the responses.
                    // .contains helps the chatbot understand the quesetions posed to it.
                    if (input.Contains("how are you?"))
                    {
                        BotMessage("I am feeling secure and I am ready to protect you 🤖");
                    }
                    else if (input.Contains("purpose"))
                    {
                        BotMessage("I am here to help you stay safe online and educate on CyberSecurity.");
                    }
                    else if (input.Contains("what can") && input.Contains("ask"))
                    {
                        BotMessage("You can ask me questions about passwords, phishing, safe browsing and cyber security issues");
                    }
                    else if (input.Contains("password"))
                    {
                        BotMessage(
                            "Use a unique strong password. ensure the use of capital letters, special characters and numbers." +
                            "\n Avoid using personal information as passwords");
                    }
                    else if (input.Contains("phishing"))
                    {
                        BotMessage("Phishing is a technique used by cyber criminals to gain your personal information via email." 
                                   +"\n Avoid suspicious links. Companies won't ask for sensitive information via email."
                                   +"\n If still doubtful, contact the organisation directly.");
                    }
                    else if (input.Contains("safe") && input.Contains("browsing"))
                    {
                        BotMessage("browse on websites that are secured by (https), do not click on pop-up ads. " +
                                   "\n do not download files from suspicious sites nor enter personal information.");
                    }
                    else
                    {
                        BotMessage("I'm not sure how to answer that. Try asking a question about safe browsing, phishing or passwords");
                    }
                }
            }
        }
    }
