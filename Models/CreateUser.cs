namespace CapitalPlacement.Models
{
    public class CreateUser
    {
        public CreateUser()
        {
            UserId = Guid.NewGuid().ToString();
        }
        public string UserId { get; set; }
        public ProgramDetails ProgramDetailsInfo { get; set; }

        public ApplicationForm applicationFormInfo { get; set; }

        public WorkFlow WorkFlowInfo { get; set; }

    }
}
