namespace AST1.Models
{
    public class ErrorViewModel
    {  //Class to be executed when the Id requested is empty or null  
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(this.RequestId);
    }
}
