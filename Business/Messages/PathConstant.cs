namespace Business.Messages;

public class PathConstant
{
    public static string FilesPath = @"\Uploads\Files\";
    public static string CertificatesPath = @"\Uploads\Files\Certificates\";
    public static string LocalCertificatesPath = @"wwwroot/Uploads/Files/Certificates/";

    public static string ImagePath = @"\Uploads\Files\Images\";
    public static string DefaultImagePath = @"\Uploads\Files\Images\DefaultProfilePhoto\";

    public static string LocalBaseUrl = @"http://localhost:5257/";
    public static string LocalPath =@"wwwroot/";
    public static string LocalImagePath = @"wwwroot/Uploads/Files/Images/";
    public static string LocalBaseUrlImagePath = LocalBaseUrl + @"Uploads/Files/Images/";
    public static string LocalBaseUrlCertificatesPath = LocalBaseUrl + @"Uploads/Files/Certificates/";
}
