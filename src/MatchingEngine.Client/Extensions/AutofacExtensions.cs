using System;
using System.Diagnostics.CodeAnalysis;
using Autofac;

namespace MatchingEngine.Client.Extensions
{
    /// <summary>
    /// Extension for client registration.
    /// </summary>
    public static class AutofacExtension
    {
        /// <summary>
        /// Registers <see cref="IMatchingEngineClient"/> in Autofac container using <see cref="MatchingEngineClientSettings"/>.
        /// </summary>
        /// <param name="builder">Autofac container builder.</param>
        /// <param name="settings">Matching engine client settings.</param>
        public static void RegisterMatchingEngineClient(
            [NotNull] this ContainerBuilder builder,
            [NotNull] MatchingEngineClientSettings settings)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            builder.RegisterInstance(new MatchingEngineClient(settings))
                .As<IMatchingEngineClient>()
                .SingleInstance();
        }
    }
}