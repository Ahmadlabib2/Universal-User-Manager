namespace UUM.Api
{
    public interface IPlugin
    {
        string Name { get; }
        string Description { get; }

        /// <summary>
        /// Factory method to build a repository from the parameters
        /// </summary>
        /// <param name="parameters">Initialized parameters</param>
        /// <returns>A repository capable of exchanging data with the source/target system</returns>
        IRepository GetRepository(IParameters parameters);
    }
}
