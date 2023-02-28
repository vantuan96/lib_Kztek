using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using eazy_library.Configs;
using eazy_library.Models;

namespace eazy_library.Helpers
{
    public class StaticList
    {
        /// <summary>
        /// Danh sách loại menu
        /// </summary>
        /// <returns>List<SelectListModel></returns>
        public static List<SelectListModel> MenuType()
        {
            var list = new List<SelectListModel> {
                                        new SelectListModel { ItemValue = "0", ItemText = "App"},
                                        new SelectListModel { ItemValue = "1", ItemText = "Menu"},
                                        new SelectListModel { ItemValue = "2", ItemText = "Function"},
                                        new SelectListModel { ItemValue = "3", ItemText = "Hidden Menu"}
                                    };
            return list;
        }

        public static List<SelectListModel> GetAllUnit()
        {
            var list = new List<SelectListModel> {
                new SelectListModel { ItemValue = "Cái", ItemText = "Cái"},
                new SelectListModel { ItemValue = "Chiếc", ItemText = "Chiếc"},
                new SelectListModel { ItemValue = "Bộ", ItemText = "Bộ"},
                new SelectListModel { ItemValue = "m", ItemText = "m"},
                new SelectListModel { ItemValue = "Hệ", ItemText = "Hệ"},
                new SelectListModel { ItemValue = "TT", ItemText = "TT"},

                                    };
            return list;
        }

        public static List<SelectListModel_MenuGroup> GroupMenuList()
        {
            var list = new List<SelectListModel_MenuGroup> {
                                        new SelectListModel_MenuGroup { ItemValue = "67810176", ItemText = "Dịch vụ tòa nhà", ItemIndex = 1, ItemCode = "RS_", Icon = "/Content/Image/sy-building-icon.png", Color = "infobox-green", AreaName = "Resident", Layout = "~/Areas/Resident/Views/Shared/_Layout.cshtml", Label = "label-danger"},
                                         new SelectListModel_MenuGroup { ItemValue = "98818976", ItemText = "Kiểm soát vào ra", ItemIndex = 2, ItemCode = "AC_", Icon = "/Content/Image/access-control-icon.png", Color = "infobox-grey", AreaName = "Access", Layout = "~/Areas/Access/Views/Shared/_Layout.cshtml", Label = "label-warning"},
                                         new SelectListModel_MenuGroup { ItemValue = "12878956", ItemText = "Bãi xe thông minh", ItemIndex = 3, ItemCode = "PK_", Icon = "/Content/Image/sy-parking-icon.png", Color = "infobox-blue", AreaName = "Parking", Layout = "~/Areas/Parking/Views/Shared/_Layout.cshtml", Label = "label-success"},
                                          new SelectListModel_MenuGroup { ItemValue = "61119719", ItemText = "Tủ đồ thông minh", ItemIndex = 3, ItemCode = "LK_", Icon = "/Content/Image/iconfinder_go_locker_143845.png", Color = "infobox-red", AreaName = "Locker", Layout = "~/Areas/Locker/Views/Shared/_Layout.cshtml", Label = "label-pink"}
                                    };

            return list;
        }

        public static List<SelectListModel> SelectChoseTimeYear()
        {
            var list = new List<SelectListModel> {
                                        new SelectListModel { ItemValue = "2018", ItemText = "Năm 2018"},
                                         new SelectListModel { ItemValue = "2019", ItemText = "Năm 2019"},
                                         new SelectListModel { ItemValue = "2020", ItemText = "Năm 2020"},
                                         new SelectListModel { ItemValue = "2021", ItemText = "Năm 2021"},
                                          new SelectListModel { ItemValue = "2022", ItemText = "Năm 2022"},
                                         new SelectListModel { ItemValue = "2023", ItemText = "Năm 2023"}
                                    };
            return list;
        }

        public static List<SelectListModel> VehicleType()
        {
            var list = new List<SelectListModel> {
                                        new SelectListModel { ItemValue = "0", ItemText = "Ô tô"},
                                         new SelectListModel { ItemValue = "1", ItemText = "Xe máy"},
                                         new SelectListModel { ItemValue = "2", ItemText = "Xe đạp"},
                                         new SelectListModel { ItemValue = "3", ItemText = "Xe đạp điện"}
                                    };
            return list;
        }

        public static List<SelectListModel> HolidayMode()
        {
            var list = new List<SelectListModel> {
                                        new SelectListModel { ItemValue = "0", ItemText = "Nghỉ cả ngày"},
                                         new SelectListModel { ItemValue = "1", ItemText = "Nghỉ buổi sáng"},
                                         new SelectListModel { ItemValue = "2", ItemText = "Nghỉ buổi chiều"}
                                    };
            return list;
        }

        public static List<SelectListModel> HolidayType()
        {
            var list = new List<SelectListModel> {
                                        new SelectListModel { ItemValue = "0", ItemText = "Nghỉ 100% lương"},
                                         new SelectListModel { ItemValue = "1", ItemText = "Nghỉ phép"},
                                         new SelectListModel { ItemValue = "2", ItemText = "Nghỉ không lương"},
                                          new SelectListModel { ItemValue = "3", ItemText = "Nghỉ bảo hiểm"},
                                         new SelectListModel { ItemValue = "4", ItemText = "Nghỉ 70% lương"},
                                         new SelectListModel { ItemValue = "5", ItemText = "Nghỉ phép năm"}
                                    };
            return list;
        }

        public static List<SelectListModel> HolidayReason()
        {
            var list = new List<SelectListModel> {
                                        new SelectListModel { ItemValue = "0", ItemText = "Nghỉ phép"},
                                         new SelectListModel { ItemValue = "1", ItemText = "Nghỉ hiếu hỉ"},
                                         new SelectListModel { ItemValue = "2", ItemText = "Nghỉ khám thai"},
                                          new SelectListModel { ItemValue = "3", ItemText = "Đi họp"},
                                         new SelectListModel { ItemValue = "4", ItemText = "Nghỉ thai sản"},
                                         new SelectListModel { ItemValue = "5", ItemText = "Nghỉ vô lý do"}
                                    };
            return list;
        }

        public static async Task<List<SelectListModel>> FormulationList()
        {
            var list = new List<SelectListModel> {
                                        new SelectListModel { ItemValue = "0", ItemText = await LanguageHelper.GetLanguageText("STATICLIST:TURN") },
                                         new SelectListModel { ItemValue = "1", ItemText = await LanguageHelper.GetLanguageText("STATICLIST:BLOCK")},
                                         new SelectListModel { ItemValue = "2", ItemText = await LanguageHelper.GetLanguageText("STATICLIST:PERIODTIME")}
                                    };
            return list;
        }

        public static async Task<List<SelectListModel>> GetCardType()
        {
            var list = new List<SelectListModel> {
                                        new SelectListModel { ItemValue = "0", ItemText = await LanguageHelper.GetLanguageText("STATICLIST:MONTHLYTICKET")},
                                         new SelectListModel { ItemValue = "1", ItemText = await LanguageHelper.GetLanguageText("STATICLIST:TICKETEACHTIME")},
                                         new SelectListModel { ItemValue = "2", ItemText = await LanguageHelper.GetLanguageText("STATICLIST:FREETICKET")}
                                    };
            return list;

        }


        public static async Task<List<SelectListModel>> CardStatus()
        {

            var list = new List<SelectListModel> {
                                         new SelectListModel { ItemValue = "", ItemText = await LanguageHelper.GetLanguageText("STATICLIST:DEFAULT")},
                                         new SelectListModel { ItemValue = "0", ItemText = await LanguageHelper.GetLanguageText("STATICLIST:CARDACTIVE")},
                                         new SelectListModel { ItemValue = "1", ItemText = await LanguageHelper.GetLanguageText("STATICLIST:CARDINACTIVE")},
                                    };
            return list;
        }

        public static List<SelectListModel_Communication> Communication1()
        {
            return new List<SelectListModel_Communication>
            {
                new SelectListModel_Communication {ItemValue = 1, ItemText = "TCP/IP"},
                new SelectListModel_Communication {ItemValue = 0, ItemText = "RS232/485/422"}
            };
        }

