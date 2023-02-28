namespace eazy_library.Models
{
    public class AuthActionModel
    {
        public int Create_Auth { get; set; } = 0; // 0 - No, 1 - Yes

        public int Update_Auth { get; set; } = 0; // 0 - No, 1 - Yes

        public int Delete_Auth { get; set; } = 0; // 0 - No, 1 - Yes

        public int MultiDelete_Auth { get; set; } = 0; // 0 - No, 1 - Yes
    }
}