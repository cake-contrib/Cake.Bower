namespace Cake.Bower
{
    /// <summary>
    /// Levels of logs to report
    /// </summary>
    public enum BowerLogLevel
    {
        /// <summary>
        /// No value
        /// </summary>
        None = 0,
        /// <summary>
        /// Only output errors
        /// </summary>
        Error,
        /// <summary>
        /// Conflict
        /// </summary>
        Conflict,
        /// <summary>
        /// Warn
        /// </summary>
        Warn,
        /// <summary>
        /// Action
        /// </summary>
        Action,
        /// <summary>
        /// Info
        /// </summary>
        Info,
        /// <summary>
        /// Debug
        /// </summary>
        Debug
    }
}