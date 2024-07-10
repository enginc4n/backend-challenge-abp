using BackendChallenge.Debugging;

namespace BackendChallenge
{
    public class BackendChallengeConsts
    {
        public const string LocalizationSourceName = "BackendChallenge";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "2e9a57375875441aae0db18097142e15";
    }
}
