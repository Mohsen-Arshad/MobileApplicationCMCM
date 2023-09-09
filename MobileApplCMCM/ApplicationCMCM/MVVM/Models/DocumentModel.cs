using System.Reflection.Metadata.Ecma335;

namespace ApplicationCMCM.MVVM.Models;

public class DocumentModel
{
    public int id { get; set; }
    public int UserId { get; set; }
    public string FileName { get; set; }
    public string FilePathUrl { get; set; }
}