        public static List<SelectListModel> LineTypes2()
        {
            return new List<SelectListModel>
            {
                new  SelectListModel{ ItemValue = "", ItemText = "-- Chọn loại"},
                new  SelectListModel{ ItemValue = "0", ItemText = "IDTECK"},
                new  SelectListModel{ ItemValue = "1", ItemText = "Honeywell SY-MSA30/60L"},
                new  SelectListModel{ ItemValue = "2", ItemText = "Honeywell Nstar"},
                new  SelectListModel{ ItemValue = "3", ItemText = "Pegasus PP-3760"},
                new  SelectListModel{ ItemValue = "4", ItemText = "Pegasus PP-6750"},
                new  SelectListModel{ ItemValue = "5", ItemText = "Pegasus PFP-3700"},
                new  SelectListModel{ ItemValue = "6", ItemText = "FINGERTEC"},
                new  SelectListModel{ ItemValue = "7", ItemText = "DS3000"},
                new  SelectListModel{ ItemValue = "8", ItemText = "CS3000"},
                new  SelectListModel{ ItemValue = "9", ItemText = "RCP4000"},
                new  SelectListModel{ ItemValue = "10", ItemText = "PEGASUS PB7/PT3"},
                new  SelectListModel{ ItemValue = "11", ItemText = "PEGASUS PB5"},
                new  SelectListModel{ ItemValue = "12", ItemText = "IDTECK (006)"},
                new  SelectListModel{ ItemValue = "13", ItemText = "IDTECK (iTDC)"},
                new  SelectListModel{ ItemValue = "14", ItemText = "IDTECK (iMDC)"},
                new  SelectListModel{ ItemValue = "15", ItemText = "IDTECK (Elevator384)"},
                new  SelectListModel{ ItemValue = "16", ItemText = "Promax - FAT810W Kanteen"},
                new  SelectListModel{ ItemValue = "17", ItemText = "Promax - AC908"},
                new  SelectListModel{ ItemValue = "18", ItemText = "HAEIN S&amp;S"},
                new  SelectListModel{ ItemValue = "19", ItemText = "Promax - PCR310U"},
                new  SelectListModel{ ItemValue = "20", ItemText = "NetPOS Client MDB"},
                new  SelectListModel{ ItemValue = "21", ItemText = "NetPOS Client SERVER"},
                new  SelectListModel{ ItemValue = "22", ItemText = "Promax - FAT810W Parking"},
                new  SelectListModel{ ItemValue = "23", ItemText = "Promax - FAT810W Vending Machine"},
                new  SelectListModel{ ItemValue = "24", ItemText = "Pegasus - PP-110/PP-5210/PUA-310"},
                new  SelectListModel{ ItemValue = "25", ItemText = "Futech SC100"},
                new  SelectListModel{ ItemValue = "26", ItemText = "Honeywell HSR900"},
                new  SelectListModel{ ItemValue = "27", ItemText = "AC9xxPCR"},
                new  SelectListModel{ ItemValue = "28", ItemText = "E02.NET"},
                new  SelectListModel{ ItemValue = "29", ItemText = "Futech SC101"},
                new  SelectListModel{ ItemValue = "30", ItemText = "Futech SC100FPT"},
                new  SelectListModel{ ItemValue = "31", ItemText = "Futech SC100LANCASTER"},
                new  SelectListModel{ ItemValue = "32", ItemText = "Futech FUCM100"},
                new  SelectListModel{ ItemValue = "33", ItemText = "IDTECK 8 Number"},
                new  SelectListModel{ ItemValue = "34", ItemText = "E01 RS485"},
                new  SelectListModel{ ItemValue = "35", ItemText = "E02.NET Card Int"},
                new  SelectListModel{ ItemValue = "36", ItemText = "FUPC100"},
                new  SelectListModel{ ItemValue = "37", ItemText = "E02.NET Mifare"},
                new  SelectListModel{ ItemValue = "38", ItemText = "SOYAL"},
                new  SelectListModel{ ItemValue = "39", ItemText = "E02.NET Mifare SR30"},
                new  SelectListModel{ ItemValue = "40", ItemText = "Ingressus"},
                new  SelectListModel{ ItemValue = "41", ItemText = "E01 RS485 V2"},
                new  SelectListModel{ ItemValue = "42", ItemText = "Ingressus Mifare"},
                new  SelectListModel{ ItemValue = "43", ItemText = "FAT810WDispenser"},
                 new  SelectListModel{ ItemValue = "44", ItemText = "FUCMHID100"},
                new  SelectListModel{ ItemValue = "45", ItemText = "USB Mifare"},
                new  SelectListModel{ ItemValue = "46", ItemText = "USB Proximity"},

                new  SelectListModel{ ItemValue = "47", ItemText = "IDTECKSR30"},
                new  SelectListModel{ ItemValue = "48", ItemText = "E02QRCode"},
                new  SelectListModel{ ItemValue = "49", ItemText = "E04.NET"},
                new  SelectListModel{ ItemValue = "50", ItemText = "E04.NET Mifare"},
                new  SelectListModel{ ItemValue = "51", ItemText = "E05.NET"},
                new  SelectListModel{ ItemValue = "52", ItemText = "KZ-MFC01.NET"},
                new  SelectListModel{ ItemValue = "53", ItemText = "E02_FPT"},
                new  SelectListModel{ ItemValue = "54", ItemText = "E05.NET Mifare"},
                new  SelectListModel{ ItemValue = "55", ItemText = "IDTECK Mifare"}
            };
        }

