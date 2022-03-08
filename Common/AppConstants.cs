using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class AppConstants
    {
        public const string DefaultLanguage = "es";
        public const string DefaultCulture = "es-PR";
        public const string EnglishLanguage = "en";
        public const string EnglishCulture = "en-US";
        public const string TransactionId = "TransactionId";
        public const string Origin = "CustomOrigin";
        public const string Web = "Web";
        public const string Mobile = "Mobile";
        public const string Unknow = "Unknow";
        public const string NotificationEmailExpendio = "NotificationEmailExpendio";
        public const string SessionUserId = "SessionUserId";
        public const string SessionTokenName = "SessionTokenName";
        public const string SessionUsernName = "SessionUsernName";
        public const string CompleteName = "CompleteName";
        public const string Language = "Language";

        public const string ExpenseNeedMyAttentionNotify = "ExpenseNeedMyAttentionNotify";
        public const string ExpenseApprovedNotify = "ExpenseApprovedNotify";
        public const string ExpenseToRetrieveNotify = "ExpenseToRetrieveNotify";

        public const string CurrencyPreferedId = "CurrencyPreferedId";
        public const string AuthorizationToken = "Authorization";
        public const string TokenKey = "token";
        public const string TokenType = "bearer";
        public const string TokenGrantType = "password";
        public const string MobileSettingsKey = "MobileSettings";
        public const string FAQ = "FAQ";
        public const int MileageId = 4;

        public const int WaitingForApprovalState = 2;
        public const int DeniedState = 3;
        public const int AttentionRequired = 6;
        public const int ApprovedState = 4;
        public const int ReimbursedState = 5;


        public const int ApprovalSupervisor = 2;
        public const int InitialRegisterStage = 1;
        public const int SupervisorApprovalStage = 2;
        public const int DefaultTimeExpires = 1800;
        public const string CurrencyTypes = "CurrencyTypes";
        public const string Approval = "Approvals";
        public const string ConfigurationDetail = "ConfigurationDetails";
        public const string Configuration = "Configurations";
        public const string Client = "Clients";
        public const string CopilotUser = "CopilotUsers";
        public const string Expense = "Expenses";
        public const string ExpenseType = "ExpenseTypes";
        public const string Project = "Projects";
        public const string Receipt = "Receipts";
        public const string RoleUserProject = "RoleUserProjects";
        public const string Stage = "Stages";
        public const string State = "States";
        public const string Application = "Applications";
        public const string OptionRol = "OptionRoles";
        public const string Option = "Options";
        public const string OptionType = "OptionTypes";
        public const string Role = "Roles";
        public const string UserRol = "UserRoles";
        public const string User = "Users";
        public const string CostByLocation = "CostByLocations";
        public const string Location = "Locations";
        public const string Synchronization = "Synchronizations";
        public const string SynchronizationDetail = "SynchronizationDetails";
        public const string DisputeOptions = "DisputeOptions";
        public const double HourOfNextSync = 24;
        public const string FAQConfigurationCode = "FAQ";
        public const string PhotoBaseURI = "https://expensesdevstorage.blob.core.windows.net/expenses-dev-blob-container";
        public const int ApplicationId = 1;
        public const int HotelExpenseTypeId = 1;
        public const int MaintenanceExpenseTypeId = 2;
        public const int MealExpenseTypeId = 3;
        public const int MileageExpenseTypeId = 4;
        public const int PlaneTicketExpenseTypeId = 5;
        public const int TrainingExpenseTypeId = 6;
        public const int TransportExpenseTypeId = 7;
        public const int OtherExpenseTypeId = 8;
        //List of Action Id's
        public const int ActionApproved = 1;
        public const int ActionDisapproved = 2;
        public const int ActionRejected = 3;
        //List of Role Id's
        public const int RoleExpenser = 1;
        public const int RoleSupervisor = 2;
        public const int RoleSupervisor2 = 3;
        public const int RoleFinance = 4;
        public const string NavigateToExpense = "NavigateToExpense";
        public const int Zero = 0;
        public const string FileImagesExtensions = "jpg|gif|png|jpeg";
        //list of disputeoptions
        public const int DisputeOptionNoApproved = 10;
    }
}
