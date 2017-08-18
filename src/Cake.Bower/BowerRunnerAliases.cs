using System;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.Bower
{
    /// <summary>
    /// Provides a wrapper around Bower functionality within a Cake build script
    /// </summary>
    [CakeAliasCategory("Bower")]
    public static class BowerRunnerAliases
    {
        /// <summary>
        /// Get a Bower runner
        /// </summary>
        /// <param name="context">The context</param>
        /// <returns></returns>
        /// <example>
        /// <para>Run 'bower install'</para>
        /// <para>Cake task:</para>
        /// <code>
        /// <![CDATA[
        /// Task("Bower-FromPath")
        ///     .Does(() =>
        /// {
        ///     Bower.FromPath("./dir-with-bowerjson").Install();
        /// });
        /// ]]>
        /// </code>
        /// <para>Run 'bower install'</para>
        /// <para>Cake task:</para>
        /// <code>
        /// <![CDATA[
        /// Task("Bower-Install")
        ///     .Does(() =>
        /// {
        ///     Bower.Install();
        /// });
        /// ]]>
        /// </code>
        /// </example>
        [CakePropertyAlias]
        public static BowerRunner Bower(this ICakeContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            return new BowerRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
        }
    }
}