        public static List<SelectListModel> GetAllContry()
        {
            var list = new List<SelectListModel> {
               new  SelectListModel{ ItemValue = "Afghanistan", ItemText = "Afghanistan"},
               new  SelectListModel{ ItemValue = "Åland Islands", ItemText = "Åland Islands"},
               new  SelectListModel{ ItemValue = "Albania", ItemText = "Albania"},
               new  SelectListModel{ ItemValue = "American Samoa", ItemText = "American Samoa"},
               new  SelectListModel{ ItemValue = "Andorra", ItemText = "Andorra"},
               new  SelectListModel{ ItemValue = "Angola", ItemText = "Angola"},
               new  SelectListModel{ ItemValue = "Anguilla", ItemText = "Anguilla"},
               new  SelectListModel{ ItemValue = "Antarctica", ItemText = "Antarctica"},
               new  SelectListModel{ ItemValue = "Antigua and Barbuda", ItemText = "Antigua and Barbuda"},
               new  SelectListModel{ ItemValue = "Argentina", ItemText = "Argentina"},
               new  SelectListModel{ ItemValue = "Aruba", ItemText = "Aruba"},
               new  SelectListModel{ ItemValue = "Austria", ItemText = "Austria"},
               new  SelectListModel{ ItemValue = "Azerbaijan", ItemText = "Azerbaijan"},
               new  SelectListModel{ ItemValue = "Bahamas", ItemText = "Bahamas"},
               new  SelectListModel{ ItemValue = "Bahrain", ItemText = "Bahrain"},
               new  SelectListModel{ ItemValue = "Bangladesh", ItemText = "Bangladesh"},
               new  SelectListModel{ ItemValue = "Barbados", ItemText = "Barbados"},
               new  SelectListModel{ ItemValue = "Belarus", ItemText = "Belarus"},
               new  SelectListModel{ ItemValue = "Belgium", ItemText = "Belgium"},
               new  SelectListModel{ ItemValue = "Belize", ItemText = "Belize"},
               new  SelectListModel{ ItemValue = "Benin", ItemText = "Benin"},
               new  SelectListModel{ ItemValue = "Bermuda", ItemText = "Bermuda"},
               new  SelectListModel{ ItemValue = "Bhutan", ItemText = "Bhutan"},
               new  SelectListModel{ ItemValue = "Bolivia", ItemText = "Bolivia"},
               new  SelectListModel{ ItemValue = "Bosnia and Herzegovina", ItemText = "Bosnia and Herzegovina"},
               new  SelectListModel{ ItemValue = "Botswana", ItemText = "Botswana"},
              new  SelectListModel{ ItemValue = "Bouvet Island", ItemText = "Bouvet Island"},
               new  SelectListModel{ ItemValue = "Brazil", ItemText = "Brazil"},
               new  SelectListModel{ ItemValue = "British Indian Ocean Territory", ItemText = "British Indian Ocean Territory"},
               new  SelectListModel{ ItemValue = "Brunei Darussalam", ItemText = "Brunei Darussalam"},
               new  SelectListModel{ ItemValue = "Bulgaria", ItemText = "Bulgaria"},
               new  SelectListModel{ ItemValue = "Burkina Faso", ItemText = "Burkina Faso"},
               new  SelectListModel{ ItemValue = "Burundi", ItemText = "Burundi"},
               new  SelectListModel{ ItemValue = "Cambodia", ItemText = "Cambodia"},
               new  SelectListModel{ ItemValue = "Cameroon", ItemText = "Cameroon"},
               new  SelectListModel{ ItemValue = "Canada", ItemText = "Canada"},
               new  SelectListModel{ ItemValue = "Cape Verde", ItemText = "Cape Verde"},
               new  SelectListModel{ ItemValue = "Cayman Islands", ItemText = "Cayman Islands"},
               new  SelectListModel{ ItemValue = "Central African Republic", ItemText = "Central African Republic"},
               new  SelectListModel{ ItemValue = "Chad", ItemText = "Chad"},
               new  SelectListModel{ ItemValue = "Chile", ItemText = "Chile"},
               new  SelectListModel{ ItemValue = "China", ItemText = "China"},
               new  SelectListModel{ ItemValue = "Christmas Island", ItemText = "Christmas Island"},
               new  SelectListModel{ ItemValue = "Cocos (Keeling) Islands", ItemText = "Cocos (Keeling) Islands"},
               new  SelectListModel{ ItemValue = "Colombia", ItemText = "Colombia"},
               new  SelectListModel{ ItemValue = "Comoros", ItemText = "Comoros"},
               new  SelectListModel{ ItemValue = "Congo", ItemText = "Congo"},
               new  SelectListModel{ ItemValue = "Congo, The Democratic Republic of the", ItemText = "Congo, The Democratic Republic of the"},
               new  SelectListModel{ ItemValue = "Cook Islands", ItemText = "Cook Islands"},
               new  SelectListModel{ ItemValue = "Costa Rica", ItemText = "Costa Rica"},
               new  SelectListModel{ ItemValue = "Cote D'Ivoire", ItemText = "Cote D'Ivoire"},
               new  SelectListModel{ ItemValue = "Croatia", ItemText = "Croatia"},
               new  SelectListModel{ ItemValue = "Cuba", ItemText = "Cuba"},
               new  SelectListModel{ ItemValue = "Cyprus", ItemText = "Cyprus"},
               new  SelectListModel{ ItemValue = "Czech Republic", ItemText = "Czech Republic"},
               new  SelectListModel{ ItemValue = "Denmark", ItemText = "Denmark"},
               new  SelectListModel{ ItemValue = "Djibouti", ItemText = "Djibouti"},
               new  SelectListModel{ ItemValue = "Dominica", ItemText = "Dominica"},
               new  SelectListModel{ ItemValue = "Dominican Republic", ItemText = "Dominican Republic"},
               new  SelectListModel{ ItemValue = "Ecuador", ItemText = "Ecuador"},
               new  SelectListModel{ ItemValue = "Egypt", ItemText = "Egypt"},
               new  SelectListModel{ ItemValue = "El Salvador", ItemText = "El Salvador"},
               new  SelectListModel{ ItemValue = "Equatorial Guinea", ItemText = "Equatorial Guinea"},
               new  SelectListModel{ ItemValue = "Eritrea", ItemText = "Eritrea"},
               new  SelectListModel{ ItemValue = "Estonia", ItemText = "Estonia"},
               new  SelectListModel { ItemText = "Ethiopia",ItemValue = "Ethiopia" },
               new  SelectListModel { ItemText = "Falkland Islands (Malvinas)",ItemValue = "Falkland Islands (Malvinas)" },
               new SelectListModel { ItemText = "Faroe Islands",ItemValue = "Faroe Islands" },
               new SelectListModel { ItemText = "Fiji",ItemValue = "Fiji" },
               new SelectListModel { ItemText = "Finland",ItemValue = "Finland" },
               new SelectListModel { ItemText = "France",ItemValue = "France" },
               new SelectListModel { ItemText = "French Guiana",ItemValue = "French Guiana" },
               new SelectListModel { ItemText = "French Polynesia",ItemValue = "French Polynesia" },
               new SelectListModel { ItemText = "French Southern Territories",ItemValue = "French Southern Territories" },
               new SelectListModel { ItemText = "Gabon",ItemValue = "Gabon" },
               new SelectListModel { ItemText = "Gambia",ItemValue = "Gambia" },
               new SelectListModel { ItemText = "Georgia",ItemValue = "Georgia" },
               new SelectListModel { ItemText = "Germany",ItemValue = "Germany" },
               new SelectListModel { ItemText = "Ghana",ItemValue = "Ghana" },
               new SelectListModel { ItemText = "Gibraltar",ItemValue = "Gibraltar" },
               new SelectListModel { ItemText = "Greece",ItemValue = "Greece" },
               new SelectListModel { ItemText = "Greenland",ItemValue = "Greenland" },
               new SelectListModel { ItemText = "Grenada",ItemValue = "Grenada" },
               new SelectListModel { ItemText = "Guadeloupe",ItemValue = "Guadeloupe" },
               new SelectListModel { ItemText = "Guam",ItemValue = "Guam" },
               new SelectListModel { ItemText = "Guatemala",ItemValue = "Guatemala" },
               new SelectListModel { ItemText = "Guernsey",ItemValue = "Guernsey" },
               new SelectListModel { ItemText = "Guinea",ItemValue = "Guinea" },
               new SelectListModel { ItemText = "Guinea-Bissau",ItemValue = "Guinea-Bissau" },
               new SelectListModel { ItemText = "Guyana",ItemValue = "Guyana" },
               new SelectListModel { ItemText = "Haiti",ItemValue = "Haiti" },
               new SelectListModel { ItemText = "Heard Island and Mcdonald Islands",ItemValue = "Heard Island and Mcdonald Islands" },
               new SelectListModel { ItemText = "Holy See (Vatican City State)",ItemValue = "Holy See (Vatican City State)" },
               new SelectListModel { ItemText = "Honduras",ItemValue = "Honduras" },
               new SelectListModel { ItemText = "Hong Kong",ItemValue = "Hong Kong" },
               new SelectListModel { ItemText = "Hungary",ItemValue = "Hungary" },
               new SelectListModel { ItemText = "Iceland",ItemValue = "Iceland" },
               new SelectListModel { ItemText = "India",ItemValue = "India" },
               new SelectListModel { ItemText = "Indonesia",ItemValue = "Indonesia" },
               new SelectListModel { ItemText = "Iran, Islamic Republic Of",ItemValue = "Iran, Islamic Republic Of" },
               new SelectListModel { ItemText = "Iraq",ItemValue = "Iraq" },
               new SelectListModel { ItemText = "Ireland",ItemValue = "Ireland" },
               new SelectListModel { ItemText = "Isle of Man",ItemValue = "Isle of Man" },
               new SelectListModel { ItemText = "Israel",ItemValue = "Israel" },
               new SelectListModel { ItemText = "Italy",ItemValue = "Italy" },
               new SelectListModel { ItemText = "Jamaica",ItemValue = "Jamaica" },
               new SelectListModel { ItemText = "Japan",ItemValue = "Japan" },
               new SelectListModel { ItemText = "Jersey",ItemValue = "Jersey" },
               new SelectListModel { ItemText = "Jordan",ItemValue = "Jordan" },
               new SelectListModel { ItemText = "Kazakhstan",ItemValue = "Kazakhstan" },
               new SelectListModel { ItemText = "Kenya",ItemValue = "Kenya" },
               new SelectListModel { ItemText = "Kiribati",ItemValue = "Kiribati" },
               new SelectListModel { ItemText = "Korea, Democratic People'S Republic of",ItemValue = "Korea, Democratic People'S Republic of" },
               new SelectListModel { ItemText = "Korea, Republic of",ItemValue = "Korea, Republic of" },
               new SelectListModel { ItemText = "Kuwait",ItemValue = "Kuwait" },
               new SelectListModel { ItemText = "Kyrgyzstan",ItemValue = "Kyrgyzstan" },
               new SelectListModel { ItemText = "Lao People'S Democratic Republic",ItemValue = "Lao People'S Democratic Republic" },
               new SelectListModel { ItemText = "Latvia",ItemValue = "Latvia" },
               new SelectListModel { ItemText = "Lebanon",ItemValue = "Lebanon" },
               new SelectListModel { ItemText = "Lesotho",ItemValue = "Lesotho" },
               new SelectListModel { ItemText = "Liberia",ItemValue = "Liberia" },
               new SelectListModel { ItemText = "Libyan Arab Jamahiriya",ItemValue = "Libyan Arab Jamahiriya" },
               new SelectListModel { ItemText = "Liechtenstein",ItemValue = "Liechtenstein" },
               new SelectListModel { ItemText = "Lithuania",ItemValue = "Lithuania" },
               new SelectListModel { ItemText = "Luxembourg",ItemValue = "Luxembourg" },
               new SelectListModel { ItemText = "Macao",ItemValue = "Macao" },
               new SelectListModel { ItemText = "Macedonia, The Former Yugoslav Republic of",ItemValue = "Macedonia, The Former Yugoslav Republic of" },
               new SelectListModel { ItemText = "Madagascar",ItemValue = "Madagascar" },
               new SelectListModel { ItemText = "Malawi",ItemValue = "Malawi" },
               new  SelectListModel { ItemText = "Malaysia",ItemValue = "Malaysia" },
               new SelectListModel { ItemText = "Maldives",ItemValue = "Maldives" },
               new SelectListModel { ItemText = "Mali",ItemValue = "Mali" },
               new SelectListModel { ItemText = "Malta",ItemValue = "Malta" },
               new SelectListModel { ItemText = "Marshall Islands",ItemValue = "Marshall Islands" },
               new SelectListModel { ItemText = "Martinique",ItemValue = "Martinique" },
               new SelectListModel { ItemText = "Mauritania",ItemValue = "Mauritania" },
               new SelectListModel { ItemText = "Mauritius",ItemValue = "Mauritius" },
               new SelectListModel { ItemText = "Mayotte",ItemValue = "Mayotte" },
               new SelectListModel { ItemText = "Mexico",ItemValue = "Mexico" },
               new SelectListModel { ItemText = "Micronesia, Federated States of",ItemValue = "Micronesia, Federated States of" },
               new SelectListModel { ItemText = "Moldova, Republic of",ItemValue = "Moldova, Republic of" },
               new SelectListModel { ItemText = "Monaco",ItemValue = "Monaco" },
               new SelectListModel { ItemText = "Mongolia",ItemValue = "Mongolia" },
               new SelectListModel { ItemText = "Montserrat",ItemValue = "Montserrat" },
               new SelectListModel { ItemText = "Morocco",ItemValue = "Morocco" },
               new SelectListModel { ItemText = "Mozambique",ItemValue = "Mozambique" },
               new SelectListModel { ItemText = "Myanmar",ItemValue = "Myanmar" },
               new SelectListModel { ItemText = "Namibia",ItemValue = "Namibia" },
               new SelectListModel { ItemText = "Nauru",ItemValue = "Nauru" },
               new SelectListModel { ItemText = "Nepal",ItemValue = "Nepal" },
               new SelectListModel { ItemText = "Netherlands",ItemValue = "Netherlands" },
               new SelectListModel { ItemText = "Netherlands Antilles",ItemValue = "Netherlands Antilles" },
               new SelectListModel { ItemText = "New Caledonia",ItemValue = "New Caledonia" },
               new SelectListModel { ItemText = "New Zealand",ItemValue = "New Zealand" },
               new SelectListModel { ItemText = "Nicaragua",ItemValue = "Nicaragua" },
               new SelectListModel { ItemText = "Niger",ItemValue = "Niger" },
               new SelectListModel { ItemText = "Nigeria",ItemValue = "Nigeria" },
               new SelectListModel { ItemText = "Niue",ItemValue = "Niue" },
               new SelectListModel { ItemText = "Norfolk Island",ItemValue = "Norfolk Island" },
               new SelectListModel { ItemText = "Northern Mariana Islands",ItemValue = "Northern Mariana Islands" },
               new SelectListModel { ItemText = "Norway",ItemValue = "Norway" },
               new SelectListModel { ItemText = "Oman",ItemValue = "Oman" },
               new SelectListModel { ItemText = "Pakistan",ItemValue = "Pakistan" },
               new SelectListModel { ItemText = "Palau",ItemValue = "Palau" },
               new SelectListModel { ItemText = "Palestinian Territory, Occupied",ItemValue = "Palestinian Territory, Occupied" },
               new SelectListModel { ItemText = "Panama",ItemValue = "Panama" },
               new SelectListModel { ItemText = "Papua New Guinea",ItemValue = "Papua New Guinea" },
               new SelectListModel { ItemText = "Paraguay",ItemValue = "Paraguay" },
               new SelectListModel { ItemText = "Peru",ItemValue = "Peru" },
               new SelectListModel { ItemText = "Philippines",ItemValue = "Philippines" },
               new SelectListModel { ItemText = "Pitcairn",ItemValue = "Pitcairn" },
               new SelectListModel { ItemText = "Poland",ItemValue = "Poland" },
               new SelectListModel { ItemText = "Portugal",ItemValue = "Portugal" },
               new SelectListModel { ItemText = "Puerto Rico",ItemValue = "Puerto Rico" },
               new SelectListModel { ItemText = "Qatar",ItemValue = "Qatar" },
               new SelectListModel { ItemText = "Reunion",ItemValue = "Reunion" },
               new SelectListModel { ItemText = "Romania",ItemValue = "Romania" },
               new SelectListModel { ItemText = "Russian Federation",ItemValue = "Russian Federation" },
               new SelectListModel { ItemText = "RWANDA",ItemValue = "RWANDA" },
               new SelectListModel { ItemText = "Saint Helena",ItemValue = "Saint Helena" },
               new SelectListModel { ItemText = "Saint Kitts and Nevis",ItemValue = "Saint Kitts and Nevis" },
               new SelectListModel { ItemText = "Saint Lucia",ItemValue = "Saint Lucia" },
               new SelectListModel { ItemText = "Saint Pierre and Miquelon",ItemValue = "Saint Pierre and Miquelon" },
               new SelectListModel { ItemText = "Saint Vincent and the Grenadines",ItemValue = "Saint Vincent and the Grenadines" },
               new SelectListModel { ItemText = "Samoa",ItemValue = "Samoa" },
               new SelectListModel { ItemText = "San Marino",ItemValue = "San Marino" },
               new SelectListModel { ItemText = "Sao Tome and Principe",ItemValue = "Sao Tome and Principe" },
               new SelectListModel { ItemText = "Saudi Arabia",ItemValue = "Saudi Arabia" },
               new SelectListModel { ItemText = "Senegal",ItemValue = "Senegal" },
               new SelectListModel { ItemText = "Serbia and Montenegro",ItemValue = "Serbia and Montenegro" },
               new SelectListModel { ItemText = "Seychelles",ItemValue = "Seychelles" },
               new SelectListModel { ItemText = "Sierra Leone",ItemValue = "Sierra Leone" },
               new SelectListModel { ItemText = "Singapore",ItemValue = "Singapore" },
               new SelectListModel { ItemText = "Slovakia",ItemValue = "Slovakia" },
               new SelectListModel { ItemText = "Slovenia",ItemValue = "Slovenia" },
               new SelectListModel { ItemText = "Solomon Islands",ItemValue = "Solomon Islands" },
               new SelectListModel { ItemText = "Somalia",ItemValue = "Somalia" },
               new SelectListModel { ItemText = "South Africa",ItemValue = "South Africa" },
               new SelectListModel { ItemText = "South Georgia and the South Sandwich Islands",ItemValue = "South Georgia and the South Sandwich Islands" },
               new SelectListModel { ItemText = "Spain",ItemValue = "Spain" },
               new SelectListModel { ItemText = "Sri Lanka",ItemValue = "Sri Lanka" },
               new SelectListModel { ItemText = "Sudan",ItemValue = "Sudan" },
               new SelectListModel { ItemText = "Suriname",ItemValue = "Suriname" },
               new SelectListModel { ItemText = "Svalbard and Jan Mayen",ItemValue = "Svalbard and Jan Mayen" },
               new SelectListModel { ItemText = "Swaziland",ItemValue = "Swaziland" },
               new SelectListModel { ItemText = "Sweden",ItemValue = "Sweden" },
               new SelectListModel { ItemText = "Switzerland",ItemValue = "Switzerland" },
               new SelectListModel { ItemText = "Syrian Arab Republic",ItemValue = "Syrian Arab Republic" },
               new SelectListModel { ItemText = "Taiwan, Province of China",ItemValue = "Taiwan, Province of China" },
               new SelectListModel { ItemText = "Tajikistan",ItemValue = "Tajikistan" },
               new SelectListModel { ItemText = "Tanzania, United Republic of",ItemValue = "Tanzania, United Republic of" },
               new SelectListModel { ItemText = "Thailand",ItemValue = "Thailand" },
               new SelectListModel { ItemText = "Timor-Leste",ItemValue = "Timor-Leste" },
               new SelectListModel { ItemText = "Togo",ItemValue = "Togo" },
               new SelectListModel { ItemText = "Tokelau",ItemValue = "Tokelau" },
               new SelectListModel { ItemText = "Tonga",ItemValue = "Tonga" },
               new SelectListModel { ItemText = "Trinidad and Tobago",ItemValue = "Trinidad and Tobago" },
               new SelectListModel { ItemText = "Tunisia",ItemValue = "Tunisia" },
                new SelectListModel { ItemText = "Turkey",ItemValue = "Turkey" },
               new SelectListModel { ItemText = "Turkmenistan",ItemValue = "Turkmenistan" },
               new SelectListModel { ItemText = "Turks and Caicos Islands",ItemValue = "Turks and Caicos Islands" },
               new SelectListModel { ItemText = "Tuvalu",ItemValue = "Tuvalu" },
               new SelectListModel { ItemText = "Uganda",ItemValue = "Uganda" },
               new SelectListModel { ItemText = "Ukraine",ItemValue = "Ukraine" },
               new SelectListModel { ItemText = "United Arab Emirates",ItemValue = "United Arab Emirates" },
               new SelectListModel { ItemText = "United Kingdom",ItemValue = "United Kingdom" },
               new SelectListModel { ItemText = "United States",ItemValue = "United States" },
               new SelectListModel { ItemText = "United States Minor Outlying Islands",ItemValue = "United States Minor Outlying Islands" },
               new SelectListModel { ItemText = "Uruguay",ItemValue = "Uruguay" },
               new SelectListModel { ItemText = "Uzbekistan",ItemValue = "Uzbekistan" },
               new SelectListModel { ItemText = "Vanuatu",ItemValue = "Vanuatu" },
               new SelectListModel { ItemText = "Venezuela",ItemValue = "Venezuela" },
               new SelectListModel { ItemText = "Viet Nam",ItemValue = "Viet Nam" },
               new SelectListModel { ItemText = "Virgin Islands, British",ItemValue = "Virgin Islands, British" },
               new SelectListModel { ItemText = "Virgin Islands, U.S.",ItemValue = "Virgin Islands, U.S." },
               new SelectListModel { ItemText = "Wallis and Futuna",ItemValue = "Wallis and Futuna" },
               new SelectListModel { ItemText = "Western Sahara",ItemValue = "Western Sahara" },
               new SelectListModel { ItemText = "Yemen",ItemValue = "Yemen" },
               new SelectListModel { ItemText = "Zambia",ItemValue = "Zambia" },
               new SelectListModel { ItemText = "Zimbabwe",ItemValue = "Zimbabwe" }
                                    };

            return list;
        }


