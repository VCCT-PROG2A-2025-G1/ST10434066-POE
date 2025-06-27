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
using System.Linq;

namespace ChatbotGUI
{
    public class CyberChatBot
    {
        private string lastConvo = "";
        private string interestUser = "";

        // Lists and Dictionaries
        private readonly List<string> scaredKeywords = new() { "worried", "anxious", "scared", "nervous" };
        private readonly List<string> interestedKeywords = new() { "curious", "interested", "want to know" };
        private readonly List<string> angryKeywords = new() { "frustrated", "confused", "angry" };

        private readonly List<string> phishingTips = new()
        {
            "Verify email senders before opening suspicious looking emails.",
            "Look out for urgency in messages as they are usually a scam.",
            "Preview links before opening so you can see where they lead",
            "Don't download attachments from unknown senders.",
            "Report phishing scams to your email provider."
        };

        private readonly List<string> passwordTips = new()
        {
            "Use special characters, a mix of numbers and letters. Use Captial and LowerCase letters.",
            "Do not reuse the same password.",
            "Regularly update passwords every few months.",
            "Do not use obvious passwords such as '12345ABC'.",
            "Use secure password managers to store your passwords."
        };

        private readonly List<string> privacyTips = new()
        {
            "Review the privacy settings on your social media accounts regularly.",
            "Do not overshare private and sensetive information online",
            "Avoid sharing your location online.",
            "Use secure messaging apps that offer end-to-end encryption."
        };

        private readonly Dictionary<string, string> keywordResponses = new()
        {
            { "password", "Use a strong, unique password for every account. Avoid using personal details." },
            { "phishing", "Be cautious of emails asking for personal info. Verify links before clicking on them." },
            { "scam", "Scammers may pretend to be legit organisations. Don't share sensitive data online." },
            { "privacy", "Limit personal info shared online and review your account privacy settings." }
        };

        // Main method to process user input
        public string ProcessInput(string input)
        {
            input = input.ToLower().Trim();

            if (string.IsNullOrWhiteSpace(input))
                return null;

            if (input == "exit")
                return "CyberBot: Goodbye! Stay safe online.";

            if (input.Contains("how are you"))
                return "CyberBot: I am feeling secure and I am ready to protect you ";

            if (input.Contains("purpose"))
                return "CyberBot: I am here to help you stay safe online and educate on CyberSecurity.";

            if (input.Contains("what can") && input.Contains("ask"))
                return "CyberBot: You can ask me questions about passwords, phishing, safe browsing and cyber security issues";

            if (input.Contains("more") || input.Contains("explain"))
            {
                if (!string.IsNullOrEmpty(lastConvo))
                {
                    if (!string.IsNullOrEmpty(interestUser))
                        return $"CyberBot: Since you're interested in {interestUser}, here's something that might help:\n{GetTip(lastConvo)}";
                    else
                        return $"CyberBot: Here's another tip about {lastConvo}:\n{GetTip(lastConvo)}";
                }
                else
                {
                    return "CyberBot: What would you like to know more about?";
                }
            }

            if (input.Contains("interested in"))
            {
                int i = input.IndexOf("interested in");
                string interest = input[(i + "interested in".Length)..].Trim();
                if (!string.IsNullOrWhiteSpace(interest))
                {
                    interestUser = interest;
                    return $"CyberBot: Thanks, I will remember you're interested in {interest}.";
                }
                return "CyberBot: Tell me what you're interested in?";
            }

            if (scaredKeywords.Any(w => input.Contains(w)))
                return "CyberBot: It's completely normal to feel that way. Let's go through a few tips to help you stay safe.";

            if (interestedKeywords.Any(w => input.Contains(w)))
                return "CyberBot: Being curious is really good, here are some tips we can look at.";

            if (angryKeywords.Any(w => input.Contains(w)))
                return "CyberBot: I know it can get frustrating, let us look at it together.";

            foreach (var keyword in keywordResponses.Keys)
            {
                if (input.Contains(keyword))
                {
                    lastConvo = keyword;
                    return $"CyberBot: {GetTip(keyword)}";
                }
            }

            return "CyberBot: I'm not sure how to answer that. Try asking a question about safe browsing, phishing or passwords.";
        }

        // Tip Generator Logic
        private string GetTip(string category)
        {
            var rand = new Random();
            return category switch
            {
                "phishing" => phishingTips[rand.Next(phishingTips.Count)],
                "password" => passwordTips[rand.Next(passwordTips.Count)],
                "privacy" => privacyTips[rand.Next(privacyTips.Count)],
                _ => keywordResponses.ContainsKey(category) ? keywordResponses[category] : "I'm not sure how to answer that."
            };
        }
    }
}