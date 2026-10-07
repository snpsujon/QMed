namespace QuickMedProtal.ViewModels
{
    public class DoctorVM
    {
        public string? id { get; set; } // Unique identifier, primary key
        public string? name { get; set; }
        public string? doctorNameBn { get; set; }
        public string? passedMedicalDegree { get; set; }
        public string? passedMedicalDegreeBn { get; set; }
        public string? designation { get; set; }
        public string? designationBn { get; set; }
        public string? department { get; set; }
        public string? departmentBn { get; set; }
        public string? address { get; set; }
        public string? addressBn { get; set; } // Use nchar only if fixed length is necessary
        public string? mobile { get; set; }
        public string? mobileBn { get; set; }
        public string? chemberHospital { get; set; }
        public string? chemberHospitalBn { get; set; }
        public string? chemberAddress { get; set; }
        public string? chemberAddressBn { get; set; }
        public string? phoneNumber { get; set; }
        public string? phoneBn { get; set; }
        public string? doctorPhnSL { get; set; }
        public string? doctorPhnSLBn { get; set; }
        public string? startTime { get; set; }
        public string? endTime { get; set; }
        public string? offDay { get; set; }
        public string? offDayBn { get; set; }
        public string? offDayNotes { get; set; }
        public string? offDayNotesBn { get; set; }
        public string? bmdcRegNo { get; set; }
        public string? licenseKey { get; set; }
        public string? createdBy { get; set; }
        public DateTime createdAt { get; set; }
        public string? updatedBy { get; set; }
        public DateTime? updatedAt { get; set; } // Nullable to handle scenarios where it's not updated yet
        public bool isSynced { get; set; }
    }

}

