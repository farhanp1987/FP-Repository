using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
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
            invalidInput = Properties.Messages.InvalidInput;
            enterLanguageTxt = Properties.Messages.EnterLanguageText;
            languageChangedTxt = Properties.Messages.LanguageChangedText;
            languageName = Properties.Messages.LanguageName;
            machineBalanceTxt = Properties.Messages.MachineBalanceText;
        }
    }

    public class GermanLanguage : Language
    {
        public new void SetMessagesByLanguage()
        {
            Language.initializeMachineTxt = Properties.Messages_DE.InitalizeMachineText;
            Language.machineReadyTxt = Properties.Messages_DE.MachineReadyText;
            Language.commandHeaderTitle = Properties.Messages_DE.CommandHeaderTitle;
            Language.command1Txt = Properties.Messages_DE.Command1Text;
            Language.command2Txt = Properties.Messages_DE.Command2Text;
            Language.command3Txt = Properties.Messages_DE.Command3Text;
            Language.command4Txt = Properties.Messages_DE.Command4Text;
            Language.command5Txt = Properties.Messages_DE.Command5Text;
            Language.command6Txt = Properties.Messages_DE.Command6Text;
            Language.command7Txt = Properties.Messages_DE.Command7Text;
            Language.invalidCommand = Properties.Messages_DE.InvalidCommand;
            Language.enterLanguageTxt = Properties.Messages_DE.EnterLanguageText;
            Language.languageChangedTxt = Properties.Messages_DE.LanguageChangedText;
            Language.invalidInput = Properties.Messages_DE.InvalidInput;
            Language.languageName = Properties.Messages_DE.LanguageName;
            Language.machineBalanceTxt = Properties.Messages_DE.MachineBalanceText;
        }
    }

    public class FrenchLanguage : Language
    {
        public new void SetMessagesByLanguage()
        {
            Language.initializeMachineTxt = Properties.Messages_FR.InitalizeMachineText;
            Language.machineReadyTxt = Properties.Messages_FR.MachineReadyText;
            Language.commandHeaderTitle = Properties.Messages_FR.CommandHeaderTitle;
            Language.command1Txt = Properties.Messages_FR.Command1Text;
            Language.command2Txt = Properties.Messages_FR.Command2Text;
            Language.command3Txt = Properties.Messages_FR.Command3Text;
            Language.command4Txt = Properties.Messages_FR.Command4Text;
            Language.command5Txt = Properties.Messages_FR.Command5Text;
            Language.command6Txt = Properties.Messages_FR.Command6Text;
            Language.command7Txt = Properties.Messages_FR.Command7Text;
            Language.invalidCommand = Properties.Messages_FR.InvalidCommand;
            Language.enterLanguageTxt = Properties.Messages_FR.EnterLanguageText;
            Language.languageChangedTxt = Properties.Messages_FR.LanguageChangedText;
            Language.invalidInput = Properties.Messages_FR.InvalidInput;
            Language.languageName = Properties.Messages_FR.LanguageName;
            Language.machineBalanceTxt = Properties.Messages_FR.MachineBalanceText;
        }
    }
}