        public static List<SelectListModel_Communication> GetAllStatusPU()
        {
            var list = new List<SelectListModel_Communication> {
                                         //new SelectListModel { ItemValue = "t", ItemText = "--Lựa chọn--"},
                                        new  SelectListModel_Communication{ ItemValue = 0, ItemText = "Đang thực hiện"},
                                        new  SelectListModel_Communication{ ItemValue = 1, ItemText = "Đã thực hiện xong"},
                                        new  SelectListModel_Communication{ ItemValue = 2, ItemText = "Hủy bỏ"}

                                    };
            return list;
        }
        public static List<SelectListModel> TypeEventLocker()
        {
            var list = new List<SelectListModel> {
                                         //new SelectListModel { ItemValue = "t", ItemText = "--Lựa chọn--"},
                                         new  SelectListModel{ ItemValue = "1", ItemText = "Nạp cố định"},
                                         new  SelectListModel{ ItemValue = "2", ItemText = "Thẻ tức thời"},
                                         new  SelectListModel{ ItemValue = "3", ItemText = "Nhận dạng khuôn mặt"}

                                    };
            return list;
        }

        public static List<SelectListModel> ActionLockerProcess()
        {
            var list = new List<SelectListModel> {
                                         new SelectListModel { ItemValue = "t", ItemText = "--Lựa chọn--"},
                                         new SelectListModel { ItemValue = "0", ItemText = "Hủy" },
                                         new SelectListModel { ItemValue = "1", ItemText = "Nạp"},
                                         new SelectListModel { ItemValue = "2", ItemText = "Mở tủ thủ công"},
                                    };
            return list;
        }

        public static List<SelectListModel> TypeLockerProcess()
        {
            var list = new List<SelectListModel> {
                                         new SelectListModel { ItemValue = "t", ItemText = "--Lựa chọn--"},
                                         new SelectListModel { ItemValue = "1", ItemText = "Cố định" },
                                         new SelectListModel { ItemValue = "2", ItemText = "Tức thời"},
                                         new SelectListModel { ItemValue = "3", ItemText = "Nhận dạng"},
                                         new SelectListModel { ItemValue = "4", ItemText = "Mở tủ thủ công"},
                                    };
            return list;
        }

        public static List<SelectListModel> LockerEventCode()
        {
            var list = new List<SelectListModel> {
                                         new SelectListModel { ItemValue = "", ItemText = "--Lựa chọn--"},
                                         new SelectListModel { ItemValue = "1", ItemText = "Check in" },
                                         new SelectListModel { ItemValue = "2", ItemText = "Check out"},
                                    };
            return list;
        }

