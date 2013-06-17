namespace UUM.Api.Interfaces
{
    public interface IPlugin: IIdentifiable
    {

        /// <summary>
        /// Short name of the plugin
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Detailled description
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Factory method to build a repository from the parameters
        /// </summary>
        /// <param name="parameters">Initialized parameters</param>
        /// <returns>A repository capable of exchanging data with the source/target system</returns>
        IRepository GetRepository(IParameters parameters);

    	IParameters GetParameters();
    }
}
