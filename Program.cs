using System;
using System.Resources;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.IO;

[assembly: NeutralResourcesLanguage("en")]

namespace VendingMachine
{
    class Program
    {
        #region Resource Variables
        static string initializeMachineTxt = string.Empty;
        static string machineReadyTxt = string.Empty;
        static string commandHeaderTitle = string.Empty;
        static string command1Txt = string.Empty;
        static string command2Txt = string.Empty;
        static string command3Txt = string.Empty;
        static string command4Txt = string.Empty;
        static string command5Txt = string.Empty;
        static string command6Txt = string.Empty;
        static string command7Txt = string.Empty;
        static string invalidCommand = string.Empty;
        #endregion

        static void Main(string[] args)
        {            
            VendingMachine vendingMachine = new VendingMachine();
            SetUserMessagesByLanguage();

            PrintMessage(initializeMachineTxt, ConsoleColor.Cyan);
            PrintMessage(machineReadyTxt, ConsoleColor.Cyan);
            RequestUserCommand(vendingMachine);
        }

        public static void RequestUserCommand(VendingMachine vendingMachine)
        {
            SetUserMessagesByLanguage();

            PrintMessage(commandHeaderTitle +
                "\n" + command1Txt +
                "\n" + command2Txt +
                "\n" + command3Txt +
                "\n" + command4Txt +
                "\n" + command5Txt +
                "\n" + command6Txt +
                "\n" + command7Txt, ConsoleColor.Cyan);
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "BALANCE" or "balance" or "GLEICHGEWICHT" or "gleichgewicht" or "SOLDE" or "solde":
                    vendingMachine.DisplayMachineBalance();
                    break;
                case "SHOW" or "show" or "AFFICHER" or "afficher":
                    vendingMachine.ShowProducts();
                    break;
                case "REFILL" or "refill" or "NACHFÜLLUNG" or "nachfullung" or "RECHARGE" or "recharge":
                    vendingMachine.RefillMachine();
                    break;
                case "SELECT" or "select" or "AUSWÄHLEN" or "auswahlen" or "SÉLECTIONNER" or "selectionner":
                    vendingMachine.SelectProduct();
                    break;
                case "HISTORY" or "history" or "GESCHICHTE" or "geschichte" or "HISTOIRE" or "histoire":
                    vendingMachine.DisplaySaleRecords();
                    break;
                case "LANGUAGE" or "language" or "SPRACHE" or "sprache" or "LANGUE" or "langue":
                    vendingMachine.ChangeLanguage();
                    break;
                case "EXIT" or "exit" or "AUSFAHRT" or "ausfahrt" or "SORTIR" or "sortir":
                    vendingMachine.CancelTransaction();
                    break;
                default:
                    PrintMessage(invalidCommand, ConsoleColor.Red);
                    break;
            }
            RequestUserCommand(vendingMachine);
        }

        public static void SetUserMessagesByLanguage()
        {
            string cultureName = CultureInfo.CurrentUICulture.Name;

            if (cultureName == "de-DE")
            {
                initializeMachineTxt = Properties.Messages_DE.InitalizeMachineText;
                machineReadyTxt = Properties.Messages_DE.MachineReadyText;
                commandHeaderTitle = Properties.Messages_DE.CommandHeaderTitle;
                command1Txt = Properties.Messages_DE.Command1Text;
                command2Txt = Properties.Messages_DE.Command2Text;
                command3Txt = Properties.Messages_DE.Command3Text;
                command4Txt = Properties.Messages_DE.Command4Text;
                command5Txt = Properties.Messages_DE.Command5Text;
                command6Txt = Properties.Messages_DE.Command6Text;
                command7Txt = Properties.Messages_DE.Command7Text;
                invalidCommand = Properties.Messages_DE.InvalidCommand;
            }
            else if (cultureName == "fr-FR")
            {
                initializeMachineTxt = Properties.Messages_FR.InitalizeMachineText;
                machineReadyTxt = Properties.Messages_FR.MachineReadyText;
                commandHeaderTitle = Properties.Messages_FR.CommandHeaderTitle;
                command1Txt = Properties.Messages_FR.Command1Text;
                command2Txt = Properties.Messages_FR.Command2Text;
                command3Txt = Properties.Messages_FR.Command3Text;
                command4Txt = Properties.Messages_FR.Command4Text;
                command5Txt = Properties.Messages_FR.Command5Text;
                command6Txt = Properties.Messages_FR.Command6Text;
                command7Txt = Properties.Messages_FR.Command7Text;
                invalidCommand = Properties.Messages_FR.InvalidCommand;
            }
            else
            {
                initializeMachineTxt = Properties.Messages.InitalizeMachineText;
                machineReadyTxt = Properties.Messages.MachineReadyText;
                commandHeaderTitle = Properties.Messages.CommandHeaderTitle;
                command1Txt = Properties.Messages.Command1Text;
                command2Txt = Properties.Messages.Command2Text;
                command3Txt = Properties.Messages.Command3Text;
                command4Txt = Properties.Messages.Command4Text;
                command5Txt = Properties.Messages.Command5Text;
                command6Txt = Properties.Messages.Command6Text;
                command7Txt = Properties.Messages.Command7Text;
                invalidCommand = Properties.Messages.InvalidCommand;
            }
        }

        static void PrintMessage(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text + "\n");
            Console.ResetColor();
        }
    }
}
