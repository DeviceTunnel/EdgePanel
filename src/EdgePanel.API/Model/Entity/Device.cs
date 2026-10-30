namespace EdgePanel.Model.Entity
{
    public class Device
    {
        public int Id {get ; set; }
        public string Hostname {get; set;} = string.Empty;
        public bool online {get;set;} = false;
    }
}