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
using System.Windows.Forms;

namespace ChatbotGUI
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.RichTextBox chatBox;
        private System.Windows.Forms.TextBox inputBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Button startQuizButton;
        private System.Windows.Forms.TextBox taskInputBox;
        private System.Windows.Forms.Button saveTaskButton;
        private System.Windows.Forms.Button displayTasksButton;
        private System.Windows.Forms.DateTimePicker reminders;
        private System.Windows.Forms.Button setReminderButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.chatBox = new System.Windows.Forms.RichTextBox();
            this.inputBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.startQuizButton = new System.Windows.Forms.Button();
            this.taskInputBox = new System.Windows.Forms.TextBox();
            this.displayTasksButton = new System.Windows.Forms.Button();
            this.reminders = new System.Windows.Forms.DateTimePicker();
            this.setReminderButton = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // chatBox
            this.chatBox.Location = new System.Drawing.Point(12, 12);
            this.chatBox.Name = "chatBox";
            this.chatBox.ReadOnly = true;
            this.chatBox.Size = new System.Drawing.Size(460, 300);
            this.chatBox.TabIndex = 0;
            this.chatBox.Text = "";

            // inputBox
            this.inputBox.Location = new System.Drawing.Point(12, 320);
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(360, 23);
            this.inputBox.TabIndex = 1;

            // sendButton
            this.sendButton.Location = new System.Drawing.Point(390, 320);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(82, 23);
            this.sendButton.TabIndex = 2;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);

            // startQuizButton
            this.startQuizButton.Location = new System.Drawing.Point(12, 350);
            this.startQuizButton.Name = "startQuizButton";
            this.startQuizButton.Size = new System.Drawing.Size(100, 23);
            this.startQuizButton.TabIndex = 3;
            this.startQuizButton.Text = "Start Quiz";
            this.startQuizButton.UseVisualStyleBackColor = true;
            this.startQuizButton.Click += new System.EventHandler(this.startQuizButton_Click);

            // taskInputBox
            this.taskInputBox.Location = new System.Drawing.Point(12, 380);
            this.taskInputBox.Name = "taskInputBox";
            this.taskInputBox.Size = new System.Drawing.Size(250, 23);
            this.taskInputBox.TabIndex = 4;

            // saveTaskButton
            this.saveTaskButton = new System.Windows.Forms.Button();
            this.saveTaskButton.Location = new System.Drawing.Point(380, 380);
            this.saveTaskButton.Name = "saveTaskButton";
            this.saveTaskButton.Size = new System.Drawing.Size(92, 23);
            this.saveTaskButton.TabIndex = 8;
            this.saveTaskButton.Text = "Save Task";
            this.saveTaskButton.UseVisualStyleBackColor = true;
            this.saveTaskButton.Click += new System.EventHandler(this.saveTaskButton_Click);

            // displayTasksButton
            this.displayTasksButton.Location = new System.Drawing.Point(270, 380);
            this.displayTasksButton.Name = "displayTasksButton";
            this.displayTasksButton.Size = new System.Drawing.Size(100, 23);
            this.displayTasksButton.TabIndex = 5;
            this.displayTasksButton.Text = "Show Tasks";
            this.displayTasksButton.UseVisualStyleBackColor = true;
            this.displayTasksButton.Click += new System.EventHandler(this.displayTasksButton_Click);

            // reminders
            this.reminders.Location = new System.Drawing.Point(12, 410);
            this.reminders.Name = "reminders";
            this.reminders.Size = new System.Drawing.Size(250, 23);
            this.reminders.TabIndex = 6;

            // setReminderButton
            this.setReminderButton.Location = new System.Drawing.Point(270, 410);
            this.setReminderButton.Name = "setReminderButton";
            this.setReminderButton.Size = new System.Drawing.Size(100, 23);
            this.setReminderButton.TabIndex = 7;
            this.setReminderButton.Text = "Set Reminder";
            this.setReminderButton.UseVisualStyleBackColor = true;
            this.setReminderButton.Click += new System.EventHandler(this.setReminderButton_Click);

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 450);
            this.Controls.Add(this.setReminderButton);
            this.Controls.Add(this.reminders);
            this.Controls.Add(this.displayTasksButton);
            this.Controls.Add(this.taskInputBox);
            this.Controls.Add(this.saveTaskButton);
            this.Controls.Add(this.startQuizButton);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.inputBox);
            this.Controls.Add(this.chatBox);
            this.Name = "Form1";
            this.Text = "Cyber Security ChatBot";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

            // Allow Enter key to trigger Send
            inputBox.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    sendButton.PerformClick();
                }
            };
        }
    }
}