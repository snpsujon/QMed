using Dapper;
using QuickMedProtal.Infrastructure.DBContext;
using QuickMedProtal.ServiceInterface;
using QuickMedProtal.ServiceRepository.BaseRepository;
using QuickMedProtal.ViewModels;
using System.Data;

namespace QuickMedProtal.ServiceRepository
{
    public class DoctorService : BaseRepository<DoctorVM>, IDoctor
    {
        public DoctorService(EFContext context, DapperContext dapperContext, IConfiguration configuration) : base(context, dapperContext, configuration)
        {
        }
        public async Task<dynamic> SaveDoctorData(DoctorVM doctor)
        {
            try
            {
                var parameters = new DynamicParameters();
                if (doctor.id == null)
                {
                    var id = Guid.NewGuid();
                    parameters.Add("@id", id);
                    parameters.Add("@Flag", 4);
                    parameters.Add("@name", doctor.name);
                    parameters.Add("@doctorNameBn", doctor.doctorNameBn);
                    parameters.Add("@passedMedicalDegree", doctor.passedMedicalDegree);
                    parameters.Add("@passedMedicalDegreeBn", doctor.passedMedicalDegreeBn);
                    parameters.Add("@designation", doctor.designation);
                    parameters.Add("@designationBn", doctor.designationBn);
                    parameters.Add("@department", doctor.department);
                    parameters.Add("@departmentBn", doctor.departmentBn);
                    parameters.Add("@address", doctor.address);
                    parameters.Add("@addressBn", doctor.addressBn);
                    parameters.Add("@mobile", doctor.mobile);
                    parameters.Add("@mobileBn", doctor.mobileBn);
                    parameters.Add("@chemberHospital", doctor.chemberHospital);
                    parameters.Add("@chemberHospitalBn", doctor.chemberHospitalBn);
                    parameters.Add("@chemberAddress", doctor.chemberAddress);
                    parameters.Add("@chemberAddressBn", doctor.chemberAddressBn);
                    parameters.Add("@phoneNumber", doctor.phoneNumber);
                    parameters.Add("@phoneBn", doctor.phoneBn);
                    parameters.Add("@doctorPhnSL", doctor.doctorPhnSL);
                    parameters.Add("@doctorPhnSLBn", doctor.doctorPhnSLBn);
                    parameters.Add("@startTime", doctor.startTime);
                    parameters.Add("@endTime", doctor.endTime);
                    parameters.Add("@offDay", doctor.offDay);
                    parameters.Add("@offDayBn", doctor.offDayBn);
                    parameters.Add("@offDayNotes", doctor.offDayNotes);
                    parameters.Add("@offDayNotesBn", doctor.offDayNotesBn);
                    parameters.Add("@bmdcRegNo", doctor.bmdcRegNo);
                    parameters.Add("@licenseKey", doctor.licenseKey);
                    parameters.Add("@createdBy", doctor.createdBy);
                    parameters.Add("@isSynced", doctor.isSynced);
                }
                else
                {
                    parameters.Add("@Flag", 5);
                    parameters.Add("@id", doctor.id);
                    parameters.Add("@name", doctor.name);
                    parameters.Add("@doctorNameBn", doctor.doctorNameBn);
                    parameters.Add("@passedMedicalDegree", doctor.passedMedicalDegree);
                    parameters.Add("@passedMedicalDegreeBn", doctor.passedMedicalDegreeBn);
                    parameters.Add("@designation", doctor.designation);
                    parameters.Add("@designationBn", doctor.designationBn);
                    parameters.Add("@department", doctor.department);
                    parameters.Add("@departmentBn", doctor.departmentBn);
                    parameters.Add("@address", doctor.address);
                    parameters.Add("@addressBn", doctor.addressBn);
                    parameters.Add("@mobile", doctor.mobile);
                    parameters.Add("@mobileBn", doctor.mobileBn);
                    parameters.Add("@chemberHospital", doctor.chemberHospital);
                    parameters.Add("@chemberHospitalBn", doctor.chemberHospitalBn);
                    parameters.Add("@chemberAddress", doctor.chemberAddress);
                    parameters.Add("@chemberAddressBn", doctor.chemberAddressBn);
                    parameters.Add("@phoneNumber", doctor.phoneNumber);
                    parameters.Add("@phoneBn", doctor.phoneBn);
                    parameters.Add("@doctorPhnSL", doctor.doctorPhnSL);
                    parameters.Add("@doctorPhnSLBn", doctor.doctorPhnSLBn);
                    parameters.Add("@startTime", doctor.startTime);
                    parameters.Add("@endTime", doctor.endTime);
                    parameters.Add("@offDay", doctor.offDay);
                    parameters.Add("@offDayBn", doctor.offDayBn);
                    parameters.Add("@offDayNotes", doctor.offDayNotes);
                    parameters.Add("@offDayNotesBn", doctor.offDayNotesBn);
                    parameters.Add("@bmdcRegNo", doctor.bmdcRegNo);
                    parameters.Add("@licenseKey", doctor.licenseKey);
                    parameters.Add("@updatedBy", doctor.updatedBy);
                    parameters.Add("@updatedAt", DateTime.Now); // or use doctor.updatedAt if available
                    parameters.Add("@isSynced", doctor.isSynced);

                }

                using (var _dp = _dapperContext.CreateConnection())
                {
                    var query = await _dp.QueryAsync<dynamic>("SP_Doctor", parameters, commandType: CommandType.StoredProcedure);
                    return query;
                }
            }
            catch (Exception ex)
            {
                throw ex; // Consider logging the exception for better debugging
            }
        }

        public async Task<dynamic> DeleteDoctorData(string id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Flag", 6);
                parameters.Add("@Id", id);
                using (var _dp = _dapperContext.CreateConnection())
                {
                    var query = await _dp.QueryAsync<dynamic>("SP_Doctor", parameters, commandType: CommandType.StoredProcedure);
                    return query;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
