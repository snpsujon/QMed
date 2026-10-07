namespace QuickMedProtal.ServiceInterface
{
    public interface IPrescription
    {
        Task<dynamic> GetDoctorListData();
        Task<dynamic> GetLicenseListData();
        Task<dynamic> GetPrescriptionDataByDoctorId(string doctorId);
        Task<dynamic> GetPrescriptionPreviewDataById(string prescriptionId);
    }
}