        public static List<SelectListModel> LockerAlarmCode()
        {
            var list = new List<SelectListModel> {
                                         new SelectListModel { ItemValue = "", ItemText = "--Lựa chọn--"},
                                         new SelectListModel { ItemValue = "1", ItemText = "Thẻ không tồn tại" },
                                         new SelectListModel { ItemValue = "2", ItemText = "Thẻ chưa đăng ký"},
                                         new SelectListModel { ItemValue = "3", ItemText = "Chưa gửi đồ"},
                                    };
            return list;
        }

        public static List<SelectListModel> TypeFee()
        {
            var list = new List<SelectListModel> {

                                         new SelectListModel { ItemValue = "1", ItemText = "Áp dụng từng thẻ" },
                                        new SelectListModel { ItemValue = "2", ItemText = "Tổng giá trị hóa đơn" },
                                         //new SelectListModel { ItemValue = "3", ItemText = "Áp dụng theo biểu phí"}
                                    };
            return list;
        }

        public static List<SelectListModel> CustomerStatusType()
        {
            var list = new List<SelectListModel> {
                                        new SelectListModel { ItemValue = "0", ItemText = "Kích hoạt"},
                                         new SelectListModel { ItemValue = "1", ItemText = "Chưa kích hoạt"}
                                    };
            return list;
        }

        public static async Task<List<SelectListModel>> AlarmCodes()
        {
            var list = new List<SelectListModel> {
                      // dự án hòa phát mandarin garden 15/7/2019 dungdt
                      //Sự kiện cảnh báo chưa có trường thông tin: "Không tồn tại trên hệ thống" => đổi tên 001 unknownCard <-> Not_exist_on_the_system
                                         new SelectListModel { ItemValue = "001", ItemText = await LanguageHelper.GetLanguageText("STATICLIST:Not_exist_on_the_system") },
                                         new SelectListModel { ItemValue = "002", ItemText = await LanguageHelper.GetLanguageText("STATICLIST:Lock")},
                                         new SelectListModel { ItemValue = "003", ItemText = await LanguageHelper.GetLanguageText("STATICLIST:Permissions")},
                                         new SelectListModel { ItemValue = "004", ItemText = await LanguageHelper.GetLanguageText("STATICLIST:InParking")},
                                         new SelectListModel { ItemValue = "005", ItemText = await LanguageHelper.GetLanguageText("STATICLIST:notInParking")},
                                         new SelectListModel { ItemValue = "006", ItemText = await LanguageHelper.GetLanguageText("STATICLIST:OpenBarrieByComputer")},
                                         new SelectListModel { ItemValue = "007", ItemText = await LanguageHelper.GetLanguageText("STATICLIST:OpenBarrieByButton")},
                                         new SelectListModel { ItemValue = "008", ItemText = await LanguageHelper.GetLanguageText("STATICLIST:EventEscapeIn")},
                                         new SelectListModel { ItemValue = "009", ItemText = await LanguageHelper.GetLanguageText("STATICLIST:eventEscapeOut")},

                                         new SelectListModel { ItemValue = "010", ItemText = await LanguageHelper.GetLanguageText("BODY:SEARCH:ExpiredCard")},

                                         new SelectListModel { ItemValue = "011", ItemText = await LanguageHelper.GetLanguageText("STATICLIST:Invalid_license_plates")},
                                         new SelectListModel { ItemValue = "012", ItemText = await LanguageHelper.GetLanguageText("STATICLIST:Black_list")},
                                         new SelectListModel { ItemValue = "013", ItemText = await LanguageHelper.GetLanguageText("STATICLIST:Lock_License_plate")},
                                         new SelectListModel { ItemValue = "014", ItemText = await LanguageHelper.GetLanguageText("STATICLIST:License_plate_expired")},
                                         new SelectListModel { ItemValue = "015", ItemText = await LanguageHelper.GetLanguageText("STATICLIST:Locked_tag_group")},
                                         new SelectListModel { ItemValue = "016", ItemText = await LanguageHelper.GetLanguageText("STATICLIST:License_plate_do_not_match")},
                                         new SelectListModel { ItemValue = "017", ItemText = await LanguageHelper.GetLanguageText("STATICLIST:Vehicles_beyond_the_magnetic_ring")},
                                    };
            return list;
        }

        public static async Task<List<SelectListModel>> FrequencyDateTypeString()
        {
            var list = new List<SelectListModel>();

            for (int i = 0; i < DateUI.FrequencyDateTypeString().Length; i++)
            {
                SelectListModel item = new SelectListModel()
                {
                    ItemValue = i.ToString(),
                    ItemText = DateUI.FrequencyDateTypeString()[i]
                };

                list.Add(item);

            }

            return list;
        }

        public static async Task<List<SelectListModel>> Action()
        {
            var list = new List<SelectListModel> {
                                         new SelectListModel { ItemValue = "", ItemText = await LanguageHelper.GetLanguageText("STATICLIST:DEFAULT")},
                                         new  SelectListModel{ ItemValue = "ADD", ItemText = await LanguageHelper.GetLanguageText("STATICLIST:ADD")},
                                         new SelectListModel { ItemValue = "RELEASE", ItemText = await LanguageHelper.GetLanguageText("STATICLIST:RELEASE")},
                                         new  SelectListModel{ ItemValue = "RETURN", ItemText = await LanguageHelper.GetLanguageText("STATICLIST:RETURN")},
                                         new SelectListModel { ItemValue = "CHANGE", ItemText = await LanguageHelper.GetLanguageText("STATICLIST:CHANGE")},
                                         new  SelectListModel{ ItemValue = "DELETE", ItemText = await LanguageHelper.GetLanguageText("STATICLIST:DELETE")},
                                         new  SelectListModel{ ItemValue = "LOCK", ItemText = await LanguageHelper.GetLanguageText("STATICLIST:LOCK")},
                                         new SelectListModel { ItemValue = "UNLOCK", ItemText =await LanguageHelper.GetLanguageText("STATICLIST:UNLOCK")},
                                         new  SelectListModel{ ItemValue = "ACTIVE", ItemText = await LanguageHelper.GetLanguageText("STATICLIST:ACTIVE")}

                                    };
            return list;
        }

        public static async Task<List<SelectListModel>> TimePeriodType()
        {
            var list = new List<SelectListModel> {
                                         new SelectListModel { ItemValue = "0", ItemText = await LanguageHelper.GetLanguageText("STATICLIST:Month") },
                                         new SelectListModel { ItemValue = "1", ItemText = await LanguageHelper.GetLanguageText("STATICLIST:Quarter") },
                                         new SelectListModel { ItemValue = "2", ItemText = await LanguageHelper.GetLanguageText("STATICLIST:Year") },
                                         new SelectListModel { ItemValue = "3", ItemText = await LanguageHelper.GetLanguageText("STATICLIST:Day") }
                                    };
            return list;
        }
        public static async Task<List<SelectListModel>> CameraTypes1()
        {

            return new List<SelectListModel> {
                                         new  SelectListModel{ ItemValue = "", ItemText = await LanguageHelper.GetLanguageText("STATICLIST:DEFAULT")},
                                         new  SelectListModel{ ItemValue = "Geovision", ItemText = "Geovision"},
                                         new  SelectListModel{ ItemValue = "Panasonic i-Pro", ItemText = "Panasonic i-Pro"},
                                         new  SelectListModel{ ItemValue = "Axis", ItemText = "Axis"},
                                         new  SelectListModel{ ItemValue = "Secus", ItemText = "Secus"},
                                         new  SelectListModel{ ItemValue = "Shany-Stream1", ItemText = "Shany-Stream1"},
                                         new  SelectListModel{ ItemValue = "Shany-Stream21", ItemText = "Shany-Stream2"},
                                         new  SelectListModel{ ItemValue = "Vivotek", ItemText = "Vivotek"},
                                         new  SelectListModel{ ItemValue = "Lilin", ItemText = "Lilin"},
                                         new  SelectListModel{ ItemValue = "Messoa", ItemText = "Messoa"},
                                         new  SelectListModel{ ItemValue = "Entrovision", ItemText = "Entrovision"},
                                         new  SelectListModel{ ItemValue = "Sony", ItemText = "Sony"},
                                         new  SelectListModel{ ItemValue = "Bosch", ItemText = "Bosch"},
                                         new  SelectListModel{ ItemValue = "Vantech", ItemText = "Vantech"},
                                         new  SelectListModel{ ItemValue = "SC330", ItemText = "SC330"},
                                         new  SelectListModel{ ItemValue = "SecusFFMPEG", ItemText = "SecusFFMPEG"},
                                         new  SelectListModel{ ItemValue = "CNB", ItemText = "CNB"},//"CNB", "HIK", "Enster", "Afidus", "Dahua", "ITX"
                                         new  SelectListModel{ ItemValue = "HIK", ItemText = "HIK"},
                                         new  SelectListModel{ ItemValue = "Enster", ItemText = "Enster"},
                                         new  SelectListModel{ ItemValue = "Afidus", ItemText = "Afidus"},
                                         new  SelectListModel{ ItemValue = "Dahua", ItemText = "Dahua"},
                                         new  SelectListModel{ ItemValue = "ITX", ItemText = "ITX"},
                                         new  SelectListModel{ ItemValue = "Hanse", ItemText = "Hanse"},
                                          new  SelectListModel{ ItemValue = "Samsung", ItemText = "Samsung"}
                                    };
        }

        public static async Task<List<SelectListModel>> StreamTypes1()
        {

            return new List<SelectListModel> {
                                         new  SelectListModel{ ItemValue = "", ItemText =  await LanguageHelper.GetLanguageText("STATICLIST:DEFAULT")},
                                         new  SelectListModel{ ItemValue = "MJPEG", ItemText = "MJPEG"},
                                         new  SelectListModel{ ItemValue = "PlayFile", ItemText = "PlayFile"},
                                         new  SelectListModel{ ItemValue = "Local Video Capture Device", ItemText = "Local Video Capture Device"},
                                         new  SelectListModel{ ItemValue = "JPEG", ItemText = "JPEG"},
                                         new  SelectListModel{ ItemValue = "MPEG4", ItemText = "MPEG4"},
                                         new  SelectListModel{ ItemValue = "H264", ItemText = "H264"},
                                         new  SelectListModel{ ItemValue = "Onvif", ItemText = "Onvif"}
                                    };
        }

