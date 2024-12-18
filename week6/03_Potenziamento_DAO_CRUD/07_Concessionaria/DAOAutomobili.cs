using _04_Utility;

namespace _07_Concessionaria
{
    internal class DAOAutomobili : IDAOAutomobili
    {
        private readonly Database db;
        private readonly string tableName = "Automobili";
        private DAOAutomobili()
        {
            db = new Database("Concessionaria");
        }
        private static DAOAutomobili? instance = null;
        public static DAOAutomobili GetInstance()
        {
            return instance ??= new DAOAutomobili();
        }
    }
}
