namespace Cake.Bower
{
    /// <summary>
    /// Bower command options
    /// </summary>
    public static class BowerOptions {
        /// <summary>
        /// bower list options
        /// </summary>
        public static class List
        {
            /// <summary>
            /// Paths switch
            /// </summary>
            public static string Paths = "--paths";
            /// <summary>
            /// Relative switch
            /// </summary>
            public static string Relative = "--relative";
        }

        /// <summary>
        /// bower login options
        /// </summary>
        public static class Login
        {
            /// <summary>
            /// Login switch
            /// </summary>
            public static string Token = "--token";
        }
    }
}