        public static async Task<List<SelectListModel>> SDKs1()
        {
            return new List<SelectListModel>
            {
                new  SelectListModel{ ItemValue = "", ItemText = await LanguageHelper.GetLanguageText("STATICLIST:DEFAULT")},
                new  SelectListModel{ ItemValue = "AForgeSDK", ItemText = "AForgeSDK"},
                new  SelectListModel{ ItemValue = "AxisSDK", ItemText = "AxisSDK"},
                new  SelectListModel{ ItemValue = "GeoSDK", ItemText = "GeoSDK"},
                new  SelectListModel{ ItemValue = "ScSDK", ItemText = "ScSDK"},
                new  SelectListModel{ ItemValue = "FFMPEG", ItemText = "FFMPEG"},
                new  SelectListModel{ItemValue = "VLC", ItemText = "VLC"},
                new  SelectListModel{ItemValue = "KztekSDK", ItemText = "KztekSDK"},
            };
        }
        //dung cho iparking
        public static async Task<List<SelectListModel>> LineTypes1()
        {
            return new List<SelectListModel>
            {
                new  SelectListModel{ ItemValue = "", ItemText = await LanguageHelper.GetLanguageText("STATICLIST:DEFAULT")},
                new  SelectListModel{ ItemValue = "0", ItemText = "IDTECK"},
                new  SelectListModel{ ItemValue = "1", ItemText = "Honeywell SY-MSA30/60L"},
                new  SelectListModel{ ItemValue = "2", ItemText = "Honeywell Nstar"},
                new  SelectListModel{ ItemValue = "3", ItemText = "Pegasus PP-3760"},
                new  SelectListModel{ ItemValue = "4", ItemText = "Pegasus PP-6750"},
                new  SelectListModel{ ItemValue = "5", ItemText = "Pegasus PFP-3700"},
                new  SelectListModel{ ItemValue = "6", ItemText = "FINGERTEC"},
                new  SelectListModel{ ItemValue = "7", ItemText = "DS3000"},
                new  SelectListModel{ ItemValue = "8", ItemText = "CS3000"},
                new  SelectListModel{ ItemValue = "9", ItemText = "RCP4000"},
                new  SelectListModel{ ItemValue = "10", ItemText = "PEGASUS PB7/PT3"},
                new  SelectListModel{ ItemValue = "11", ItemText = "PEGASUS PB5"},
                new  SelectListModel{ ItemValue = "12", ItemText = "IDTECK (006)"},
                new  SelectListModel{ ItemValue = "13", ItemText = "IDTECK (iTDC)"},
                new  SelectListModel{ ItemValue = "14", ItemText = "IDTECK (iMDC)"},
                new  SelectListModel{ ItemValue = "15", ItemText = "IDTECK (Elevator384)"},
                new  SelectListModel{ ItemValue = "16", ItemText = "Promax - FAT810W Kanteen"},
                new  SelectListModel{ ItemValue = "17", ItemText = "Promax - AC908"},
                new  SelectListModel{ ItemValue = "18", ItemText = "HAEIN S&amp;S"},
                new  SelectListModel{ ItemValue = "19", ItemText = "Promax - PCR310U"},
                new  SelectListModel{ ItemValue = "20", ItemText = "NetPOS Client MDB"},
                new  SelectListModel{ ItemValue = "21", ItemText = "NetPOS Client SERVER"},
                new  SelectListModel{ ItemValue = "22", ItemText = "Promax - FAT810W Parking"},
                new  SelectListModel{ ItemValue = "23", ItemText = "Promax - FAT810W Vending Machine"},
                new  SelectListModel{ ItemValue = "24", ItemText = "Pegasus - PP-110/PP-5210/PUA-310"},
                new  SelectListModel{ ItemValue = "25", ItemText = "Futech SC100"},
                new  SelectListModel{ ItemValue = "26", ItemText = "Honeywell HSR900"},
                new  SelectListModel{ ItemValue = "27", ItemText = "AC9xxPCR"},
                new  SelectListModel{ ItemValue = "28", ItemText = "E02.NET"},
                new  SelectListModel{ ItemValue = "29", ItemText = "Futech SC101"},
                new  SelectListModel{ ItemValue = "30", ItemText = "Futech SC100FPT"},
                new  SelectListModel{ ItemValue = "31", ItemText = "Futech SC100LANCASTER"},
                new  SelectListModel{ ItemValue = "32", ItemText = "Futech FUCM100"},
                new  SelectListModel{ ItemValue = "33", ItemText = "IDTECK 8 Number"},
                new  SelectListModel{ ItemValue = "34", ItemText = "E01 RS485"},
                new  SelectListModel{ ItemValue = "35", ItemText = "E02.NET Card Int"},
                new  SelectListModel{ ItemValue = "36", ItemText = "FUPC100"},
                new  SelectListModel{ ItemValue = "37", ItemText = "E02.NET Mifare"},
                new  SelectListModel{ ItemValue = "38", ItemText = "SOYAL"},
                new  SelectListModel{ ItemValue = "39", ItemText = "E02.NET Mifare SR30"},

                new  SelectListModel{ ItemValue = "40", ItemText = "Ingressus"},
                new  SelectListModel{ ItemValue = "41", ItemText = "E01 RS485 V2"},
                new  SelectListModel{ ItemValue = "42", ItemText = "Ingressus Mifare"},
                new  SelectListModel{ ItemValue = "43", ItemText = "FAT810WDispenser"},
                new  SelectListModel{ ItemValue = "44", ItemText = "FUCMHID100"},
                new  SelectListModel{ ItemValue = "45", ItemText = "USB Mifare"},
                new  SelectListModel{ ItemValue = "46", ItemText = "USB Proximity"},

                new  SelectListModel{ ItemValue = "47", ItemText = "IDTECKSR30"},
                new  SelectListModel{ ItemValue = "48", ItemText = "E02QRCode"},
                new  SelectListModel{ ItemValue = "49", ItemText = "E04.NET"},
                new  SelectListModel{ ItemValue = "50", ItemText = "E04.NET Mifare"},
                new  SelectListModel{ ItemValue = "51", ItemText = "E05.NET"},
                new  SelectListModel{ ItemValue = "52", ItemText = "KZ-MFC01.NET"},
                new  SelectListModel{ ItemValue = "53", ItemText = "E02_FPT"},
                new  SelectListModel{ ItemValue = "54", ItemText = "E05.NET Mifare"},
                new  SelectListModel{ ItemValue = "55", ItemText = "IDTECK Mifare"}

            };
        }

        public static List<SelectListModel> ReaderTypes1()
        {
            return new List<SelectListModel>
            {
                new SelectListModel{ItemValue = "0", ItemText = "1"},
                new SelectListModel{ItemValue = "1", ItemText = "2"}
            };
        }
        public static async Task<List<SelectListModel>> LaneTypes1()
        {
            return new List<SelectListModel>
            {
                new  SelectListModel{ ItemValue = "", ItemText = await LanguageHelper.GetLanguageText("STATICLIST:DEFAULT")},
                new  SelectListModel{ ItemValue = "0", ItemText = "0." + await LanguageHelper.GetLanguageText("BODY:TABLE:IN")},
                new  SelectListModel{ ItemValue = "1", ItemText = "1." + await LanguageHelper.GetLanguageText("BODY:TABLE:OUT")},
                new  SelectListModel{ ItemValue = "2", ItemText = "2." + await LanguageHelper.GetLanguageText("BODY:TABLE:IN") +"-" + await LanguageHelper.GetLanguageText("BODY:TABLE:OUT")},
                new  SelectListModel{ ItemValue = "3", ItemText = "3."+ await LanguageHelper.GetLanguageText("BODY:TABLE:IN") +"-" + await LanguageHelper.GetLanguageText("BODY:TABLE:IN")},
                new  SelectListModel{ ItemValue = "4", ItemText = "4."+ await LanguageHelper.GetLanguageText("BODY:TABLE:OUT") +"-" + await LanguageHelper.GetLanguageText("BODY:TABLE:OUT")},
                new  SelectListModel{ ItemValue = "5", ItemText = "5."+ await LanguageHelper.GetLanguageText("BODY:TABLE:IN") +"-" + await LanguageHelper.GetLanguageText("BODY:TABLE:OUT") +"2"},
                 new  SelectListModel{ ItemValue = "6", ItemText = "6. #"},
            };
        }
        public static async Task<List<SelectListModel_Communication>> CheckBSType()
        {

            var list = new List<SelectListModel_Communication> {
                                        new SelectListModel_Communication { ItemValue = 1, ItemText = await LanguageHelper.GetLanguageText("STATICLIST:CheckPlateLevelOuts:4char")},
                                        new SelectListModel_Communication { ItemValue = 2, ItemText = await LanguageHelper.GetLanguageText("STATICLIST:CheckPlateLevelOuts:all")},
                                        new SelectListModel_Communication { ItemValue = 0, ItemText = await LanguageHelper.GetLanguageText("STATICLIST:CheckPlateLevelOuts:noCheck")},
                                        new SelectListModel_Communication { ItemValue = 3, ItemText = await LanguageHelper.GetLanguageText("STATICLIST:CheckPlateLevelOuts:noOpen")}
                                    };
            return list;
        }
        public static async Task<List<SelectListModel>> HubList1()
        {
            var list = new List<SelectListModel> {
                                        new SelectListModel { ItemValue = "", ItemText = await LanguageHelper.GetLanguageText("STATICLIST:DEFAULT")},
                                         new SelectListModel { ItemValue = "0", ItemText = await LanguageHelper.GetLanguageText("STATICLIST:HubList1:Left")},
                                         new SelectListModel { ItemValue = "1", ItemText =  await LanguageHelper.GetLanguageText("STATICLIST:HubList1:Right")},
                                         new SelectListModel { ItemValue = "2", ItemText =  await LanguageHelper.GetLanguageText("STATICLIST:HubList1:All")},
                                    };
            return list;
        }
        public static async Task<List<SelectListModel>> LEDType1()
        {
            var list = new List<SelectListModel> {
                                        new SelectListModel { ItemValue = "", ItemText = await LanguageHelper.GetLanguageText("STATICLIST:DEFAULT")},
                                         new SelectListModel { ItemValue = "1", ItemText = "DSP840"},
                                         new SelectListModel { ItemValue = "2", ItemText = "FUTECH"},
                                         new SelectListModel { ItemValue = "3", ItemText = "FAT810"},
                                         new SelectListModel { ItemValue = "4", ItemText = "FUTECH2"},
                                         new SelectListModel { ItemValue = "5", ItemText = "FUTECH2LINE"},
                                         new SelectListModel { ItemValue = "6", ItemText = "PGS_LED"},
                                         new SelectListModel { ItemValue = "7", ItemText = "ATPRO"}
                                    };
            return list;
        }

