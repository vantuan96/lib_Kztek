using System;
namespace eazy_library.Models
{
    public class HR_ConfigModel
    {
        public string HourStart { get; set; } //Giờ bắt đầu làm vd: 8:00

        public string HourEnd { get; set; } //Giờ kết thúc làm vd: 17:00

        public int Rest { get; set; } //Số giờ nghỉ trưa

        public int PenaltyUnder15 { get; set; } //Mức phạt dưới 15 phút

        public int PenaltyBeyond15 { get; set; } //Mức phạt trên 15 phút
    }
}
