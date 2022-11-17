namespace AOQBIY_HFT_2022231.Repository.Interfaces
{
    public interface IProcessorRepository
    {
        void UpdateMaxTurboFrequency(int id, int newMaxFreq);
    }
}