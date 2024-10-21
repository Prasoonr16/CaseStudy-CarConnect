using DAO;
using System.Data;


namespace HelperLibrary
{
    public class ReportGeneratorHelper
    {
        ReportGenerator reportGenerator = null;
        public ReportGeneratorHelper()
        {
            reportGenerator = new ReportGenerator();
        }

        public DataTable generateReservationHistoryReport()
        {
            return reportGenerator.GenerateReservationHistoryReport();
        }

        public DataTable generateVehicleUtilizationReport()
        {
            return reportGenerator.GenerateVehicleUtilizationReport();
        }

        public DataTable generateRevenueReport()
        {
            return reportGenerator.GenerateRevenueReport();
        }
    }
}