        public static List<SelectListModel> AccountStatus()
        {
            var list = new List<SelectListModel> {
                                        new SelectListModel { ItemValue = "0", ItemText = "Chờ duyệt"},
                                        new SelectListModel { ItemValue = "1", ItemText = "Hoạt động"},
                                        new SelectListModel { ItemValue = "2", ItemText = "Khóa"},
                                        new SelectListModel { ItemValue = "3", ItemText = "Dừng hoạt động"}
                                    };
            return list;
        }

        public static List<SelectListModel> ProductOrigin()
        {
            var list = new List<SelectListModel> {
                                        new SelectListModel { ItemValue = "1", ItemText = "Trong nước"},
                                        new SelectListModel { ItemValue = "2", ItemText = "Nước ngoài"},
                                    };
            return list;
        }

        public static List<SelectListModel> AttrType()
        {
            var list = new List<SelectListModel> {
                                        new SelectListModel { ItemValue = "TEXT", ItemText = "Dạng text"},
                                        new SelectListModel { ItemValue = "CHECKBOX", ItemText = "Dạng checkbox"},
                                    };
            return list;
        }

        public static List<SelectListModel> ProductStatus()
        {
            var list = new List<SelectListModel> {
                new SelectListModel { ItemValue = "", ItemText = "-- Lựa chọn trạng thái --"},
                                        new SelectListModel { ItemValue = "1", ItemText = "mới"},
                                        new SelectListModel { ItemValue = "2", ItemText = "cũ"},
                                    };
            return list;
        }

        public static List<SelectListModel_InvoiceStatus> InvoiceStatus()
        {
            var list = new List<SelectListModel_InvoiceStatus> {
                new SelectListModel_InvoiceStatus { ItemValue = "0", ItemText = "Phiếu nháp", ItemColor = "badge-secondary"},
                new SelectListModel_InvoiceStatus { ItemValue = "1", ItemText = "Chờ thanh toán", ItemColor = "badge-info"},
                new SelectListModel_InvoiceStatus { ItemValue = "2", ItemText = "Thanh toán chấp nhận", ItemColor = "badge-success"},
                new SelectListModel_InvoiceStatus { ItemValue = "3", ItemText = "Đang chuẩn bị hàng", ItemColor = "badge-warning"},
                new SelectListModel_InvoiceStatus { ItemValue = "4", ItemText = "Đã vận chuyển", ItemColor = "bgc-purple brc-purple text-white"},
                new SelectListModel_InvoiceStatus { ItemValue = "5", ItemText = "Đã giao hàng", ItemColor = "badge-success"},
                new SelectListModel_InvoiceStatus { ItemValue = "6", ItemText = "Đã hủy đơn", ItemColor = "btn-pink"},
                new SelectListModel_InvoiceStatus { ItemValue = "7", ItemText = "Đã hoàn tiền", ItemColor = "badge-danger"},
                new SelectListModel_InvoiceStatus { ItemValue = "8", ItemText = "Thanh toán bị lỗi", ItemColor = "badge-danger"},
                new SelectListModel_InvoiceStatus { ItemValue = "9", ItemText = "Đặt hàng trước (Đã thanh toán)", ItemColor = "bgc-purple brc-purple text-white"},
                new SelectListModel_InvoiceStatus { ItemValue = "10", ItemText = "Đang chờ tiền về tài khoản ngân hàng", ItemColor = "badge-info"},
                new SelectListModel_InvoiceStatus { ItemValue = "11", ItemText = "Chờ thanh toán bằng PayPal", ItemColor = "badge-info"},
                new SelectListModel_InvoiceStatus { ItemValue = "12", ItemText = "Xóa thanh toán chấp nhận", ItemColor = "badge-success"},
                new SelectListModel_InvoiceStatus { ItemValue = "13", ItemText = "Đặt hàng trước (Chưa thanh toán)", ItemColor = "bgc-purple brc-purple text-white"},
                new SelectListModel_InvoiceStatus { ItemValue = "14", ItemText = "Chờ thanh toán khi nhận hàng", ItemColor = "badge-info"},
                        };
            return list;
        }

        public static List<SelectListModel> InvoiceResult()
        {
            var list = new List<SelectListModel> {
                new SelectListModel { ItemValue = "0", ItemText = "Đang theo dõi"},
                new SelectListModel { ItemValue = "1", ItemText = "Đang chờ phản hồi báo giá"},
                new SelectListModel { ItemValue = "2", ItemText = "Đang thương thảo Hợp đồng"},
                new SelectListModel { ItemValue = "3", ItemText = "Đã ký hợp đồng"},
                new SelectListModel { ItemValue = "4", ItemText = "Thất bại"},
            };

            return list;
        }

        public static List<SelectListModel> DiscountType()
        {
            var list = new List<SelectListModel> {
                                        new SelectListModel { ItemValue = "1", ItemText = "%"},
                                        new SelectListModel { ItemValue = "2", ItemText = "VND"},
                                    };
            return list;
        }

        public static List<SelectListModel_ProjectStatus> ProjectStatus()
        {
            var list = new List<SelectListModel_ProjectStatus> {
                new SelectListModel_ProjectStatus { ItemValue = "0", ItemText = "Phiếu nháp", ItemColor = "badge-secondary", ColumnColor = "brc-default-m1", ButtonColor = "btn-outline-secondary"},
                new SelectListModel_ProjectStatus { ItemValue = "1", ItemText = "Đã báo giá", ItemColor = "badge-info", ColumnColor = "brc-info-m1", ButtonColor = "btn-outline-info"},
                new SelectListModel_ProjectStatus { ItemValue = "2", ItemText = "Đã ký", ItemColor = "badge-success", ColumnColor = "brc-success-m1", ButtonColor = "btn-outline-success"},
                        };
            return list;
        }

        public static List<SelectListModel_ProjectStatus> WorkProjectStatus()
        {
            var list = new List<SelectListModel_ProjectStatus> {
                new SelectListModel_ProjectStatus { ItemValue = "0", ItemText = "Phiếu nháp", ItemColor = "badge-secondary", ColumnColor = "brc-default-m1", ButtonColor = "btn-outline-secondary"},
                new SelectListModel_ProjectStatus { ItemValue = "1", ItemText = "Đang tiến hành", ItemColor = "badge-info", ColumnColor = "brc-info-m1", ButtonColor = "btn-outline-info"},
                new SelectListModel_ProjectStatus { ItemValue = "2", ItemText = "Hoàn thành", ItemColor = "badge-success", ColumnColor = "brc-success-m1", ButtonColor = "btn-outline-success"},
                new SelectListModel_ProjectStatus { ItemValue = "3", ItemText = "Hủy bỏ", ItemColor = "badge-danger", ColumnColor = "brc-danger-m1", ButtonColor = "btn-outline-danger"}
                        };
            return list;
        }

        public static List<SelectListModel_Kanban> KanbanStyle()
        {
            var list = new List<SelectListModel_Kanban> {
                new SelectListModel_Kanban { ItemValue = "0", ItemColor = "badge-secondary", ColumnColor = "brc-default-m1", ButtonColor = "btn-outline-secondary", ItemText = "Mặc định"},
                new SelectListModel_Kanban { ItemValue = "1", ItemColor = "badge-info", ColumnColor = "brc-info-m1", ButtonColor = "btn-outline-info", ItemText = "Xanh nước biển nhạt"},
                new SelectListModel_Kanban { ItemValue = "2", ItemColor = "badge-success", ColumnColor = "brc-success-m1", ButtonColor = "btn-outline-success", ItemText="Xanh lá cây"},
                new SelectListModel_Kanban { ItemValue = "3", ItemColor = "badge-danger", ColumnColor = "brc-danger-m1", ButtonColor = "btn-outline-danger", ItemText="Đỏ"},
                new SelectListModel_Kanban { ItemValue = "4", ItemColor = "badge-warning", ColumnColor = "brc-warning-m1", ButtonColor = "btn-outline-warning", ItemText="Cam"},
                new SelectListModel_Kanban { ItemValue = "5", ItemColor = "bgc-purple brc-purple text-white", ColumnColor = "brc-purple-m1", ButtonColor = "btn-outline-purple", ItemText="Tím"},
                new SelectListModel_Kanban { ItemValue = "6", ItemColor = "badge-primary", ColumnColor = "brc-primary-m1", ButtonColor = "btn-outline-primary", ItemText="Xanh nước biển đậm"},
                        };
            return list;
        }

