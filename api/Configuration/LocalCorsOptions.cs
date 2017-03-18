namespace Devallish.SportsClub.Api.Configuration{

    public class LocalCorsOptions{

        public string PolicyName { get; set; }
        public string AllowedOrigin { get; set; }

        public LocalCorsOptions(){
            PolicyName = "DefaultCorsPolicy";
            AllowedOrigin = string.Empty;
        }
    }
}