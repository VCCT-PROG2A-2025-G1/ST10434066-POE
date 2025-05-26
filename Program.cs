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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Threading;


namespace ChatBot
{
   
    internal class Program

    {
        //Tracking for conversation flow.
        static string lastConvo = "";
        static string interestUser = "";
        static string userName = "User";

        //Lists and Dictionaries.

        static List<string> scaredKeywords = new List<string> { "worried", "anxious", "scared", "nervous" };
        static List<string> interestedKeywords = new List<string> { "curious", "interested", "want to know" };
        static List<string> angryKeywords = new List<string> { "frustrated", "confused", "angry" };

        static List<string> phishingTips = new List<string>
{
    "Verify email senders before opening suspicious looking emails.",
    "Look out for urgency in messages as they are usually a scam.",
    "Preview links before opening so you can see where they lead",
    "Don't download attachments from unknown senders.",
    "Report phishing scams to your email provider."
};
        static List<string> passwordTips = new List<string>
{
    "Use special characters, a mix of numbers and letters. Use Captial and LowerCase letters.",
    "Do not reuse the same password.",
    "Regularly update passwords every few months.",
    "Do not use obvious passwords such as '12345ABC'.",
    "Use secure password managers to store your passwords."
};

        static List<string> privacyTips = new List<string>
{
    "Review the privacy settings on your social media accounts regularly.",
    "Do not overshare private and sensetive information online",
    "Avoid sharing your location online.",
    "Use secure messaging apps that offer end-to-end encryption."
};
        static Dictionary<string, string> keywordResponses = new Dictionary<string, string>
{
    { "password", "Use a strong, unique password for every account. Avoid using personal details." },
    { "phishing", "Be cautious of emails asking for personal info. Verify links before clicking on them." },
    { "scam", "Scammers may pretend to be legit organisations. Don't share sensitive data online." },
    { "privacy", "Limit personal info shared online and review your account privacy settings." }
};
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

        //Random tip Generator.
        static string GetRanPhishingTip()
        {
            Random ran = new Random();
            int i = ran.Next(phishingTips.Count);
            return phishingTips[i];
        }
        static string GetRanPasswordTip()
        {
            Random ran = new Random();
            return passwordTips[ran.Next(passwordTips.Count)];
        }

        static string GetRanPrivacyTip()
        {
            Random ran = new Random();
            return privacyTips[ran.Next(privacyTips.Count)];
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
              
                //Conversation flow.
                if (input.Contains("more") || input.Contains("explain"))
                {
                    if (!string.IsNullOrEmpty(lastConvo))
                    {
                        //Tells the user about what they are interested in or will give another tip.
                        if (!string.IsNullOrEmpty(interestUser))
                        {
                            BotMessage($"Since you're interested in {interestUser}, here's something that might help:");
                        }
                        else
                        {
                            BotMessage("Here's another tip about " + lastConvo + ":");
                        }

                        switch (lastConvo)
                        {
                            case "phishing":
                                BotMessage(GetRanPhishingTip());
                                break;
                            case "password":
                                BotMessage(GetRanPasswordTip());
                                break;
                            case "privacy":
                                BotMessage(GetRanPrivacyTip());
                                break;

                            default:
                                BotMessage("Let me explain again in a simplier way.");
                                break;
                        }
                    }
                    else
                    {
                        BotMessage("What would you like to know more about?");
                    }

                    continue;
                }
               
                
                //User Interest logic. Looks to see what the user is interested in.
               
                if (input.Contains("interested in"))
                {   //extraction method of what the user is interested in.
                    int i = input.IndexOf("interested in");
                    string interest = input.Substring(i + "interested in".Length).Trim();

                    if (!string.IsNullOrWhiteSpace(interest))
                    {
                        interestUser = interest;
                        BotMessage($"Thanks, I will remember you're interested in, {interest}.");
                    }
                    else
                    {
                        BotMessage("Tell me what you're interested in?");
                    }

                    continue;
                }
               
                // Sentiment detection
                if (scaredKeywords.Any(word => input.Contains(word)))
                {
                    BotMessage("It's completely normal to feel that way. Let's go through a few tips to help you stay safe.");
                }
                else if (interestedKeywords.Any(word => input.Contains(word)))
                {
                    BotMessage("Being curious is really good, here are some tips we can look at.");
                }
                else if (angryKeywords.Any(word => input.Contains(word)))
                {
                    BotMessage("I know it can get frustrating, let us look at it together.");
                }
               
                
                //keyword logic implementation.
                //Random selection of tips
                //Tracking for conversation flow.
                bool isKeyword = false;

                foreach (var keyword in keywordResponses.Keys)
                {
                    if (input.Contains(keyword))
                    {
                        lastConvo = keyword;
                        switch (keyword)
                        {
                            case "phishing":
                                BotMessage(GetRanPhishingTip());
                                break;
                            case "password":
                                BotMessage(GetRanPasswordTip());
                                break;
                            case "privacy":
                                BotMessage(GetRanPrivacyTip());
                                break;
                            default:
                                BotMessage(keywordResponses[keyword]);
                                break;
                        }
                        isKeyword = true;
                        break; 
                    }
                }

                // Fallback 
                if (!isKeyword)
                {
                    BotMessage("I'm not sure how to answer that. Try asking a question about safe browsing, phishing or passwords.");
                }
            
                }
            }
        }
    }
//------------------------------------------------------------------END OF FILE ---------------------------------------------------------