        /// <summary>
        /// Danh sách loại menu
        /// </summary>
        /// <returns>List<SelectListModel></returns>
        public static List<SelectListModel> StageType()
        {
            var list = new List<SelectListModel> {
                                        new SelectListModel { ItemValue = "1", ItemText = "ToDo"},
                                        new SelectListModel { ItemValue = "2", ItemText = "In Progress"},
                                        new SelectListModel { ItemValue = "3", ItemText = "Done"},
                                        new SelectListModel { ItemValue = "4", ItemText = "Cancel"}
                                    };
            return list;
        }

        // Loại tài khoản
        public static List<SelectListModel> AccountType()
        {
            var list = new List<SelectListModel>
            {
                new SelectListModel { ItemValue = "0", ItemText = "Bên ngoài" },
                new SelectListModel { ItemValue = "1", ItemText = "Bên trong" }
            };

            return list;
        }

        /// <summary>
        /// Danh sách loại menu
        /// </summary>
        /// <returns>List<SelectListModel></returns>
        public static List<SelectListModel> InvoiceFormat()
        {
            var list = new List<SelectListModel> {
                                        new SelectListModel { ItemValue = "1", ItemText = "Mẫu excel có nhân công"},
                                        new SelectListModel { ItemValue = "2", ItemText = "Mẫu excel không có nhân công"},
                                    };
            return list;
        }

        /// <summary>
        /// Danh sách loại menu
        /// </summary>
        /// <returns>List<SelectListModel></returns>
        public static List<SelectListModel> DateTimeSearch()
        {
            var list = new List<SelectListModel> {
                 new SelectListModel { ItemValue = "", ItemText = "Không lọc theo ngày"},
                                new SelectListModel { ItemValue = "DateStart", ItemText = "Ngày bắt đầu"},
                new SelectListModel { ItemValue = "DateCreated", ItemText = "Ngày tạo"},
                                new SelectListModel { ItemValue = "DateStart", ItemText = "Ngày bắt đầu"},
                                new SelectListModel { ItemValue = "DateEnd", ItemText = "Ngày kết thúc"},
                                    };
            return list;
        }

        /// <summary>
        /// Danh sách loại menu
        /// </summary>
        /// <returns>List<SelectListModel></returns>
        public static List<SelectListModel> DateTimeContractSearch()
        {
            var list = new List<SelectListModel> {
                 new SelectListModel { ItemValue = "", ItemText = "Không lọc theo ngày"},
                                new SelectListModel { ItemValue = "ModifiedDate", ItemText = "Ngày sửa"},
                                new SelectListModel { ItemValue = "CreatedDate", ItemText = "Ngày tạo"},
                                new SelectListModel { ItemValue = "TechnicalFromDate", ItemText = "Ngày chuyển thi công"},
                                new SelectListModel { ItemValue = "WarrantyFromDate", ItemText = "Ngày bắt đầu bảo hành"},
                                new SelectListModel { ItemValue = "WarrantyToDate", ItemText = "Ngày kết thúc bảo hành"},
                                    };
            return list;
        }

        /// <summary>
        /// Danh sách loại menu
        /// </summary>
        /// <returns>List<SelectListModel></returns>
        public static List<SelectListModel> DateTime_ContractSearch()
        {
            var list = new List<SelectListModel> {
                    new SelectListModel { ItemValue = "CreatedDate", ItemText = "Ngày tạo"},
                    new SelectListModel { ItemValue = "CustomerSignedDate", ItemText = "Ngày ký hợp đồng"},
                    new SelectListModel { ItemValue = "ModifiedDate", ItemText = "Ngày sửa"},
                    new SelectListModel { ItemValue = "EmployeeID", ItemText = "Nhân viên kinh doanh"},
                    new SelectListModel { ItemValue = "EnterpriseID", ItemText = "Khách hàng"},
                    new SelectListModel { ItemValue = "TechnicalStatus", ItemText = "Tình trạng thi công"},
                    new SelectListModel { ItemValue = "ContractStatusID", ItemText = "Tình trạng thực hiện hợp đồng"},
            };

            return list;
        }

        public static List<SelectListModel> SortInvoice()
        {
            var list = new List<SelectListModel> {
                    new SelectListModel { ItemValue = "CreatedDate", ItemText = "Ngày tạo"},
                    new SelectListModel { ItemValue = "CustomerSignedDate", ItemText = "Ngày ký báo giá"},
                    new SelectListModel { ItemValue = "ModifiedDate", ItemText = "Ngày sửa"},
                    new SelectListModel { ItemValue = "OwnerID", ItemText = "Nhân viên kinh doanh"},
                    new SelectListModel { ItemValue = "EnterpriseID", ItemText = "Khách hàng"},

            };

            return list;
        }

        public static List<SelectListModel> TaskComplete()
        {
            var list = new List<SelectListModel> {
                new SelectListModel { ItemValue = "", ItemText = "Tất cả"},
                                        new SelectListModel { ItemValue = "0", ItemText = "Chỉ nhiệm vụ hoàn thành"},
                                        new SelectListModel { ItemValue = "1", ItemText = "Chỉ nhiệm vụ đang tiến hành"},
                                    };
            return list;
        }

        public static List<SelectListModel> AccountAccessType()
        {
            var list = new List<SelectListModel> {
                                        new SelectListModel { ItemValue = "1", ItemText = "Thẻ"},
                                        new SelectListModel { ItemValue = "2", ItemText = "Vân tay"},
                                        new SelectListModel { ItemValue = "3", ItemText = "Khuôn mặt"}
            };
            return list;
        }

        public static List<SelectListModel> SALES_ProjectStatus()
        {
            var list = new List<SelectListModel> {
                new SelectListModel { ItemValue = "", ItemText = "-- Lựa chọn"},
                                         new SelectListModel { ItemValue = "0", ItemText = "Chưa làm báo giá"},
                                         new SelectListModel { ItemValue = "1", ItemText = "Đang thiết kế" },
                                         new SelectListModel { ItemValue = "2", ItemText = "Gửi đáp ứng kĩ thuật"},
                                         new SelectListModel { ItemValue = "3", ItemText = "Đang bóc khối lượng"},
                                         new SelectListModel { ItemValue = "4", ItemText = "Đang lên báo giá"},
                                         new SelectListModel { ItemValue = "5", ItemText = "Đã gửi báo giá"},
                                         new SelectListModel { ItemValue = "6", ItemText = "Gửi lại báo giá"},
                                    };
            return list;
        }

        public static List<SelectListModel> SALES_ProjectResult()
        {
            var list = new List<SelectListModel> {
                new SelectListModel { ItemValue = "", ItemText = "-- Lựa chọn"},
                                         new SelectListModel { ItemValue = "0", ItemText = "Đang chờ phản hồi báo giá"},
                                         new SelectListModel { ItemValue = "1", ItemText = "Đang thương thảo hợp đồng" },
                                         new SelectListModel { ItemValue = "2", ItemText = "Đã ký hợp đồng"},
                                         new SelectListModel { ItemValue = "3", ItemText = "Không có kết quả"},
                                    };
            return list;
        }

        public static List<SelectListModel> SALES_EnterpriseType()
        {
            var list = new List<SelectListModel> {
                                        new SelectListModel { ItemValue = "0", ItemText = "Khách hàng"},
                                        new SelectListModel { ItemValue = "1", ItemText = "Nhà cung cấp"},
                                    };
            return list;
        }

        // Trạng thái thi công của hợp đồng, dự án
        public static List<SelectListModel> SALES_TechnicalStatus()
        {
            var list = new List<SelectListModel> {
                                        new SelectListModel { ItemValue = "0", ItemText = "Mới nhận"},
                                        new SelectListModel { ItemValue = "1", ItemText = "Đang khảo sát & lên phương án thi công"},
                                        new SelectListModel { ItemValue = "2", ItemText = "Đang thi công"},
                                        new SelectListModel { ItemValue = "3", ItemText = "Đang bàn giao & nghiệm thu"},
                                        new SelectListModel { ItemValue = "4", ItemText = "Đang tạm dừng"},
                                        new SelectListModel { ItemValue = "5", ItemText = "Đã hoàn thành"},
            };
            return list;
        }

        // Trạng thái làm hồ sơ của hợp đồng, dự án
        public static List<SelectListModel> SALES_FileStatus()
        {
            var list = new List<SelectListModel> {
                                        new SelectListModel { ItemValue = "0", ItemText = "Mới nhận"},
                                        new SelectListModel { ItemValue = "1", ItemText = "Đang làm hồ sơ pháp lý"},
                                        new SelectListModel { ItemValue = "2", ItemText = "Đang làm hồ sơ đầu vào"},
                                        new SelectListModel { ItemValue = "3", ItemText = "Đang làm hồ sơ thanh toán"},
                                        new SelectListModel { ItemValue = "4", ItemText = "Đang làm hồ sơ quyết toán"},
                                        new SelectListModel { ItemValue = "5", ItemText = "Đang chờ"},
                                        new SelectListModel { ItemValue = "6", ItemText = "Đã hoàn thành"},
            };
            return list;
        }
        // Trạng thái làm hồ sơ của hợp đồng, dự án
        public static List<SelectListModel> SelectChoseTime()
        {
            var list = new List<SelectListModel> {
                                        new SelectListModel { ItemValue = "1", ItemText = "1 tháng"},
                                        new SelectListModel { ItemValue = "2", ItemText = "2 tháng"},
                                        new SelectListModel { ItemValue = "3", ItemText = "3 tháng"},
                                        new SelectListModel { ItemValue = "4", ItemText = "4 tháng"},
                                        new SelectListModel { ItemValue = "5", ItemText = "5 tháng"},
                                        new SelectListModel { ItemValue = "6", ItemText = "6 tháng"},

            };
            return list;
        }

    }
}