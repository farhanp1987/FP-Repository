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

        #region Global Variables
        public static Language language = null;
        public static GermanLanguage germanLanguage = null;
        public static FrenchLanguage frenchLanguage = null;
        #endregion

        static void Main(string[] args)
        {
            VendingMachine vendingMachine = new VendingMachine();
            
            SetUserMessagesByLanguage();

            PrintMessage(Language.initializeMachineTxt, ConsoleColor.Cyan);
            PrintMessage(Language.machineReadyTxt, ConsoleColor.Cyan);

            RequestUserCommand(vendingMachine);
        }

        public static void RequestUserCommand(VendingMachine vendingMachine)
        {
            SetUserMessagesByLanguage();

            PrintMessage(Language.commandHeaderTitle +
                "\n" + Language.command1Txt +
                "\n" + Language.command2Txt +
                "\n" + Language.command3Txt +
                "\n" + Language.command4Txt +
                "\n" + Language.command5Txt +
                "\n" + Language.command6Txt +
                "\n" + Language.command7Txt, ConsoleColor.Cyan);

            string userInput = Console.ReadLine();

            switch (userInput.ToUpper())
            {
                case "BALANCE" or "GLEICHGEWICHT" or "SOLDE":
                    vendingMachine.DisplayMachineBalance();
                    break;
                case "SHOW" or "AFFICHER":
                    vendingMachine.ShowProducts();
                    break;
                case "REFILL" or "NACHFÜLLUNG" or "RECHARGE":
                    vendingMachine.RefillMachine();
                    break;
                case "SELECT" or "AUSWÄHLEN" or "SÉLECTIONNER":
                    vendingMachine.SelectProduct();
                    break;
                case "HISTORY" or "GESCHICHTE" or "HISTOIRE":
                    vendingMachine.DisplaySaleRecords();
                    break;
                case "LANGUAGE" or "SPRACHE" or "LANGUE":
                    vendingMachine.ChangeLanguage();
                    break;
                case "EXIT" or "AUSFAHRT" or "SORTIR":
                    vendingMachine.CancelTransaction();
                    break;
                default:
                    PrintMessage(Language.invalidCommand, ConsoleColor.Red);
                    break;
            }
            RequestUserCommand(vendingMachine);
        }

        public static void SetUserMessagesByLanguage()
        {
            if (CultureInfo.CurrentUICulture.Name == "de-DE")
            {
                germanLanguage = new GermanLanguage();
                germanLanguage.SetMessagesByLanguage();
            }
            else if (CultureInfo.CurrentUICulture.Name == "fr-FR")
            {
                frenchLanguage = new FrenchLanguage();
                frenchLanguage.SetMessagesByLanguage();
            }
            else
            {
                Language.SetMessagesByLanguage();
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
