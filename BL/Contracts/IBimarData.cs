namespace BL.Contracts
{
    public interface IBimarData
    {
        bool Insert(string firstName, string lastName, string nationalCode);

        int SelectBimarId(string nationalCode);
    }
}
