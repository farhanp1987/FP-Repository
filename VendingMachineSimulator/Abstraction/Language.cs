using System;

namespace VendingMachine.Abstraction
{
    public abstract class Language
    {
        #region Resource Variables Declaration
        public static string initializeMachineTxt = string.Empty;
        public static string machineReadyTxt = string.Empty;
        public static string commandHeaderTitle = string.Empty;
        public static string command1Txt = string.Empty;
        public static string command2Txt = string.Empty;
        public static string command3Txt = string.Empty;
        public static string command4Txt = string.Empty;
        public static string command5Txt = string.Empty;
        public static string command6Txt = string.Empty;
        public static string command7Txt = string.Empty;
        public static string invalidCommand = string.Empty;
        public static string invalidInput = string.Empty;
        public static string enterLanguageTxt = string.Empty;
        public static string languageChangedTxt = string.Empty;
        public static string languageName = string.Empty;
        public static string machineBalanceTxt = string.Empty;
        #endregion

        public static void SetMessagesByLanguage()
        {
            initializeMachineTxt = Resources.Messages.InitalizeMachineText;
            machineReadyTxt = Resources.Messages.MachineReadyText;
            commandHeaderTitle = Resources.Messages.CommandHeaderTitle;
            command1Txt = Resources.Messages.Command1Text;
            command2Txt = Resources.Messages.Command2Text;
            command3Txt = Resources.Messages.Command3Text;
            command4Txt = Resources.Messages.Command4Text;
            command5Txt = Resources.Messages.Command5Text;
            command6Txt = Resources.Messages.Command6Text;
            command7Txt = Resources.Messages.Command7Text;
            invalidCommand = Resources.Messages.InvalidCommand;
            invalidInput = Resources.Messages.InvalidInput;
            enterLanguageTxt = Resources.Messages.EnterLanguageText;
            languageChangedTxt = Resources.Messages.LanguageChangedText;
            languageName = Resources.Messages.LanguageName;
            machineBalanceTxt = Resources.Messages.MachineBalanceText;
        }
    }

    public class GermanLanguage : Language
    {
        public new void SetMessagesByLanguage()
        {
            Language.initializeMachineTxt = Resources.Messages_DE.InitalizeMachineText;
            Language.machineReadyTxt = Resources.Messages_DE.MachineReadyText;
            Language.commandHeaderTitle = Resources.Messages_DE.CommandHeaderTitle;
            Language.command1Txt = Resources.Messages_DE.Command1Text;
            Language.command2Txt = Resources.Messages_DE.Command2Text;
            Language.command3Txt = Resources.Messages_DE.Command3Text;
            Language.command4Txt = Resources.Messages_DE.Command4Text;
            Language.command5Txt = Resources.Messages_DE.Command5Text;
            Language.command6Txt = Resources.Messages_DE.Command6Text;
            Language.command7Txt = Resources.Messages_DE.Command7Text;
            Language.invalidCommand = Resources.Messages_DE.InvalidCommand;
            Language.enterLanguageTxt = Resources.Messages_DE.EnterLanguageText;
            Language.languageChangedTxt = Resources.Messages_DE.LanguageChangedText;
            Language.invalidInput = Resources.Messages_DE.InvalidInput;
            Language.languageName = Resources.Messages_DE.LanguageName;
            Language.machineBalanceTxt = Resources.Messages_DE.MachineBalanceText;
        }
    }

    public class FrenchLanguage : Language
    {
        public new void SetMessagesByLanguage()
        {
            Language.initializeMachineTxt = Resources.Messages_FR.InitalizeMachineText;
            Language.machineReadyTxt = Resources.Messages_FR.MachineReadyText;
            Language.commandHeaderTitle = Resources.Messages_FR.CommandHeaderTitle;
            Language.command1Txt = Resources.Messages_FR.Command1Text;
            Language.command2Txt = Resources.Messages_FR.Command2Text;
            Language.command3Txt = Resources.Messages_FR.Command3Text;
            Language.command4Txt = Resources.Messages_FR.Command4Text;
            Language.command5Txt = Resources.Messages_FR.Command5Text;
            Language.command6Txt = Resources.Messages_FR.Command6Text;
            Language.command7Txt = Resources.Messages_FR.Command7Text;
            Language.invalidCommand = Resources.Messages_FR.InvalidCommand;
            Language.enterLanguageTxt = Resources.Messages_FR.EnterLanguageText;
            Language.languageChangedTxt = Resources.Messages_FR.LanguageChangedText;
            Language.invalidInput = Resources.Messages_FR.InvalidInput;
            Language.languageName = Resources.Messages_FR.LanguageName;
            Language.machineBalanceTxt = Resources.Messages_FR.MachineBalanceText;
        }
    }
}
