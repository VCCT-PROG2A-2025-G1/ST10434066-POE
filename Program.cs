/* Fay-yaad Ahmed Parker
 * ST10434066
 * Group 1
 * References:
 * OpenAI (2025). OpenAI. [online] OpenAI. Available at: https://openai.com/.
 * GeeksforGeeks. (2018). C# Programming Language - GeeksforGeeks. [online] Available at: https://www.geeksforgeeks.org/csharp-programming-language/.
 * 
 * 
 * -----------------------------------------------------------------------------------------------------------
 */



using System;
using System.IO;
using System.Media;
using System.Threading;

namespace ChatBot
{
   
    internal class Program
    {
        static string userName = "User";
        //Main method to run the program.
        public static void Main(string[] args)
        {
          
            WelcomeMessage(); 
            Ascii();
           Typing("---------------------------------------------------------------");
           string username = GetUserName();
           Typing("---------------------------------------------------------------");
           ChatLoop();
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
                Typing("Audio file could not be found.");
            }
        }

        private static void Ascii()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            var asciiArt = @"
                        CYBER SECURITY CHATBOT
                               _______
                             /         \
                            /   _____   \
                           |   |     |   |
                           |   |     |   |
                           |   |_____|   |
                           |     ___     |
                           |    |___|    |
                            \           /
                             \_________/
                              /       \
                             |         |
                             |         |
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
            Typing($"\n Hello {username}, Welcome to CyberSecurity Awareness Assistant " +
                              "\n I am here to help you stay safe online.");
            Console.ResetColor();
            return username;
        }




        //TYPING EFFECTS SUCH AS DELAYS
        static void Typing(string message)
        {
             int delay = 20;
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
        }


        //CHATBOT SETTINGS
        public static void BotMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Typing("CyberBot:"+ message);
            Console.ResetColor();
        }

        public static string UserInput()
        {
            //sets the user colour, name and avoids null errors and type case errors.
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{userName}:");
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
                        Console.WriteLine("CyberBot: Goodbye! Stay safe online.  ");
                        Console.ResetColor();
                        Environment.Exit(0);
                        
                    }
                    
                    //Logic for the responses.
                    // .contains helps the chatbot understand the quesetions posed to it.
                    if (input.Contains("how are you"))
                    {
                        BotMessage("I am feeling secure and I am ready to protect you ");
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
                        BotMessage("Phishing is a technique used by cyber criminals to gain your personal information via email. " 
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
//------------------------------------------------------------------END OF FILE ---------------------------------------------------------