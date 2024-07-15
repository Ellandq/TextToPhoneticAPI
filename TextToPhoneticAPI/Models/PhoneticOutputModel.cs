namespace TextToPhoneticAPI.Models;

public class PhoneticOutputModel
{
    public string AS { get; set; }
    public string IPA { get; set; }
}

public class PhoneticOutputWrapper
{
    public PhoneticOutputModel Result { get; set; }
}