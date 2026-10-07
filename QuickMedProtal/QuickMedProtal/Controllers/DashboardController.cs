using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuickMedPortal.ViewModels;
using QuickMedProtal.ServiceInterface;

namespace QuickMedProtal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboard _dashboard;
        public DashboardController(IDashboard dashboard)
        {
            _dashboard = dashboard;
        }

        [HttpPost("GetAllDashboardData")]
        public async Task<IActionResult> GetAllDashboardData(TotalInfoVm data)
        {
            try
            {
                var result = await _dashboard.GetAllDashboardData(data);
                var response = new
                {
                    status = 200,
                    message = "Success",
                    data = result
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    status = 500,
                    message = ex.Message
                };
                return StatusCode(500, errorResponse);
            }
        }

        [HttpGet("GetAllDashboardDoctorData")]
        public async Task<IActionResult> GetAllDashboardDoctorData()
        {
            try
            {
                var result = await _dashboard.GetAllDashboardDoctorData();
                var response = new
                {
                    status = 200,
                    message = "Success",
                    data = result
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    status = 500,
                    message = ex.Message
                };
                return StatusCode(500, errorResponse);
            }
        }

        [HttpPost("ProcessCSV")]
        public async Task<IActionResult> ReadCSV()
        {
            try
            {
                // Read all lines from the CSV file
                var lines = System.IO.File.ReadAllLines("wwwroot/medicine.csv");
                if (lines.Length < 2)
                {
                    return BadRequest(new { status = 400, message = "CSV file is empty or invalid." });
                }

                var header = lines[0].Split(','); // Assuming the first line is the header
                var rows = lines.Skip(1).Select(line => line.Split(',')).ToList();

                // Define column indices (adjust based on your CSV file)
                int idIndex = Array.IndexOf(header, "brand id");
                int nameIndex = Array.IndexOf(header, "brand name");
                int typeNameIndex = Array.IndexOf(header, "type");
                int dosageformIndex = Array.IndexOf(header, "dosage form");
                int genericIndex = Array.IndexOf(header, "generic");
                int strengthIndex = Array.IndexOf(header, "strength");
                int manufacturerIndex = Array.IndexOf(header, "manufacturer");
                int packagecontainerIndex = Array.IndexOf(header, "package container");
                int PackageSizeIndex = Array.IndexOf(header, "Package Size");


                // Validate header columns
                if (idIndex == -1 || nameIndex == -1 || typeNameIndex == -1 || dosageformIndex == -1 || genericIndex == -1 || strengthIndex == -1 || manufacturerIndex == -1 || packagecontainerIndex == -1 || PackageSizeIndex == -1)
                {
                    return BadRequest(new { status = 400, message = "CSV file does not contain required headers." });
                }


                // Step 2: Create TblType
                var tblType = rows
                    .Select(row => row[typeNameIndex])
                    .Distinct()
                    .Select((name, index) => new { Id = Guid.NewGuid(), Name = name })
                    .ToList();
                // Step 2: Create TblType
                var tblDosage = rows
                    .Select(row => row[dosageformIndex])
                    .Distinct()
                    .Select((name, index) => new { Id = Guid.NewGuid(), Name = name })
                    .ToList();
                // Step 2: Create TblType
                var tblGeneric = rows
                    .Select(row => row[genericIndex])
                    .Distinct()
                    .Select((name, index) => new { Id = Guid.NewGuid(), Name = name })
                    .ToList();
                // Step 2: Create TblType
                var tblManufacturer = rows
                    .Select(row => row[manufacturerIndex])
                    .Distinct()
                    .Select((name, index) => new { Id = Guid.NewGuid(), Name = name })
                    .ToList();


                // Step 3: Create TblMedicine
                var tblMedicine = rows.Select(row =>
            {

                var typeId = tblType.First(t => t.Name == row[typeNameIndex]).Id;
                var dosageId = tblDosage.First(t => t.Name == row[dosageformIndex]).Id;
                var genericId = tblGeneric.First(t => t.Name == row[genericIndex]).Id;
                var ManufacturerId = tblManufacturer.First(t => t.Name == row[manufacturerIndex]).Id;
                return new
                {
                    Id = Guid.NewGuid(),
                    Name = row[nameIndex],
                    TypeId = typeId,
                    DosageId = dosageId,
                    GenericId = genericId,
                    ManufacturerId = ManufacturerId,
                    PackageContainer = row[packagecontainerIndex],
                    PackageSize = row[PackageSizeIndex],
                    Strength = row[strengthIndex]

                };
            }).ToList();

                // Prepare response data
                //var responseData = new
                //{
                //    TblType = tblType,
                //    TblMedicine = tblMedicine
                //};

                var responseMedicineDataAsJSON = JsonConvert.SerializeObject(tblMedicine, Formatting.Indented);
                var responseTypeDataAsJSON = JsonConvert.SerializeObject(tblType, Formatting.Indented);
                var responseGenericDataAsJSON = JsonConvert.SerializeObject(tblGeneric, Formatting.Indented);
                var responseDosageDataAsJSON = JsonConvert.SerializeObject(tblDosage, Formatting.Indented);
                var responseManufacturerDataAsJSON = JsonConvert.SerializeObject(tblManufacturer, Formatting.Indented);


                var isSuccess = _dashboard.InsertDatasToTable(responseMedicineDataAsJSON, responseTypeDataAsJSON, responseGenericDataAsJSON, responseDosageDataAsJSON, responseManufacturerDataAsJSON);

                return Ok(new
                {
                    status = 200,
                    message = "CSV processed successfully",
                    data = isSuccess
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    status = 500,
                    message = "An error occurred while processing the CSV file.",
                    error = ex.Message
                });
            }
        }



    }
}
